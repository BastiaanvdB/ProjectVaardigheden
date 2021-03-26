using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SomerenModel;
using SomerenDAL;

namespace SomerenLogic
{
    public class Activity_Service
    {
        Activity_DAO activity_DAO = new Activity_DAO();

        public List<Activity> GetActivities()
        {
            try
            {
                List<Activity> activitylist = activity_DAO.Db_Get_All_Activities();
                return activitylist;
            }
            catch (Exception)
            {
                // something went wrong connecting to the database, so we will add a fake student to the list to make sure the rest of the application continues working!
                List<Activity> activities = new List<Activity>();

                Activity a = new Activity();
                a.Id = 345;
                a.Description = "No connection - Test activity";
                a.StartTime = new DateTime(2022, 03, 22, 10, 30, 00);
                a.EndTime = new DateTime(2022, 03, 22, 12, 30, 00);
                activities.Add(a);
                return activities;
            }
}

        public void DeleteActivity(int id)
        {
            activity_DAO.DB_Delete_Activity(id);
        }

        public void AddActivity(Activity activity)
        {
            activity_DAO.DB_Add_Activity(activity);
        }

        public void ModifyActivity(Activity activity)
        {
            activity_DAO.DB_Modify_Activity(activity);
        }
    }
}
