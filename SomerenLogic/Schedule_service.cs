using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SomerenDAL;
using SomerenModel;

namespace SomerenLogic
{
    public class Schedule_Service
    {
        Schedule_DAO Schedule_db = new Schedule_DAO();

        public List<Schedule> GetSchedules()
        {
            try
            {
                List<Schedule> scheduleList = Schedule_db.Db_Get_All_Schedules();
                return scheduleList;
            }
            catch (Exception)
            {
                List<Schedule> scheduleList = new List<Schedule>();
                return scheduleList;

            }
        }

        public void SwapScheduleDates(ListViewItem s1, ListViewItem s2)
        {
            Schedule_db.DB_Modify_Swap_ScheduleDates(s1, s2);
        }

    }
}
