using SomerenModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomerenDAL
{
    public class Schedule_DAO : Base
    {

        public List<Schedule> Db_Get_All_Schedules()
        {

            string query = "SELECT s.schedule_id, a.activity_id, su.activity_supervisor_id, t.teacher_name , a.activity_description, schedule_datestart, schedule_dateend from Schedule as s INNER JOIN Activity as a ON s.activity_id = a.activity_id INNER JOIN ActivitySupervisor as su ON s.activity_supervisor_id = su.activity_supervisor_id INNER JOIN Teacher as t on su.teacher_id = t.teacher_id ORDER BY s.schedule_dateend ASC";


            SqlParameter[] sqlParameters = new SqlParameter[0];
            return ReadTables(ExecuteSelectQuery(query, sqlParameters));
        }

        private List<Schedule> ReadTables(DataTable dataTable)
        {
            List<Schedule> scheduleList = new List<Schedule>();
            foreach (DataRow dr in dataTable.Rows)
            {


                Schedule sch = new Schedule()
                {
                    Id = (int)dr["schedule_id"],
                    ActivityId = (int)dr["activity_id"],
                    ActivitySupervisorName = (string)dr["teacher_name"],
                    ActivityDescription = (string)dr["activity_description"],
                    ActivitySupervisorId = (int)dr["activity_supervisor_id"],
                    Datestart = (DateTime)dr["schedule_datestart"],
                    Dateend = (DateTime)dr["schedule_dateend"],

                };
                scheduleList.Add(sch);
            }
            return scheduleList;
        }



    }
}
