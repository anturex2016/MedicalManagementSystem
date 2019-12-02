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
    public partial class companyForm : Form
    {
        ErrorProvider ep = new ErrorProvider();
        ComapnyManager comapnyManager =new ComapnyManager();
        public companyForm()
        {
            InitializeComponent();
        }

      

        private void saveButton_Click(object sender, EventArgs e)
        {
            Company company = new Company();
            company.CompanyName = nameTextBox.Text;
            if (nameTextBox.Text == "")
            {
                ep.SetError(nameTextBox, "Enter Company Name");
            }
            else
            {
                MessageBox.Show(comapnyManager.SaveCompany(company));
                companyForm_Load(null, null);
                nameTextBox.Text = "";
            }
        }

        private void companyForm_Load(object sender, EventArgs e)
        {
            dataGridView.DataSource = comapnyManager.AllData();
        }

        
    }
}
