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

namespace MedicalManagementApp
{
    public partial class PurchaseForm : Form
    {
        ComapnyManager comapnyManager=new ComapnyManager();
        PurchaseManager purchaseManager=new PurchaseManager();
        ErrorProvider ep = new ErrorProvider();
        public PurchaseForm()
        {
            InitializeComponent();
        }

        private void companyComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int companyId = Convert.ToInt32(companyComboBox.SelectedValue.ToString());
                productComboBox.DataSource = purchaseManager.GetProducs(companyId);
                productComboBox.DisplayMember = "ProductName";
                productComboBox.ValueMember = "ProductID";
                productComboBox.SelectedValue = -1;
                reorderTextBox.Text = "";


            }
            catch (Exception)
            {

               

            }
           
        }

        private void PurchaseForm_Load(object sender, EventArgs e)
        {
            companyComboBox.DataSource = comapnyManager.AllData();
            companyComboBox.DisplayMember = "CompanyName";
            companyComboBox.ValueMember = "CompanyID";
            companyComboBox.SelectedValue = -1;
            productComboBox.SelectedValue = -1;
            reorderTextBox.Text = "";

        }

        private void saveButton_Click(object sender, EventArgs e)
        {

            try
            {
                Purchase purchase = new Purchase();
                purchase.ProductId = Convert.ToInt32(productComboBox.SelectedValue.ToString());
                purchase.Quantity = Convert.ToDecimal(QuantityTextBox.Text);
               
                purchase.PerUnitCost = Convert.ToDecimal(perUnitCostTextBox.Text);
                purchase.DateTime = Convert.ToDateTime(dateTimePicker.Text);


                if (companyComboBox.SelectedValue == null || companyComboBox.SelectedValue.ToString() == "")
                {
                    ep.SetError(companyComboBox, "Select one");
                }
                if (productComboBox.SelectedValue == null || productComboBox.SelectedValue.ToString() == "")
                {
                    ep.SetError(productComboBox, "Select one");
                }

                if (QuantityTextBox.Text == "" || QuantityTextBox.Text == "0")
                {
                    ep.SetError(QuantityTextBox, "Enter Quantity");
                }

                //if (packetSizeTextBox.Text == "" || packetSizeTextBox.Text == "0")
                //{
                //    ep.SetError(packetSizeTextBox, "Enter PacketSize");
                //}

                if (perUnitCostTextBox.Text == "" || perUnitCostTextBox.Text == "0")
                {
                    ep.SetError(perUnitCostTextBox, "Enter Per Unit Cost");
                }

                if (dateTimePicker.Text == "" || dateTimePicker.Text == "0")
                {
                    ep.SetError(dateTimePicker, "Enter date");
                }
                else
                {
                    MessageBox.Show(purchaseManager.SavePurchase(purchase));
                    QuantityTextBox.Text = "";
                    //packetSizeTextBox.Text = "";
                    perUnitCostTextBox.Text = "";
                    dateTimePicker.Text = "";

                    companyComboBox.SelectedValue = -1;
                    productComboBox.SelectedValue = -1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);                
            }
       
        }

        private void productComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int productId = Convert.ToInt32(productComboBox.SelectedValue.ToString());
                reorderTextBox.Text = Convert.ToString(purchaseManager.GetReorderLevel(productId));
            }
            catch (Exception)
            {
                
                
            }
          

        }
    }
}
