using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Food
{
    internal class foodportal
    {
        SqlConnection conn;
        SqlCommand cus_details, cat_id, food_type, product, order_det, pay_type, pay,cmd1,cmd2,command;
        SqlDataAdapter da;
        DataSet ds;
        SqlDataReader s;
       private int totalamt;

        public void OpenConn()
        {

            string cnnstr = "data source=LAPTOP-EE8FKNGK\\SQLEXPRESS; Initial Catalog = food; Integrated Security = SSPI";

            conn = new SqlConnection(cnnstr);
            try
            {
                conn.Open();
                Console.WriteLine("DB Connected..");
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Connection not established");
            }
        }

        public void createtable()
        {
            OpenConn();
            SqlCommand cus_details = new SqlCommand("create table customer_det(name varchar(10), mob_num int primary key, city varchar(10));", conn);
            SqlCommand cat_id = new SqlCommand("create table category(c_id varchar(1) primary key, c_type varchar(10));", conn);
            SqlCommand food_type = new SqlCommand("create table food_type(type_id int primary key, specification varchar(10));", conn);
            SqlCommand product = new SqlCommand("create table product(p_id int identity(11,1) primary key,c_id varchar(1) Foreign Key references category(c_id),type_id int Foreign Key references food_type(type_id),p_name varchar(20),cost int);", conn);
            SqlCommand order_det = new SqlCommand("create table order_det(order_id int identity(100,1) primary key, name varchar(10), mob_num int Foreign key references customer_det(mob_num),p_id int foreign key references product(p_id),quantity int, amt int);", conn);
            SqlCommand pay_type = new SqlCommand("create table payment_type(pay_id int primary key, pay_type varchar(5));", conn);
            SqlCommand pay = new SqlCommand("create table payment(payment_no int identity(1111,1) primary key,pay_id int foreign key references payment_type(pay_id),totalamt int);", conn);

            if (conn != null)
            {
                cus_details.ExecuteNonQuery();
                cat_id.ExecuteNonQuery();
                food_type.ExecuteNonQuery();
                product.ExecuteNonQuery();
                order_det.ExecuteNonQuery();
                pay_type.ExecuteNonQuery();
                pay.ExecuteNonQuery();

                Console.WriteLine("Table Created");

            }
        }
        
        public void inserttable()
        {
            SqlCommand cus_details = new SqlCommand("insert into customer_det values('vel',987654,'chennai'),('murugan',982710,'chennai'),('maha',998060,'chennai'),('sri',902345,'chennai');", conn);
            SqlCommand cat_id = new SqlCommand("insert into category values('A','veg'),('B','nonveg'),('C','fastfood');", conn);
            SqlCommand food_type = new SqlCommand("insert into food_type values(1,'breakfast'),(2,'lunch'),(3,'dinner');", conn);
            SqlCommand product = new SqlCommand("insert into product values('A',1,'idli',20),('A',2,'meals',150),('A',3,'dosa',40),('B',1,'chicken sandwich',120),('B',2,'chicken biriyani',150),('B',3,'parotta chickencurry',140),('C',1,'fried rice',120),('C',2,'noodels',150),('C',3,'burmi',140);", conn);
            SqlCommand order_det = new SqlCommand("insert into order_det values('vel',987654,11,2,40),('maha',998060,15,1,150);", conn);
            SqlCommand pay_type = new SqlCommand("insert into payment_type values(51,'cash'),(52,'NB'),(53,'UPI'),(54,'card');", conn);
            SqlCommand pay = new SqlCommand("insert into payment values(53,40),(54,150);", conn);
            if (conn != null)
            {
               cus_details.ExecuteNonQuery();
                cat_id.ExecuteNonQuery();
                food_type.ExecuteNonQuery();
                product.ExecuteNonQuery();
                order_det.ExecuteNonQuery();
                pay_type.ExecuteNonQuery();
                pay.ExecuteNonQuery();
                Console.WriteLine("Values Inserted");
            }

        }

        public void Cusadmin()
        {
            Console.WriteLine("Enter 1 or 2:");
            Console.WriteLine("1.Customer");
            Console.WriteLine("2.Admin");
            int choice = Convert.ToInt32(Console.ReadLine());
            if (choice == 1)
            {
                Customer();
            }
            else if (choice == 2)
            {
                Admin();
            }
            else
            {
                Console.WriteLine("Enter vaild Number");
            }
        }
        public void Customer()
        {
            string connectionString = "data source=LAPTOP-EE8FKNGK\\SQLEXPRESS; Initial Catalog = food; Integrated Security = SSPI";
            Console.WriteLine("Order your favorite food");
            Console.WriteLine("\nEnter your meal type:");
            Console.WriteLine("\nA for Veg");
            Console.WriteLine("\nB for NonVeg");
            Console.WriteLine("\nC for FastFood");
            char meal = Convert.ToChar(Console.ReadLine());
            //veg
            if (meal == 'A' || meal == 'a')
            {
                Console.WriteLine("\nPress 1 for Idli");
                Console.WriteLine("\nPress 2 for Meals");
                Console.WriteLine("\nPress 3 for Dosa");
                int mealtype = Convert.ToInt32(Console.ReadLine());
                if (mealtype == 1)
                {
                    Console.WriteLine("Enter quantity:");
                    int quantity = Convert.ToInt32(Console.ReadLine());
                    totalamt = quantity * 20;
                    Console.WriteLine("Your bill amount is: " + totalamt);
                    
                    payment();
                }
                else if (mealtype == 2)
                {
                    Console.WriteLine("Enter quantity:");
                    int quantity = Convert.ToInt32(Console.ReadLine());
                    totalamt = quantity * 150;
                    Console.WriteLine("Your bill amount is: " + totalamt);
                   
                    payment();
                }
                else if (mealtype == 3)
                {
                    Console.WriteLine("Enter quantity:");
                    int quantity = Convert.ToInt32(Console.ReadLine());
                    totalamt = quantity * 40;
                    Console.WriteLine("Your bill amount is: " + totalamt);
                   
                    payment();
                }
                else
                {
                    Console.WriteLine("Enter valid number");
                }
            }
            //nonveg
            else if (meal == 'B' || meal == 'b')
            {
                Console.WriteLine("\nPress 1 for Chicken Sandwich");
                Console.WriteLine("\nPress 2 for Chicken Biriyani");
                Console.WriteLine("\nPress 3 for Parotta ChickenCurry");
                int mealtype = Convert.ToInt32(Console.ReadLine());
                if (mealtype == 1)
                {
                    Console.WriteLine("Enter quantity:");
                    int quantity = Convert.ToInt32(Console.ReadLine());
                    totalamt = quantity * 120;
                    Console.WriteLine("Your bill amount is: " + totalamt);
                   
                    payment();
                }
                else if (mealtype == 2)
                {
                    Console.WriteLine("Enter quantity:");
                    int quantity = Convert.ToInt32(Console.ReadLine());
                    totalamt = quantity * 150;
                    Console.WriteLine("Your bill amount is: " + totalamt);
                    
                    payment();
                }
                else if (mealtype == 3)
                {
                    Console.WriteLine("Enter quantity:");
                    int quantity = Convert.ToInt32(Console.ReadLine());
                    totalamt = quantity * 140;
                    Console.WriteLine("Your bill amount is: " + totalamt);
                   
                    payment();
                }
                else
                {
                    Console.WriteLine("Enter valid number");
                }
            }
            //fastfood
            else if (meal == 'C' || meal == 'c')
            {
                Console.WriteLine("\nPress 1 for FriedRice");
                Console.WriteLine("\nPress 2 for Noodels");
                Console.WriteLine("\nPress 3 for Burmi");
                int mealtype = Convert.ToInt32(Console.ReadLine());
                if (mealtype == 1)
                {
                    Console.WriteLine("Enter quantity:");
                    int quantity = Convert.ToInt32(Console.ReadLine());
                    totalamt = quantity * 120;
                    Console.WriteLine("Your bill amount is: " + totalamt);
                   
                    payment();
                }
                else if (mealtype == 2)
                {
                    Console.WriteLine("Enter quantity:");
                    int quantity = Convert.ToInt32(Console.ReadLine());
                    totalamt = quantity * 150;
                    Console.WriteLine("Your bill amount is: " + totalamt);
                    
                    payment();
                }
                else if (mealtype == 3)
                {
                    Console.WriteLine("Enter quantity:");
                    int quantity = Convert.ToInt32(Console.ReadLine());
                     totalamt = quantity * 140;
                    Console.WriteLine("Your bill amount is: " + totalamt);
                     payment();
                

                }
                else
                {
                    Console.WriteLine("Enter valid number");
                }
            }
            else
            {
                Console.WriteLine("Enter a valid character");
            }
        }
        public void payment()
        {
            string connectionString = "data source=LAPTOP-EE8FKNGK\\SQLEXPRESS; Initial Catalog = food; Integrated Security = SSPI";
            Console.WriteLine("\nEnter a payment mode:");
            Console.WriteLine("\nPress 1 for cash");
            Console.WriteLine("\nPress 2 for NB");
            Console.WriteLine("\nPress 3 for UPI");
            Console.WriteLine("\nPress 4 for card");
            int pay = Convert.ToInt32(Console.ReadLine());
            if (pay == 1)
            {
                int pay_id = 51;

                string query1 = "INSERT INTO payment (pay_id,totalamt) VALUES (@pay_id,@totalamt)";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand(query1, connection))
                    {
                        command.Parameters.AddWithValue("@totalamt", totalamt);
                        command.Parameters.AddWithValue("@pay_id", pay_id);
                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                }
                Console.WriteLine("Payment Successfull!\nThank you for ordering!!");
            }
            else if (pay == 2)
            {
                int pay_id = 52;

                string query1 = "INSERT INTO payment (pay_id,totalamt) VALUES (@pay_id,@totalamt)";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand(query1, connection))
                    {
                        command.Parameters.AddWithValue("@totalamt", totalamt);
                        command.Parameters.AddWithValue("@pay_id", pay_id);
                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                }
                Console.WriteLine("Enter a bank account number:");
                int acc_no = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Payment Processing....\n");
                Thread.Sleep(5000);
                Console.WriteLine("Payment Successfull!\nThank you for ordering!!");
            }
            else if (pay == 3)
            {
                int pay_id = 53;

                string query1 = "INSERT INTO payment (pay_id,totalamt) VALUES (@pay_id,@totalamt)";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand(query1, connection))
                    {
                        command.Parameters.AddWithValue("@totalamt", totalamt);
                        command.Parameters.AddWithValue("@pay_id", pay_id);
                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                }
                Console.WriteLine("Enter UPI ID:");
                string upi = Console.ReadLine();
                Console.WriteLine("Payment Processing....\n");
                Thread.Sleep(5000);
                Console.WriteLine("Payment Successfull!\nThank you for ordering!!");
            }
            else if (pay == 4)
            {
                int pay_id = 54;

                string query1 = "INSERT INTO payment (pay_id,totalamt) VALUES (@pay_id,@totalamt)";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand(query1, connection))
                    {
                        command.Parameters.AddWithValue("@totalamt", totalamt);
                        command.Parameters.AddWithValue("@pay_id", pay_id);
                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                }
                Console.WriteLine("Enter a card number:");
                int card = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Payment Processing....\n");
                Thread.Sleep(5000);
                Console.WriteLine("Payment Successfull!\nThank you for ordering!!");
            }
            else
            {
                Console.WriteLine("Enter a valid number");

            }
        }
      
        
        public void Admin()
        {
            int password = 1234;
            Console.WriteLine("Enter password:");
            int pass = Convert.ToInt32(Console.ReadLine());
            if (pass == password)
            {
                fetch();
            }
            else
            {
                Console.WriteLine("Password Incorrect");
                Console.WriteLine("Enter the correct password:");
                int pass1 = Convert.ToInt32(Console.ReadLine());
                if (pass1 == password)
                {
                    fetch();
                }
            }
        }
        public void fetch()
        {
            Console.WriteLine("Enter a number:");
            Console.WriteLine("1.View menu");
            Console.WriteLine("2.Add an item to menu");
            Console.WriteLine("3.View customer details");
            Console.WriteLine("4.Add customer details");
            for (int i = 0; i < 5; i++)
            {
                int num = Convert.ToInt32(Console.ReadLine());
                switch (num)
                {
                    case 1:
                        viewmenu();
                        break;

                    case 2:
                        Console.WriteLine("Enter the c_id");
                        string c_id = Console.ReadLine();
                        Console.WriteLine("Enter the type_id");
                        int type_id = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter food");
                        string p_name=Console.ReadLine();
                        Console.WriteLine("Enter the cost");
                        int cost = Convert.ToInt32(Console.ReadLine());
                        InsertRecord( c_id, type_id, p_name,cost);
                        break;

                    case 3:
                        Viewcusdet(); break;

                    case 4:
                        Console.WriteLine("Enter the name");
                        string name = Console.ReadLine();
                        Console.WriteLine("Enter the mob_num");
                        int mob_num = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter city");
                        string city = Console.ReadLine();
                        Addcusdet(name,mob_num,city);
                        break;
                }

            }
        }


        public void Viewcusdet()
        {

            da = new SqlDataAdapter("select * from customer_det", conn);
            ds = new DataSet();
            da.Fill(ds, "customer_det");
            Console.WriteLine("\nCustomer details:\n");
            foreach (DataRow dr in ds.Tables["customer_det"].Rows)
            {

                Console.WriteLine(dr[0].ToString() + " " + dr[1].ToString() + " " + dr[2].ToString());
            }

        }

        public void viewmenu()
        {
            da = new SqlDataAdapter("select * from product", conn);
            ds = new DataSet();
            da.Fill(ds, "product");
            Console.WriteLine("\nMenu:\n");
            foreach (DataRow dr in ds.Tables["product"].Rows)
            {

                Console.WriteLine(dr[0].ToString() + " " + dr[1].ToString() + " " + dr[2].ToString() + " " + dr[3].ToString() + " " + dr[4].ToString());
            }
        }

        public void Addcusdet( string name, int mob_num, string city)
        {
            SqlCommand cmd1 = new SqlCommand("insert into customer_det values (@value1, @value2, @value3)", conn);
            cmd1.Parameters.AddWithValue("@value1", name);
            cmd1.Parameters.AddWithValue("@value2", mob_num);
            cmd1.Parameters.AddWithValue("@value3", city);
           
            if (conn != null)
            {
                try
                {
                    int cou = cmd1.ExecuteNonQuery();
                    Console.WriteLine(cou + " Row inserted");
                }

                catch (SqlException ex)
                {
                    if (ex.Number == 2627) 
                    {
                        Console.WriteLine($"Error: mob_num:{mob_num} already exists!");
                    }
                    else
                    {
                        Console.WriteLine("Error: " + ex.Message);
                    }
                }
            }

            da = new SqlDataAdapter("select * from customer_det", conn);
            ds = new DataSet();
            da.Fill(ds, "customer_det");
            Console.WriteLine("\nCustomer details:\n");
            foreach (DataRow dr in ds.Tables["customer_det"].Rows)
            {

                Console.WriteLine(dr[0].ToString() + " " + dr[1].ToString() + " " + dr[2].ToString());
            }
        }
    
      /*  public void Addmenuitem()
        {
            string queryString = "INSERT INTO product " +
"(p_id,c_id,type_id,p_name,cost) Values(20, 'A',1,'poori',30)";

            SqlCommand command = new SqlCommand(queryString, conn);
            Int32 recordsAffected = command.ExecuteNonQuery();
            Console.WriteLine("Updated ");
            da = new SqlDataAdapter("select * from product", conn);
            ds = new DataSet();
            da.Fill(ds, "product");
            Console.WriteLine("\nMenu:\n");
            foreach (DataRow dr in ds.Tables["product"].Rows)
            {

                Console.WriteLine(dr[0].ToString() + " " + dr[1].ToString() + " " + dr[2].ToString() + " " + dr[3].ToString() + " " + dr[4].ToString());
            }
        }*/
        public void InsertRecord( string c_id, int type_id, string p_name, int cost)
        {
            SqlCommand cmd2 = new SqlCommand("insert into Product values ( @value2, @value3, @value4,@value5)", conn);
            
            cmd2.Parameters.AddWithValue("@value2", c_id);
            cmd2.Parameters.AddWithValue("@value3", type_id);
            cmd2.Parameters.AddWithValue("@value4", p_name);
            cmd2.Parameters.AddWithValue("@value5", cost);


            if (conn != null)
            {
                try
                {
                    int cou = cmd2.ExecuteNonQuery();
                    Console.WriteLine(cou + " Row inserted");
                }

                catch (SqlException ex)
                {
                   
                    {
                        Console.WriteLine("Error: " + ex.Message);
                    }
                }
            }
            da = new SqlDataAdapter("select * from product", conn);
            ds = new DataSet();
            da.Fill(ds, "product");
            Console.WriteLine("\nMenu:\n");
            foreach (DataRow dr in ds.Tables["product"].Rows)
            {

                Console.WriteLine(dr[0].ToString() + " " + dr[1].ToString() + " " + dr[2].ToString() + " " + dr[3].ToString() + " " + dr[4].ToString());
            }
        }
       
    }
}


