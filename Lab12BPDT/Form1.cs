using System;
using System.Windows.Forms;

namespace Lab12BPDT
{
    public partial class Form1 : Form
    {
        private string userRole;

        public Form1(string role)
        {
            InitializeComponent();
            userRole = role;
            SetupRoleBasedAccess();
        }

        private void SetupRoleBasedAccess()
        {
            // Приховуємо або показуємо елементи відповідно до ролі
            if (userRole == "Admin")
            {
                adminPanel.Visible = true;
            }
            else
            {
                adminPanel.Visible = false;
            }
        }

        private void btnAdminAction_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Admin action executed.");
        }

        private void btnUserAction_Click(object sender, EventArgs e)
        {
            MessageBox.Show("User action executed.");
        }
    }
}
