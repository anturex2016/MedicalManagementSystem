using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MedicalManagementApp.DAL;

namespace MedicalManagementApp.BLL
{
    class SellReportManager
    {

        SellReportGatway sellReportGatway =new SellReportGatway();
        public DataTable AllData()
        {
            DataTable dataTable = sellReportGatway.AllData();
            return dataTable;
        }
    }
}
