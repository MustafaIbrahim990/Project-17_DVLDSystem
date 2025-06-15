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
using System.IO;
using DVLDSystem.DVLD.Global_User;

namespace DVLDSystem.DVLD.Applications.International_Driving_License.Controls
{
    public partial class ctrlInternationalDrivingLicenseApplicationCard : UserControl
    {
        //Properties :-
        public int LocalDrivingLicenseID = -1;
        private int _InternationalDrivingLicenseID = -1;
        private clsInternationalDrivingLicense _InternationalDrivingLicenseInfo;

        public int SelectedInternationalDrivingLicenseID
        {
            get { return _InternationalDrivingLicenseID; }
        }
        public clsInternationalDrivingLicense SelectedInternationalDrivingLicenseInfo
        {
            get { return _InternationalDrivingLicenseInfo; }
        }


        //Private Methods :-
        private void _DataBack(int LocalLicenseID)
        {
            LocalDrivingLicenseID = LocalLicenseID;

            if (LocalDrivingLicenseID != -1)
            {
                LoadInternationalDrivingLicenseApplicationInfoByDriverID(clsDrivingLicense.Find(LocalDrivingLicenseID).DriverID);
            }
        }
        private void _FillInfo()
        {
            lblInternationalApplicationID.Text = _InternationalDrivingLicenseInfo.ApplicationID.ToString();
            lblInternationalLicenseID.Text = _InternationalDrivingLicenseInfo.InternationalDrivingLicenseID.ToString();
            lblLocalLicenseID.Text = _InternationalDrivingLicenseInfo.IssuedUsingDrivingLicenseID.ToString();
            //lblInternationalApplicationDate.Text = _InternationalDrivingLicenseInfo.ApplicationDate.ToShortDateString();
            //lblIssueDate.Text = _InternationalDrivingLicenseInfo.IssueDate.ToShortDateString();
            //lblFees.Text = _InternationalDrivingLicenseInfo.PaidFees.ToString();
            //lblExpirationDate.Text = _InternationalDrivingLicenseInfo.ExpriationDate.ToShortDateString();
            //lblCreatedBy.Text = _InternationalDrivingLicenseInfo.CreatedByUserID.ToString();
        }


        //Public Methods :-
        public void ResetInfo()
        {
            lblInternationalApplicationID.Text = "N/A";
            lblInternationalLicenseID.Text = "N/A";
            lblLocalLicenseID.Text = "N/A";
            lblInternationalApplicationDate.Text = DateTime.Now.ToShortDateString();
            lblIssueDate.Text = DateTime.Now.ToShortDateString();
            lblFees.Text = clsApplicationType.Find((int)clsApplication.enApplicationType.NewInternationalDrivingLicense).Fees.ToString() + " $";
            lblExpirationDate.Text = DateTime.Now.AddYears(1).ToShortDateString();
            lblCreatedBy.Text = clsGlobal.CurrentUser.UserID.ToString();

            ctrlDrivingLicenseCardWithFilter1.OnDrivingLicenseSelected += _DataBack;
        }
        public void LoadInternationalDrivingLicenseApplicationInfoByInternationalID(int InternationalDrivingLicenseID)
        {
            _InternationalDrivingLicenseInfo = clsInternationalDrivingLicense.FindInternational(InternationalDrivingLicenseID);

            if (_InternationalDrivingLicenseInfo == null)
            {
                ResetInfo();
                MessageBox.Show($"Error : No International Driving License With ID [{InternationalDrivingLicenseID}] in The System!", "Not Found!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _FillInfo();
        }
        public void LoadInternationalDrivingLicenseApplicationInfoByDriverID(int DriverID)
        {
            _InternationalDrivingLicenseInfo = clsInternationalDrivingLicense.FindByDriverID(DriverID);

            if (_InternationalDrivingLicenseInfo == null)
            {
                ResetInfo();
                MessageBox.Show($"Error : No International Driving License With Driver ID [{DriverID}] in The System!", "Not Found!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _FillInfo();
        }


        //Constructor :-
        public ctrlInternationalDrivingLicenseApplicationCard()
        {
            InitializeComponent();
        }
        private void ctrlInternationalDrivingLicenseApplicationCard_Load(object sender, EventArgs e)
        {

        }
    }
}