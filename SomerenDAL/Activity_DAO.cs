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
            string query = $"UPDATE Activity SET activity_description=@description, activity_datetime_start=@starttime, activity_datetime_end=@endtime WHERE activity_id = @id";
            SqlParameter[] sqlParameters =
            {
                new SqlParameter("@id", SqlDbType.Int) { Value = activity.Id},
                new SqlParameter("@description", SqlDbType.VarChar, 255) { Value = activity.Description},
                new SqlParameter("@starttime", SqlDbType.DateTime) { Value = activity.StartTime},
                new SqlParameter("@endtime", SqlDbType.DateTime) { Value = activity.EndTime }
            };
            ExecuteEditQuery(query, sqlParameters);
        }

        public void DB_Add_Activity(Activity activity)
        {
            string query = $"INSERT INTO Activity (activity_description, activity_datetime_start, activity_datetime_end) VALUES (@description, @starttime, @endtime)";
            SqlParameter[] sqlParameters =
            {
                new SqlParameter("@description", SqlDbType.VarChar, 255) { Value = activity.Description},
                new SqlParameter("@starttime", SqlDbType.DateTime) { Value = activity.StartTime},
                new SqlParameter("@endtime", SqlDbType.DateTime) { Value = activity.EndTime }
            };
            ExecuteEditQuery(query, sqlParameters);
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
                    StartTime = (DateTime)dr["activity_datetime_start"],
                    EndTime = (DateTime)dr["activity_datetime_end"]
                };
                activities.Add(activity);
            }
            return activities;
        }
    }
}
