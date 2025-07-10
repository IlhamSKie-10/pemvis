using System;
using System.Data;
using System.Windows.Forms;
using InventoryManagementSystem.Models;

namespace InventoryManagementSystem.Controllers
{
    public class OrderController1
    {
        private readonly OrderModel1 model;

        public OrderController1()
        {
            model = new OrderModel1();
        }

        public void LoadCustomers(DataGridView dgv, string search)
        {
            DataTable dt = model.GetCustomers(search);
            dgv.Rows.Clear();
            int i = 0;
            foreach (DataRow row in dt.Rows)
            {
                i++;
                dgv.Rows.Add(i, row["cid"], row["cname"]);
            }
        }

        public void LoadProducts(DataGridView dgv, string search)
        {
            DataTable dt = model.GetProducts(search);
            dgv.Rows.Clear();
            int i = 0;
            foreach (DataRow row in dt.Rows)
            {
                i++;
                dgv.Rows.Add(i, row["pid"], row["pname"], row["pqty"], row["pprice"], row["pdescription"], row["pcategory"]);
            }
        }

        public int GetProductQty(string pid)
        {
            return model.GetQty(pid);
        }

        public void InsertOrder(DateTime odate, int pid, int cid, int qty, int price, int total)
        {
            model.InsertOrder(odate, pid, cid, qty, price, total);
        }
    }
}
