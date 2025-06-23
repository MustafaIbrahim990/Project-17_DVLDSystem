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
using DVLDSystem.DVLD.Global_User;

namespace DVLDSystem.DVLD.Applications.Renew_Local_Driving_License.Controls
{
    public partial class ctrlRenewLocalDrivingLicenseApplications : UserControl
    {
        //Event :-
        public event Action<int> LocalDrivingLicenseIDSelected;


        //Properties :-
        private int _LocalDrivingLicenseID = -1;
        private clsLocalDrivingLicenseApplication _LocalDrivingLicenseInfo;

        public int SelectedLocalDrivingLicenseID
        {
            get { return _LocalDrivingLicenseID; }
        }
        public clsLocalDrivingLicenseApplication SelectedLocalDrivingLicenseInfo
        {
            get { return _LocalDrivingLicenseInfo; }
        }


        //Private Methods :-
        private void _LoadApplicationBasicInfo()
        {
            lblRenewlApplicationID.Text = "N/A";
            lblRenewedLocalLicenseID.Text = "N/A";

            lblRenewApplicationDate.Text = DateTime.Now.ToShortDateString();
            lblIssueDate.Text = DateTime.Now.ToShortDateString();
            lblApplicationFees.Text = clsApplicationType.Find((int)clsApplication.enApplicationType.RenewDrivingLicense).Fees.ToString() + " $";
            lblLocalLicenseFees.Text = clsLicenseClass.Find(clsLocalDrivingLicenseApplication.FindLocal(_LocalDrivingLicenseID).LicenseClassID).ClassFees.ToString() + " $";
            txtNotes.Text = null;

            lblOldLocalLicenseID.Text = _LocalDrivingLicenseID.ToString();
            lblExpirationDate.Text = clsLicenseClass.Find(_LocalDrivingLicenseID).DefaultValidityLength.ToString();
            lblCreatedBy.Text = clsGlobal.CurrentUser.UserName;
            lblTotalFees.Text = (Convert.ToInt32(lblApplicationFees.Text.Replace("$", "").Trim()) + Convert.ToInt32(lblApplicationFees.Text.Replace("$", "").Trim())).ToString() + " $";
        }
        private void _OnLocalDrivingLicenseIDSelected(int LocalLicenseID)
        {
            _LocalDrivingLicenseID = LocalLicenseID;
            _LoadApplicationBasicInfo();

            //Send Local License ID to Subscriber :-
            LocalDrivingLicenseIDSelected?.Invoke(_LocalDrivingLicenseID);
        }
        private void _ResetInfo()
        {
            _LocalDrivingLicenseID = -1;

            lblRenewlApplicationID.Text = "N/A";
            lblRenewedLocalLicenseID.Text = "N/A";
        }
        private void _FillInfo()
        {
            _LocalDrivingLicenseID = _LocalDrivingLicenseInfo.LocalDrivingLicenseApplicationID;

            lblRenewlApplicationID.Text = _LocalDrivingLicenseInfo.ApplicationID.ToString();
            lblRenewedLocalLicenseID.Text = _LocalDrivingLicenseInfo.LocalDrivingLicenseApplicationID.ToString();
        }


        //Protected Methods :-
        protected void OnLocalDrivingLicenseIDSelected(int InternationalLicenseID)
        {
            LocalDrivingLicenseIDSelected?.Invoke(InternationalLicenseID);
        }


        //Public Methods :-
        public void FilterFocus()
        {
            ctrlDrivingLicenseCardWithFilter1.FilterFocus();
        }
        public void LoadNewLocalDrivingLicenseInfo(int RenewedLocalLicenseID)
        {
            _LocalDrivingLicenseInfo = clsLocalDrivingLicenseApplication.FindLocal(_LocalDrivingLicenseID);

            if (_LocalDrivingLicenseInfo == null)
            {
                _ResetInfo();
                MessageBox.Show($"Error : Could Not Find Local Driving License With ID [{_LocalDrivingLicenseID}] in The System!", "Not Found!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _FillInfo();
            ctrlDrivingLicenseCardWithFilter1.FilterDrivingLicenseEnabled = false;
        }


        //Constructor :-
        public ctrlRenewLocalDrivingLicenseApplications()
        {
            InitializeComponent();
        }
        private void ctrlRenewLocalDrivingLicenseApplications_Load(object sender, EventArgs e)
        {
            ctrlDrivingLicenseCardWithFilter1.LocalDrivingLicenseIDSelected += _OnLocalDrivingLicenseIDSelected;
        }
    }
}