using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SomerenModel;


namespace SomerenDAL
{
    public class ActivitySupervisor_DAO : Base
    {
        public List<ActivitySupervisor> Db_Get_All_ActivitySupervisors()
        {
            string query = "SELECT ActivitySupervisor.activity_supervisor_id, Teacher.teacher_id, Teacher.teacher_name, ActivitySupervisor.activity_id, Activity.activity_description FROM ActivitySupervisor INNER JOIN Teacher ON ActivitySupervisor.teacher_id = Teacher.teacher_id INNER JOIN Activity ON ActivitySupervisor.activity_id = Activity.activity_id";
            SqlParameter[] sqlParameters = new SqlParameter[0];
            return ReadTables(ExecuteSelectQuery(query, sqlParameters));
        }

        public void DB_Delete_ActivitySupervisors(int id)
        {
            string query = $"DELETE FROM ActivitySupervisor WHERE activity_supervisor_id = @Id";
            SqlParameter[] sqlParameters =
            {
                new SqlParameter("@Id", SqlDbType.Int) { Value = id }
            };
            ExecuteEditQuery(query, sqlParameters);
        }

        public void DB_Modify_ActivitySupervisors(ActivitySupervisor activitySupervisor)
        {
            string query = $"UPDATE ActivitySupervisor SET activity_id=@activityid, teacher_id=@teacherid WHERE activity_supervisor_id = @supervisorid";
            SqlParameter[] sqlParameters =
            {
                new SqlParameter("@supervisorid", SqlDbType.Int) { Value = activitySupervisor.SupervisorId},
                new SqlParameter("@activityid", SqlDbType.Int) { Value = activitySupervisor.ActivityId},
                new SqlParameter("@teacherid", SqlDbType.Int) { Value = activitySupervisor.TeacherId}
            };
            ExecuteEditQuery(query, sqlParameters);
        }

        public void DB_Add_ActivitySupervisors(int teacherId, int activityId)
        {
            string query = $"INSERT INTO ActivitySupervisor (activity_id, teacher_id) VALUES (@activityid, @teacherid)";
            SqlParameter[] sqlParameters =
            {
                new SqlParameter("@activityid", SqlDbType.Int) { Value = activityId},
                new SqlParameter("@teacherid", SqlDbType.Int) { Value = teacherId}
            };
            ExecuteEditQuery(query, sqlParameters);
        }

        private List<ActivitySupervisor> ReadTables(DataTable dataTable)
        {
            List<ActivitySupervisor> activitySupervisors = new List<ActivitySupervisor>();

            foreach (DataRow dr in dataTable.Rows)
            {
                ActivitySupervisor activitySupervisor = new ActivitySupervisor()
                {
                    SupervisorId = (int)dr["activity_supervisor_id"],
                    ActivityId = (int)dr["activity_id"],
                    ActivityName = (string)dr["activity_description"],
                    TeacherName = (string)dr["teacher_name"],
                    TeacherId = (int)dr["teacher_id"]
                };
                activitySupervisors.Add(activitySupervisor);
            }
            return activitySupervisors;
        }
    }
}
