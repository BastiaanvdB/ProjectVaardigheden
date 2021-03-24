using SomerenDAL;
using SomerenModel;
using System;
using System.Collections.Generic;

namespace SomerenLogic
{
    public class Order_Service
    {
        Order_DAO order_db = new Order_DAO();

        public void Insert_OrderDetails(int prodQt, int prodId)
        {
            order_db.DB_Modify_OrderDetails(prodQt, prodId);
        }
        public void Insert_Order(int studId)
        {
            order_db.DB_Modify_Order(studId);
        }

        public void Insert_OrderDetails_WithList (List<Product> pL)
        {
            order_db.DB_Modify_OrderDetails_WithList(pL);
        }


    }
}
