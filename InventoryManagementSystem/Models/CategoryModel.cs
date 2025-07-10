using System.Collections.Generic;
using System.Data.SqlClient;

namespace InventoryManagementSystem.Models
{
    public class Category
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }

    public class CategoryModel
    {
        private SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=DBIMS;Integrated Security=True");

        public List<Category> GetAllCategories()
        {
            List<Category> list = new List<Category>();
            SqlCommand cmd = new SqlCommand("SELECT * FROM tbCategory", con);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                list.Add(new Category
                {
                    Id = dr[0].ToString(),
                    Name = dr[1].ToString()
                });
            }
            dr.Close();
            con.Close();
            return list;
        }

        public void DeleteCategory(string catId)
        {
            SqlCommand cmd = new SqlCommand("DELETE FROM tbCategory WHERE catid LIKE @catid", con);
            cmd.Parameters.AddWithValue("@catid", catId);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}
