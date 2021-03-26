using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SomerenModel;
using SomerenDAL;

namespace SomerenLogic
{
    public class Activity_Service
    {
        Activity_DAO activity_DAO = new Activity_DAO();

        public List<Activity> GetActivities()
        {
            //try
            //{
                List<Activity> activitylist = activity_DAO.Db_Get_All_Activities();
                return activitylist;
            //}
            //catch (Exception)
            //{
            //    // something went wrong connecting to the database, so we will add a fake student to the list to make sure the rest of the application continues working!
            //    List<Product> products = new List<Product>();
            //    /*
            //    Product a = new Product();
            //    a.Name = "Mr. Test Product";
            //    a.Number = 123456;
            //    products.Add(a);
            //    Product b = new Product();
            //    b.Name = "Mrs. Test Product";
            //    b.Number = 654321;
            //    products.Add(b);*/
            //    //return products;
            //    //throw new Exception("Someren couldn't connect to the database");
            //}
        }

        //public void DeleteProduct(int id)
        //{
        //    product_db.DB_Delete_Product(id);
        //}

        //public void AddProduct(Product product)
        //{
        //    product_db.DB_Add_Product(product);
        //}

        //public void ModifyProduct(Product product)
        //{
        //    product_db.DB_Modify_Product(product);
        //}



    }
}
