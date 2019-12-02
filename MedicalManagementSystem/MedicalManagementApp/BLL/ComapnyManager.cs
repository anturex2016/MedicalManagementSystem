using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MedicalManagementApp.DAL;
using MedicalManagementApp.Model;

namespace MedicalManagementApp.BLL
{
    class ComapnyManager
    {
        CompanyGateway companyGateway = new CompanyGateway();


        public string SaveCompany(Company company)
        {
            Company aCompany = companyGateway.IsExist(company);

            if (aCompany == null)
            {
                int rowAffected = companyGateway.SaveCompany(company);

                if (rowAffected > 0)
                {
                    return "Save Successful";
                }
                else
                {
                    return "Save failed";
                }
            }
            else
            {
                return "Company is duplicate";
            }
        }

        public DataTable AllData()
        {
            DataTable dataTable = companyGateway.AllData();
            return dataTable;
        }

        //public DataTable Data()
        //{

        //    DataTable dataTable = companyGateway.Data();
        //    return dataTable;
        //}
    }
}
