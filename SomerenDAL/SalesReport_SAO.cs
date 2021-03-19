using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Collections.ObjectModel;
using SomerenModel;

namespace SomerenDAL
{
    public class SalesReport_DAO : Base
    {
      
        public List<Sale_Report> Db_Get_All_Sales()
        {

            string query = "SELECT  SUM(d.orderdetails_quantity) as Amount, COUNT(*) as Customers,o.order_datetime, d.orderdetails_quantity*p.product_price as TotalPrice, d.orderdetails_quantity, p.product_price FROM Orders AS o INNER JOIN Orderdetails AS d ON o.orderdetails_id = d.orderdetails_id INNER JOIN Products AS p ON d.product_id = p.product_id group by d.orderdetails_quantity, p.product_price, o.order_datetime";


            SqlParameter[] sqlParameters = new SqlParameter[0];
            return ReadTables(ExecuteSelectQuery(query, sqlParameters));
        }

        private List<Sale_Report> ReadTables(DataTable dataTable)
        {
            List<Sale_Report> SalesReportlist = new List<Sale_Report>();
            foreach (DataRow dr in dataTable.Rows)
            {


                Sale_Report sale = new Sale_Report()
                {
                    Sales = (int)dr["Amount"],
                    Customers = (int)dr["Customers"],
                    Revenue = (decimal)dr["TotalPrice"],
                    Date = (DateTime)dr["order_datetime"],

                
                

                };
                SalesReportlist.Add(sale);
            }
            return SalesReportlist;
        }
        public List<Sale_Report> Db_Get_Daterange(DateTime sD, DateTime eD)
        {
            string query = "SELECT  SUM(d.orderdetails_quantity) as Amount, COUNT(*) as Customers,o.order_datetime, d.orderdetails_quantity*p.product_price as TotalPrice, d.orderdetails_quantity, p.product_price FROM Orders AS o INNER JOIN Orderdetails AS d ON o.orderdetails_id = d.orderdetails_id INNER JOIN Products AS p ON d.product_id = p.product_id WHERE order_datetime  BETWEEN convert(datetime, '" + sD.Year + "/" + sD.Month + "/" + sD.Day + "') and convert(datetime, '" + eD.Year + "/" + eD.Month + "/" + eD.Day + "') group by d.orderdetails_quantity, p.product_price, o.order_datetime";
            SqlParameter[] sqlParameters = new SqlParameter[0];
            return ReadTables(ExecuteSelectQuery(query, sqlParameters));
        }


    }
}
