using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLDSystem.DVLD.Applications.International_Driving_License
{
    public partial class frmIssueInternationalDrivingLicense : Form
    {
        //Constructor :-
        public frmIssueInternationalDrivingLicense()
        {
            InitializeComponent();
        }
        private void frmIssueInternationalDrivingLicense_Load(object sender, EventArgs e)
        {
            ctrlInternationalDrivingLicenseApplicationCard1.ResetInfo();
            btnIssueInternationalDrivingLicense.Enabled = false;
        }

        //Close Form :-
        private void btnCloseForm_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        //Issue International Driving License :-
        private void btnIssueInternationalDrivingLicense_Click(object sender, EventArgs e)
        {
            
        }
    }
}