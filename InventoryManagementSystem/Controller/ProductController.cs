using System.Data;
using System.Windows.Forms;
using InventoryManagementSystem.Models;

namespace InventoryManagementSystem.Controllers
{
    public class ProductController
    {
        private readonly ProductModel model;

        public ProductController()
        {
            model = new ProductModel();
        }

        public void LoadProducts(DataGridView dgv, string search)
        {
            DataTable dt = model.SearchProducts(search);
            dgv.Rows.Clear();
            int i = 0;
            foreach (DataRow row in dt.Rows)
            {
                i++;
                dgv.Rows.Add(i, row["pid"], row["pname"], row["pqty"], row["pprice"], row["pdescription"], row["pcategory"]);
            }
        }

        public void DeleteProduct(string pid)
        {
            model.DeleteProduct(pid);
        }
    }
}
