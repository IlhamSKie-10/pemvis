using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace InventoryManagementSystem.Models
{
    public class OrderData
    {
        public string OrderId { get; set; }
        public DateTime Date { get; set; }
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public string CustomerId { get; set; }
        public string CustomerName { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal Total { get; set; }
    }

    public class OrderModel
    {
        private SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=DBIMS;Integrated Security=True");

        public List<OrderData> GetOrders(string keyword)
        {
            List<OrderData> orders = new List<OrderData>();
            SqlCommand cmd = new SqlCommand("SELECT orderid, odate, O.pid, P.pname, O.cid, C.cname, qty, price, total " +
                                            "FROM tbOrder AS O " +
                                            "JOIN tbCustomer AS C ON O.cid = C.cid " +
                                            "JOIN tbProduct AS P ON O.pid = P.pid " +
                                            $"WHERE CONCAT(orderid, odate, O.pid, P.pname, O.cid, C.cname, qty, price) LIKE '%{keyword}%'", con);

            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                orders.Add(new OrderData
                {
                    OrderId = dr[0].ToString(),
                    Date = Convert.ToDateTime(dr[1]),
                    ProductId = dr[2].ToString(),
                    ProductName = dr[3].ToString(),
                    CustomerId = dr[4].ToString(),
                    CustomerName = dr[5].ToString(),
                    Quantity = Convert.ToInt32(dr[6]),
                    Price = Convert.ToDecimal(dr[7]),
                    Total = Convert.ToDecimal(dr[8])
                });
            }
            dr.Close();
            con.Close();

            return orders;
        }

        public void DeleteOrder(string orderId)
        {
            SqlCommand cmd = new SqlCommand("DELETE FROM tbOrder WHERE orderid LIKE @orderid", con);
            cmd.Parameters.AddWithValue("@orderid", orderId);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void RestoreProductQuantity(string productId, int quantity)
        {
            SqlCommand cmd = new SqlCommand("UPDATE tbProduct SET pqty = pqty + @qty WHERE pid LIKE @pid", con);
            cmd.Parameters.AddWithValue("@qty", quantity);
            cmd.Parameters.AddWithValue("@pid", productId);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}
