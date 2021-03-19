using SomerenDAL;
using SomerenModel;
using System;
using System.Collections.Generic;

namespace SomerenLogic
{
    public class Product_Service
    {
        Product_DAO product_db = new Product_DAO();

        public List<Product> GetProducts()
        {
            try
            {
                List<Product> product = product_db.Db_Get_All_Products();
                return product;
            }
            catch (Exception)
            {
                // something went wrong connecting to the database, so we will add a fake student to the list to make sure the rest of the application continues working!
                List<Product> products = new List<Product>();
                /*
                Product a = new Product();
                a.Name = "Mr. Test Product";
                a.Number = 123456;
                products.Add(a);
                Product b = new Product();
                b.Name = "Mrs. Test Product";
                b.Number = 654321;
                products.Add(b);*/
                return products;
                //throw new Exception("Someren couldn't connect to the database");
            }
        }

        public void DeleteProduct(int id)
        {
            product_db.DB_Delete_Product(id);
        }

        public void AddProduct(Product product)
        {
            product_db.DB_Add_Product(product);
        }

        public void ModifyProduct(Product product)
        {
            product_db.DB_Modify_Product(product);
        }
    }
}
