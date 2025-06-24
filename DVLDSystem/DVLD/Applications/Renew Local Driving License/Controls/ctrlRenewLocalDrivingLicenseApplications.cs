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
        private int _OldLocalDrivingLicenseID = -1;
        private int _NewLocalDrivingLicenseID = -1;
        private clsDrivingLicense _LocalDrivingLicenseInfo;

        public int SelectedLocalDrivingLicenseID
        {
            get { return _NewLocalDrivingLicenseID; }
        }
        public string Notes
        {
            get { return txtNotes.Text.Trim(); }
        }
        public clsDrivingLicense SelectedLocalDrivingLicenseInfo
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
            txtNotes.Text = null;
           
            lblCreatedBy.Text = clsGlobal.CurrentUser.UserName;
        }
        private void _OnLocalDrivingLicenseIDSelected(int LocalLicenseID)
        {
            _OldLocalDrivingLicenseID = LocalLicenseID;
            _LoadApplicationBasicInfo();

            //Send Local License ID to Subscriber :-
            LocalDrivingLicenseIDSelected?.Invoke(_OldLocalDrivingLicenseID);
        }
        private void _ResetInfo()
        {
            _OldLocalDrivingLicenseID = -1;
            _NewLocalDrivingLicenseID = -1;

            lblRenewlApplicationID.Text = "N/A";
            lblRenewedLocalLicenseID.Text = "N/A";
        }
        private void _FillInfo()
        {
            lblOldLocalLicenseID.Text = _OldLocalDrivingLicenseID.ToString();
            lblRenewlApplicationID.Text = _LocalDrivingLicenseInfo.ApplicationID.ToString();
            lblRenewedLocalLicenseID.Text = _NewLocalDrivingLicenseID.ToString();
            lblExpirationDate.Text = (DateTime.Now.AddYears(_LocalDrivingLicenseInfo.LicenseClassInfo.DefaultValidityLength).ToShortDateString());
            lblLocalLicenseFees.Text = _LocalDrivingLicenseInfo.LicenseClassInfo.ClassFees.ToString() + " $";
            lblTotalFees.Text = ((Convert.ToSingle(lblApplicationFees.Text.Replace("$", "").Trim())) + (Convert.ToSingle(lblApplicationFees.Text.Replace("$", "").Trim()))).ToString() + " $";
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
        public void LoadLocalDrivingLicenseInfo(int LocalLicenseID)
        {
            _NewLocalDrivingLicenseID = LocalLicenseID;
            _LocalDrivingLicenseInfo = clsDrivingLicense.Find(_NewLocalDrivingLicenseID);

            if (_LocalDrivingLicenseInfo == null)
            {
                _ResetInfo();
                MessageBox.Show($"Error : Could Not Find Local Driving License With ID [{_NewLocalDrivingLicenseID}] in The System!", "Not Found!", MessageBoxButtons.OK, MessageBoxIcon.Error);
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