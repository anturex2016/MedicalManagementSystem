using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalManagementApp.Model
{
    class Sell
    {
        public int ProductId { get; set; }
        public int CompanyId { get; set; }
        public int SellId { get; set; }
        public decimal Quantity { get; set; }
        public decimal PerUnitCost { get; set; }
        public decimal TotalCost { get; set; }
        public DateTime Date { get; set; }

    }
}
