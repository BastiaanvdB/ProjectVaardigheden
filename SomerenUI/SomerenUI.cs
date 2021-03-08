using SomerenLogic;
using SomerenModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace SomerenUI
{
    public partial class SomerenUI : Form
    {
        public SomerenUI()
        {
            InitializeComponent();
            
        }

        private void SomerenUI_Load(object sender, EventArgs e)
        {
            showPanel("Dashboard");
        }

        private void showPanel(string panelName)
        {

            if(panelName == "Dashboard")
            {

                // hide all other panels
                pnl_Students.Hide();
                pnl_Teachers.Hide();

                // show dashboard
                pnl_Dashboard.Show();
                img_Dashboard.Show();
            }
            else if(panelName == "Students")
            {
                // hide all other panels
                pnl_Dashboard.Hide();
                img_Dashboard.Hide();
                pnl_Teachers.Hide();

                // show students
                pnl_Students.Show();

                listViewStudents.Items.Clear();


                // fill the students listview within the students panel with a list of students
                SomerenLogic.Student_Service studService = new SomerenLogic.Student_Service();
                List<Student> studentList = studService.GetStudents();
                listViewStudents.View = View.Details;
                foreach (var s in studentList)
                {
                    //listViewStudents.Items.Add(s.Name + s.Number + s.BirthDate);
                    listViewStudents.Items.Add(new ListViewItem(new string[] { $"{s.Number}", $"{s.Name}", $"{s.BirthDate}" }));
                    // Console.WriteLine(s.Name);
                }
              

                // clear the listview before filling it again
                //listViewStudents.Clear();

                /*foreach (SomerenModel.Student s in studentList)
                {

                    ListViewItem li = new ListViewItem(s.Name);
                    listViewStudents.Items.Add(li);
                }*/
              // listViewStudents.Clear();
            }
            else if (panelName == "Teachers")
            {
                // hide all other panels
                pnl_Dashboard.Hide();
                img_Dashboard.Hide();
                pnl_Students.Hide();
                // show teachers
                pnl_Teachers.Show();

                listViewTeachers.Items.Clear();
                listViewTeachers.Columns.Clear();
                listViewTeachers.Columns.Add("Number");
                listViewTeachers.Columns.Add("Name");


                // fill the students listview within the students panel with a list of students
                SomerenLogic.Teacher_Service teachService = new SomerenLogic.Teacher_Service();
                List<Teacher> teacherList = teachService.GetTeachers();

                // clear the listview before filling it again
                
                listViewTeachers.View = View.Details;
                foreach (SomerenModel.Teacher t in teacherList)
                {
                    listViewTeachers.Items.Add(new ListViewItem(new string[] { $"{t.Name}", $"{t.Number}"}));
                   // ListViewItem li = new ListViewItem(t.Name);
                    //listViewStudents.Items.Add(li);
                }
            }
        }

        private void dashboardToolStripMenuItem_Click(object sender, EventArgs e)
        {
           //
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void dashboardToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            showPanel("Dashboard");
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void img_Dashboard_Click(object sender, EventArgs e)
        {
            MessageBox.Show("What happens in Someren, stays in Someren!");
        }

        private void studentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showPanel("Students");
        }

        private void lecturersToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void teachersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showPanel("Teachers");
        }
    }
}
