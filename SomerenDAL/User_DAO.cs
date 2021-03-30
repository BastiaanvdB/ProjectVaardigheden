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
            string query = "SELECT COUNT(user_id) AS 'user_auth' FROM Users WHERE user_username = @Username AND user_password = @Password";
            SqlParameter[] sqlParameters =
            {
                new SqlParameter("@Username", SqlDbType.NVarChar, 50) { Value = Username},
                new SqlParameter("@Password", SqlDbType.NVarChar, 50) { Value = Password}
            };

            return ReadUserAuth(ExecuteSelectQuery(query, sqlParameters));
        }

        public bool DB_License_Check(string License)
        {
            string query = "SELECT COUNT(license_key) AS 'license_auth' FROM License WHERE license_key = @License";
            SqlParameter[] sqlParameters =
            {
                new SqlParameter("@License", SqlDbType.NVarChar, 50) { Value = License}
            };

            return ReadLicenseAuth(ExecuteSelectQuery(query, sqlParameters));
        }

        public bool DB_Check_Already_Registrated(String Username)
        {
            string query = "SELECT COUNT(user_username) AS 'check_user' FROM Users WHERE user_username = @Username";
            SqlParameter[] sqlParameters =
            {
                new SqlParameter("@Username", SqlDbType.NVarChar, 50) { Value = Username}
            };

            return AlreadyRegistrated(ExecuteSelectQuery(query, sqlParameters));
        }

        public bool DB_Check_Admin_Status(string Username, string Password)
        {
            string query = "SELECT user_admin_status FROM Users WHERE user_username = @Username AND user_password = @Password";
            SqlParameter[] sqlParameters =
            {
                new SqlParameter("@Username", SqlDbType.NVarChar, 50) { Value = Username},
                new SqlParameter("@Password", SqlDbType.NVarChar, 50) { Value = Password}
            };

            return ReadAdminStatus(ExecuteSelectQuery(query, sqlParameters));
        }

        public bool DB_Register_User(User user)
        {
            string query = $"INSERT INTO Users (user_firstname, user_lastname, user_username, user_password, user_admin_status, license_key, user_secrect_question, user_secrect_answer) VALUES (@Firstname, @Lastname, @Username, @Password, @AdminStatus, @License, @SecrectQuestion, @SecrectAnswer)";
            SqlParameter[] sqlParameters =
            {
                new SqlParameter("@Firstname", SqlDbType.VarChar, 50) { Value = user.Firstname },
                new SqlParameter("@Lastname", SqlDbType.VarChar, 50) { Value = user.Lastname},
                new SqlParameter("@Username", SqlDbType.NVarChar, 50) { Value = user.Username},
                new SqlParameter("@Password", SqlDbType.NVarChar, 50) { Value = user.Password },
                new SqlParameter("@AdminStatus", SqlDbType.Bit) { Value = user.AdminStatus },
                new SqlParameter("@License", SqlDbType.NVarChar, 50) { Value = user.License},
                new SqlParameter("@SecrectQuestion", SqlDbType.NVarChar, 50) { Value = user.SecrectQuestion},
                new SqlParameter("@SecrectAnswer", SqlDbType.NVarChar, 50) { Value = user.SecretAnswer}
            };
            ExecuteEditQuery(query, sqlParameters);
            return Db_Login_Check_User(user.Username, user.Password);
        }

        public User DB_Get_User(string Username, string Password)
        {
            string query = "SELECT user_firstname, user_lastname, user_username, user_password, user_admin_status, license_key, user_secrect_question, user_secrect_answer FROM Users WHERE user_username = @Username AND user_password = @Password";
            SqlParameter[] sqlParameters =
            {
                new SqlParameter("@Username", SqlDbType.NVarChar, 50) { Value = Username},
                new SqlParameter("@Password", SqlDbType.NVarChar, 50) { Value = Password}
            };
            return ReadUser(ExecuteSelectQuery(query, sqlParameters));
        }

        private bool ReadAdminStatus(DataTable dataTable)
        {
            bool AdminStatus = false;
            foreach (DataRow dr in dataTable.Rows)
            {
                AdminStatus = (bool)dr["user_admin_status"];
            }
            return AdminStatus;
        }


        private bool AlreadyRegistrated(DataTable dataTable)
        {
            int username = 1;
            foreach (DataRow dr in dataTable.Rows)
            {
                username = (int)dr["check_user"];
            }
            return username != 0;
        }

        private User ReadUser(DataTable dataTable)
        {
            User user = null;
            foreach (DataRow dr in dataTable.Rows)
            {
                user = new User
                {
                    Firstname = (string)dr["user_firstname"],
                    Lastname = (string)dr["user_lastname"],
                    Username = (string)dr["user_username"],
                    Password = (string)dr["user_password"],
                    AdminStatus = (bool)dr["user_admin_status"],
                    License = (string)dr["license_key"],
                    SecrectQuestion = (string)dr["user_secrect_question"],
                    SecretAnswer = (string)dr["user_secrect_answer"]
                };
            }
            return user;
        }

        private bool ReadLicenseAuth(DataTable dataTable)
        {
            int auth = 0;
            foreach (DataRow dr in dataTable.Rows)
            {
                auth = (int)dr["license_auth"];
            }
            return auth != 0;
        }

        private bool ReadUserAuth(DataTable dataTable)
        {
            int auth = 1;
            foreach (DataRow dr in dataTable.Rows)
            {
                auth = (int)dr["user_auth"];
            }
            return auth != 0;
        }

    }
}