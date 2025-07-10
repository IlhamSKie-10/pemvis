using InventoryManagementSystem.Controllers;
using InventoryManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace InventoryManagementSystem
{
    public partial class OrderForm : Form
    {
        private readonly OrderController controller;

        public OrderForm()
        {
            InitializeComponent();
            controller = new OrderController();
            LoadOrder();
        }

        public void LoadOrder()
        {
            double total = 0;
            int i = 0;
            dgvOrder.Rows.Clear();

            List<OrderData> orders = controller.LoadOrders(txtSearch.Text);

            foreach (var order in orders)
            {
                i++;
                dgvOrder.Rows.Add(i, order.OrderId, order.Date.ToString("dd/MM/yyyy"), order.ProductId, order.ProductName, order.CustomerId, order.CustomerName, order.Quantity, order.Price, order.Total);
                total += Convert.ToDouble(order.Total);
            }

            lblQty.Text = i.ToString();
            lblTotal.Text = total.ToString();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            OrderModuleForm moduleForm = new OrderModuleForm();
            moduleForm.ShowDialog();
            LoadOrder();
        }

        private void dgvUser_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dgvOrder.Columns[e.ColumnIndex].Name;

            if (colName == "Delete")
            {
                string orderId = dgvOrder.Rows[e.RowIndex].Cells[1].Value.ToString();
                string productId = dgvOrder.Rows[e.RowIndex].Cells[3].Value.ToString();
                int quantity = Convert.ToInt32(dgvOrder.Rows[e.RowIndex].Cells[7].Value.ToString());

                if (MessageBox.Show("Are you sure you want to delete this order?", "Delete Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    controller.DeleteOrder(orderId, productId, quantity);
                    MessageBox.Show("Record has been successfully deleted!");
                }
                LoadOrder();
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadOrder();
        }
    }
}
