using System;
using System.Windows.Forms;

namespace InventoryManagementSystem.Controllers
{
    public class MainController
    {
        private Form activeForm = null;
        private Panel panelMain;

        public MainController(Panel panel)
        {
            panelMain = panel;
        }

        public void OpenChildForm(Form childForm)
        {
            if (activeForm != null)
                activeForm.Close();

            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelMain.Controls.Add(childForm);
            panelMain.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }
    }
}
