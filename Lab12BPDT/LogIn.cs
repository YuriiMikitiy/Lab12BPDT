
using System;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace Lab12BPDT
{
    public partial class LogIn : Form
    {
        public LogIn()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            // Виконуємо аутентифікацію
            if (AuthenticateUser(username, password))
            {
                MessageBox.Show("Успішний вхід");
                // Визначаємо роль користувача
                string role = GetUserRole(username);
                // Запускаємо основну форму з правами відповідно до ролі
                Form1 mainForm = new Form1(role);
                mainForm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Неправильне ім'я користувача або пароль.");
            }
        }

        private bool AuthenticateUser(string username, string password)
        {
            // Хешуємо введений пароль
            string hashedPassword = SecurityHelper.ComputeMD5Hash(password);

            string connectionString = "Data Source=DESKTOP-9KT5M4L;Initial Catalog=Lab12BPD;Integrated Security=True";
            string query = "SELECT COUNT(*) FROM Users WHERE Username=@username AND Password=@password";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@username", username);
                command.Parameters.AddWithValue("@password", hashedPassword);

                connection.Open();
                int result = (int)command.ExecuteScalar();
                return result > 0;
            }
        }

        private string GetUserRole(string username)
        {
            string connectionString = "Data Source=DESKTOP-9KT5M4L;Initial Catalog=Lab12BPD;Integrated Security=True";
            string query = @"
        SELECT Roles.RoleName 
        FROM Users 
        INNER JOIN Roles ON Users.RoleID = Roles.RoleID 
        WHERE Users.Username = @username";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@username", username);

                connection.Open();
                return command.ExecuteScalar()?.ToString();
            }
        }
    }

    public static class SecurityHelper
    {
        public static string ComputeMD5Hash(string input)
        {
            using (MD5 md5 = MD5.Create())
            {
                byte[] inputBytes = Encoding.UTF8.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                // Конвертуємо байти хешу в шістнадцятковий рядок
                StringBuilder sb = new StringBuilder();
                foreach (byte b in hashBytes)
                {
                    sb.Append(b.ToString("x2"));
                }
                return sb.ToString();
            }
        }
    }
}
