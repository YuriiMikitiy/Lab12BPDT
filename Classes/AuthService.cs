using Microsoft.Data.SqlClient;
using System.Text;
using System.Security.Cryptography;


namespace Lab12BPDT.Classes
{
    internal class AuthService
    {
        private string connectionString = "Server=DESKTOP-FJ7FH92\\LAB10;Database=Lab12;User Id=admin;Password=adminpassword;TrustServerCertificate=True;";

        public string AuthenticateUser(string username, string password)
        {
            string hashedPassword = HashPassword(password);
            using (SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-FJ7FH92\LAB10;Initial Catalog=Lab12;Integrated Security=True"))
            {
                connection.Open();

                string query = "SELECT Role FROM Users WHERE Username = @Username AND Password = @Password";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Username", username);
                    command.Parameters.AddWithValue("@Password", hashedPassword);

                    var role = command.ExecuteScalar();
                    if (role != null)
                    {
                        return role.ToString();
                    }
                    else
                    {
                        return null; // Невірний логін або пароль
                    }
                }
            }
        }

        private string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return BitConverter.ToString(bytes).Replace("-", "").ToLower();
            }
        }
    }
}
