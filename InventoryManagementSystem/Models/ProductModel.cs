using System.Data;
using System.Data.SqlClient;

namespace InventoryManagementSystem.Models
{
    public class ProductModel
    {
        private readonly SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=DBIMS;Integrated Security=True");

        public DataTable SearchProducts(string keyword)
        {
            DataTable dt = new DataTable();
            string query = "SELECT * FROM tbProduct WHERE CONCAT(pid, pname, pprice, pdescription, pcategory) LIKE @keyword";
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@keyword", "%" + keyword + "%");
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                dt.Load(reader);
                con.Close();
            }
            return dt;
        }

        public void DeleteProduct(string pid)
        {
            string query = "DELETE FROM tbProduct WHERE pid = @pid";
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@pid", pid);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
    }
}
