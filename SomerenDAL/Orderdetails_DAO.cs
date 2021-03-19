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
    public class Orderdetails_DAO : Base
    {
      
        public List<Orderdetails> Db_Get_All_Orderdetails()
        {
           
            string query = "SELECT o.orderdetails_id, o.orderdetails_quantity, o.product_id, p.product_price FROM Orderdetails AS o INNER JOIN Products AS p ON o.product_id = p.product_id";

            SqlParameter[] sqlParameters = new SqlParameter[0];
            return ReadTables(ExecuteSelectQuery(query, sqlParameters));
        }

        private List<Orderdetails> ReadTables(DataTable dataTable)
        {
            List<Orderdetails> Orderdetaillist = new List<Orderdetails>();
            foreach (DataRow dr in dataTable.Rows)
            {
                Orderdetails Orderdetails = new Orderdetails()
                {
                    Id = (int)dr["orderdetails_id"],
                    ProductId = (int)dr["orderdetails_id"],
                    Quantity = (int)dr["orderdetails_quantity"],
                    Amount = (int)dr["Amount"],

            };
                Orderdetaillist.Add(Orderdetails);
            }
            return Orderdetaillist;
        }


    }
}
