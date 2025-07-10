using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;

namespace InventoryManagementSystem.Models
{
    public class OrderModel1
    {
        private readonly SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=DBIMS;Integrated Security=True");

        public DataTable GetCustomers(string search)
        {
            var dt = new DataTable();
            string query = "SELECT cid, cname FROM tbCustomer WHERE CONCAT(cid,cname) LIKE @search";
            using (SqlCommand cm = new SqlCommand(query, con))
            {
                cm.Parameters.AddWithValue("@search", "%" + search + "%");
                con.Open();
                dt.Load(cm.ExecuteReader());
                con.Close();
            }
            return dt;
        }

        public DataTable GetProducts(string search)
        {
            var dt = new DataTable();
            string query = "SELECT * FROM tbProduct WHERE CONCAT(pid, pname, pprice, pdescription, pcategory) LIKE @search";
            using (SqlCommand cm = new SqlCommand(query, con))
            {
                cm.Parameters.AddWithValue("@search", "%" + search + "%");
                con.Open();
                dt.Load(cm.ExecuteReader());
                con.Close();
            }
            return dt;
        }

        public int GetQty(string pid)
        {
            int qty = 0;
            string query = "SELECT pqty FROM tbProduct WHERE pid=@pid";
            using (SqlCommand cm = new SqlCommand(query, con))
            {
                cm.Parameters.AddWithValue("@pid", pid);
                con.Open();
                SqlDataReader dr = cm.ExecuteReader();
                if (dr.Read())
                    qty = Convert.ToInt32(dr[0]);
                dr.Close();
                con.Close();
            }
            return qty;
        }

        public void InsertOrder(DateTime odate, int pid, int cid, int qty, int price, int total)
        {
            string insertQuery = "INSERT INTO tbOrder(odate, pid, cid, qty, price, total)VALUES(@odate, @pid, @cid, @qty, @price, @total)";
            using (SqlCommand cm = new SqlCommand(insertQuery, con))
            {
                cm.Parameters.AddWithValue("@odate", odate);
                cm.Parameters.AddWithValue("@pid", pid);
                cm.Parameters.AddWithValue("@cid", cid);
                cm.Parameters.AddWithValue("@qty", qty);
                cm.Parameters.AddWithValue("@price", price);
                cm.Parameters.AddWithValue("@total", total);
                con.Open();
                cm.ExecuteNonQuery();
                con.Close();
            }

            string updateQuery = "UPDATE tbProduct SET pqty=(pqty-@pqty) WHERE pid=@pid";
            using (SqlCommand cm = new SqlCommand(updateQuery, con))
            {
                cm.Parameters.AddWithValue("@pqty", qty);
                cm.Parameters.AddWithValue("@pid", pid);
                con.Open();
                cm.ExecuteNonQuery();
                con.Close();
            }
        }
    }
}
