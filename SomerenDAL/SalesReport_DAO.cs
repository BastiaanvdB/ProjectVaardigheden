using SomerenModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomerenDAL
{
    public class SalesReport_DAO : Base
    {

        public List<Sale_Report> Db_Get_All_Sales()
        {

            string query = "SELECT o.order_id, SUM(d.orderdetails_quantity) as Amount,COUNT(*) as Customers,SUM(d.orderdetails_quantity*p.product_price) as TotalPrice, MAX(o.order_datetime) as order_date FROM Orders AS o INNER JOIN OrderDetails AS d ON d.order_id = o.order_id INNER JOIN Products AS p ON d.product_id = p.product_id group by o.order_id";


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
                    OrderId = (int)dr["order_id"],
                    Sales = (int)dr["Amount"],
                    Customers = (int)dr["Customers"],
                    Revenue = (decimal)dr["TotalPrice"],
                    Date = (DateTime)dr["order_date"],

                };
                SalesReportlist.Add(sale);
            }
            return SalesReportlist;
        }
        public List<Sale_Report> Db_Get_Daterange(DateTime sD, DateTime eD)
        {
            
            string query = "SELECT o.order_id, SUM(d.orderdetails_quantity) as Amount,COUNT(*) as Customers,SUM(d.orderdetails_quantity * p.product_price) as TotalPrice, MAX(o.order_datetime) as order_date FROM Orders AS o INNER JOIN OrderDetails AS d ON d.order_id = o.order_id INNER JOIN Products AS p ON d.product_id = p.product_id  WHERE order_datetime  BETWEEN convert(datetime, '" + sD.Year + "/" + sD.Month + "/" + sD.Day + "') and convert(datetime, '" + eD.Year + "/" + eD.Month + "/" + eD.Day + "') group by o.order_id";
            SqlParameter[] sqlParameters = new SqlParameter[0];
            return ReadTables(ExecuteSelectQuery(query, sqlParameters));
        }


    }
}
