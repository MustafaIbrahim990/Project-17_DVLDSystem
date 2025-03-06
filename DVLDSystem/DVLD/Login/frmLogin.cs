using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLDSystem.Gobal_Classes;
using DVLDSystem.DVLD.Global_User;
using DVLDSystem_BusinessLayer;

namespace DVLDSystem.DVLD.Login
{
    public partial class frmLogin : Form
    {
        //Private Methods :-
        private bool _RememberUser()
        {
            return chbRememberMe.Checked;
        }


        //Constructor :-
        public frmLogin()
        {
            InitializeComponent();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            string UserName = "", PassWord = "";

            if (clsGlobal.GetStoredCredential(ref UserName, ref PassWord))
            {
                chbRememberMe.Checked = true;
                txtUserName.Text = UserName;
                txtPassWord.Text = PassWord;
            }
            else
                chbRememberMe.Checked = false;
        }


        //UserName :-
        private void txtUserName_Validating(object sender, CancelEventArgs e)
        {
            if (clsValidation.IsEmpty(txtUserName.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtUserName, "This Field is Required!");
                return;
            }

            if (!clsUser.IsExist(txtUserName.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtUserName, "Invalid UserName!");
                return;
            }
            errorProvider1.SetError(txtUserName, null);
        }


        //PassWord :-
        private void txtPassWord_Validating(object sender, CancelEventArgs e)
        {
            if (clsValidation.IsEmpty(txtPassWord.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtPassWord, "This Field is Required!");
                return;
            }
            errorProvider1.SetError(txtPassWord, null);
        }


        //Close Form :-
        private void btnCloseForm_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        //Login :-
        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                //Here we dont continue becuase the form is not valid :-
                MessageBox.Show("Some Fields Are Not Valid!, Put The Mouse On The Red Icon(s) to See The Error!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            clsUser UserInfo = clsUser.Find(txtUserName.Text.Trim(), txtPassWord.Text.Trim());

            if (UserInfo == null)
            {
                MessageBox.Show("Invalid UserName Or PassWord!", "Wrong Credentials", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (_RememberUser())
            {
                clsGlobal.RememberUserNameANDPassWord(txtUserName.Text.Trim(), txtPassWord.Text.Trim());
            }
            else
            {
                clsGlobal.RememberUserNameANDPassWord(null, null);
            }

            if (!UserInfo.IsActive)
            {
                txtUserName.Focus();
                MessageBox.Show("Invalid Your Account is Not Active, Contact With Admin!", "In Active Account", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //clsGlobal.CurrentUser = UserInfo;
            //this.Hide();
            //frmMainScreen frm = new frmMainScreen(this);
            //frm.ShowDialog();

            MessageBox.Show("You Sign in Successful");
        }
    }
}