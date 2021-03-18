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
            string query = "SELECT product_id, product_name, product_price, product_vatpercentage, product_age, product_stock, product_restocklevel FROM Products";
            SqlParameter[] sqlParameters = new SqlParameter[0];
            return ReadTables(ExecuteSelectQuery(query, sqlParameters));
        }

        public void DB_Modify_Products()
        {

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
                };
                products.Add(product);
            }
            return products;
        }

    }
}
