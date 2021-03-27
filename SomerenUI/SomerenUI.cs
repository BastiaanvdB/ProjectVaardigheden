using SomerenLogic;
using SomerenModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
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
                    Pnl_Sales.Hide();
                    Pnl_Supervisors.Hide();
                    pnl_Schedule.Hide();
                    Pnl_Activity_List.Hide();


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
                    Pnl_Sales.Hide();
                    Pnl_Supervisors.Hide();
                    pnl_Schedule.Hide();
                    Pnl_Activity_List.Hide();


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
                case "Sales":
                    // hide all other panels
                    pnl_Dashboard.Hide();
                    img_Dashboard.Hide();
                    pnl_Students.Hide();
                    pnl_Teachers.Hide();
                    pnl_Rooms.Hide();
                    pnl_Order.Hide();
                    pnl_Products.Hide();
                    Pnl_Supervisors.Hide();
                    pnl_Schedule.Hide();
                    Pnl_Activity_List.Hide();


                    // show product panel
                    Pnl_Sales.Show();
                    order_listView.Items.Clear();

                    SomerenLogic.SalesReport_Service saleServ = new SomerenLogic.SalesReport_Service();
                    List<Sale_Report> salereportList = saleServ.GetSalesReports();

                    date_from.MaxDate = DateTime.Now;
                    date_to.MaxDate = DateTime.Now;

                    order_listView.View = View.Details;

                    foreach (SomerenModel.Sale_Report s in salereportList)
                    {

                        order_listView.Items.Add(new ListViewItem(new string[] { $"{s.OrderId}", $"{s.Sales}", $"{s.Revenue.ToString("0.00")}", $"{s.Customers}", $"{s.Date.ToString("dd/MM/yyyy")}" }));

                    }
                    break;
                case "Schedule":
                    // hide all other panels
                    pnl_Dashboard.Hide();
                    img_Dashboard.Hide();
                    pnl_Students.Hide();
                    pnl_Teachers.Hide();
                    pnl_Rooms.Hide();
                    pnl_Order.Hide();
                    pnl_Products.Hide();
                    Pnl_Sales.Hide();
                    Pnl_Supervisors.Hide();
                    Pnl_Activity_List.Hide();

                    // show product panel
                    pnl_Schedule.Show();
                    listViewDate1.Items.Clear();
                    listViewDate2.Items.Clear();
                    listView_Schedule.Items.Clear();

                    SomerenLogic.Schedule_Service scheduleServ = new SomerenLogic.Schedule_Service();
                    List<Schedule> scheduleList = scheduleServ.GetSchedules();

                    listViewDate1.View = View.Details;
                    listView_Schedule.View = View.Details;
                    foreach (SomerenModel.Schedule s in scheduleList)
                    {
                        if(s.TeacherId == null)
                        {
                            s.ActivitySupervisorName = "No Supervisor";
                        }
                        listView_Schedule.Items.Add(new ListViewItem(new string[] { $"{s.Id}", $"{s.ActivitySupervisorName}", $"{s.ActivityDescription}", $"{s.Datestart}", $"{s.Dateend}" }));

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
                    Pnl_Sales.Hide();
                    Pnl_Supervisors.Hide();
                    pnl_Schedule.Hide();
                    Pnl_Activity_List.Hide();

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
                    Pnl_Sales.Hide();
                    Pnl_Supervisors.Hide();
                    pnl_Schedule.Hide();
                    Pnl_Activity_List.Hide();

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
                    Pnl_Sales.Hide();
                    Pnl_Supervisors.Hide();
                    pnl_Schedule.Hide();
                    Pnl_Activity_List.Hide();

                    // show product panel
                    pnl_Products.Show();
                    listViewBeverage.Items.Clear();

                    // set pre selected button
                    ModifyRadioButton.Checked = true;

                    // fill the product listview within the product panel with a list of products
                    SomerenLogic.Product_Service productService = new SomerenLogic.Product_Service();
                    List<Product> productList = productService.GetProducts();
                    listViewBeverage.View = View.Details;
                    foreach (SomerenModel.Product p in productList)
                    {
                        string age = "<18";
                        string alarm = "FULL";
                        if (p.Stock < p.Restocklevel)
                        {
                            //test
                           alarm = "REFILL!";
                        }
                        if (p.Age == true)
                        {
                            age = ">18";
                        }

                        listViewBeverage.Items.Add(new ListViewItem(new string[] { $"{p.Id}", $"{p.Name}", $"€{p.Price.ToString("0.00")}", $"{age}", $"{p.VAT}%", $"{p.Stock}", $"{p.Restocklevel}", $"{p.Sold}", $"{alarm}" }));
                    }
                    break;

                case "Order":
                    // hide all other panels
                    pnl_Dashboard.Hide();
                    img_Dashboard.Hide();
                    pnl_Students.Hide();
                    pnl_Teachers.Hide();
                    pnl_Rooms.Hide();
                    pnl_Products.Hide();
                    Pnl_Sales.Hide();
                    Pnl_Supervisors.Hide();
                    pnl_Schedule.Hide();
                    Pnl_Activity_List.Hide();

                    // show product panel
                    pnl_Order.Show();
                    ListViewOrder_Students.Items.Clear();
                    ListViewOrder_Products.Items.Clear();
                    NewOrder();

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
                case "Supervisors":
                    // hide all other panels
                    pnl_Dashboard.Hide();
                    img_Dashboard.Hide();
                    pnl_Students.Hide();
                    pnl_Teachers.Hide();
                    pnl_Rooms.Hide();
                    pnl_Products.Hide();
                    Pnl_Sales.Hide();
                    pnl_Schedule.Hide();
                    pnl_Order.Hide();
                    Pnl_Activity_List.Hide();

                    // show product panel
                    Pnl_Supervisors.Show();

                    // fill lists
                    FillListsActivitySupervisor();
                    break;
                case "Activity_List":
                    // hide all other panels
                    pnl_Dashboard.Hide();
                    img_Dashboard.Hide();
                    pnl_Students.Hide();
                    pnl_Teachers.Hide();
                    pnl_Rooms.Hide();
                    pnl_Products.Hide();
                    Pnl_Sales.Hide();
                    pnl_Order.Hide();
                    Pnl_Supervisors.Hide();

                    // show product panel
                    Pnl_Activity_List.Show();

                    // fill lists
                    ActivityListStart();

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
                if(item.SubItems[3].Text == ">18")
                {
                    AgeLowerRadioButton.Checked = false;
                    AgeHigherRadioButton.Checked = true;
                }
                else
                {
                    AgeHigherRadioButton.Checked = false;
                    AgeLowerRadioButton.Checked = true;
                }
                VATTextbox.Text = item.SubItems[4].Text.Replace("%", String.Empty);
                StockTextbox.Text = item.SubItems[5].Text;
                RestockLevelTextbox.Text = item.SubItems[6].Text;
                SoldTextbox.Text = item.SubItems[7].Text;
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
            EditStorage(ProductModifyButton.Text);
        }

        private void EditStorage(string setting)
        {
            SomerenLogic.Product_Service product_Service = new Product_Service();
            
            switch (setting)
            {
                case "Delete":
                    ListViewItem item = listViewBeverage.SelectedItems[0];
                    if (item != null)
                    {
                        // Read textbox to int
                      //  int id = int.Parse(IDTextBox.Text);

                        // send delete command to database
                        product_Service.DeleteProduct(int.Parse(IDTextBox.Text));
                    }
                    break;
                case "Modify":
                    ListViewItem items = listViewBeverage.SelectedItems[0];
                    if (items != null)
                    {

                        // Read textbox to listview
                        items.SubItems[0].Text = IDTextBox.Text;
                        items.SubItems[1].Text = NameTextbox.Text;
                        items.SubItems[2].Text = "€" + PriceTextbox.Text;
                        if (AgeHigherRadioButton.Checked == true)
                        {
                            items.SubItems[3].Text = ">18";
                        }
                        else if (AgeLowerRadioButton.Checked == true)
                        {
                            items.SubItems[3].Text = "<18";
                        }
                        items.SubItems[4].Text = VATTextbox.Text + "%";
                        items.SubItems[5].Text = StockTextbox.Text;
                        items.SubItems[6].Text = RestockLevelTextbox.Text;
                        items.SubItems[7].Text = SoldTextbox.Text;

                        // create edited product
                        Product newproduct = new Product();
                        newproduct.Id = int.Parse(IDTextBox.Text);
                        newproduct.Name = NameTextbox.Text;
                        newproduct.Price = decimal.Parse(PriceTextbox.Text.Replace("€", String.Empty));
                        if(AgeHigherRadioButton.Checked == true)
                        {
                            newproduct.Age = true;
                        }
                        else if (AgeLowerRadioButton.Checked == true)
                        {
                            newproduct.Age = false;
                        }
                        newproduct.VAT = int.Parse(VATTextbox.Text.Replace("%", String.Empty));
                        newproduct.Stock = int.Parse(StockTextbox.Text);
                        newproduct.Restocklevel = int.Parse(RestockLevelTextbox.Text);
                        newproduct.Sold = int.Parse(SoldTextbox.Text);

                        // send edited product to database
                        product_Service.ModifyProduct(newproduct);
                    }
                        break;
                case "Add":
                    
                        // create edited product
                        Product product = new Product();
                        product.Id = int.Parse(IDTextBox.Text);
                        product.Name = NameTextbox.Text;
                        product.Price = decimal.Parse(PriceTextbox.Text.Replace("€", String.Empty));
                        product.VAT = int.Parse(VATTextbox.Text.Replace("%", String.Empty));
                        if(AgeHigherRadioButton.Checked == true)
                        {
                            product.Age = true;
                        }
                        else if(AgeLowerRadioButton.Checked == true)
                        {
                            product.Age = false;
                        }
                        product.Stock = int.Parse(StockTextbox.Text);
                        product.Restocklevel = int.Parse(RestockLevelTextbox.Text);
                        product.Sold = int.Parse(SoldTextbox.Text);

                        // send new product to database
                        product_Service.AddProduct(product);

                        listViewBeverage.View = View.Details;
                        
                        string age = "<18";
                        string alarm = "FULL";
                        if (product.Stock < product.Restocklevel)
                        {
                           alarm = "REFILL!";
                        }
                        if (product.Age == true)
                        {
                            age = ">18";
                        }
                        listViewBeverage.Items.Add(new ListViewItem(new string[] { $"{product.Id}", $"{product.Name}", $"€{product.Price}", $"{age}", $"{product.VAT}%", $"{product.Stock}", $"{product.Restocklevel}", $"{product.Sold}", $"{alarm}" }));
                        break;
            }

        }

        private void RadioButton(string button)
        {
            switch(button)
            {
                case "Add":
                    ProductModifyButton.Text = "Add";
                    IDTextBox.Enabled = true;
                    NameTextbox.Enabled = true;
                    PriceTextbox.Enabled = true;
                    VATTextbox.Enabled = true;
                    StockTextbox.Enabled = true;
                    RestockLevelTextbox.Enabled = true;
                    SoldTextbox.Enabled = true;
                    AgeHigherRadioButton.Enabled = true;
                    AgeLowerRadioButton.Enabled = true;
                    break;
                case "Modify":
                    ProductModifyButton.Text = "Modify";
                    IDTextBox.Enabled = false;
                    NameTextbox.Enabled = true;
                    PriceTextbox.Enabled = true;
                    VATTextbox.Enabled = true;
                    StockTextbox.Enabled = true;
                    RestockLevelTextbox.Enabled = true;
                    SoldTextbox.Enabled = true;
                    AgeHigherRadioButton.Enabled = true;
                    AgeLowerRadioButton.Enabled = true;
                    break;
                case "Delete":
                    ProductModifyButton.Text = "Delete";
                    IDTextBox.Enabled = true;
                    NameTextbox.Enabled = false;
                    PriceTextbox.Enabled = false;
                    VATTextbox.Enabled = false;
                    StockTextbox.Enabled = false;
                    RestockLevelTextbox.Enabled = false;
                    SoldTextbox.Enabled = false;
                    AgeHigherRadioButton.Enabled = false;
                    AgeLowerRadioButton.Enabled = false;
                    break;
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton("Add");
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton("Modify");
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton("Delete");
        }

        private void ListViewOrder_Students_SelectedIndexChanged(object sender, EventArgs e)
        {            
            //If a student is selected it will show in the 'For:' textbox

            if (ListViewOrder_Students.SelectedItems.Count > 0)
            {
                ListViewItem item = ListViewOrder_Students.SelectedItems[0];
                TextBoxStudentName.Text = item.SubItems[1].Text;
            }
            else
            {
                TextBoxStudentName.Text = string.Empty;
            }
        }

        private void btn_Add_Product_Click(object sender, EventArgs e)
        {
            OrderMenu("Add");
        }

        private void btn_Remove_Product_Click(object sender, EventArgs e)
        {
            OrderMenu("Remove");
        }

        private Product AddProductOrder()
        {

            ListViewItem item = ListViewOrder_Products.SelectedItems[0];
            Product product = new Product()
            {
                Id = int.Parse(item.SubItems[0].Text),
                Name = item.SubItems[1].Text,
                Price = decimal.Parse(item.SubItems[2].Text.Replace("€", String.Empty)),
                VAT = decimal.Parse(item.SubItems[3].Text.Replace("%", String.Empty)),
            };

            return product;
        }

        private void NewOrder()
        {
            OrderMenu("New");
        }
        private List<Product> orderlist;
        private void OrderMenu(string ordersetting)
        {
            switch (ordersetting)
            {
                case "Add":
                    Product product = new Product();
                    product = AddProductOrder();
                    this.orderlist.Add(product);
                    Orderlist();
                    break;
                case "New":
                    this.orderlist = new List<Product>();
                    ListViewTotalOrder_Details.Items.Clear();
                    lbl_Total_Price_Value.Text = "0,00";
                    VATDisplayLBL.Text = "0,00";
                    break;
                case "Remove":
                    RemoveFromOrderlist();
                    break;
                case "Purchase":
                    PurchaseOrder(this.orderlist);
                    NewOrder();
                    break;
            }
        }

        private void PurchaseOrder(List<Product> pL)
        {
            // send order to database
            
            ListViewItem stuItem = ListViewOrder_Students.SelectedItems[0];
            ListViewItem proItem = ListViewOrder_Products.SelectedItems[0];
            //order parameters
            int sNr = int.Parse(stuItem.SubItems[0].Text);
            int prodId = int.Parse(proItem.SubItems[0].Text);
            int orderQuantity = pL.Count();
            SomerenLogic.Order_Service orderServ = new SomerenLogic.Order_Service();

            //order insert
            orderServ.Insert_Order(sNr);

           orderServ.Insert_OrderDetails_WithList(pL);
        }

        private void RemoveFromOrderlist()
        {
            int index = ListViewTotalOrder_Details.SelectedIndices[0];
            orderlist.RemoveAt(index);
            Orderlist();
        }

        private void Orderlist()
        {
            ListViewTotalOrder_Details.Items.Clear();
            decimal totalprice = 0;
            decimal totalvat = 0;
            foreach (Product product in orderlist)
            {
                ListViewTotalOrder_Details.Items.Add(new ListViewItem(new string[] { $"{product.Name}", $"{product.VAT}%", $"€{product.Price}" }));
                totalvat += (product.Price / 100) * product.VAT;
                totalprice += product.Price;
            }
            VATDisplayLBL.Text = totalvat.ToString("0.00");
            lbl_Total_Price_Value.Text = (totalvat + totalprice).ToString("0.00");
        }

        private void btn_Purchase_Order_Click(object sender, EventArgs e)
        {
            OrderMenu("Purchase");
        }

        private void orderToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            showPanel("Order");
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

               // order_listView.View = View.Details;


                foreach (SomerenModel.Sale_Report s in saleReportList)
                {

                    order_listView.Items.Add(new ListViewItem(new string[] { $"{s.OrderId}", $"{s.Sales}", $"{s.Revenue}", $"{s.Customers}", $"{s.Date.ToString("dd/MM/yyyy")}" }));

                }
            }
            else
            {

                MessageBox.Show("The date has to be correct.");
            }
        }

        private void salesReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showPanel("Sales");
        }

        private void ActivitySupervisorMenu(string settingmenu)
        {
            switch(settingmenu)
            {
                case "Refresh":
                    FillListsActivitySupervisor();
                    break;
                case "Add":
                    AddToSupervisor();
                    break;
                case "Remove":
                    RemoveSupervisor();
                    break;
            }
        }

        private void FillListsActivitySupervisor()
        {
            // clear and fill the teachers listview within the teachers panel with a list of teachers
            TeacherActivityListView.Items.Clear();
            SomerenLogic.Teacher_Service teachService = new SomerenLogic.Teacher_Service();
            List<Teacher> teacherList = teachService.GetTeachers();
            TeacherActivityListView.View = View.Details;
            foreach (SomerenModel.Teacher teacher in teacherList)
            {
                TeacherActivityListView.Items.Add(new ListViewItem(new string[] { $"{teacher.Number}", $"{teacher.Name}" }));
            }
            TeacherActivityListView.Items[0].Selected = true;
            TeacherActivityListView.Items[0].Focused = true;


            // clear and fill the supervisor listview within the supervisors panel with a list of supervisors
            SupervisorListview.Items.Clear();
            SomerenLogic.ActivitySupervisor_Service supervisor_Service = new SomerenLogic.ActivitySupervisor_Service();
            List<ActivitySupervisor> activitySupervisors = supervisor_Service.GetActivitySupervisor();
            SupervisorListview.View = View.Details;
            foreach (SomerenModel.ActivitySupervisor supervisor in activitySupervisors)
            {
                SupervisorListview.Items.Add(new ListViewItem(new string[] { $"{supervisor.SupervisorId}", $"{supervisor.TeacherId}", $"{supervisor.TeacherName}", $"{supervisor.ActivityId}", $"{supervisor.ActivityName}" }));
            }
            //SupervisorListview.Items[0].Selected = true;
            //SupervisorListview.Items[0].Focused = true;

            // Fill combobox with activities
            FillActivityCombobox();
        }

        private void FillActivityCombobox()
        {
            SomerenLogic.Activity_Service activity_Service = new Activity_Service();
            List<Activity> activities = activity_Service.GetActivities();
            ActivityComboBox.Items.Clear();
            foreach (Activity activity in activities)
            {
                ActivityComboBox.Items.Add(activity.Description);
            }
            ActivityComboBox.SelectedIndex = 0;
        }

        private int ActivityComboBoxSelect()
        {
            SomerenLogic.Activity_Service activity_Service = new Activity_Service();
            List<Activity> activities = activity_Service.GetActivities();
            return (activities[ActivityComboBox.SelectedIndex].Id);
        }

        private void RemoveSupervisor()
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete a supervisor?", "Removing Supervisor", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                SomerenLogic.ActivitySupervisor_Service activitySupervisor_Service = new ActivitySupervisor_Service();
                List<ActivitySupervisor> activitySupervisors = activitySupervisor_Service.GetActivitySupervisor();
                int index = SupervisorListview.SelectedIndices[0];
                activitySupervisor_Service.DeleteActivitySupervisory(activitySupervisors[index].SupervisorId);
                ActivitySupervisorMenu("Refresh");
            }
            else if (dialogResult == DialogResult.No)
            {

            }
        }

        private void AddToSupervisor()
        {
            SomerenLogic.ActivitySupervisor_Service activitySupervisor_Service = new ActivitySupervisor_Service();
            SomerenLogic.Teacher_Service teacher_Service = new Teacher_Service();
            List<Teacher> teacherlist = teacher_Service.GetTeachers();
            int activityId = ActivityComboBoxSelect();
            int teacherindex = TeacherActivityListView.SelectedIndices[0];
            activitySupervisor_Service.AddActivitySupervisor(teacherlist[teacherindex].Number, activityId);
            ActivitySupervisorMenu("Refresh");
        }

        private void AddSupervisorbtn_Click(object sender, EventArgs e)
        {
            ActivitySupervisorMenu("Add");
        }

        private void RemoveSupervisorbtn_Click(object sender, EventArgs e)
        {
            ActivitySupervisorMenu("Remove");
        }

        private void RefreshListbtn_Click(object sender, EventArgs e)
        {
            ActivitySupervisorMenu("Refresh");
        }

        private void supervisorsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showPanel("Supervisors");
        }

        private void scheduleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showPanel("Schedule");
        }

        private void listview_Schedule_ItemDrag(object sender, ItemDragEventArgs e)
        {

            // create array or collection for all selected items

            // pass the items to move...
            listView_Schedule.DoDragDrop(e.Item, DragDropEffects.Move);

        }
        private void listView_Schedule_MouseMove(object sender, MouseEventArgs e)
        {

        }

        private void listView_Schedule_DragDrop(object sender, DragEventArgs e)
        {
            if (listViewDate1.Items.Count == 0)
            {
                var items = (ListViewItem)e.Data.GetData(typeof(ListViewItem));
                // LVI obj can only belong to one LVI, remove
                listView_Schedule.Items.Remove(items);
                listViewDate1.Items.Add(items);
            }
            else
            {
                MessageBox.Show("Only 1 item can be added in the dragdrop");
            }
        }

        private void listViewDate1_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        private void listViewDate1_DragOver(object sender, DragEventArgs e)
        {

            e.Effect = DragDropEffects.Move;

        }

        private void listViewDate2_DragDrop(object sender, DragEventArgs e)
        {
            if (listViewDate2.Items.Count == 0)
            {
                var items = (ListViewItem)e.Data.GetData(typeof(ListViewItem));
                // LVI obj can only belong to one LVI, remove
                listView_Schedule.Items.Remove(items);
                listViewDate2.Items.Add(items);
            }
            else
            {
                MessageBox.Show("Only 1 item can be added in the dragdrop");
            }
        }

        private void btn_swapSchedule_Click(object sender, EventArgs e)
        {
            ListViewItem i1 = listViewDate1.Items[0];
            ListViewItem i2 = listViewDate2.Items[0];
            SomerenLogic.Schedule_Service scheduleServ = new SomerenLogic.Schedule_Service();
            scheduleServ.SwapScheduleDates(i1, i2);
            showPanel("Schedule");
        }

        private void activityListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showPanel("Activity_List");
        }

        private void ActivityListStart()
        {
            Fill_Activity_List();
            radioButton2.Checked = true;
        }

        private void Fill_Activity_List()
        {

            LV_Activity_List.Items.Clear();
            SomerenLogic.Activity_Service activServ = new SomerenLogic.Activity_Service();
            List<Activity> actList = activServ.GetActivities();
            LV_Activity_List.View = View.Details;
            foreach (SomerenModel.Activity activity in actList)
            {
                LV_Activity_List.Items.Add(new ListViewItem(new string[] { $"{activity.Id}", $"{activity.Description}", $"{activity.StartTime.ToString("dd/MM/yyyy HH:mm")}", $"{activity.EndTime.ToString("dd/MM/yyyy HH:mm")}" }));
            }
            LV_Activity_List.Items[0].Selected = true;
            LV_Activity_List.Items[0].Focused = true;
        }

        private void Radio_Activity_Button(string button)
        {
            switch (button)
            {
                case "Act_Add":
                    btn_Act_Confirm.Text = "Add";
                    btn_Act_Confirm.BackColor = Color.Green;
                    TextBox_Activity_Id.Enabled = false;
                    TextBox_Activity_Description.Enabled = true;
                    TextBox_Act_Sday.Enabled = true;
                    TextBox_Act_Smonth.Enabled = true;
                    TextBox_Act_Syear.Enabled = true;
                    TextBox_Act_Sminute.Enabled = true;
                    TextBox_Act_Shour.Enabled = true;
                    TextBox_Act_Eday.Enabled = true;
                    TextBox_Act_Emonth.Enabled = true;
                    TextBox_Act_Eyear.Enabled = true;
                    TextBox_Act_Eminute.Enabled = true;
                    TextBox_Act_Ehour.Enabled = true;

                    // clear all boxes
                    TextBox_Activity_Id.Clear();
                    TextBox_Activity_Description.Clear(); ;
                    TextBox_Act_Sday.Clear();
                    TextBox_Act_Smonth.Clear();
                    TextBox_Act_Syear.Clear();
                    TextBox_Act_Sminute.Clear();
                    TextBox_Act_Shour.Clear();
                    TextBox_Act_Eday.Clear();
                    TextBox_Act_Emonth.Clear();
                    TextBox_Act_Eyear.Clear();
                    TextBox_Act_Eminute.Clear();
                    TextBox_Act_Ehour.Clear();


                    break;
                case "Act_Modify":
                    btn_Act_Confirm.Text = "Modify";
                    btn_Act_Confirm.BackColor = Color.Yellow;
                    TextBox_Activity_Id.Enabled = false;
                    TextBox_Activity_Description.Enabled = true;
                    TextBox_Act_Sday.Enabled = true;
                    TextBox_Act_Smonth.Enabled = true;
                    TextBox_Act_Syear.Enabled = true;
                    TextBox_Act_Sminute.Enabled = true;
                    TextBox_Act_Shour.Enabled = true;
                    TextBox_Act_Eday.Enabled = true;
                    TextBox_Act_Emonth.Enabled = true;
                    TextBox_Act_Eyear.Enabled = true;
                    TextBox_Act_Eminute.Enabled = true;
                    TextBox_Act_Ehour.Enabled = true;
                    break;
                case "Act_Delete":
                    btn_Act_Confirm.Text = "Delete";
                    btn_Act_Confirm.BackColor = Color.Red;
                    TextBox_Activity_Id.Enabled = true;
                    TextBox_Activity_Description.Enabled = false;
                    TextBox_Act_Sday.Enabled = false;
                    TextBox_Act_Smonth.Enabled = false;
                    TextBox_Act_Syear.Enabled = false;
                    TextBox_Act_Sminute.Enabled = false;
                    TextBox_Act_Shour.Enabled = false;
                    TextBox_Act_Eday.Enabled = false;
                    TextBox_Act_Emonth.Enabled = false;
                    TextBox_Act_Eyear.Enabled = false;
                    TextBox_Act_Eminute.Enabled = false;
                    TextBox_Act_Ehour.Enabled = false;
                    break;
            }
        }

        private void Modify_Activity()
        {

            if (LV_Activity_List.SelectedItems.Count > 0)
            {
                SomerenLogic.Activity_Service activity_Service = new Activity_Service();
                List<Activity> activities = activity_Service.GetActivities();
                int index = LV_Activity_List.SelectedIndices[0];
                Activity activity = activities[index];

                TextBox_Activity_Id.Text = activity.Id.ToString();
                TextBox_Activity_Description.Text = activity.Description;
                TextBox_Act_Sday.Text = activity.StartTime.Day.ToString();
                TextBox_Act_Smonth.Text = activity.StartTime.Month.ToString();
                TextBox_Act_Syear.Text = activity.StartTime.Year.ToString();
                TextBox_Act_Sminute.Text = activity.StartTime.Minute.ToString();
                TextBox_Act_Shour.Text = activity.StartTime.Hour.ToString();
                TextBox_Act_Eday.Text = activity.EndTime.Day.ToString();
                TextBox_Act_Emonth.Text = activity.EndTime.Month.ToString();
                TextBox_Act_Eyear.Text = activity.EndTime.Year.ToString();
                TextBox_Act_Eminute.Text = activity.EndTime.Minute.ToString();
                TextBox_Act_Ehour.Text = activity.EndTime.Hour.ToString();
            }
        }



        private void Modify_Activity(string setting)
        {
            SomerenLogic.Activity_Service activity_Service = new Activity_Service();

            string StartTime = $"{TextBox_Act_Sday.Text}/{TextBox_Act_Smonth.Text}/{TextBox_Act_Syear.Text} {TextBox_Act_Shour.Text}:{TextBox_Act_Sminute.Text}:00";
            string EndTime = $"{TextBox_Act_Eday.Text}/{TextBox_Act_Emonth.Text}/{TextBox_Act_Eyear.Text} {TextBox_Act_Ehour.Text}:{TextBox_Act_Eminute.Text}:00";

            DateTime SdateTime = DateTime.Parse(StartTime);
            DateTime EdateTime = DateTime.Parse(EndTime);
            switch (setting)
            {
                case "Delete":
                    ListViewItem item = LV_Activity_List.SelectedItems[0];
                    if (item != null)
                    {
                        // send delete command to database
                        activity_Service.DeleteActivity(int.Parse(TextBox_Activity_Id.Text));
                    }
                    break;
                case "Modify":
                    ListViewItem items = LV_Activity_List.SelectedItems[0];
                    if (items != null)
                    {


                        // create edited product
                        Activity newactivity = new Activity();
                        newactivity.Id = int.Parse(TextBox_Activity_Id.Text);
                        newactivity.Description = TextBox_Activity_Description.Text;
                        newactivity.StartTime = SdateTime;
                        newactivity.EndTime = EdateTime;


                        // send edited product to database
                        activity_Service.ModifyActivity(newactivity);
                    }
                    break;
                case "Add":

                    // create edited product
                    Activity activity = new Activity();
                    activity.Description = TextBox_Activity_Description.Text;
                    activity.StartTime = SdateTime;
                    activity.EndTime = EdateTime;

                    // send new product to database
                    activity_Service.AddActivity(activity);

                    LV_Activity_List.View = View.Details;
                    LV_Activity_List.Items.Add(new ListViewItem(new string[] { $"{activity.Id}", $"{activity.Description}", $"{activity.StartTime.ToString("dd/MM/yyyy HH:mm")}", $"{activity.EndTime.ToString("dd/MM/yyyy HH:mm")}" }));
                    break;
            }
            Fill_Activity_List();
        }


        private void radioButton1_CheckedChanged_1(object sender, EventArgs e)
        {
            Radio_Activity_Button("Act_Add");
        }

        private void radioButton2_CheckedChanged_1(object sender, EventArgs e)
        {
            Radio_Activity_Button("Act_Modify");
        }

        private void radioButton3_CheckedChanged_1(object sender, EventArgs e)
        {
            Radio_Activity_Button("Act_Delete");
        }

        private void LV_Activity_List_SelectedIndexChanged(object sender, EventArgs e)
        {
            Modify_Activity();
        }

        private void btn_Act_Confirm_Click(object sender, EventArgs e)
        {
            Modify_Activity(btn_Act_Confirm.Text);
        }


        private void FillModifyCombobox()
        {
            if (SupervisorListview.SelectedItems.Count != 0)
            {
                SomerenLogic.Activity_Service activity_Service = new Activity_Service();
                SomerenLogic.ActivitySupervisor_Service activitySupervisor_Service = new ActivitySupervisor_Service();
                int comboindex = 0;

                List<ActivitySupervisor> activitySupervisors = activitySupervisor_Service.GetActivitySupervisor();
                List<Activity> activities = activity_Service.GetActivities();
                
                ActivitySupervisor supervisor = activitySupervisors[SupervisorListview.SelectedIndices[0]];

                for (int i = 0; i < activities.Count; i++)
                {
                    if (supervisor.ActivityId == activities[i].Id)
                    {
                        comboindex = i;
                        break;
                    }
                }

                ModifyComboBox.Items.Clear();
                foreach (Activity activity in activities)
                {
                    ModifyComboBox.Items.Add(activity.Description);
                }
                ModifyComboBox.SelectedIndex = comboindex;
            }
        }

        private void ModifySupervisor()
        {
            if (SupervisorListview.SelectedItems.Count != 0)
            {
                SomerenLogic.Activity_Service activity_Service = new Activity_Service();
                SomerenLogic.ActivitySupervisor_Service activitySupervisor_Service = new ActivitySupervisor_Service();
                List<ActivitySupervisor> activitySupervisors = activitySupervisor_Service.GetActivitySupervisor();
                ActivitySupervisor supervisor = activitySupervisors[SupervisorListview.SelectedIndices[0]];

                Activity activity = ModifyComboBoxSelect();

                ActivitySupervisor activitySupervisor = new ActivitySupervisor
                {
                    SupervisorId = supervisor.SupervisorId,
                    ActivityId = activity.Id,
                    ActivityName = activity.Description,
                    TeacherName = supervisor.TeacherName,
                    TeacherId = supervisor.TeacherId
                };

                activitySupervisor_Service.ModifyActivitySupervisor(activitySupervisor);
                ActivitySupervisorMenu("Refresh");
            }
        }

        private Activity ModifyComboBoxSelect()
        {
            SomerenLogic.Activity_Service activity_Service = new Activity_Service();
            List<Activity> activities = activity_Service.GetActivities();
            return activities[ModifyComboBox.SelectedIndex];
        }


        private void ModifySupervisorbtn_Click(object sender, EventArgs e)
        {
            ModifySupervisor();
        }

        private void SupervisorListview_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillModifyCombobox();
        }
    }
}
