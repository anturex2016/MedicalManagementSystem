using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MedicalManagementApp.DAL;
using MedicalManagementApp.Model;

namespace MedicalManagementApp.BLL
{
    class PurchaseManager
    {
        PurchaseGetway purchaseGetway = new PurchaseGetway();
       public string SavePurchase(Purchase purchase)
        {
            Purchase aPurchase = purchaseGetway.IsExist(purchase);

            if (aPurchase== null)
            {
                int rowAffected = purchaseGetway.SavePurchase(purchase);

                if (rowAffected > 0)
                {
                    return "Save Successful";
                }
                
                return "Save Failed";
            }
            else
            {
                int rowAffected = purchaseGetway.UpdatePurchase(purchase);

                if (rowAffected > 0)
                {
                    return "Update Successful";
                }
                return "Update Failed";
            }
        }
 

        public List<Product> GetProducs(int companyId)
        {
            return purchaseGetway.GetProducs(companyId);
        }

        public int GetReorderLevel(int productId)
        {

            return purchaseGetway.GetReorderLevel(productId);
        }
           

    }
}
