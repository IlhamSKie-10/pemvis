using InventoryManagementSystem.Controllers;
using System;
using System.Windows.Forms;

namespace InventoryManagementSystem
{
    public partial class LoginForm : Form
    {
        private readonly LoginController loginController;

        public LoginForm()
        {
            InitializeComponent();
            loginController = new LoginController();
        }

        private void checkBoxPass_CheckedChanged(object sender, EventArgs e)
        {
            txtPass.UseSystemPasswordChar = !checkBoxPass.Checked;
        }

        private void lblClear_Click(object sender, EventArgs e)
        {
            txtName.Clear();
            txtPass.Clear();
        }

        private void pictureBoxClose_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Exit Application", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            loginController.Login(txtName.Text, txtPass.Text, this);
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            // Optional
        }
    }
}
