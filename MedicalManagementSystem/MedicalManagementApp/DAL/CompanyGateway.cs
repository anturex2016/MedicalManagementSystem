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
    class CompanyGateway : Gateway
    {
        string erro;
        public int SaveCompany(Company company)
        {
            int rowCount = 0;
            Query = "INSERT INTO Company (CompanyName) VALUES (@companyName)";
            Command = new SqlCommand(Query, Connection);
            Command.Parameters.Clear();
            Command.Parameters.AddWithValue("companyName", company.CompanyName);
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


        public Company IsExist(Company company)
        {
            Query = "SELECT CompanyName FROM Company WHERE CompanyName=@name ";
            Command = new SqlCommand(Query, Connection);
            Command.Parameters.Clear();
            Command.Parameters.AddWithValue("name", company.CompanyName);
            Connection.Open();
            Reader = Command.ExecuteReader();
            Company aCompany = null;
            while (Reader.Read())
            {
                aCompany = new Company();

                aCompany.CompanyName = Reader["CompanyName"].ToString();


            }
            Reader.Close();
            Connection.Close();
            return aCompany;
        }



        public DataTable AllData()
        {
            Query = "Select CompanyID,CompanyName From Company";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            DataSet dataSet = new DataSet();
            SqlDataAdapter dataAdapter = new SqlDataAdapter(Command);
            dataAdapter.Fill(dataSet);
            Connection.Close();
            DataTable table = dataSet.Tables[0];
            return table;
        }


        //public DataTable Data()
        //{
        //    Query = "Select CompanyID,CompanyName From Company";
        //    Command = new SqlCommand(Query, Connection);
        //    Connection.Open();
           
        //    SqlDataAdapter dataAdapter = new SqlDataAdapter(Command);
        //    DataTable table = new DataTable();
        //    dataAdapter.Fill(table);
        //    Connection.Close();
           
        //    return table;
        //}

      
    }
}
