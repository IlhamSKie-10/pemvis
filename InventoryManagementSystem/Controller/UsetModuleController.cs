using InventoryManagementSystem.Models;

namespace InventoryManagementSystem.Controllers
{
    public class UserModuleController
    {
        private readonly UserModel1 model = new UserModel1();

        public void SaveUser(string username, string fullname, string password, string phone)
        {
            model.InsertUser(username, fullname, password, phone);
        }

        public void UpdateUser(string username, string fullname, string password, string phone)
        {
            model.UpdateUser(username, fullname, password, phone);
        }
    }
}
