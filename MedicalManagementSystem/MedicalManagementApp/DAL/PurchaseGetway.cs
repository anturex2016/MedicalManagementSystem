using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MedicalManagementApp.Model;

namespace MedicalManagementApp.DAL
{
    internal class PurchaseGetway : Gateway
    {
        private string _erro;

        public int SavePurchase(Purchase purchase)
        {
            int rowCount = 0;
            decimal totalcost = TotalCost(purchase);
            Query = "INSERT INTO Storage (ProductID,Quantity,PerUnitCost,TotalCost,PurchaseDate) VALUES (@productId,@quantity,@cost,@totalCost,@date)";
            Command = new SqlCommand(Query, Connection);
            Command.Parameters.Clear();
            Command.Parameters.AddWithValue("productId", purchase.ProductId);
            Command.Parameters.AddWithValue("quantity", purchase.Quantity);
            Command.Parameters.AddWithValue("cost", purchase.PerUnitCost);
            Command.Parameters.AddWithValue("totalCost", totalcost);
            Command.Parameters.AddWithValue("date", purchase.DateTime);
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




        public int UpdatePurchase(Purchase purchase)
        {
            int rowCount = 0;

            decimal quantyTotal = purchase.Quantity + TotalQuantity(purchase);
            decimal totalcost =TotalCost(purchase)+TotalCostOf(purchase);
            Query = "Update Storage set  Quantity=@quantity,PerUnitCost=@cost,TotalCost=@totalCost,PurchaseDate=@date  Where  ProductID=@productId ";
            Command = new SqlCommand(Query, Connection);
            Command.Parameters.Clear();
            Command.Parameters.AddWithValue("productId", purchase.ProductId);
            Command.Parameters.AddWithValue("quantity", quantyTotal);
            Command.Parameters.AddWithValue("cost", purchase.PerUnitCost);
            Command.Parameters.AddWithValue("totalCost", totalcost);
            Command.Parameters.AddWithValue("date", purchase.DateTime);
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




        public Purchase IsExist(Purchase purchase)
        {
            Query = "SELECT ProductID FROM Storage WHERE ProductID=@productId ";
            Command = new SqlCommand(Query, Connection);
            Command.Parameters.Clear();
            Command.Parameters.AddWithValue("productId", purchase.ProductId);
            Connection.Open();
            Reader = Command.ExecuteReader();
            Purchase aPurchase = null;
            while (Reader.Read())
            {
                aPurchase = new Purchase();

                aPurchase.ProductId = Convert.ToInt32(Reader["ProductID"]);


            }
            Reader.Close();
            Connection.Close();
            return aPurchase;
        }

        public List<Product> GetProducs(int companyId)
        {

            Query = "SELECT ProductID, ProductName FROM Product  Where CompanyID=@companyId";
            Command = new SqlCommand(Query, Connection);

            Command.Parameters.Clear();
            Command.Parameters.AddWithValue("companyId", companyId);
            Connection.Open();
            Reader = Command.ExecuteReader();
            List<Product> productList = new List<Product>();
            while (Reader.Read())
            {
                Product product = new Product();

                product.ProductId = (int) Reader["ProductID"];
                product.ProductName = Reader["ProductName"].ToString();

                productList.Add(product);


            }

            Reader.Close();
            Connection.Close();
            return productList;
        }

        private decimal TotalCost(Purchase purchase)
        {
            decimal totalCost =(purchase.Quantity ) * purchase.PerUnitCost;
            return totalCost;
        }


        public int GetReorderLevel(int productId)
        {

            Query = "SELECT ReorderLevel FROM Product  Where ProductID=@productId";
            Command = new SqlCommand(Query, Connection);

            Command.Parameters.Clear();
            Command.Parameters.AddWithValue("productId", productId);
            Connection.Open();
            Reader = Command.ExecuteReader();
            int code= 0;
            Product products = null;
            while (Reader.Read())
            {
                products = new Product();

                products.ReorderLavel = (int)Reader["ReorderLevel"];

                code = products.ReorderLavel;
            }

            Reader.Close();
            Connection.Close();

            return code;
        }


        public decimal TotalCostOf(Purchase purchase)
        {

            Query = "SELECT TotalCost FROM Storage  Where ProductID=@productId";
            Command = new SqlCommand(Query, Connection);

            Command.Parameters.Clear();
            Command.Parameters.AddWithValue("productId",purchase.ProductId);
            Connection.Open();
            Reader = Command.ExecuteReader();
            decimal code = 0;
            Purchase aPurchase = null;
            while (Reader.Read())
            {
                aPurchase = new Purchase();

                aPurchase.TotalCost = (decimal)Reader["TotalCost"];

                code = aPurchase.TotalCost;
            }

            Reader.Close();
            Connection.Close();

            return code;
        }

        public decimal TotalQuantity(Purchase purchase)
        {

            Query = "SELECT Quantity FROM Storage  Where ProductID=@productId";
            Command = new SqlCommand(Query, Connection);

            Command.Parameters.Clear();
            Command.Parameters.AddWithValue("productId", purchase.ProductId);
            Connection.Open();
            Reader = Command.ExecuteReader();
            decimal code = 0;
            Purchase aPurchase = null;
            while (Reader.Read())
            {
                aPurchase = new Purchase();

                aPurchase.Quantity = (decimal)Reader["Quantity"];

                code = aPurchase.Quantity;
            }

            Reader.Close();
            Connection.Close();

            return code;
        }


        }
    }

