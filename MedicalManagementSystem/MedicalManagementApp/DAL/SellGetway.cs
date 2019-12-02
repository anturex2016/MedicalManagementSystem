using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MedicalManagementApp.Model;

namespace MedicalManagementApp.DAL
{
    class SellGetway:Gateway
    {
        private string _erro;

        public int SaveSell(Sell sell)
        {
            int rowCount = 0;
            
           
            Query = "INSERT INTO Sell (ProductID,Quantity,PerUnitCost,TotalSellingCost,SellingDate) VALUES (@productId,@quantity,@cost,@totalCost,@date)";
            Command = new SqlCommand(Query, Connection);
            Command.Parameters.Clear();
            Command.Parameters.AddWithValue("productId", sell.ProductId);
            Command.Parameters.AddWithValue("quantity", sell.Quantity);
            Command.Parameters.AddWithValue("cost", sell.PerUnitCost);
            Command.Parameters.AddWithValue("totalCost",sell.TotalCost);
            Command.Parameters.AddWithValue("date", sell.Date);
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




       public decimal TotalCost(Sell sell)
        {
            decimal totalCost =(sell.Quantity ) * sell.PerUnitCost;
            return totalCost;
        }


       public decimal IsExist(Sell sell)
       {
           Query = "SELECT Quantity FROM Storage  Where ProductID=@productId";
           Command = new SqlCommand(Query, Connection);

           Command.Parameters.Clear();
           Command.Parameters.AddWithValue("productId", sell.ProductId);
           Connection.Open();
           Reader = Command.ExecuteReader();
           decimal code = 0;
           Sell aSell = null;
           while (Reader.Read())
           {
               aSell = new Sell();

               aSell.Quantity = (decimal)Reader["Quantity"];

               code = aSell.Quantity;
           }

           Reader.Close();
           Connection.Close();

           return code;
       }



        public int UpdateQuantity(decimal quantity, Sell sell)
        {
            int rowCount=0;
            decimal totalQuantity =( quantity) - (sell.Quantity);
            
            Query = "Update Storage set  Quantity=@quantity Where  ProductID=@productId ";
            Command = new SqlCommand(Query, Connection);
            Command.Parameters.Clear();
            Command.Parameters.AddWithValue("productId", sell.ProductId);
            Command.Parameters.AddWithValue("quantity", totalQuantity);
          
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

  
    }
}
