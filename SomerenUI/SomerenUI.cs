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
            switch(panelName)
            {
                case "Dashboard":
                    // hide all other panels
                    pnl_Students.Hide();
                    pnl_Teachers.Hide();
                    pnl_Rooms.Hide();
                    pnl_Products.Hide();


                    // show dashboard
                    pnl_Dashboard.Show();
                    img_Dashboard.Show();
                    break;

                case "Students":
                    // hide all other panels
                    pnl_Dashboard.Hide();
                    img_Dashboard.Hide();
                    pnl_Teachers.Hide();
                    pnl_Rooms.Hide();
                    pnl_Products.Hide();

                    // show students panel
                    pnl_Students.Show();
                    listViewStudents.Items.Clear();

                    // fill the students listview within the students panel with a list of students
                    SomerenLogic.Student_Service studService = new SomerenLogic.Student_Service();
                    List<Student> studentList = studService.GetStudents();
                    listViewStudents.View = View.Details;
                    foreach (SomerenModel.Student student in studentList)
                    {
                        listViewStudents.Items.Add(new ListViewItem(new string[] { $"{student.Number}", $"{student.Name}", $"{student.BirthDate.ToString("dd/MM/yyyy")}" }));
                    }
                    break;

                case "Teachers":
                    // hide all other panels
                    pnl_Dashboard.Hide();
                    img_Dashboard.Hide();
                    pnl_Students.Hide();
                    pnl_Rooms.Hide();
                    pnl_Products.Hide();

                    // show teachers panel
                    pnl_Teachers.Show();
                    listViewTeachers.Items.Clear();

                    // fill the teachers listview within the teachers panel with a list of teachers
                    SomerenLogic.Teacher_Service teachService = new SomerenLogic.Teacher_Service();
                    List<Teacher> teacherList = teachService.GetTeachers();
                    listViewTeachers.View = View.Details;
                    foreach (SomerenModel.Teacher teacher in teacherList)
                    {
                        listViewTeachers.Items.Add(new ListViewItem(new string[] { $"{teacher.Number}", $"{teacher.Name}" }));
                    }
                    break;

                case "Rooms":
                    // hide all other panels
                    pnl_Dashboard.Hide();
                    img_Dashboard.Hide();
                    pnl_Students.Hide();
                    pnl_Teachers.Hide();
                    pnl_Products.Hide();

                    // show room panel
                    pnl_Rooms.Show();
                    listViewRooms.Items.Clear();

                    // fill the rooms listview within the rooms panel with a list of rooms
                    SomerenLogic.Rooms_Service roomService = new SomerenLogic.Rooms_Service();
                    List<Room> roomList = roomService.GetRooms();
                    listViewRooms.View = View.Details;
                    foreach (SomerenModel.Room r in roomList)
                    {
                        string type = "";
                        if (r.Type == true)
                        {
                            type = "Docentenkamer";
                        }
                        else
                        {
                            type = "Studentenkamer";
                        }
                        listViewRooms.Items.Add(new ListViewItem(new string[] { $"{r.Number}", $"{type}", $"{r.Capacity}" }));
                    }
                    break;

                case "Products":
                    // hide all other panels
                    pnl_Dashboard.Hide();
                    img_Dashboard.Hide();
                    pnl_Students.Hide();
                    pnl_Teachers.Hide();
                    pnl_Rooms.Hide();

                    // show product panel
                    pnl_Products.Show();
                    listViewBeverage.Items.Clear();

                    // fill the product listview within the product panel with a list of products
                    SomerenLogic.Product_Service productService = new SomerenLogic.Product_Service();
                    List<Product> productList = productService.GetProducts();
                    listViewBeverage.View = View.Details;
                    foreach (SomerenModel.Product p in productList)
                    {
                        string alarm = "FULL";
                        if (p.Stock < p.Restocklevel)
                        {
                            //test
                           alarm = "REFILL!";
                        }

                        listViewBeverage.Items.Add(new ListViewItem(new string[] { $"{p.Id}", $"{p.Name}", $"€{p.Price.ToString("0.00")}",$"{p.VAT}%", $"{p.Stock}", $"{p.Restocklevel}", $"{alarm}" }));
                    }
                    break;
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

        private void roomsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showPanel("Rooms");
        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void listViewTeachers_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void listViewRooms_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listViewStudents_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void beverageStripMenuItem1_Click(object sender, EventArgs e)
        {
            showPanel("Products");
        }

        private void listViewBeverage_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Select from listview
            var selectitem = listViewBeverage.SelectedItems;
            int sl = 0;
            sl = Convert.ToInt32(selectitem[0].Text);
            ListViewItem lvitem = listViewBeverage.FindItemWithText(Convert.ToString(sl));
            if (lvitem != null)
            {
                IDTextBox.Text = lvitem.SubItems[0].Text;
                NameTextbox.Text = lvitem.SubItems[1].Text;
                PriceTextbox.Text = lvitem.SubItems[2].Text.Replace("€", String.Empty);
                VATTextbox.Text = lvitem.SubItems[3].Text.Replace("%", String.Empty);
                StockTextbox.Text = lvitem.SubItems[4].Text;
                RestockLevelTextbox.Text = lvitem.SubItems[5].Text;
            }
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void ProductModifyButton_Click(object sender, EventArgs e)
        {

        }
    }
}
