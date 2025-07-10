using InventoryManagementSystem.Models;

namespace InventoryManagementSystem.Controllers
{
    public class CategoryModuleController
    {
        private readonly CategoryModel1 model;

        public CategoryModuleController()
        {
            model = new CategoryModel1();
        }

        public void SaveCategory(string name)
        {
            model.InsertCategory(name);
        }

        public void UpdateCategory(string id, string name)
        {
            model.UpdateCategory(id, name);
        }
    }
}
