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
using System.Text;

namespace DVLDSystem.DVLD.Applications.International_Driving_License.Controls
{
    public partial class ctrlInternationalDrivingLicenseApplicationCard : UserControl
    {
        //Error ////////////////////////////////////////////////////////////////////////////////////////
        //Private Properties :-
        private int _InternationalDrivingLicenseID;
        private clsInternationalDrivingLicense _InternationalDrivingLicenseInfo;

        //Public Properties :-
        public int InternationalDrivingLicenseID
        {
            get { return _InternationalDrivingLicenseID; }
        }


        //Private Methods :-
        private void _LoadPersonImage()
        {
            //if (_InternationalDrivingLicenseInfo.DriverInfo.PersonInfo.Gender == 0) 
            //    pbPersonImage.Image = Resources.Male_512;
            //else
            //    pbPersonImage.Image = Resources.Female_512;

            //string ImagePath = _InternationalDrivingLicenseInfo.DriverInfo.PersonInfo.ImagePath;

            //if (ImagePath != "")
            //    if (File.Exists(ImagePath))
            //        pbPersonImage.Load(ImagePath);
            //    else
            //        MessageBox.Show("Could not find this image: = " + ImagePath, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        public void LoadInfo(int InternationalLicenseID)
        {
            //_InternationalLicenseID = InternationalLicenseID;
            //_InternationalLicense = clsInternationalLicense.Find(_InternationalLicenseID);
            //if (_InternationalLicense == null)
            //{
            //    MessageBox.Show("Could not find Internationa License ID = " + _InternationalLicenseID.ToString(),
            //        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    _InternationalLicenseID = -1;
            //    return;
            //}

            //lblInternationalLicenseID.Text = _InternationalDrivingLicenseInfo.ID.ToString();
            //lblApplicationID.Text = _InternationalDrivingLicenseInfo.ApplicationID.ToString();
            //lblIsActive.Text = _InternationalDrivingLicenseInfo.IsActive ? "Yes" : "No";
            //lblLocalLicenseID.Text = _InternationalDrivingLicenseInfo.IssuedUsingDrivingLicenseID.ToString();
            //lblFullName.Text = _InternationalDrivingLicenseInfo.DriverInfo.PersonInfo.FullName;
            //lblNationalNo.Text = _InternationalDrivingLicenseInfo.DriverInfo.PersonInfo.NationalNo;
            //lblGendor.Text = _InternationalDrivingLicenseInfo.DriverInfo.PersonInfo.Gender == 0 ? "Male" : "Female";
            //lblDateOfBirth.Text = _InternationalDrivingLicenseInfo.DriverInfo.PersonInfo.DateOfBirth.ToShortDateString();

            //lblDriverID.Text = _InternationalDrivingLicenseInfo.DriverID.ToString();
            //lblIssueDate.Text = _InternationalDrivingLicenseInfo.IssueDate.ToShortDateString();
            //lblExpirationDate.Text = _InternationalDrivingLicenseInfo.ExpriationDate.ToShortDateString();.

            //_LoadPersonImage();
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