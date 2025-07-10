using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace InventoryManagementSystem.Models
{
    public class UserModel
    {
        private readonly SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=DBIMS;Integrated Security=True");

        public List<string[]> GetUsers()
        {
            List<string[]> users = new List<string[]>();
            string query = "SELECT * FROM tbUser";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                string[] user = new string[]
                {
                    dr[0].ToString(), // username
                    dr[1].ToString(), // fullname
                    dr[2].ToString(), // password
                    dr[3].ToString()  // phone
                };
                users.Add(user);
            }
            dr.Close();
            con.Close();
            return users;
        }

        public void DeleteUser(string username)
        {
            string query = "DELETE FROM tbUser WHERE username = @username";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@username", username);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}
