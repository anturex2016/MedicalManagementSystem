using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MedicalManagementApp.Common
{
    public partial class MainFrm : Form
    {
        categoryForm category = new categoryForm();
        companyForm company = new companyForm(); 
        productForm product= new productForm();
        PurchaseForm purchase=new PurchaseForm();
        SellForm sell=new SellForm();
        PurchaseReportForm purchaseReport = new PurchaseReportForm();
        SellReportForm sellReport=new SellReportForm();


        public MainFrm()
        {
            InitializeComponent();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void categoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(category.IsDisposed)
                category = new categoryForm();
            category.MdiParent = this;
            category.Show();
            category.BringToFront();

        }

        private void companyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(company.IsDisposed)
                company=new companyForm();
            company.MdiParent = this;
            company.Show();
            company.BringToFront();

        }

        private void productToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(product.IsDisposed)
                product=new productForm();
            product.MdiParent = this;
            product.Show();
            product.BringToFront();

        }

        private void purchaseToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (purchase.IsDisposed)
                purchase = new PurchaseForm();
            purchase.MdiParent = this;
            purchase.Show();
            purchase.BringToFront();
        }

        private void sellToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (sell.IsDisposed)
                sell=new SellForm();
            sell.MdiParent = this;
            sell.Show();
            sell.BringToFront();


        }

        private void purchaseReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(purchaseReport.IsDisposed)
                purchaseReport=new PurchaseReportForm();
            purchaseReport.MdiParent = this;
            purchaseReport.Show();
            purchaseReport.BringToFront();
        }

        private void sellReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (sellReport.IsDisposed)
                sellReport=new SellReportForm();
            sellReport.MdiParent = this;
            sellReport.Show();
            sellReport.BringToFront();

        }


       
    }
}
