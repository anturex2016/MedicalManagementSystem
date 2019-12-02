using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MedicalManagementApp.BLL;
using MedicalManagementApp.Model;

namespace MedicalManagementApp.Common
{
    public partial class categoryForm : Form
    {
        ErrorProvider ep= new ErrorProvider();
        CategoryManager categoryManager = new CategoryManager();
        public categoryForm()
        {
            InitializeComponent();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            Category category = new Category();
            category.CategoryName = nameTextBox.Text;
            if (nameTextBox.Text == "")
            {
                ep.SetError(nameTextBox,"Enter Category Name");
            }
            else
            {
                MessageBox.Show(categoryManager.SaveCategory(category));
                categoryForm_Load(null, null);
                nameTextBox.Text = "";
            }
        }

        private void categoryForm_Load(object sender, EventArgs e)
        {
            dataGridView.DataSource = categoryManager.AllData();
        }
    }
}
