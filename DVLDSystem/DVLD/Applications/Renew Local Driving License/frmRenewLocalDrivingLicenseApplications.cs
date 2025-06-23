using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLDSystem_BusinessLayer;
using DVLDSystem.DVLD.Driving_License;
using DVLDSystem.DVLD.Driving_License.Local_Driving_License;

namespace DVLDSystem.DVLD.Applications.Renew_Local_Driving_License
{
    public partial class frmRenewLocalDrivingLicenseApplications : Form
    {
        //Properties :-
        private int _LocalLicenseID = -1;
        private int _InternationalDrivingLicenseID = -1;


        //Private Methods :-
        private void _OnLocalDrivingLicenseIDSelected(int LocalLicenseID)
        {
            _LocalLicenseID = LocalLicenseID;
            btnIssueInternationalDrivingLicense.Enabled = (LocalLicenseID == -1) ? false : true;
            llShowLicenseHistory.Enabled = (LocalLicenseID == -1) ? false : true;
        }
        private void _ShowMessageError(string Message, string Caption, MessageBoxButtons MessageBoxButtons, MessageBoxIcon MessageBoxIcon)
        {
            MessageBox.Show(Message, Caption, MessageBoxButtons, MessageBoxIcon);
        }
        private bool DoesHaveActiveInternationalLicense()
        {
            if (clsInternationalDrivingLicense.DoesHaveActiveInternationalLicense(_LocalLicenseID))
            {
                _InternationalDrivingLicenseID = clsInternationalDrivingLicense.FindByLocalLicenseID(_LocalLicenseID).InternationalDrivingLicenseID;
                MessageBox.Show($"Error : Person Already have an International License With ID [{_InternationalDrivingLicenseID}] in The System.", "Not Allowed!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ctrlInternationalDrivingLicenseApplicationCard1.LoadApplicationBasicInfo(_InternationalDrivingLicenseID);
                btnIssueInternationalDrivingLicense.Enabled = false;
                llShowLicenseInfo.Enabled = true;
                return true;
            }
            return false;
        }
        private bool IsLocalDrivingLicenseAsOrdinaryDrivingLicense()
        {
            if (!clsLocalDrivingLicenseApplication.IsLocalDrivingLicenseAsOrdinaryDrivingLicense(clsLocalDrivingLicenseApplication.FindLocalBy(clsDrivingLicense.Find(_LocalLicenseID).ApplicationID).LocalDrivingLicenseApplicationID))
            {
                MessageBox.Show($"Selected License Should be Class 3 [Ordinary Driving License], Select another One.", "Not Allowed!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnIssueInternationalDrivingLicense.Enabled = false;
                return false;
            }
            return true;
        }
        private void _IssueInternationalDrivingLicnese()
        {
            clsInternationalDrivingLicense _InternationalDrivingLicenseInfo = new clsInternationalDrivingLicense();
            _InternationalDrivingLicenseID = _InternationalDrivingLicenseInfo.IssueInternationalDrivingLicense(_LocalLicenseID, clsGlobal.CurrentUser.UserID);

            if (_InternationalDrivingLicenseID != -1)
            {
                _ShowMessageError($"International Driving License Issued Successfully With ID [{_InternationalDrivingLicenseID}] in The System.", "Succeeded", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ctrlInternationalDrivingLicenseApplicationCard1.LoadApplicationBasicInfo(_InternationalDrivingLicenseID);
            }
            else
            {
                _ShowMessageError($"International Driving License Was Not Issued!", "Failed!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            llShowLicenseInfo.Enabled = (_InternationalDrivingLicenseID == -1) ? false : true;
            btnIssueInternationalDrivingLicense.Enabled = false;
        }


        //Constructor :-
        public frmRenewLocalDrivingLicenseApplications()
        {
            InitializeComponent();
        }
        private void frmRenewLocalDrivingLicenseApplications_Load(object sender, EventArgs e)
        {
            ctrlInternationalDrivingLicenseApplicationCard1.LocalDrivingLicenseIDSelected += _OnLocalDrivingLicenseIDSelected;
        }
        private void frmRenewLocalDrivingLicenseApplications_Activated(object sender, EventArgs e)
        {
            ctrlInternationalDrivingLicenseApplicationCard1.FilterFocus();
        }


        //Close Form :-
        private void btnCloseForm_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        //Renew Local Driving License Application :-
        private void btnRenewLocalDrivingLicenseApplication_Click(object sender, EventArgs e)
        {

        }


        //Show New Local Driving License Info :-
        private void llShowNewLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowDrivingLicenseCard frm = new frmShowDrivingLicenseCard(_LocalLicenseID);
            frm.ShowDialog();

            //Refresh :-
            //
        }


        //Show Driving License History :-
        private void llShowLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowPersonDrivingLicenseHistory frm = new frmShowPersonDrivingLicenseHistory(clsDrivingLicense.Find(_LocalLicenseID).DriverInfo.PersonID);
            frm.ShowDialog();

            //Refresh :-
            //
        }
    }
}