using System;
using System.Windows.Forms;
using InventoryManagementSystem.Models;

namespace InventoryManagementSystem.Controllers
{
    public class LoginController
    {
        private readonly Login userModel;

        public LoginController()
        {
            userModel = new Login();
        }

        public void Login(string username, string password, Form currentForm)
        {
            try
            {
                var reader = userModel.AuthenticateUser(username, password);
                if (reader.Read())
                {
                    MessageBox.Show("Welcome " + reader["fullname"].ToString() + " | ", "ACCESS GRANTED", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    reader.Close();
                    userModel.CloseConnection();
                    MainForm main = new MainForm();
                    currentForm.Hide();
                    main.ShowDialog();
                    currentForm.Close();
                }
                else
                {
                    reader.Close();
                    userModel.CloseConnection();
                    MessageBox.Show("Invalid username or password!", "ACCESS DENIED", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                userModel.CloseConnection();
                MessageBox.Show(ex.Message);
            }
        }
    }
}
