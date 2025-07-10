using InventoryManagementSystem.Models;
using System.Collections.Generic;

namespace InventoryManagementSystem.Controllers
{
    public class CustomerController
    {
        private readonly CustomerModel model;

        public CustomerController()
        {
            model = new CustomerModel();
        }

        public List<Customer> LoadCustomers()
        {
            return model.GetAllCustomers();
        }

        public void DeleteCustomer(string id)
        {
            model.DeleteCustomer(id);
        }
    }
}
