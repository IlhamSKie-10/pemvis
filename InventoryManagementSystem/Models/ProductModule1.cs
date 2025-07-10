using System.Collections.Generic;
using System.Data.SqlClient;

namespace InventoryManagementSystem.Models
{
    public class ProductModel1
    {
        private readonly SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;InitialCatalog=DBIMS;Integrated Security=True");

        public List<string> LoadCategories()
        {
            List<string> categories = new List<string>();
            string query = "SELECT catname FROM tbCategory";

            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    categories.Add(dr[0].ToString());
                }
                dr.Close();
                con.Close();
            }
            return categories;
        }

        public void InsertProduct(string pname, int pqty, int pprice, string pdescription, string pcategory)
        {
            string query = "INSERT INTO tbProduct(pname, pqty, pprice, pdescription, pcategory) VALUES(@pname, @pqty, @pprice, @pdescription, @pcategory)";
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@pname", pname);
                cmd.Parameters.AddWithValue("@pqty", pqty);
                cmd.Parameters.AddWithValue("@pprice", pprice);
                cmd.Parameters.AddWithValue("@pdescription", pdescription);
                cmd.Parameters.AddWithValue("@pcategory", pcategory);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public void UpdateProduct(int pid, string pname, int pqty, int pprice, string pdescription, string pcategory)
        {
            string query = "UPDATE tbProduct SET pname=@pname, pqty=@pqty, pprice=@pprice, pdescription=@pdescription, pcategory=@pcategory WHERE pid=@pid";
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@pid", pid);
                cmd.Parameters.AddWithValue("@pname", pname);
                cmd.Parameters.AddWithValue("@pqty", pqty);
                cmd.Parameters.AddWithValue("@pprice", pprice);
                cmd.Parameters.AddWithValue("@pdescription", pdescription);
                cmd.Parameters.AddWithValue("@pcategory", pcategory);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
    }
}
