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
    class ProductManager
    {
        ProductGateway productGateway =new ProductGateway();

        public string SaveProduct(Product product)
        {
            Product aProduct = productGateway.IsExist(product);

            if (aProduct == null)
            {
                int rowAffected = productGateway.SaveProduct(product);

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
                return "Product is duplicate";
            }
        }

        public DataTable AllProducts()
        {
            DataTable dataTable = productGateway.AllProducts();
            return dataTable;
        }


    }
}
