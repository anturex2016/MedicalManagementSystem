using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalManagementApp.DAL
{
    class SellReportGatway:Gateway
    {
        public DataTable AllData()
        {
            Query = "Select Company.CompanyName,Product.ProductName,Sell.Quantity,Sell.PerUnitCost,Sell.TotalSellingCost,Sell.SellingDate from Sell inner join Product on Product.ProductID=Sell.ProductID inner join Company on Product.CompanyID=Company.CompanyID";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            DataSet dataSet = new DataSet();
            SqlDataAdapter dataAdapter = new SqlDataAdapter(Command);
            dataAdapter.Fill(dataSet);
            Connection.Close();
            DataTable table = dataSet.Tables[0];
            return table;
        }
    }
}
