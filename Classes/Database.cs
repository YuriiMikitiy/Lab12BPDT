
using Microsoft.Data.SqlClient;

namespace Lab12BPDT.Classes
{
    internal class Database
    {
        SqlConnection sqlConnection = new SqlConnection(
            @"Data Source=DESKTOP-FJ7FH92\LAB10;Initial Catalog=Lab12;Integrated Security=True;Trust Server Certificate=True");
    
        public void OpenConnection()
        {
            if(sqlConnection.State == System.Data.ConnectionState.Closed)
            {
                sqlConnection.Open();
            }
        }

        public void CloseConnection()
        {
            if (sqlConnection.State == System.Data.ConnectionState.Open)
            {
                sqlConnection.Close();
            }
        }

        public SqlConnection GetConnection()
        {
            return sqlConnection;
        }

    }
}
