using Lab12BPDT.Classes;
using Microsoft.Data.SqlClient;
using System.Data;

namespace Lab12BPDT
{
    public partial class LoginForm : Form
    {
        private Database database;

        public LoginForm()
        {
            InitializeComponent();
            database = new Database();
        }

        private void SignInbtn_Click(object sender, EventArgs e)
        {
            string username = login.Text;
            string password = Password.Text;

            DataTable userTable = new DataTable();
            string getUserQuery = "SELECT Id, Password, Role, FailedLoginAttempts, LastFailedLoginTime FROM Users WHERE Username = @Username";
            try
            {
                // Open connection
                database.OpenConnection();

                using (SqlCommand command = new SqlCommand(getUserQuery, database.GetConnection()))
                {
                    command.Parameters.AddWithValue("@Username", username);
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(userTable);
                    }
                }

                if (userTable.Rows.Count == 0)
                {
                    MessageBox.Show("������� ���� ��� ������.");
                    return;
                }

                // Get user info
                var userRow = userTable.Rows[0];
                int userId = Convert.ToInt32(userRow["Id"]);
                string role = userRow["Role"].ToString();
                string storedPassword = userRow["Password"].ToString();

                // Hash the entered password and compare
                string hashedEnteredPassword = PasswordManager.HashPassword(password);

                // Handle failed attempts
                int failedAttempts = userRow["FailedLoginAttempts"] != DBNull.Value
                              ? Convert.ToInt32(userRow["FailedLoginAttempts"])
                              : 0;

                DateTime? lastFailedLoginTime = userRow["LastFailedLoginTime"] != DBNull.Value
                                                ? Convert.ToDateTime(userRow["LastFailedLoginTime"])
                                                : (DateTime?)null;

                // Check if account is currently locked
                if (failedAttempts >= 5 && lastFailedLoginTime.HasValue &&
                    DateTime.Now < lastFailedLoginTime.Value.AddMinutes(10))
                {
                    MessageBox.Show("��� ������� ����������� �� 10 ������. ��������� �����.");
                    return;
                }

                if (hashedEnteredPassword != storedPassword)
                {
                    failedAttempts++;
                    // Update failed attempts and timestamp on failed login
                    string updateFailedAttemptsQuery = "UPDATE Users SET FailedLoginAttempts = @FailedAttempts, LastFailedLoginTime = @Now WHERE Id = @UserId";
                    using (SqlCommand updateCommand = new SqlCommand(updateFailedAttemptsQuery, database.GetConnection()))
                    {
                        updateCommand.Parameters.AddWithValue("@FailedAttempts", failedAttempts);
                        updateCommand.Parameters.AddWithValue("@Now", DateTime.Now);
                        updateCommand.Parameters.AddWithValue("@UserId", userId);
                        updateCommand.ExecuteNonQuery();
                    }
                    MessageBox.Show("������� ���� ��� ������.");
                    return;
                }

                // Successful login
                string resetAttemptsQuery = "UPDATE Users SET FailedLoginAttempts = 0, LastFailedLoginTime = NULL WHERE Id = @UserId";
                using (SqlCommand resetCommand = new SqlCommand(resetAttemptsQuery, database.GetConnection()))
                {
                    resetCommand.Parameters.AddWithValue("@UserId", userId);
                    resetCommand.ExecuteNonQuery();
                }

                // Successful login
                MessageBox.Show($"���� �������! ���� ����: {role}");
                MainForm mainForm = new MainForm(role, userId);
                mainForm.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
            finally
            {
                database.CloseConnection();
            }
        }


        private void SignUpbtn_Click(object sender, EventArgs e)
        {
            SignUpForm signUpForm = new SignUpForm();
            signUpForm.Show();
            this.Hide();
        }
    }

}
