﻿namespace DVLDSystem.DVLD.Applications.Application_Types
{
    partial class frmShowApplicationTypeCard
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
            this.lable1 = new System.Windows.Forms.Label();
            this.btnCloseForm = new System.Windows.Forms.Button();
            this.ctrlApplicationTypeCard1 = new DVLDSystem.DVLD.Applications.Application_Types.Controls.ctrlApplicationTypeCard();
            this.SuspendLayout();
            // 
            // lable1
            // 
            this.lable1.AutoSize = true;
            this.lable1.Font = new System.Drawing.Font("Microsoft JhengHei", 20F, System.Drawing.FontStyle.Bold);
            this.lable1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lable1.Location = new System.Drawing.Point(290, 19);
            this.lable1.Name = "lable1";
            this.lable1.Size = new System.Drawing.Size(327, 35);
            this.lable1.TabIndex = 29;
            this.lable1.Text = "Application Type Details";
            this.lable1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnCloseForm
            // 
            this.btnCloseForm.BackColor = System.Drawing.Color.White;
            this.btnCloseForm.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCloseForm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCloseForm.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCloseForm.Image = global::DVLDSystem.Properties.Resources.Close_32;
            this.btnCloseForm.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCloseForm.Location = new System.Drawing.Point(717, 423);
            this.btnCloseForm.Name = "btnCloseForm";
            this.btnCloseForm.Size = new System.Drawing.Size(161, 47);
            this.btnCloseForm.TabIndex = 31;
            this.btnCloseForm.Text = "Close";
            this.btnCloseForm.UseVisualStyleBackColor = false;
            this.btnCloseForm.Click += new System.EventHandler(this.btnCloseForm_Click);
            // 
            // ctrlApplicationTypeCard1
            // 
            this.ctrlApplicationTypeCard1.BackColor = System.Drawing.Color.White;
            this.ctrlApplicationTypeCard1.Location = new System.Drawing.Point(19, 87);
            this.ctrlApplicationTypeCard1.Name = "ctrlApplicationTypeCard1";
            this.ctrlApplicationTypeCard1.Size = new System.Drawing.Size(868, 317);
            this.ctrlApplicationTypeCard1.TabIndex = 30;
            // 
            // frmShowApplicationTypeCard
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(904, 497);
            this.Controls.Add(this.btnCloseForm);
            this.Controls.Add(this.ctrlApplicationTypeCard1);
            this.Controls.Add(this.lable1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmShowApplicationTypeCard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Show Application Type Info";
            this.Load += new System.EventHandler(this.frmShowApplicationTypeCard_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lable1;
        private Controls.ctrlApplicationTypeCard ctrlApplicationTypeCard1;
        private System.Windows.Forms.Button btnCloseForm;
    }
}