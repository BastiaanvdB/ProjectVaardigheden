using SomerenModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            string query = $"INSERT INTO Orders (   d.orderdetails_id ,student_id, voucher_id,  order_datetime, order_paystatus) SELECT MAX(d.orderdetails_id), ({studId}), (1) , convert(datetime, '{orderDate.Year}/{orderDate.Month}/{orderDate.Day}'), (0) FROM OrderDetails As d ";
            SqlParameter[] sqlParameters = new SqlParameter[0];
            ExecuteEditQuery(query, sqlParameters);
        }



    }
}
