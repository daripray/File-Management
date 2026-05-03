using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Simple_GDI
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
            RegisterAllMenu(menuStrip1.Items);
        }
        void RegisterAllMenu(ToolStripItemCollection items)
        {
            foreach (ToolStripItem item in items)
            {
                if (item is ToolStripMenuItem menuItem)
                {
                    menuItem.Click += menuItem_Click;

                    if (menuItem.HasDropDownItems)
                        RegisterAllMenu(menuItem.DropDownItems);
                }
            }
        }
        private void menuItem_Click(object sender, EventArgs e)
        {
            var item = sender as ToolStripMenuItem;

            // if item is null return
            if (item == null)
                return;
            Console.WriteLine(item.Name + " is clicked");

            // when item clicked then make action with switch case
            switch (item.Name)
            {
                // when menu_1 is clicked, open menu_1 as MDI child and if it is already open then do not open it again
                case "menu_1":
                    // if menu_1 is already open, do not open it again
                    if (Application.OpenForms.OfType<Menu_1>().Count() > 0)
                    {
                        // if menu_1 is already open, print in console that it is already open and return
                        Console.WriteLine(item.Name + " is already open");
                        return;
                    }
                    // open menu_1 as MDI child
                    Menu_1 menu_1 = new Menu_1();
                    // set this form as MDI container
                    this.IsMdiContainer = true;
                    // set menu_1 as MDI child of this form
                    menu_1.MdiParent = this;
                    // show menu_1
                    menu_1.Show();
                    // print in console that menu_1 is opened
                    Console.WriteLine(item.Name + " is opened");
                    break;

                // when menu_2 is clicked, open menu_2 as MDI child and if it is already open then do not open it again
                case "menu_2":
                    if (Application.OpenForms.OfType<Menu_2>().Count() > 0)
                    {
                        Console.WriteLine(item.Name + " is already open");
                        return;
                    }
                    Menu_2 menu_2 = new Menu_2();
                    this.IsMdiContainer = true;
                    menu_2.MdiParent = this;
                    menu_2.Show();
                    Console.WriteLine(item.Name + " is opened");
                    break;

                // when close all menu item is clicked, close all MDI child forms
                case "closeAllToolStripMenuItem":
                    foreach (Form form in this.MdiChildren)
                    {
                        form.Close();
                    }
                    Console.WriteLine("All MDI child forms are closed");
                    break;

                // when exit menu item is clicked, show message box to confirm exit and if yes then close the application
                case "exitToolStripMenuItem":
                    if (MessageBox.Show("Are you sure you want to exit?", "Exit", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        Application.Exit();
                    break;

                default:
                    break;
            }
        }
    }
}
