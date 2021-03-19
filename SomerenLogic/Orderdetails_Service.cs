using SomerenDAL;
using SomerenModel;
using System;
using System.Collections.Generic;

namespace SomerenLogic
{
    public class Orderdetails_Service
    {
        Orderdetails_DAO Orderdetails_db = new Orderdetails_DAO();

        public List<Orderdetails> GetOrderdetails()
        {
            try
            {
                List<Orderdetails> Orderdetaillist = Orderdetails_db.Db_Get_All_Orderdetails();
                return Orderdetaillist;
            }
            catch (Exception)
            {
                // something went wrong connecting to the database, so we will add a fake student to the list to make sure the rest of the application continues working!
                List<Orderdetails> Orderdetaillist = new List<Orderdetails>();
                /*
                Sales a = new Sales();
                a.Name = "Mr. Test Sales";
                a.Number = 123456;
                Saless.Add(a);
                Sales b = new Sales();
                b.Name = "Mrs. Test Sales";
                b.Number = 654321;
                Saless.Add(b);*/
                return Orderdetaillist;
                //throw new Exception("Someren couldn't connect to the database");
            }
        }
        
    }
}
