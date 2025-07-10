using InventoryManagementSystem.Controllers;
using InventoryManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace InventoryManagementSystem
{
    public partial class CategoryForm : Form
    {
        private readonly CategoryController controller;

        public CategoryForm()
        {
            InitializeComponent();
            controller = new CategoryController();
            LoadCategory();
        }

        public void LoadCategory()
        {
            dgvCategory.Rows.Clear();
            List<Category> categories = controller.LoadCategories();
            int i = 0;
            foreach (var cat in categories)
            {
                i++;
                dgvCategory.Rows.Add(i, cat.Id, cat.Name);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            CategoryModuleForm formModule = new CategoryModuleForm();
            formModule.btnSave.Enabled = true;
            formModule.btnUpdate.Enabled = false;
            formModule.ShowDialog();
            LoadCategory();
        }

        private void dgvCategory_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dgvCategory.Columns[e.ColumnIndex].Name;
            string catId = dgvCategory.Rows[e.RowIndex].Cells[1].Value.ToString();

            if (colName == "Edit")
            {
                CategoryModuleForm formModule = new CategoryModuleForm();
                formModule.lblCatId.Text = catId;
                formModule.txtCatName.Text = dgvCategory.Rows[e.RowIndex].Cells[2].Value.ToString();
                formModule.btnSave.Enabled = false;
                formModule.btnUpdate.Enabled = true;
                formModule.ShowDialog();
            }
            else if (colName == "Delete")
            {
                if (MessageBox.Show("Are you sure you want to delete this category?", "Delete Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    controller.DeleteCategory(catId);
                    MessageBox.Show("Record has been successfully deleted!");
                }
            }
            LoadCategory();
        }
    }
}
