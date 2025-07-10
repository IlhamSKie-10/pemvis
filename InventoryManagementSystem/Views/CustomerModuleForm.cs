using InventoryManagementSystem.Controllers;
using System;
using System.Windows.Forms;

namespace InventoryManagementSystem
{
    public partial class CustomerModuleForm : Form
    {
        private readonly CustomerModuleController controller;

        public CustomerModuleForm()
        {
            InitializeComponent();
            controller = new CustomerModuleController();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Are you sure you want to save this customer?", "Saving Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    controller.SaveCustomer(txtCName.Text, txtCPhone.Text);
                    MessageBox.Show("User has been successfully saved.");
                    Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Are you sure you want to update this Customer?", "Update Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    controller.UpdateCustomer(lblCId.Text, txtCName.Text, txtCPhone.Text);
                    MessageBox.Show("Customer has been successfully updated!");
                    this.Dispose();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
            btnSave.Enabled = true;
            btnUpdate.Enabled = false;
        }

        private void pictureBoxClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        public void Clear()
        {
            txtCName.Clear();
            txtCPhone.Clear();
        }
    }
}
