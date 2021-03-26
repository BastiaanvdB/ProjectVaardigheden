using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SomerenDAL;
using SomerenModel;

namespace SomerenLogic
{
    public class ActivitySupervisor_Service
    {
        ActivitySupervisor_DAO activitySupervisor_DAO = new ActivitySupervisor_DAO();

        public List<ActivitySupervisor> GetActivitySupervisor()
        {
            try
            {
                List<ActivitySupervisor> activitySupervisors = activitySupervisor_DAO.Db_Get_All_ActivitySupervisors();
                return activitySupervisors;
            }
            catch (Exception)
            {
                // something went wrong connecting to the database, so we will add a fake student to the list to make sure the rest of the application continues working!
                List<ActivitySupervisor> activitySupervisors = new List<ActivitySupervisor>();

                ActivitySupervisor a = new ActivitySupervisor();
                a.SupervisorId = 999;
                a.ActivityId = 999;
                a.TeacherId = 999;
                activitySupervisors.Add(a);
                return activitySupervisors;
            }
}

        public void DeleteActivitySupervisory(int id)
        {
            activitySupervisor_DAO.DB_Delete_ActivitySupervisors(id);
        }

        public void AddActivitySupervisor(int teacherId, int activityId)
        {
            activitySupervisor_DAO.DB_Add_ActivitySupervisors(teacherId, activityId);
        }

        public void ModifyActivitySupervisor(ActivitySupervisor activitySupervisor)
        {
            activitySupervisor_DAO.DB_Modify_ActivitySupervisors(activitySupervisor);
        }
    }
}
