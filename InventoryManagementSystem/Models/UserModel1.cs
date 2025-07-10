using System.Data.SqlClient;

namespace InventoryManagementSystem.Models
{
    public class UserModel1
    {
        private readonly SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=DBIMS;Integrated Security=True");

        public void InsertUser(string username, string fullname, string password, string phone)
        {
            string query = "INSERT INTO tbUser(username, fullname, password, phone) VALUES(@username, @fullname, @password, @phone)";
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@fullname", fullname);
                cmd.Parameters.AddWithValue("@password", password);
                cmd.Parameters.AddWithValue("@phone", phone);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public void UpdateUser(string username, string fullname, string password, string phone)
        {
            string query = "UPDATE tbUser SET fullname=@fullname, password=@password, phone=@phone WHERE username=@username";
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@fullname", fullname);
                cmd.Parameters.AddWithValue("@password", password);
                cmd.Parameters.AddWithValue("@phone", phone);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
    }
}
