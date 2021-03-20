using SomerenDAL;
using SomerenModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomerenLogic
{
    public class SalesReport_Service
    {
        SalesReport_DAO SalesReport_db = new SalesReport_DAO();

        public List<Sale_Report> GetSalesReports()
        {
            try
            {
                List<Sale_Report> SalesReportlist = SalesReport_db.Db_Get_All_Sales();
                return SalesReportlist;
            }
            catch (Exception)
            {
                List<Sale_Report> SalesReports = new List<Sale_Report>();
                return SalesReports;

            }
        }
        public List<Sale_Report> GetDrinksByDate(DateTime sD, DateTime eD)
        {
            try
            {
                List<Sale_Report> sales = SalesReport_db.Db_Get_Daterange(sD, eD);
                return sales;
            }
            catch (Exception)
            {
                List<Sale_Report> SalesReports = new List<Sale_Report>();

                return SalesReports;

            }
        }
    }
}
