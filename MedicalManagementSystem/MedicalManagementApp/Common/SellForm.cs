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
    public partial class SellForm : Form
    {

        ProductManager productManager=new ProductManager();
        SellManager sellManager=new SellManager();
        ErrorProvider ep = new ErrorProvider();
        public SellForm()
        {
            InitializeComponent();
        }

        private void SellForm_Load(object sender, EventArgs e)
        {
            productComboBox.DataSource = productManager.AllProducts();
            productComboBox.DisplayMember = "ProductName";
            productComboBox.ValueMember = "ProductID";
            productComboBox.SelectedValue = -1;

        }

        private void saveSell_Click(object sender, EventArgs e)
        {
            try
            {
                Sell sell= new Sell();
                sell.ProductId = Convert.ToInt32(productComboBox.SelectedValue.ToString());
                sell.Quantity = Convert.ToDecimal(quantityTextBox.Text);

                sell.PerUnitCost = Convert.ToDecimal(perUnitCostTextBox.Text);
                sell.TotalCost = sellManager.TotalCost(sell);
                
                sell.Date = Convert.ToDateTime(dateTimePicker.Text);
                string cost = sell.TotalCost.ToString();



                if (productComboBox.SelectedValue == null || productComboBox.SelectedValue.ToString() == "")
                {
                    ep.SetError(productComboBox, "Select one");
                }

                if (quantityTextBox.Text == "" || quantityTextBox.Text == "0")
                {
                    ep.SetError(quantityTextBox, "Enter Quantity");
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
                    MessageBox.Show(sellManager.SaveSell(sell));
                    quantityTextBox.Text = "";
                    //packetSizeTextBox.Text = "";
                    perUnitCostTextBox.Text = "";
                    dateTimePicker.Text = "";
                    totalCostLabel.Text =cost;
                    productComboBox.SelectedValue = -1;
                }


            }
            catch (Exception)
            {
                
            }
                        


        }

       
    }
}
