using System.Data.SqlClient;

namespace InventoryManagementSystem.Models
{
    public class Login
    {
        private SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=DBIMS;Integrated Security=True");

        public SqlDataReader AuthenticateUser(string username, string password)
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM tbUser WHERE username=@username AND password=@password", con);
            cmd.Parameters.AddWithValue("@username", username);
            cmd.Parameters.AddWithValue("@password", password);
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            return reader;
        }

        public void CloseConnection()
        {
            if (con.State == System.Data.ConnectionState.Open)
                con.Close();
        }
    }
}
