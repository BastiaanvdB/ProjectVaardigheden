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
    public class Order_DAO : Base
    {
      
        public List<Order> Db_Get_All_Orders()
        {
           
            string query = "SELECT o.order_id, o.orderdetails_id, o.student_id, o.voucher_id, o.order_datetime, o.order_paystatus, s.student_name FROM Orders AS o INNER JOIN Student AS s ON o.student_id = s.student_id";


            SqlParameter[] sqlParameters = new SqlParameter[0];
            return ReadTables(ExecuteSelectQuery(query, sqlParameters));
        }

        private List<Order> ReadTables(DataTable dataTable)
        {
            List<Order> Orders = new List<Order>();
            foreach (DataRow dr in dataTable.Rows)
            {
                Student student = new Student()
                {
                    Name = (string)(dr["student_name"]),

                };


                Order Order = new Order()
                {
                    Id = (int)dr["order_id"],
                    OrderDetailsId = (int)dr["orderdetails_id"],
                    StudentId = (int)dr["student_id"],
                    VoucherId = (int)dr["voucher_id"],
                    Date = (DateTime)dr["order_datetime"],
                    PayStatus = (bool)dr["order_paystatus"],
                    Student = student,
                };
                Orders.Add(Order);
            }
            return Orders;
        }


    }
}
