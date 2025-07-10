using System.Collections.Generic;
using System.Data.SqlClient;

namespace InventoryManagementSystem.Models
{
    public class Customer
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
    }

    public class CustomerModel
    {
        private SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=DBIMS;Integrated Security=True");

        public List<Customer> GetAllCustomers()
        {
            List<Customer> customers = new List<Customer>();
            SqlCommand cmd = new SqlCommand("SELECT * FROM tbCustomer", con);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                customers.Add(new Customer
                {
                    Id = dr[0].ToString(),
                    Name = dr[1].ToString(),
                    Phone = dr[2].ToString()
                });
            }
            dr.Close();
            con.Close();
            return customers;
        }

        public void DeleteCustomer(string id)
        {
            SqlCommand cmd = new SqlCommand("DELETE FROM tbCustomer WHERE cid LIKE @cid", con);
            cmd.Parameters.AddWithValue("@cid", id);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}
