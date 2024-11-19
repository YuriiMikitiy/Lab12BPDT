using Lab12BPDT.Classes;
using Microsoft.Data.SqlClient;

namespace Lab12BPDT
{
    public partial class SignUpForm : Form
    {
        private Database database;
        public SignUpForm()
        {
            database = new Database();
            InitializeComponent();
        }

        private void SignUpBTN_Click(object sender, EventArgs e)
        {
            string username = LoginTXT.Text;
            string password = PasswordTXT.Text;
            string confirmPassword = ConfirmPassTXT.Text;

            // Basic input validation
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(confirmPassword))
            {
                MessageBox.Show("Всі поля повинні бути заповнені.");
                return;
            }

            if (password != confirmPassword)
            {
                MessageBox.Show("Паролі не співпадають.");
                return;
            }

            // Check if the username already exists in the database
            string checkUserQuery = "SELECT COUNT(*) FROM Users WHERE Username = @Username";

            try
            {
                database.OpenConnection();

                using (SqlCommand command = new SqlCommand(checkUserQuery, database.GetConnection()))
                {
                    command.Parameters.AddWithValue("@Username", username);
                    int userCount = (int)command.ExecuteScalar();

                    if (userCount > 0)
                    {
                        MessageBox.Show("Користувач з таким логіном вже існує.");
                        return;
                    }
                }

                // If username is available, proceed to insert new user
                string insertQuery = "INSERT INTO Users (Username, Password, Role) VALUES (@Username, @Password, @Role)";

                using (SqlCommand command = new SqlCommand(insertQuery, database.GetConnection()))
                {
                    command.Parameters.AddWithValue("@Username", username);
                    string hashedPassword = PasswordManager.HashPassword(password);
                    command.Parameters.AddWithValue("@Password", hashedPassword);
                    command.Parameters.AddWithValue("@Role", "User"); // Default role for a new user

                    command.ExecuteNonQuery();
                }

                MessageBox.Show("Реєстрація успішна! Тепер ви можете увійти.");
                // Optionally, clear the input fields after successful registration
                LoginTXT.Clear();
                PasswordTXT.Clear();
                ConfirmPassTXT.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Сталася помилка при реєстрації: {ex.Message}");
            }
            finally
            {
                database.CloseConnection();
            }
        }

        private void BackBtn_Click(object sender, EventArgs e)
        {
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
            this.Hide();
        }
    }
}
