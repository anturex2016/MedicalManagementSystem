using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MedicalManagementApp.Model;

namespace MedicalManagementApp.DAL
{
    class CategoryGateway : Gateway
    {
         string erro;
        public int saveCategory(Category category)
        {
            int rowCount=0;
            Query = "INSERT INTO Category (CategoryName) VALUES (@categoryName)";
            Command = new SqlCommand(Query, Connection);
            Command.Parameters.Clear();
            Command.Parameters.AddWithValue("categoryName", category.CategoryName);
            Connection.Open();
            
            try
            {
                         
                rowCount = Command.ExecuteNonQuery();

            }
            catch (Exception exception)
            {
                erro = exception.Message;
            }
            finally
            {
                Connection.Close();
            }
            return rowCount;
        }


        public Category IsExist(Category category)
        {
            Query = "SELECT CategoryName FROM Category WHERE CategoryName=@name ";
            Command = new SqlCommand(Query, Connection);
            Command.Parameters.Clear();
            Command.Parameters.AddWithValue("name", category.CategoryName);
            Connection.Open();
            Reader = Command.ExecuteReader();
            Category aCategory = null;
            while (Reader.Read())
            {
                aCategory = new Category();
                
                aCategory.CategoryName = Reader["CategoryName"].ToString();


            }
            Reader.Close();
            Connection.Close();
            return aCategory;
        }



        public DataTable AllData()
        {
            Query = "Select CategoryID,CategoryName From Category";
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
