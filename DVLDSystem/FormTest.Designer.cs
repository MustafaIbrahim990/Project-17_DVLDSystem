namespace DVLDSystem
{
    partial class FormTest
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ctrlInternationalDrivingLicenseApplicationCard1 = new DVLDSystem.DVLD.Applications.International_Driving_License.Controls.ctrlInternationalDrivingLicenseApplicationCard();
            this.SuspendLayout();
            // 
            // ctrlInternationalDrivingLicenseApplicationCard1
            // 
            this.ctrlInternationalDrivingLicenseApplicationCard1.BackColor = System.Drawing.Color.White;
            this.ctrlInternationalDrivingLicenseApplicationCard1.Location = new System.Drawing.Point(12, 12);
            this.ctrlInternationalDrivingLicenseApplicationCard1.Name = "ctrlInternationalDrivingLicenseApplicationCard1";
            this.ctrlInternationalDrivingLicenseApplicationCard1.Size = new System.Drawing.Size(1275, 861);
            this.ctrlInternationalDrivingLicenseApplicationCard1.TabIndex = 0;
            // 
            // FormTest
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1319, 928);
            this.Controls.Add(this.ctrlInternationalDrivingLicenseApplicationCard1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "FormTest";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormTest";
            this.Load += new System.EventHandler(this.FormTest_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private DVLD.Applications.International_Driving_License.Controls.ctrlInternationalDrivingLicenseApplicationCard ctrlInternationalDrivingLicenseApplicationCard1;
    }
}