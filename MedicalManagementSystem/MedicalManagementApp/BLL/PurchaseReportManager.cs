using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MedicalManagementApp.DAL;

namespace MedicalManagementApp.BLL
{
    class PurchaseReportManager
    {
        PurchaseReportGateway purchaseReportGateway =new PurchaseReportGateway();
        public DataTable AllData()
        {
            DataTable dataTable = purchaseReportGateway.AllData();
            return dataTable;
        }

    }
}
