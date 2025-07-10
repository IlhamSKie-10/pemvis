using System.Collections.Generic;
using System.Windows.Forms;
using InventoryManagementSystem.Models;

namespace InventoryManagementSystem.Controllers
{
    public class UserController
    {
        private readonly UserModel model = new UserModel();

        public void LoadUsers(DataGridView dgv)
        {
            dgv.Rows.Clear();
            var users = model.GetUsers();
            int i = 0;
            foreach (var user in users)
            {
                i++;
                dgv.Rows.Add(i, user[0], user[1], user[2], user[3]);
            }
        }

        public void DeleteUser(string username)
        {
            model.DeleteUser(username);
        }
    }
}
