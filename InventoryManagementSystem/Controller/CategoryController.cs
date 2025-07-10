using InventoryManagementSystem.Models;
using System.Collections.Generic;

namespace InventoryManagementSystem.Controllers
{
    public class CategoryController
    {
        private readonly CategoryModel model;

        public CategoryController()
        {
            model = new CategoryModel();
        }

        public List<Category> LoadCategories()
        {
            return model.GetAllCategories();
        }

        public void DeleteCategory(string id)
        {
            model.DeleteCategory(id);
        }
    }
}
