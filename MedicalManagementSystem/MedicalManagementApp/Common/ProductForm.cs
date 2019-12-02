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
    public partial class productForm : Form
    {
        ErrorProvider ep = new ErrorProvider();
        ProductManager productManager = new ProductManager();
        public productForm()
        {
            InitializeComponent();
        }
        
        private void productForm_Load(object sender, EventArgs e)
        {
            CategoryManager categoryManager = new CategoryManager();
            ComapnyManager comapnyManager = new ComapnyManager();

            categoryComboBox.DataSource = categoryManager.AllData();
            categoryComboBox.DisplayMember = "CategoryName";
            categoryComboBox.ValueMember = "CategoryID";
            categoryComboBox.SelectedValue=-1;


            companyComboBox.DataSource = comapnyManager.AllData();
            companyComboBox.DisplayMember = "CompanyName";
            companyComboBox.ValueMember = "CompanyID";
            companyComboBox.SelectedValue =-1;
            reorderTextBox.Text = "0";

        }

        private void saveButton_Click(object sender, EventArgs e)
        {

            Product product=new Product();
           
            product.ProductName = nameTextBox.Text;
            product.CategoryId = Convert.ToInt32(categoryComboBox.SelectedValue);
            product.CompanyId = Convert.ToInt32(companyComboBox.SelectedValue);
            product.ReorderLavel = Convert.ToInt32(reorderTextBox.Text);

            if (categoryComboBox.SelectedValue==null || categoryComboBox.SelectedValue.ToString()=="")
            {
                ep.SetError(categoryComboBox,"Select one");
            }
            if (companyComboBox.SelectedValue==null|| companyComboBox.SelectedValue.ToString()=="")
            {
                ep.SetError(companyComboBox,"Select one");
            }

            if (nameTextBox.Text == "")
            {
                ep.SetError(nameTextBox, "Enter Product Name");
            }

            if (reorderTextBox.Text==""|| reorderTextBox.Text=="0")
            {
                ep.SetError(reorderTextBox,"Enter ReorderLevel");
            }
            else
            {
                MessageBox.Show(productManager.SaveProduct(product));
                nameTextBox.Text = "";
                reorderTextBox.Text = "0";
                categoryComboBox.SelectedValue = -1;
                companyComboBox.SelectedValue = -1;
            }

            

        }

       
    }
}
