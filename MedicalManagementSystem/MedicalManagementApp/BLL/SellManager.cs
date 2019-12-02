using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MedicalManagementApp.DAL;
using MedicalManagementApp.Model;

namespace MedicalManagementApp.BLL
{
    class SellManager
    {
        SellGetway sellGetway=new SellGetway();



        public string SaveSell(Sell sell)
        {
            decimal sellQuantity = sellGetway.IsExist(sell);

            if (sellQuantity>sell.Quantity ||sellQuantity==sell.Quantity)
            {
                int rowAffectedOfUpdatequantity = sellGetway.UpdateQuantity(sellQuantity,sell);
                int rowAffected =sellGetway.SaveSell(sell);

                if (rowAffected > 0 && rowAffectedOfUpdatequantity>0)
                {
                    return "Save Successful";
                }

                return "Save Failed";
            }
            else
            {
                return "Stock out of this product";
            }
        }

        public decimal TotalCost(Sell sell)
        {
            return sellGetway.TotalCost(sell);
        }



        ////public List<Company> GetCompany(int productId)
        ////{
        ////    return sellGetway.GetCompany(productId);

        ////}
    }
}
