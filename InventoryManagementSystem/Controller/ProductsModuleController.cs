using System;
using System.Collections.Generic;
using System.Windows.Forms;
using InventoryManagementSystem.Models;

namespace InventoryManagementSystem.Controllers
{
    public class ProductModuleController
    {
        private readonly ProductModel1 model = new ProductModel1();

        public void LoadCategories(ComboBox comboBox)
        {
            comboBox.Items.Clear();
            List<string> categories = model.LoadCategories();
            foreach (string cat in categories)
            {
                comboBox.Items.Add(cat);
            }
        }

        public void SaveProduct(string pname, string pqty, string pprice, string pdescription, string pcategory)
        {
            model.InsertProduct(pname, Convert.ToInt32(pqty), Convert.ToInt32(pprice), pdescription, pcategory);
        }

        public void UpdateProduct(string pid, string pname, string pqty, string pprice, string pdescription, string pcategory)
        {
            model.UpdateProduct(Convert.ToInt32(pid), pname, Convert.ToInt32(pqty), Convert.ToInt32(pprice), pdescription, pcategory);
        }
    }
}
