using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SomerenModel;
using System.Data;
using System.Data.SqlClient;

namespace SomerenDAL
{
    public class Activity_DAO : Base
    {
        public List<Activity> Db_Get_All_Activities()
        {
            string query = "SELECT activity_id, activity_description, activity_datetime_start, activity_datetime_end FROM Activity";
            SqlParameter[] sqlParameters = new SqlParameter[0];
            return ReadTables(ExecuteSelectQuery(query, sqlParameters));
        }

        public void DB_Delete_Activity(int id)
        {
            string query = $"DELETE FROM Activity WHERE activity_id = @Id";
            SqlParameter[] sqlParameters =
            {
                new SqlParameter("@Id", SqlDbType.Int) { Value = id }
            };
            ExecuteEditQuery(query, sqlParameters);
        }

        public void DB_Modify_Activity(Activity activity)
        {
            //string query = $"UPDATE Products SET product_name=@Name, product_price=@Price, product_vatpercentage=@Vat, product_age=@Age, product_stock=@Stock, product_restocklevel=@Restock, product_sold=@Sold WHERE product_id = @Id";
            //SqlParameter[] sqlParameters =
            //{
            //    new SqlParameter("@Id", SqlDbType.Int) { Value = product.Id },
            //    new SqlParameter("@Name", SqlDbType.VarChar, 50) { Value = product.Name},
            //    new SqlParameter("@Price", SqlDbType.Money) { Value = product.Price},
            //    new SqlParameter("@Vat", SqlDbType.Decimal) { Value = product.VAT 
            //};
            //ExecuteEditQuery(query, sqlParameters);
        }

        public void DB_Add_Activity(Activity activity)
        {
            //string query = $"INSERT INTO Products (product_id, product_name, product_price, product_vatpercentage, product_age, product_stock, product_restocklevel, product_sold) VALUES (@Id, @Name, @Price, @Vat, @Age, @Stock, @Restock, @Sold)";
            //SqlParameter[] sqlParameters =
            //{
            //    new SqlParameter("@Id", SqlDbType.Int) { Value = product.Id },
            //    new SqlParameter("@Name", SqlDbType.VarChar, 50) { Value = product.Name},
            //    new SqlParameter("@Price", SqlDbType.Money) { Value = product.Price},
            //    new SqlParameter("@Vat", SqlDbType.Decimal) { Value = product.VAT }
            //};
            //ExecuteEditQuery(query, sqlParameters);
        }

        private List<Activity> ReadTables(DataTable dataTable)
        {
            List<Activity> activities = new List<Activity>();

            foreach (DataRow dr in dataTable.Rows)
            {
                Activity activity = new Activity()
                {
                    Id = (int)dr["activity_id"],
                    Description = (String)(dr["activity_description"].ToString()),
                    StartTime = (DateTime)dr["product_price"],
                    EndTime = (DateTime)dr["product_vatpercentage"]
                };
                activities.Add(activity);
            }
            return activities;
        }









    }
}
