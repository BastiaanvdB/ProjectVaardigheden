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
            string query = $"DELETE FROM Products WHERE product_id = @Id";
            SqlParameter[] sqlParameters =
            {
                new SqlParameter("@Id", SqlDbType.Int) { Value = id }
            };
            ExecuteEditQuery(query, sqlParameters);
        }

        public void DB_Modify_Product(Product product)
        {
            string query = $"UPDATE Products SET product_name=@Name, product_price=@Price, product_vatpercentage=@Vat, product_age=@Age, product_stock=@Stock, product_restocklevel=@Restock, product_sold=@Sold WHERE product_id = @Id";
            SqlParameter[] sqlParameters =
            {
                new SqlParameter("@Id", SqlDbType.Int) { Value = product.Id },
                new SqlParameter("@Name", SqlDbType.VarChar, 50) { Value = product.Name},
                new SqlParameter("@Price", SqlDbType.Money) { Value = product.Price},
                new SqlParameter("@Vat", SqlDbType.Decimal) { Value = product.VAT },
                new SqlParameter("@Age", SqlDbType.Bit) { Value = product.Age },
                new SqlParameter("@Stock", SqlDbType.Int) { Value = product.Stock },
                new SqlParameter("@Restock", SqlDbType.Int) { Value = product.Restocklevel },
                new SqlParameter("@Sold", SqlDbType.Int) { Value = product.Sold }
            };
            ExecuteEditQuery(query, sqlParameters);
        }
        
        public void DB_Add_Product(Product product)
        {
            string query = $"INSERT INTO Products (product_id, product_name, product_price, product_vatpercentage, product_age, product_stock, product_restocklevel, product_sold) VALUES (@Id, @Name, @Price, @Vat, @Age, @Stock, @Restock, @Sold)";
            SqlParameter[] sqlParameters =
            {
                new SqlParameter("@Id", SqlDbType.Int) { Value = product.Id },
                new SqlParameter("@Name", SqlDbType.VarChar, 50) { Value = product.Name},
                new SqlParameter("@Price", SqlDbType.Money) { Value = product.Price},
                new SqlParameter("@Vat", SqlDbType.Decimal) { Value = product.VAT },
                new SqlParameter("@Age", SqlDbType.Bit) { Value = product.Age },
                new SqlParameter("@Stock", SqlDbType.Int) { Value = product.Stock },
                new SqlParameter("@Restock", SqlDbType.Int) { Value = product.Restocklevel },
                new SqlParameter("@Sold", SqlDbType.Int) { Value = product.Sold }
            };
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
