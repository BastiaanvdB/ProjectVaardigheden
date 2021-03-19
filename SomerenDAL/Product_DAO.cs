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
    public class Product_DAO : Base
    {
      
        public List<Product> Db_Get_All_Products()
        {
            string query = "SELECT product_id, product_name, product_price, product_vatpercentage, product_age, product_stock, product_restocklevel, product_sold FROM Products";
            SqlParameter[] sqlParameters = new SqlParameter[0];
            return ReadTables(ExecuteSelectQuery(query, sqlParameters));
        }


        public void DB_Delete_Product(int id)
        {
            string query = $"DELETE FROM Products WHERE product_id = {id}";
            SqlParameter[] sqlParameters = new SqlParameter[0];
            ExecuteEditQuery(query, sqlParameters);
        }

        public void DB_Modify_Product(Product product)
        {
            int ageint = product.Age ? 1 : 0;
            string query = $"UPDATE Products SET product_name = '{product.Name}', product_price = {product.Price.ToString("0,00")}, product_vatpercentage = {product.VAT}, product_age = {ageint}, product_stock = {product.Stock}, product_restocklevel = {product.Restocklevel}, product_sold = {product.Sold} WHERE product_id = {product.Id}; ";
            SqlParameter[] sqlParameters = new SqlParameter[0];
            ExecuteEditQuery(query, sqlParameters);
        }
        
        public void DB_Add_Product(Product product)
        {
            int ageint = product.Age ? 1 : 0;
            string query = $"INSERT INTO Products (product_id, product_name, product_price, product_vatpercentage, product_age, product_stock, product_restocklevel, product_sold) VALUES ({product.Id}, '{product.Name}', {product.Price}, {product.VAT}, {ageint}, {product.Stock}, {product.Restocklevel}, {product.Sold})"; 
            SqlParameter[] sqlParameters = new SqlParameter[0];
            ExecuteEditQuery(query, sqlParameters);
        }

        private List<Product> ReadTables(DataTable dataTable)
        {
            List<Product> products = new List<Product>();

            foreach (DataRow dr in dataTable.Rows)
            {
                Product product = new Product()
                {
                    Id = (int)dr["product_id"],
                    Name = (String)(dr["product_name"].ToString()),
                    Price = (decimal)dr["product_price"],
                    VAT = (decimal)dr["product_vatpercentage"],
                    Age = (bool)dr["product_age"],
                    Stock = (int)dr["product_stock"],
                    Restocklevel = (int)dr["product_restocklevel"],
                    Sold = (int)dr["product_sold"]
                };
                products.Add(product);
            }
            return products;
        }

    }
}
