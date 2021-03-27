using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SomerenModel;
using System.Windows.Forms;
namespace SomerenDAL
{
    public class Schedule_DAO : Base
    {

        public List<Schedule> Db_Get_All_Schedules()
        {
            string query_old = "SELECT  a.activity_id, ar.activity_supervisor_id, t.teacher_name , a.activity_description, a.activity_datetime_start, a.activity_datetime_end, t.teacher_id from Activity as a INNER JOIN ActivitySupervisor as ar ON a.activity_id = ar.activity_id INNER JOIN ActivityParticipant as ap ON a.activity_id = ap.activity_id INNER JOIN Teacher as t on ar.teacher_id = t.teacher_id INNER JOIN Student as s on ap.student_id = s.student_id ORDER BY a.activity_datetime_start ASC";
            string query = "SELECT  a.activity_id, ISNULL(STRING_AGG(t.teacher_name, ', '), 'null') as teacher_name ,COUNT(s.student_id) as students, MAX(a.activity_description) as activity_description, MAX(a.activity_datetime_start) as activity_datetime_start,MAX(a.activity_datetime_end) as activity_datetime_end from Activity as a LEFT JOIN ActivitySupervisor as ar ON a.activity_id = ar.activity_id LEFT JOIN ActivityParticipant as ap ON a.activity_id = ap.activity_id LEFT JOIN Teacher as t on ar.teacher_id = t.teacher_id LEFT JOIN Student as s on ap.student_id = s.student_id group by a.activity_id";


            SqlParameter[] sqlParameters = new SqlParameter[0];
            return ReadTables(ExecuteSelectQuery(query, sqlParameters));
        }
        public void DB_Modify_Swap_ScheduleDates(ListViewItem s1, ListViewItem s2)
        {

            int id1 = int.Parse(s1.SubItems[0].Text);
            DateTime ds1 = DateTime.Parse(s1.SubItems[4].Text);
            DateTime de1 = DateTime.Parse(s1.SubItems[5].Text);

            int id2 = int.Parse(s2.SubItems[0].Text);
            DateTime ds2 = DateTime.Parse(s2.SubItems[4].Text);
            DateTime de2 = DateTime.Parse(s2.SubItems[5].Text);

            Console.WriteLine(ds1.Day + ds1.Month + ds1.Year);

            string query = "UPDATE Activity SET activity_datetime_start = @datestart2, activity_datetime_end = @dateend2 WHERE activity_id = @id1";
            SqlParameter[] sqlParameters =
           {
                new SqlParameter("@Id1", SqlDbType.Int) { Value = id1 },
                new SqlParameter("@datestart2", SqlDbType.DateTime, 50) { Value = ds2},
                new SqlParameter("@dateend2", SqlDbType.DateTime, 50) { Value = de2},
            };

            ExecuteEditQuery(query, sqlParameters);

            string query2 = "UPDATE Activity SET activity_datetime_start = @datestart, activity_datetime_end = @dateend WHERE activity_id = @id2";
            SqlParameter[] sqlParameters2 =
           {
                new SqlParameter("@Id2", SqlDbType.Int) { Value = id2 },
                new SqlParameter("@datestart", SqlDbType.DateTime, 50) { Value = ds1},
                new SqlParameter("@dateend", SqlDbType.DateTime, 50) { Value = de1},
            };
            ExecuteEditQuery(query2, sqlParameters2);
        }

        private List<Schedule> ReadTables(DataTable dataTable)
        {
            List<Schedule> scheduleList = new List<Schedule>();
            foreach (DataRow dr in dataTable.Rows)
            {
                Schedule sch = new Schedule()
                {
                    Id = (int)dr["activity_id"],
                    ActivitySupervisorName = (string)dr["teacher_name"],
                    Students = (int)dr["students"],

                    ActivityDescription = (string)dr["activity_description"],
                    Datestart = (DateTime)dr["activity_datetime_start"],
                    Dateend = (DateTime)dr["activity_datetime_end"],


                };
                if (sch.ActivitySupervisorName == "null")
                {
                    sch.ActivitySupervisorName = "No Supervisor";
                }
                scheduleList.Add(sch);
            }
            return scheduleList;
        }



    }
}
