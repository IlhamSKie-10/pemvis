using System.Data.SqlClient;

namespace InventoryManagementSystem.Models
{
    public class CategoryModel1
    {
        private SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=DBIMS;Integrated Security=True");

        public void InsertCategory(string name)
        {
            SqlCommand cm = new SqlCommand("INSERT INTO tbCategory(catname)VALUES(@catname)", con);
            cm.Parameters.AddWithValue("@catname", name);
            con.Open();
            cm.ExecuteNonQuery();
            con.Close();
        }

        public void UpdateCategory(string id, string name)
        {
            SqlCommand cm = new SqlCommand("UPDATE tbCategory SET catname = @catname WHERE catid LIKE @catid", con);
            cm.Parameters.AddWithValue("@catname", name);
            cm.Parameters.AddWithValue("@catid", id);
            con.Open();
            cm.ExecuteNonQuery();
            con.Close();
        }
    }
}
