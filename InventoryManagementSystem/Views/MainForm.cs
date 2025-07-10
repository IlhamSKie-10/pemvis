using InventoryManagementSystem.Controllers;
using System;
using System.Windows.Forms;

namespace InventoryManagementSystem
{
    public partial class MainForm : Form
    {
        private MainController mainController;

        public MainForm()
        {
            InitializeComponent();
            mainController = new MainController(panelMain);
        }

        private void btnUser_Click(object sender, EventArgs e)
        {
            mainController.OpenChildForm(new UserForm());
        }

        private void btnCustomer_Click(object sender, EventArgs e)
        {
            mainController.OpenChildForm(new CustomerForm());
        }

        private void btnCategory_Click(object sender, EventArgs e)
        {
            mainController.OpenChildForm(new CategoryForm());
        }

        private void btnProduct_Click(object sender, EventArgs e)
        {
            mainController.OpenChildForm(new ProductForm());
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            mainController.OpenChildForm(new OrderForm());
        }

        private void label3_Click(object sender, EventArgs e)
        {
            // Optional click handler
        }
    }
}
