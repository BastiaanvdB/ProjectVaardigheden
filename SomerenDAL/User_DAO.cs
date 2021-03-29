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
    public class User_DAO : Base
    {
        public bool Db_Login_Check_User(string Username, string Password)
        {
            string query = "SELECT COUNT(user_id) AS 'auth' FROM Users WHERE user_username = @Username AND user_password = @Password";
            SqlParameter[] sqlParameters =
            {
                new SqlParameter("@Username", SqlDbType.NVarChar, 50) { Value = Username},
                new SqlParameter("@Password", SqlDbType.NVarChar, 50) { Value = Password}
            };

            return ReadAuth(ExecuteSelectQuery(query, sqlParameters));
        }

        private bool ReadAuth(DataTable dataTable)
        {
            int auth = 0;
            foreach (DataRow dr in dataTable.Rows)
            {
                auth = (int)dr["auth"];

            }
            return auth != 0;
        }

    }
}