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
    class CategoryManager
    {
        CategoryGateway categoryGateway = new CategoryGateway();


        public string SaveCategory(Category category)
        {
            Category aCategory = categoryGateway.IsExist(category);

            if (aCategory == null)
            {
                int rowAffected = categoryGateway.saveCategory(category);

                if (rowAffected>0)
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
                return "Category is duplicate";
            }
        }

        public DataTable AllData()
        {
            DataTable dataTable = categoryGateway.AllData();
            return dataTable;
        }

    }
}
