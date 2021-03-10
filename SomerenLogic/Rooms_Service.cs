using SomerenDAL;
using SomerenModel;
using System;
using System.Collections.Generic;

namespace SomerenLogic
{
    public class Rooms_Service
    {
        Room_DAO room_db = new Room_DAO();

        public List<Room> GetRooms()
        {
            try
            {
                List<Room> room = room_db.Db_Get_All_Rooms();
                return room;
            }
            catch (Exception)
            {
                // something went wrong connecting to the database, so we will add a fake student to the list to make sure the rest of the application continues working!
                List<Room> rooms = new List<Room>();
                Room a = new Room();
                a.Number = 1;
                a.Type = true;
                a.Capacity = 6;
                rooms.Add(a);
                Room b = new Room();
                b.Number = 2;
                b.Type = false;
                b.Capacity = 4;
                rooms.Add(b);
                return rooms;
                //throw new Exception("Someren couldn't connect to the database");
            }

        }
    }
}
