using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MedicalManagementApp.BLL;
using MedicalManagementApp.Model;

namespace MedicalManagementApp.DAL
{
    class ProductGateway : Gateway
    {
         string _erro;

        public int SaveProduct(Product product)
        {
            int rowCount = 0;
            Query = "INSERT INTO Product (CategoryId,CompanyID,ProductName,ReorderLevel) VALUES (@categoryId,@companyId,@productName,@reorderLevel)";
            Command = new SqlCommand(Query, Connection);
            Command.Parameters.Clear();
            Command.Parameters.AddWithValue("categoryId", product.CategoryId);
            Command.Parameters.AddWithValue("companyId", product.CompanyId);
            Command.Parameters.AddWithValue("productName", product.ProductName);
            Command.Parameters.AddWithValue("reorderLevel", product.ReorderLavel);
            Connection.Open();

            try
            {

                rowCount = Command.ExecuteNonQuery();

            }
            catch (Exception exception)
            {
                _erro = exception.Message;
            }
            finally
            {
                Connection.Close();
            }
            return rowCount;
        }

        public Product IsExist(Product product)
        {
            Query = "SELECT ProductName FROM Product WHERE ProductName=@name ";
            Command = new SqlCommand(Query, Connection);
            Command.Parameters.Clear();
            Command.Parameters.AddWithValue("name", product.ProductName);
            Connection.Open();
            Reader = Command.ExecuteReader();
            Product aProduct = null;
            while (Reader.Read())
            {
                aProduct= new Product();

                aProduct.ProductName = Reader["ProductName"].ToString();


            }
            Reader.Close();
            Connection.Close();
            return aProduct;
        }


        public DataTable AllProducts()
        {
            Query = "Select ProductID,ProductName From Product";
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
