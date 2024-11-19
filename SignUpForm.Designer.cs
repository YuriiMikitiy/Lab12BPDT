namespace Lab12BPDT
{
    partial class SignUpForm
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
            SignUpBTN = new Button();
            BackBtn = new Button();
            LoginTXT = new TextBox();
            PasswordTXT = new TextBox();
            label1 = new Label();
            label2 = new Label();
            ConfirmPassTXT = new TextBox();
            label3 = new Label();
            SuspendLayout();
            // 
            // SignUpBTN
            // 
            SignUpBTN.Location = new Point(218, 223);
            SignUpBTN.Name = "SignUpBTN";
            SignUpBTN.Size = new Size(94, 29);
            SignUpBTN.TabIndex = 0;
            SignUpBTN.Text = "Sign Up";
            SignUpBTN.UseVisualStyleBackColor = true;
            SignUpBTN.Click += SignUpBTN_Click;
            // 
            // BackBtn
            // 
            BackBtn.Location = new Point(330, 223);
            BackBtn.Name = "BackBtn";
            BackBtn.Size = new Size(94, 29);
            BackBtn.TabIndex = 1;
            BackBtn.Text = "Back";
            BackBtn.UseVisualStyleBackColor = true;
            BackBtn.Click += BackBtn_Click;
            // 
            // LoginTXT
            // 
            LoginTXT.Location = new Point(270, 65);
            LoginTXT.Name = "LoginTXT";
            LoginTXT.Size = new Size(125, 27);
            LoginTXT.TabIndex = 2;
            // 
            // PasswordTXT
            // 
            PasswordTXT.Location = new Point(270, 122);
            PasswordTXT.Name = "PasswordTXT";
            PasswordTXT.Size = new Size(125, 27);
            PasswordTXT.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(270, 42);
            label1.Name = "label1";
            label1.Size = new Size(46, 20);
            label1.TabIndex = 4;
            label1.Text = "Login";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(270, 99);
            label2.Name = "label2";
            label2.Size = new Size(70, 20);
            label2.TabIndex = 5;
            label2.Text = "Password";
            // 
            // ConfirmPassTXT
            // 
            ConfirmPassTXT.Location = new Point(270, 179);
            ConfirmPassTXT.Name = "ConfirmPassTXT";
            ConfirmPassTXT.Size = new Size(125, 27);
            ConfirmPassTXT.TabIndex = 6;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(270, 156);
            label3.Name = "label3";
            label3.Size = new Size(123, 20);
            label3.TabIndex = 7;
            label3.Text = "ConfirmPassword";
            // 
            // SignUpForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label3);
            Controls.Add(ConfirmPassTXT);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(PasswordTXT);
            Controls.Add(LoginTXT);
            Controls.Add(BackBtn);
            Controls.Add(SignUpBTN);
            Name = "SignUpForm";
            Text = "SignUpForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button SignUpBTN;
        private Button BackBtn;
        private TextBox LoginTXT;
        private TextBox PasswordTXT;
        private Label label1;
        private Label label2;
        private TextBox ConfirmPassTXT;
        private Label label3;
    }
}