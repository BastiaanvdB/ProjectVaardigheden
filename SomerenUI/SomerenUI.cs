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
                    pnl_Order.Hide();
                    pnl_Sales.Hide();


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
                    pnl_Order.Hide();
                    pnl_Sales.Hide();

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
                    pnl_Order.Hide();
                    pnl_Sales.Hide();

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
                    pnl_Order.Hide();
                    pnl_Sales.Hide();

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
                    pnl_Order.Hide();
                    pnl_Sales.Hide();

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

                        listViewBeverage.Items.Add(new ListViewItem(new string[] { $"{p.Id}", $"{p.Name}", $"€{p.Price.ToString("0.00")}",$"{p.VAT}%", $"{p.Stock}", $"{p.Restocklevel}", $"{p.Sold}", $"{alarm}" }));
                    }
                    break;

                case "Order":
                    // hide all other panels
                    pnl_Dashboard.Hide();
                    img_Dashboard.Hide();
                    pnl_Students.Hide();
                    pnl_Teachers.Hide();
                    pnl_Rooms.Hide();
                    pnl_Sales.Hide();

                    // show product panel
                    pnl_Order.Show();
                    ListViewOrder_Students.Items.Clear();
                    ListViewOrder_Products.Items.Clear();

                    // fill the students listview within the order panel with students
                    SomerenLogic.Student_Service studServ = new SomerenLogic.Student_Service();
                    List<Student> studList = studServ.GetStudents();
                    ListViewOrder_Students.View = View.Details;
                    foreach (SomerenModel.Student student in studList)
                    {
                        ListViewOrder_Students.Items.Add(new ListViewItem(new string[] { $"{student.Number}", $"{student.Name}", $"{student.BirthDate.ToString("dd/MM/yyyy")}" }));
                    }

                    // fill the product listview within the product panel with a list of products
                    SomerenLogic.Product_Service prodServ = new SomerenLogic.Product_Service();
                    List<Product> prodList = prodServ.GetProducts();
                    ListViewOrder_Products.View = View.Details;
                    foreach (SomerenModel.Product product in prodList)
                    {                      

                        ListViewOrder_Products.Items.Add(new ListViewItem(new string[] { $"{product.Id}", $"{product.Name}", $"€{product.Price.ToString("0.00")}", $"{product.VAT}%", $"{product.Stock}", $"{product.Sold}"}));
                    }
                    break;

                case "Sales":
                    // hide all other panels
                    pnl_Dashboard.Hide();
                    img_Dashboard.Hide();
                    pnl_Students.Hide();
                    pnl_Teachers.Hide();
                    pnl_Rooms.Hide();
                    pnl_Order.Hide();

                    // show product panel
                    pnl_Sales.Show();
                    order_listView.Items.Clear();

                    // fill the students listview within the order panel with students
                    SomerenLogic.Order_Service orderService = new SomerenLogic.Order_Service();
                    List<Order> orderList = orderService.GetOrders();

                    SomerenLogic.SalesReport_Service saleServ = new SomerenLogic.SalesReport_Service();
                    List<Sale_Report> salereportList = saleServ.GetSalesReports();

                    /*SomerenLogic.Orderdetails_Service orderdetailsService = new SomerenLogic.Orderdetails_Service();
                    List<Orderdetails> orderdList = orderdetailsService.GetOrderdetails();*/





                    order_listView.View = View.Details;

                    
                    foreach (SomerenModel.Sale_Report s in salereportList)
                    {
                    
                        order_listView.Items.Add(new ListViewItem(new string[] { $"{s.Sales}", $"{s.Revenue}", $"{s.Customers}", $"{s.Date.ToString("dd/MM/yyyy")}" }));
                       
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
            if(listViewBeverage.SelectedItems.Count > 0)
            {
                ListViewItem item = listViewBeverage.SelectedItems[0];
                IDTextBox.Text = item.SubItems[0].Text;
                NameTextbox.Text = item.SubItems[1].Text;
                PriceTextbox.Text = item.SubItems[2].Text.Replace("€", String.Empty);
                VATTextbox.Text = item.SubItems[3].Text.Replace("%", String.Empty);
                StockTextbox.Text = item.SubItems[4].Text;
                RestockLevelTextbox.Text = item.SubItems[5].Text;
                SoldTextbox.Text = item.SubItems[6].Text;
            }
            else
            {
                IDTextBox.Text = string.Empty;
                NameTextbox.Text = string.Empty;
                PriceTextbox.Text = string.Empty;
                VATTextbox.Text = string.Empty;
                StockTextbox.Text = string.Empty;
                RestockLevelTextbox.Text = string.Empty;
                SoldTextbox.Text = string.Empty;
            }
        }

        private void ProductModifyButton_Click(object sender, EventArgs e)
        {
            SomerenLogic.Product_Service product_Service = new Product_Service();


            // modify button pressed
            ListViewItem item = listViewBeverage.SelectedItems[0];
            if(item != null)
            {
                // Read textbox to listview
                item.SubItems[0].Text = IDTextBox.Text;
                item.SubItems[1].Text = NameTextbox.Text;
                item.SubItems[2].Text = "€" + PriceTextbox.Text;
                item.SubItems[3].Text = VATTextbox.Text + "%";
                item.SubItems[4].Text = StockTextbox.Text;
                item.SubItems[5].Text = RestockLevelTextbox.Text;
                item.SubItems[6].Text = SoldTextbox.Text;

                // create edited product
                Product product = new Product();
                product.Id = int.Parse(IDTextBox.Text);
                product.Name = NameTextbox.Text;
                product.Price = decimal.Parse(PriceTextbox.Text.Replace("€", String.Empty));
                product.VAT = int.Parse(VATTextbox.Text.Replace("%", String.Empty));
                product.Stock = int.Parse(StockTextbox.Text);
                product.Restocklevel = int.Parse(RestockLevelTextbox.Text);
                product.Sold = int.Parse(SoldTextbox.Text);

                // send edited product to database
                product_Service.ModifyProduct(product);
            }

        }

        private void orderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showPanel("Order");
        }

        private void omzetrapportageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showPanel("Sales");
        }

        private void btn_sales_Click(object sender, EventArgs e)
        {
            order_listView.Items.Clear();
            SomerenLogic.SalesReport_Service saleServ = new SomerenLogic.SalesReport_Service();
            DateTime CalendarFrom = Convert.ToDateTime(date_from.SelectionStart);
            DateTime CalendarTo = Convert.ToDateTime(date_to.SelectionStart);
            if (CalendarTo > CalendarFrom)
            {
  
                
                List<Sale_Report> saleReportList = saleServ.GetDrinksByDate(CalendarFrom, CalendarTo);



                //List<Sale_Report> salereportList = saleServ.GetSalesReports();

                order_listView.View = View.Details;


                foreach (SomerenModel.Sale_Report s in saleReportList)
                {

                    order_listView.Items.Add(new ListViewItem(new string[] { $"{s.Sales}", $"{s.Revenue}", $"{s.Customers}", $"{s.Date.ToString("dd/MM/yyyy")}" }));

                }
            }
            else
            {

                MessageBox.Show("The date has to be correct.");
            }


        }
    }
}
