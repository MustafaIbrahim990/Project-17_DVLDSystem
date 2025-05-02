namespace DVLDSystem.DVLD.Applications.International_Driving_License
{
    partial class frmIssueInternationalDrivingLicense
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
            this.label3 = new System.Windows.Forms.Label();
            this.ctrlDrivingLicenseCardWithFilter1 = new DVLDSystem.DVLD.Driving_License.Local_Driving_License.Controls.ctrlDrivingLicenseCardWithFilter();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft JhengHei", 20F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label3.Location = new System.Drawing.Point(374, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(552, 35);
            this.label3.TabIndex = 41;
            this.label3.Text = "International Driving License Applications";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ctrlDrivingLicenseCardWithFilter1
            // 
            this.ctrlDrivingLicenseCardWithFilter1.BackColor = System.Drawing.Color.White;
            this.ctrlDrivingLicenseCardWithFilter1.FilterDrivingLicenseEnabled = true;
            this.ctrlDrivingLicenseCardWithFilter1.Location = new System.Drawing.Point(16, 82);
            this.ctrlDrivingLicenseCardWithFilter1.Name = "ctrlDrivingLicenseCardWithFilter1";
            this.ctrlDrivingLicenseCardWithFilter1.ShowDrivingLicenseButton = true;
            this.ctrlDrivingLicenseCardWithFilter1.Size = new System.Drawing.Size(1268, 598);
            this.ctrlDrivingLicenseCardWithFilter1.TabIndex = 42;
            // 
            // frmIssueInternationalDrivingLicense
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1297, 946);
            this.Controls.Add(this.ctrlDrivingLicenseCardWithFilter1);
            this.Controls.Add(this.label3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "frmIssueInternationalDrivingLicense";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Issue International  Driving License";
            this.Load += new System.EventHandler(this.frmIssueInternationalDrivingLicense_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private Driving_License.Local_Driving_License.Controls.ctrlDrivingLicenseCardWithFilter ctrlDrivingLicenseCardWithFilter1;
    }
}