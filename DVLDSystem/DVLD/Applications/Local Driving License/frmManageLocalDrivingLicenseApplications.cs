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
using DVLDSystem.Gobal_Classes;

namespace DVLDSystem.DVLD.Applications.Local_Driving_License
{
    public partial class frmManageLocalDrivingLicenseApplications : Form
    {
        //Private Prpperties :-
        private static DataTable _dtLocalDrivingLicenseApplicationLists;


        //Private Methods :-
        private bool _IsVisible(Control control)
        {
            return control.Visible;
        }

        private void _FocusControl(Control control)
        {
            control.Focus();
        }

        private void _GetLocalDrivingLicenseApplicationLists()
        {
            _dtLocalDrivingLicenseApplicationLists = clsLocalDrivingLicenseApplication.GetAllInfo();
        }

        private void _ShowLocalDrivingLicenseApplicationListsInGrid()
        {
            dgvLocalDrivingLicenseApplicationLists.DataSource = _dtLocalDrivingLicenseApplicationLists;
        }

        private void _ShowRecordCountInGrid()
        {
            lblRecordCount.Text = dgvLocalDrivingLicenseApplicationLists.Rows.Count.ToString();
        }

        private void _RefreshDataInGrid()
        {
            _GetLocalDrivingLicenseApplicationLists();
            _ShowLocalDrivingLicenseApplicationListsInGrid();
            _ShowRecordCountInGrid();

            cbFilterBy.SelectedIndex = 0;
        }

        private void _FilterDataInGridByIntValue(string ColumnName, int Value)
        {
            _dtLocalDrivingLicenseApplicationLists.DefaultView.RowFilter = String.Format($"{ColumnName} = {Value}");
        }

        private void _FilterDataInGridByStringValue(string ColumnName, string Value)
        {
            _dtLocalDrivingLicenseApplicationLists.DefaultView.RowFilter = String.Format($"{ColumnName} Like '{Value}%'");
        }

        private void _RefreshDataInGridWithoutFilter()
        {
            _dtLocalDrivingLicenseApplicationLists.DefaultView.RowFilter = null;
        }

        private void _RefreshDataInGridWithFilter()
        {
            string FilterColumn = "";

            switch (cbFilterBy.Text)
            {
                case "L.D.L.AppID":
                    FilterColumn = "LocalDrivingLicenseApplicationID";
                    break;

                case "National No.":
                    FilterColumn = "NationalNo";
                    break;

                case "Full Name":
                    FilterColumn = "FullName";
                    break;

                case "Status":
                    FilterColumn = "Status";
                    break;

                default:
                    FilterColumn = "None";
                    break;
            }

            //We Filter DataInGrid :-
            if (FilterColumn == "LocalDrivingLicenseApplicationID")
            {
                _FilterDataInGridByIntValue(FilterColumn, int.Parse(txtFilterValue.Text.Trim()));
            }
            else
            {
                _FilterDataInGridByStringValue(FilterColumn, txtFilterValue.Text.Trim());
            }
        }

        private void _ResetColumnsInGrid()
        {
            if (dgvLocalDrivingLicenseApplicationLists.Rows.Count > 0)
            {
                dgvLocalDrivingLicenseApplicationLists.Columns[0].HeaderText = "L.D.L.AppID";
                dgvLocalDrivingLicenseApplicationLists.Columns[0].Width = 50;

                dgvLocalDrivingLicenseApplicationLists.Columns[1].HeaderText = "Driving Class";
                dgvLocalDrivingLicenseApplicationLists.Columns[1].Width = 150;

                dgvLocalDrivingLicenseApplicationLists.Columns[2].HeaderText = "National No.";
                dgvLocalDrivingLicenseApplicationLists.Columns[2].Width = 80;

                dgvLocalDrivingLicenseApplicationLists.Columns[3].HeaderText = "Full Name";
                dgvLocalDrivingLicenseApplicationLists.Columns[3].Width = 150;

                dgvLocalDrivingLicenseApplicationLists.Columns[4].HeaderText = "Application Date";
                dgvLocalDrivingLicenseApplicationLists.Columns[4].Width = 100;

                dgvLocalDrivingLicenseApplicationLists.Columns[5].HeaderText = "Passed Tests";
                dgvLocalDrivingLicenseApplicationLists.Columns[5].Width = 100;

                dgvLocalDrivingLicenseApplicationLists.Columns[6].HeaderText = "Status";
                dgvLocalDrivingLicenseApplicationLists.Columns[6].Width = 100;
            }
            else
            {
                MessageBox.Show("There Are Not Record in The System.", "No Record!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        //Constructor :-
        public frmManageLocalDrivingLicenseApplications()
        {
            InitializeComponent();
        }
        private void frmManageLocalDrivingLicenseApplications_Load(object sender, EventArgs e)
        {
            _RefreshDataInGrid();
            _ResetColumnsInGrid();
        }


        //Filter By :-
        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFilterValue.Text = null;
            txtFilterValue.Visible = (cbFilterBy.Text != "None");

            if (cbFilterBy.Text == "None")
            {
                _RefreshDataInGridWithoutFilter();
                _ShowRecordCountInGrid();
                return;
            }

            _FocusControl(txtFilterValue);
        }


        //Filter Value :-
        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilterBy.Text == "L.D.L.AppID")
                e.Handled = !char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar);
        }
        private void txtFilterValue_TextChanged(object sender, EventArgs e)
        {
            if (clsValidation.IsEmpty(txtFilterValue.Text.Trim()))
            {
                txtFilterValue.Text = null;
                _RefreshDataInGridWithoutFilter();
            }
            else
            {
                _RefreshDataInGridWithFilter();
            }
            _ShowRecordCountInGrid();
        }


        //Close Form :-
        private void btnCloseForm_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        //Add New Local Driving License Application :-
        private void btnAddNewLocalDrivingLicenseApplication_Click(object sender, EventArgs e)
        {
            frmAddEditLocalDrivingLicenseApplication frm = new frmAddEditLocalDrivingLicenseApplication();
            frm.ShowDialog();

            //Refresh the Form.
            frmManageLocalDrivingLicenseApplications_Load(null, null);
        }
        private void addNewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnAddNewLocalDrivingLicenseApplication.PerformClick();
        }


        //Show Details :-
        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This Feature is Not Implemented Yet!", "Not Ready!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        private void dgvLocalDrivingLicenseApplicationLists_DoubleClick(object sender, EventArgs e)
        {
            showDetailsToolStripMenuItem.PerformClick();
        }


        //Edit Local Driving License Application :-
        private void editToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmAddEditLocalDrivingLicenseApplication frm = new frmAddEditLocalDrivingLicenseApplication((int)dgvLocalDrivingLicenseApplicationLists.CurrentRow.Cells[0].Value);
            frm.ShowDialog();

            //Refresh the Form.
            frmManageLocalDrivingLicenseApplications_Load(null, null);
        }


        //Delete Local Driving License Application :-
        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Just Delete Local
            if (MessageBox.Show("Are You Sure Do You Want to Delete This Application?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            clsLocalDrivingLicenseApplication LocalDrivingLicenseApplicationInfo = clsLocalDrivingLicenseApplication.FindLocal((int)dgvLocalDrivingLicenseApplicationLists.CurrentRow.Cells[0].Value);

            if (LocalDrivingLicenseApplicationInfo != null)
            {
                if (LocalDrivingLicenseApplicationInfo.Delete())
                {
                    MessageBox.Show("Application Deleted Successfully.", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    //Refresh the Form.
                    frmManageLocalDrivingLicenseApplications_Load(null, null);
                }
                else
                {
                    MessageBox.Show("Could Not Delete This Applicatoin, Other Data Depends On it.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        //Cancel Local Driving License Application :-
        private void cancelApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are You Sure Do You Want to Cancel This Application?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            clsLocalDrivingLicenseApplication LocalDrivingLicenseApplicationInfo = clsLocalDrivingLicenseApplication.FindLocal((int)dgvLocalDrivingLicenseApplicationLists.CurrentRow.Cells[0].Value);

            if (LocalDrivingLicenseApplicationInfo != null)
            {
                if (LocalDrivingLicenseApplicationInfo.Cancel())
                {
                    MessageBox.Show("Application Cancelled Successfully.", "Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    //refresh the form.
                    frmManageLocalDrivingLicenseApplications_Load(null, null);
                }
                else
                {
                    MessageBox.Show("Could Not Cancel This Applicatoin.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        //Sechdule Vision Test :-
        private void scheduleVisionTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This Feature is Not Implemented Yet!", "Not Ready!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }


        //Sechdule Written Test :-
        private void scheduleWrittenTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This Feature is Not Implemented Yet!", "Not Ready!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }


        //Sechdule Street Test :-
        private void scheduleStreetTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This Feature is Not Implemented Yet!", "Not Ready!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }


        //Issue Local Driving License For First Time :-
        private void issueDrivingLicenseFirstTimeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This Feature is Not Implemented Yet!", "Not Ready!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }


        //Show Local Driving License :-
        private void showLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This Feature is Not Implemented Yet!", "Not Ready!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }


        //Show Person License History :-
        private void showPersonLicneseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This Feature is Not Implemented Yet!", "Not Ready!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}