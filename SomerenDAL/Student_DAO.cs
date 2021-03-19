﻿using System;
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
    public class Student_DAO : Base
    {
      
        public List<Student> Db_Get_All_Students()
        {
            string query = "SELECT student_id, student_name, student_birthdate FROM Student";
            SqlParameter[] sqlParameters = new SqlParameter[0];
            return ReadTables(ExecuteSelectQuery(query, sqlParameters));
        }

        private List<Student> ReadTables(DataTable dataTable)
        {
            List<Student> students = new List<Student>();
            foreach (DataRow dr in dataTable.Rows)
            {
                Student student = new Student()
                {
                        
                    Name = (string)(dr["student_name"].ToString()),
                    BirthDate = (DateTime)dr["student_birthdate"]
                };
                students.Add(student);
            }
            return students;
        }

    }
}
