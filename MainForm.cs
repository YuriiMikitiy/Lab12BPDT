
using Lab12BPDT.Classes;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Lab12BPDT
{
    public partial class MainForm : Form
    {
        private string userRole;
        private Database database;
        private int currentUserId;
        public MainForm(string role, int id)
        {
            database = new Database();
            userRole = role;
            currentUserId = id;
            InitializeComponent();
            ConfigureUI();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void ConfigureUI()
        {
            switch (userRole)
            {
                case "Admin":
                    // Доступ до всіх функцій
                    DeleteUserBTN.Enabled = true;
                    DeleteUserBTN.Visible = true;
                    ViewUsersBTN.Enabled = true;
                    ViewUsersBTN.Visible = true;
                    break;
                case "User":
                    // Тільки перегляд і редагування
                    DeleteUserBTN.Enabled = false;
                    DeleteUserBTN.Visible = false;
                    ViewUsersBTN.Enabled = false;
                    ViewUsersBTN.Visible = false;
                    break;
            }
        }

        private void SaveDataBTN_Click(object sender, EventArgs e)
        {
            string userData = Data.Text;

            string query = "INSERT INTO Data (UserId, DataField) VALUES (@UserId, @DataField)";
            try
            {
                database.OpenConnection();

                using (SqlCommand command = new SqlCommand(query, database.GetConnection()))
                {
                    command.Parameters.AddWithValue("@UserId", currentUserId); // Передайте ID користувача
                    command.Parameters.AddWithValue("@DataField", userData);
                    command.ExecuteNonQuery();
                }

                MessageBox.Show("Дані успішно збережено.");
            }
            finally
            {
                database.CloseConnection();
            }
        }

        private void ViewData_Click(object sender, EventArgs e)
        {
            string query;

            if (userRole == "Admin")
            {
                // Admin can view all data
                query = "SELECT Id, UserId, DataField FROM Data";
            }
            else
            {
                // Regular users can only view their own data
                query = "SELECT Id, DataField FROM Data WHERE UserId = @UserId";
            }

            DataTable table = new DataTable();

            try
            {
                database.OpenConnection();

                using (SqlCommand command = new SqlCommand(query, database.GetConnection()))
                {
                    // Add parameter for UserId if role is not Admin
                    if (userRole != "Admin")
                    {
                        command.Parameters.AddWithValue("@UserId", currentUserId);
                    }

                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(table);
                    }
                }
            }
            finally
            {
                database.CloseConnection();
            }

            // Display data in DataGridView or ListBox
            dataGridView.DataSource = table;
        }


        private void DeleteDataBTN_Click(object sender, EventArgs e)
        {
            if (userRole != "Admin")
            {
                MessageBox.Show("У вас немає прав для видалення даних.");
                return;
            }

            if (dataGridView.SelectedRows.Count == 0)
            {
                MessageBox.Show("Виберіть хоча б один рядок для видалення.");
                return;
            }

            try
            {
                database.OpenConnection();

                foreach (DataGridViewRow row in dataGridView.SelectedRows)
                {
                    if (row.Cells["Id"].Value != null)
                    {
                        int id = Convert.ToInt32(row.Cells["Id"].Value);

                        string query = "DELETE FROM Data WHERE Id = @Id";

                        using (SqlCommand command = new SqlCommand(query, database.GetConnection()))
                        {
                            command.Parameters.AddWithValue("@Id", id);
                            command.ExecuteNonQuery();
                        }

                        // Remove row from DataGridView
                        dataGridView.Rows.Remove(row);
                    }
                }

                MessageBox.Show("Вибрані дані успішно видалено.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Сталася помилка під час видалення даних: {ex.Message}");
            }
            finally
            {
                database.CloseConnection();
            }
        }


        private void DeleteUserBTN_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 0)
            {
                MessageBox.Show("Виберіть користувача для видалення.");
                return;
            }

            // З'ясуємо ID користувача з вибраного рядка
            int selectedUserId = -1;

            foreach (DataGridViewRow row in dataGridView.SelectedRows)
            {
                // Перевірка наявності стовпця "Id"
                if (row.Cells["Id"].Value != null)
                {
                    selectedUserId = Convert.ToInt32(row.Cells["Id"].Value);
                    break; // Якщо користувач знайдений, виходимо з циклу
                }
            }

            if (selectedUserId == -1)
            {
                MessageBox.Show("Не вдалося знайти ID користувача.");
                return;
            }

            // Підтвердження видалення користувача
            var confirmResult = MessageBox.Show("Ви впевнені, що хочете видалити цього користувача?", "Підтвердження", MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.No)
            {
                return; // Якщо користувач скасував видалення
            }

            // SQL-запит для видалення користувача з бази даних
            string query2 = "DELETE FROM Users WHERE Id = @UserId";
            string query = "DELETE FROM Data WHERE UserID = @UserId";

            try
            {
                database.OpenConnection();

                using (SqlCommand command = new SqlCommand(query, database.GetConnection()))
                {
                    // Додавання параметра для ID користувача
                    command.Parameters.AddWithValue("@UserId", selectedUserId);

                    // Виконання запиту
                    command.ExecuteNonQuery();
                }
                using (SqlCommand command = new SqlCommand(query2, database.GetConnection()))
                {
                    // Додавання параметра для ID користувача
                    command.Parameters.AddWithValue("@UserId", selectedUserId);

                    // Виконання запиту
                    command.ExecuteNonQuery();
                }

                // Видалення користувача з DataGridView
                foreach (DataGridViewRow row in dataGridView.SelectedRows)
                {
                    dataGridView.Rows.Remove(row);
                }

                MessageBox.Show("Користувача успішно видалено.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Сталася помилка при видаленні користувача: {ex.Message}");
            }
            finally
            {
                database.CloseConnection();
            }
        }

        private void ViewUsersBTN_Click(object sender, EventArgs e)
        {
            if (userRole != "Admin")
            {
                MessageBox.Show("У вас немає прав для перегляду інших користувачів.");
                return;
            }

            string query = "SELECT Id, Username FROM Users";
            DataTable table = new DataTable();

            try
            {
                database.OpenConnection();

                using (SqlCommand command = new SqlCommand(query, database.GetConnection()))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(table);
                    }
                }
            }
            finally
            {
                database.CloseConnection();
            }

            // Display data in DataGridView or ListBox
            dataGridView.DataSource = table;
        }

    }
}
