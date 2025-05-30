﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLDSystem.DVLD.Login;
using DVLDSystem.DVLD.Global_User;
using DVLDSystem.DVLD.User;
using DVLDSystem.DVLD.Applications.Application_Types;
using DVLDSystem.DVLD.Tests.Test_Types;
using DVLDSystem.DVLD.Applications.Local_Driving_License;
using DVLDSystem.DVLD.Driving_License.International_Driving_License;

namespace DVLDSystem.DVLD
{
    public partial class frmMainScreen : Form
    {
        //Properties :-
        private frmLogin _frmLoginScreen;


        //Constructor :-
        public frmMainScreen(frmLogin frm)
        {
            InitializeComponent();

            _frmLoginScreen = frm;
        }
        private void frmMainScreen_Load(object sender, EventArgs e)
        {

        }
        private void frmMainScreen_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (clsGlobal.CurrentUser != null)
                _frmLoginScreen.Close();
        }


        //Account Settings :-
        //Current User Info :-
        private void currentUserInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (clsGlobal.CurrentUser == null)
            {
                MessageBox.Show($"Error : Could Not Find User With ID [{clsGlobal.CurrentUser.UserID}] in The System!", "User Not Found!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            frmShowUserInfo frm = new frmShowUserInfo(clsGlobal.CurrentUser.UserID);
            frm.ShowDialog();
        }


        //Chaange PassWord :-
        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (clsGlobal.CurrentUser == null)
            {
                MessageBox.Show($"Error : Could Not Find User With ID [{clsGlobal.CurrentUser.UserID}] in The System!", "User Not Found!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            frmChangePassWord frm = new frmChangePassWord(clsGlobal.CurrentUser.UserID);
            frm.ShowDialog();
        }


        //Sign Out :-
        private void signOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clsGlobal.CurrentUser = null;
            _frmLoginScreen.Show();
            this.Close();
        }


        //Manage People :-
        private void peopleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManagePeople frm = new frmManagePeople();
            frm.ShowDialog();
        }


        //Manage Users :-
        private void UsersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManageUsers frm = new frmManageUsers();
            frm.ShowDialog();
        }


        //Manage Drivers :-
        private void driversToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This Feature is Not Implemented Yet!", "Not Ready!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }


        //Manage Local Driving License Application :-
        private void localLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddEditLocalDrivingLicenseApplication frm = new frmAddEditLocalDrivingLicenseApplication();
            frm.ShowDialog();
        }
        private void manageLocalDrivingLicenseApplicationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManageLocalDrivingLicenseApplications frm = new frmManageLocalDrivingLicenseApplications();
            frm.ShowDialog();
        }


        //Manage International Driving License Application :-
        private void internationalLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This Feature is Not Implemented Yet!", "Not Ready!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        private void ManageInternationaDrivingLicenseToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmManageInternationalDrivingLicenseApplications frm = new frmManageInternationalDrivingLicenseApplications();
            frm.ShowDialog();
        }


        //Renew Driving License :-
        private void renewDrivingLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This Feature is Not Implemented Yet!", "Not Ready!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }


        //Replacement Driving License for (Lost Or Damaged) :-
        private void ReplacementLostOrDamagedDrivingLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This Feature is Not Implemented Yet!", "Not Ready!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }


        //Release Detained Driving License :-
        private void releaseDetainedDrivingLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This Feature is Not Implemented Yet!", "Not Ready!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }


        //Retake Test :-
        private void retakeTestToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This Feature is Not Implemented Yet!", "Not Ready!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        //Manage Detained Driving Licenses :-
        private void ManageDetainedLicensestoolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This Feature is Not Implemented Yet!", "Not Ready!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }


        //Detain Driving Licenses :-
        private void detainLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This Feature is Not Implemented Yet!", "Not Ready!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }


        //Release Detained Driving License :-
        private void releaseDetainedLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This Feature is Not Implemented Yet!", "Not Ready!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }


        //Manage Application Types :-
        private void manageApplicationTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManageApplicationTypes frm = new frmManageApplicationTypes();
            frm.ShowDialog();
        }


        //Manage Test Types :-
        private void manageTestTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManageTestTypes frm = new frmManageTestTypes();
            frm.ShowDialog();
        }
    }
}