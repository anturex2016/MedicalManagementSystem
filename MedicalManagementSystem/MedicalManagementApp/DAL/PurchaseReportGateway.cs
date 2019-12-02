using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalManagementApp.DAL
{
    class PurchaseReportGateway : Gateway
    {
        public DataTable AllData()
        {
            Query = "Select Company.CompanyName, Storage.StorageID, Product.ProductName,Storage.Quantity,Storage.PerUnitCost,Storage.TotalCost,Storage.PurchaseDate from Storage inner join Product on Storage.ProductID=Product.ProductID  inner join Company on Product.CompanyID=Company.CompanyID";
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
