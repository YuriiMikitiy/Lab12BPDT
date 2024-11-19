namespace Lab12BPDT
{
    partial class Form1
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
            this.adminPanel = new System.Windows.Forms.Panel();
            this.userPanel = new System.Windows.Forms.Panel();
            this.lblWelcome = new System.Windows.Forms.Label();
            this.btnAdminAction = new System.Windows.Forms.Button();
            this.btnUserAction = new System.Windows.Forms.Button();
            this.SuspendLayout();

            // lblWelcome
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Location = new System.Drawing.Point(20, 20);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(150, 20);
            this.lblWelcome.TabIndex = 0;
            this.lblWelcome.Text = "Welcome to the App!";

            // adminPanel
            this.adminPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.adminPanel.Controls.Add(this.btnAdminAction);
            this.adminPanel.Location = new System.Drawing.Point(20, 60);
            this.adminPanel.Name = "adminPanel";
            this.adminPanel.Size = new System.Drawing.Size(250, 100);
            this.adminPanel.TabIndex = 1;
            this.adminPanel.Visible = false; // Panel visible only for Admins

            // btnAdminAction
            this.btnAdminAction.Location = new System.Drawing.Point(10, 10);
            this.btnAdminAction.Name = "btnAdminAction";
            this.btnAdminAction.Size = new System.Drawing.Size(200, 30);
            this.btnAdminAction.TabIndex = 0;
            this.btnAdminAction.Text = "Admin Action";
            this.btnAdminAction.UseVisualStyleBackColor = true;
            this.btnAdminAction.Click += new System.EventHandler(this.btnAdminAction_Click);

            // userPanel
            this.userPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.userPanel.Controls.Add(this.btnUserAction);
            this.userPanel.Location = new System.Drawing.Point(20, 180);
            this.userPanel.Name = "userPanel";
            this.userPanel.Size = new System.Drawing.Size(250, 100);
            this.userPanel.TabIndex = 2;

            // btnUserAction
            this.btnUserAction.Location = new System.Drawing.Point(10, 10);
            this.btnUserAction.Name = "btnUserAction";
            this.btnUserAction.Size = new System.Drawing.Size(200, 30);
            this.btnUserAction.TabIndex = 0;
            this.btnUserAction.Text = "User Action";
            this.btnUserAction.UseVisualStyleBackColor = true;
            this.btnUserAction.Click += new System.EventHandler(this.btnUserAction_Click);

            // MainForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 300);
            this.Controls.Add(this.lblWelcome);
            this.Controls.Add(this.adminPanel);
            this.Controls.Add(this.userPanel);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Panel adminPanel;
        private System.Windows.Forms.Panel userPanel;
        private System.Windows.Forms.Button btnAdminAction;
        private System.Windows.Forms.Button btnUserAction;
    }
}

