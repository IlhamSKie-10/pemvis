using InventoryManagementSystem.Models;

namespace InventoryManagementSystem.Controllers
{
    public class CustomerModuleController
    {
        private readonly CustomerModel1 model;

        public CustomerModuleController()
        {
            model = new CustomerModel1();
        }

        public void SaveCustomer(string name, string phone)
        {
            model.InsertCustomer(name, phone);
        }

        public void UpdateCustomer(string id, string name, string phone)
        {
            model.UpdateCustomer(id, name, phone);
        }
    }
}
