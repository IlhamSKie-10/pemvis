using InventoryManagementSystem.Controllers;
using InventoryManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace InventoryManagementSystem
{
    public partial class CustomerForm : Form
    {
        private readonly CustomerController controller;

        public CustomerForm()
        {
            InitializeComponent();
            controller = new CustomerController();
            LoadCustomer();
        }

        public void LoadCustomer()
        {
            dgvCustomer.Rows.Clear();
            List<Customer> customers = controller.LoadCustomers();
            int i = 0;
            foreach (var customer in customers)
            {
                i++;
                dgvCustomer.Rows.Add(i, customer.Id, customer.Name, customer.Phone);
            }
        }

        private void btnAdd_Click_1(object sender, EventArgs e)
        {
            CustomerModuleForm moduleForm = new CustomerModuleForm();
            moduleForm.btnSave.Enabled = true;
            moduleForm.btnUpdate.Enabled = false;
            moduleForm.ShowDialog();
            LoadCustomer();
        }

        private void dgvCustomer_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dgvCustomer.Columns[e.ColumnIndex].Name;
            string id = dgvCustomer.Rows[e.RowIndex].Cells[1].Value.ToString();

            if (colName == "Edit")
            {
                CustomerModuleForm customerModule = new CustomerModuleForm();
                customerModule.lblCId.Text = id;
                customerModule.txtCName.Text = dgvCustomer.Rows[e.RowIndex].Cells[2].Value.ToString();
                customerModule.txtCPhone.Text = dgvCustomer.Rows[e.RowIndex].Cells[3].Value.ToString();

                customerModule.btnSave.Enabled = false;
                customerModule.btnUpdate.Enabled = true;
                customerModule.ShowDialog();
            }
            else if (colName == "Delete")
            {
                if (MessageBox.Show("Are you sure you want to delete this customer?", "Delete Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    controller.DeleteCustomer(id);
                    MessageBox.Show("Record has been successfully deleted!");
                }
            }

            LoadCustomer();
        }
    }
}
