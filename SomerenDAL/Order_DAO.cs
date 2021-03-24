using SomerenModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace SomerenDAL
{
    public class Order_DAO : Base
    {

        public void DB_Modify_OrderDetails(int prodQt, int prodId)
        {
            // DateTime orderDate = DateTime.Now;

            string query = $"INSERT INTO OrderDetails ( product_id, orderdetails_quantity) VALUES( {prodId}, {prodQt})";
            SqlParameter[] sqlParameters = new SqlParameter[0];
            ExecuteEditQuery(query, sqlParameters);
        }
        public void DB_Modify_Order(int studId)
        {
            DateTime orderDate = DateTime.Now;

            string query = $"INSERT INTO Orders ( student_id, voucher_id,  order_datetime, order_paystatus) VALUES({studId}, 1, convert(datetime, '{orderDate.Year}/{orderDate.Month}/{orderDate.Day}'), 0)";
            SqlParameter[] sqlParameters = new SqlParameter[0];
            ExecuteEditQuery(query, sqlParameters);
        }

        public void DB_Modify_OrderDetails_WithList(List<Product> pL)
        {
            //order by descending to make count easier
            var pLDupes = pL.GroupBy(x => x.Id).Select(x => new
            {
                Id = x.Key,
                Count = x.Count(),
            });

            foreach (var p in pLDupes)
            {
                string query = $"INSERT INTO OrderDetails ( order_id, product_id, orderdetails_quantity) SELECT MAX(o.order_id), ( {p.Id}), ({p.Count}) FROM Orders As o";
                SqlParameter[] sqlParameters = new SqlParameter[0];
                ExecuteEditQuery(query, sqlParameters);
            }
        }



    }
}
