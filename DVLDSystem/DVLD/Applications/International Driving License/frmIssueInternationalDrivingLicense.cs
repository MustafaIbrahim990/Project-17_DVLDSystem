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

namespace DVLDSystem.DVLD.Applications.International_Driving_License
{
    public partial class frmIssueInternationalDrivingLicense : Form
    {
        //Properties :-
        private int _LocalLicenseID = -1;
        private int _InternationalDrivingLicenseID = -1;
        private clsInternationalDrivingLicense _InternationalDrivingLicenseInfo;


        //Private Methods :-
        private void _DataBack(int LocalLicenseID)
        {
            _LocalLicenseID = LocalLicenseID;
            btnIssueInternationalDrivingLicense.Enabled = (LocalLicenseID == -1) ? false : true;
        }
        private bool DoesHaveActiveInternationalLicense()
        {
            if (clsInternationalDrivingLicense.DoesHaveActiveInternationalLicense(_InternationalDrivingLicenseID))
            {
                MessageBox.Show($"Error : Person Already have an International License With ID [{_InternationalDrivingLicenseID}] in The System.", "Not Allowed!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnIssueInternationalDrivingLicense.Enabled = false;
                return false;
            }
            return true;
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



        //Constructor :-
        public frmIssueInternationalDrivingLicense()
        {
            InitializeComponent();
        }
        private void frmIssueInternationalDrivingLicense_Load(object sender, EventArgs e)
        {
            ctrlInternationalDrivingLicenseApplicationCard1.OnSelectedLocalDrivingLicenseID += _DataBack;
        }


        //Close Form :-
        private void btnCloseForm_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        //Issue International Driving License :-
        private void btnIssueInternationalDrivingLicense_Click(object sender, EventArgs e)
        {
            _InternationalDrivingLicenseID = 1;
            if (!DoesHaveActiveInternationalLicense())
                return;

            if (!IsLocalDrivingLicenseAsOrdinaryDrivingLicense())
                return;
        }
    }
}