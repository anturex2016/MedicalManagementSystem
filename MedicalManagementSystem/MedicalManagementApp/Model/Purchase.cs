using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalManagementApp.Model
{
    class Purchase
    {
        public int PurchaseId { get; set; }
        public int  ProductId { get; set; }
        public int CompanyId { get; set; }
        public decimal  Quantity { get; set; }
      
        public decimal PerUnitCost { get; set; }
        public decimal TotalCost { get; set; }
        public decimal AvalavbleQuantity { get; set; }
        public DateTime DateTime { get; set; }


    }
}
