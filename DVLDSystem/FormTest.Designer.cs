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
            this.btnCloseForm = new System.Windows.Forms.Button();
            this.btnSaveUserData = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.ctrlApplicationTypeCard1 = new DVLDSystem.DVLD.Applications.Application_Types.Controls.ctrlApplicationTypeCard();
            this.SuspendLayout();
            // 
            // btnCloseForm
            // 
            this.btnCloseForm.BackColor = System.Drawing.Color.White;
            this.btnCloseForm.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCloseForm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCloseForm.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCloseForm.Image = global::DVLDSystem.Properties.Resources.Close_32;
            this.btnCloseForm.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCloseForm.Location = new System.Drawing.Point(871, 725);
            this.btnCloseForm.Name = "btnCloseForm";
            this.btnCloseForm.Size = new System.Drawing.Size(161, 47);
            this.btnCloseForm.TabIndex = 123;
            this.btnCloseForm.Text = "Close";
            this.btnCloseForm.UseVisualStyleBackColor = false;
            // 
            // btnSaveUserData
            // 
            this.btnSaveUserData.BackColor = System.Drawing.Color.White;
            this.btnSaveUserData.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnSaveUserData.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveUserData.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveUserData.Image = global::DVLDSystem.Properties.Resources.Save_32;
            this.btnSaveUserData.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSaveUserData.Location = new System.Drawing.Point(1051, 725);
            this.btnSaveUserData.Name = "btnSaveUserData";
            this.btnSaveUserData.Size = new System.Drawing.Size(161, 47);
            this.btnSaveUserData.TabIndex = 122;
            this.btnSaveUserData.Text = "Save";
            this.btnSaveUserData.UseVisualStyleBackColor = false;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblTitle.Location = new System.Drawing.Point(494, 15);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(236, 37);
            this.lblTitle.TabIndex = 121;
            this.lblTitle.Text = "Add New User";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ctrlApplicationTypeCard1
            // 
            this.ctrlApplicationTypeCard1.BackColor = System.Drawing.Color.White;
            this.ctrlApplicationTypeCard1.Location = new System.Drawing.Point(218, 186);
            this.ctrlApplicationTypeCard1.Name = "ctrlApplicationTypeCard1";
            this.ctrlApplicationTypeCard1.Size = new System.Drawing.Size(868, 317);
            this.ctrlApplicationTypeCard1.TabIndex = 124;
            // 
            // FormTest
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1319, 786);
            this.Controls.Add(this.ctrlApplicationTypeCard1);
            this.Controls.Add(this.btnCloseForm);
            this.Controls.Add(this.btnSaveUserData);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "FormTest";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormTest";
            this.Load += new System.EventHandler(this.FormTest_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnCloseForm;
        private System.Windows.Forms.Button btnSaveUserData;
        private System.Windows.Forms.Label lblTitle;
        private DVLD.Applications.Application_Types.Controls.ctrlApplicationTypeCard ctrlApplicationTypeCard1;
    }
}