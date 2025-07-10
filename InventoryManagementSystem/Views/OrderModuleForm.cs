using InventoryManagementSystem.Controllers;
using System;
using System.Windows.Forms;

namespace InventoryManagementSystem
{
    public partial class OrderModuleForm : Form
    {
        private readonly OrderController1 controller = new OrderController1(); // Nama class controller harus sesuai

        public OrderModuleForm()
        {
            InitializeComponent();
            LoadInitialData();
        }

        private void LoadInitialData()
        {
            controller.LoadCustomers(dgvCustomer, txtSearchCust.Text);
            controller.LoadProducts(dgvProduct, txtSearchProd.Text);
        }

        private void txtSearchCust_TextChanged(object sender, EventArgs e)
        {
            controller.LoadCustomers(dgvCustomer, txtSearchCust.Text);
        }

        private void txtSearchProd_TextChanged(object sender, EventArgs e)
        {
            controller.LoadProducts(dgvProduct, txtSearchProd.Text);
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCId.Text) || string.IsNullOrWhiteSpace(txtPid.Text))
            {
                MessageBox.Show("Please select customer and product!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Are you sure you want to insert this order?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    controller.InsertOrder(
                        dtOrder.Value,
                        Convert.ToInt32(txtPid.Text),
                        Convert.ToInt32(txtCId.Text),
                        Convert.ToInt32(UDQty.Value),
                        Convert.ToInt32(txtPrice.Text),
                        Convert.ToInt32(txtTotal.Text)
                    );

                    MessageBox.Show("Order inserted successfully.");
                    Clear();
                    controller.LoadProducts(dgvProduct, txtSearchProd.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error inserting order: " + ex.Message);
                }
            }
        }

        private void Clear()
        {
            txtCId.Clear();
            txtCName.Clear();
            txtPid.Clear();
            txtPName.Clear();
            txtPrice.Clear();
            UDQty.Value = 0;
            txtTotal.Clear();
            dtOrder.Value = DateTime.Now;
        }
    }
}
