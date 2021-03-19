using SomerenDAL;
using SomerenModel;
using System;
using System.Collections.Generic;

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
                // something went wrong connecting to the database, so we will add a fake student to the list to make sure the rest of the application continues working!
                List<Sale_Report> SalesReports = new List<Sale_Report>();
                /*
                Sales a = new Sales();
                a.Name = "Mr. Test Sales";
                a.Number = 123456;
                Saless.Add(a);
                Sales b = new Sales();
                b.Name = "Mrs. Test Sales";
                b.Number = 654321;
                Saless.Add(b);*/
                return SalesReports;
                //throw new Exception("Someren couldn't connect to the database");
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
                // something went wrong connecting to the database, so we will add a fake student to the list to make sure the rest of the application continues working!
                List<Sale_Report> SalesReports = new List<Sale_Report>();
                /*
                Sales a = new Sales();
                a.Name = "Mr. Test Sales";
                a.Number = 123456;
                Saless.Add(a);
                Sales b = new Sales();
                b.Name = "Mrs. Test Sales";
                b.Number = 654321;
                Saless.Add(b);*/
                return SalesReports;
                //throw new Exception("Someren couldn't connect to the database");
            }
        }



        }
}
