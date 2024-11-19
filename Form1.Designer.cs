namespace Lab12BPDT
{
    partial class LoginForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            SignUpbtn = new Button();
            SignInbtn = new Button();
            login = new TextBox();
            Password = new TextBox();
            label2 = new Label();
            label1 = new Label();
            SuspendLayout();
            // 
            // SignUpbtn
            // 
            SignUpbtn.Location = new Point(256, 201);
            SignUpbtn.Name = "SignUpbtn";
            SignUpbtn.Size = new Size(94, 29);
            SignUpbtn.TabIndex = 0;
            SignUpbtn.Text = "Sign Up";
            SignUpbtn.UseVisualStyleBackColor = true;
            SignUpbtn.Click += SignUpbtn_Click;
            // 
            // SignInbtn
            // 
            SignInbtn.Location = new Point(156, 201);
            SignInbtn.Name = "SignInbtn";
            SignInbtn.Size = new Size(94, 29);
            SignInbtn.TabIndex = 1;
            SignInbtn.Text = "Sign In";
            SignInbtn.UseVisualStyleBackColor = true;
            SignInbtn.Click += SignInbtn_Click;
            // 
            // login
            // 
            login.Location = new Point(190, 82);
            login.Name = "login";
            login.Size = new Size(125, 27);
            login.TabIndex = 2;
            // 
            // Password
            // 
            Password.Location = new Point(190, 142);
            Password.Name = "Password";
            Password.Size = new Size(125, 27);
            Password.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(190, 119);
            label2.Name = "label2";
            label2.Size = new Size(70, 20);
            label2.TabIndex = 5;
            label2.Text = "Password";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(190, 59);
            label1.Name = "label1";
            label1.Size = new Size(46, 20);
            label1.TabIndex = 7;
            label1.Text = "Login";
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(513, 316);
            Controls.Add(label1);
            Controls.Add(label2);
            Controls.Add(Password);
            Controls.Add(login);
            Controls.Add(SignInbtn);
            Controls.Add(SignUpbtn);
            Name = "LoginForm";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button SignUpbtn;
        private Button SignInbtn;
        private TextBox login;
        private TextBox Password;
        private Label label2;
        private Label label1;
    }
}
