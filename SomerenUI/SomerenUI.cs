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
                    Pnl_Sales.Hide();

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

                        order_listView.Items.Add(new ListViewItem(new string[] { $"{s.Sales}", $"{s.Revenue}", $"{s.Customers}", $"{s.Date.ToString("dd/MM/yyyy")}" }));

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

            int sNr = int.Parse(stuItem.SubItems[0].Text);
            int prodId = int.Parse(proItem.SubItems[0].Text);
            int orderQuantity = pL.Count();
            SomerenLogic.Order_Service orderServ = new SomerenLogic.Order_Service();


            orderServ.Insert_OrderDetails(prodId, orderQuantity);
            orderServ.Insert_Order(sNr);




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

        private void ListViewTotalOrder_Details_SelectedIndexChanged(object sender, EventArgs e)
        {

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

        private void salesReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showPanel("Sales");
        }

        private void order_listView_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
