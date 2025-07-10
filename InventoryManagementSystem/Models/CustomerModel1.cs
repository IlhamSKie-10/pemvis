using System.Data.SqlClient;

namespace InventoryManagementSystem.Models
{
    public class CustomerModel1
    {
        private SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=DBIMS;Integrated Security=True");

        public void InsertCustomer(string name, string phone)
        {
            SqlCommand cmd = new SqlCommand("INSERT INTO tbCustomer(cname, cphone) VALUES (@cname, @cphone)", con);
            cmd.Parameters.AddWithValue("@cname", name);
            cmd.Parameters.AddWithValue("@cphone", phone);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void UpdateCustomer(string id, string name, string phone)
        {
            SqlCommand cmd = new SqlCommand("UPDATE tbCustomer SET cname = @cname, cphone = @cphone WHERE cid LIKE @cid", con);
            cmd.Parameters.AddWithValue("@cid", id);
            cmd.Parameters.AddWithValue("@cname", name);
            cmd.Parameters.AddWithValue("@cphone", phone);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}
