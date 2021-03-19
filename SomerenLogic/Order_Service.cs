using SomerenDAL;
using SomerenModel;
using System;
using System.Collections.Generic;

namespace SomerenLogic
{
    public class Order_Service
    {
        Order_DAO Order_db = new Order_DAO();
        Student_DAO student_db = new Student_DAO();

        public List<Order> GetOrders()
        {
            try
            {
                List<Order> Order = Order_db.Db_Get_All_Orders();
                List<Student> Students = student_db.Db_Get_All_Students();
                return Order;
            }
            catch (Exception)
            {
                // something went wrong connecting to the database, so we will add a fake student to the list to make sure the rest of the application continues working!
                List<Order> Orders = new List<Order>();
                /*
                Sales a = new Sales();
                a.Name = "Mr. Test Sales";
                a.Number = 123456;
                Saless.Add(a);
                Sales b = new Sales();
                b.Name = "Mrs. Test Sales";
                b.Number = 654321;
                Saless.Add(b);*/
                return Orders;
                //throw new Exception("Someren couldn't connect to the database");
            }
        }
        
    }
}
