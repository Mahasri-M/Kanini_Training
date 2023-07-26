using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bus
{
    internal class buses
    {
        SqlConnection conn;
        SqlDataAdapter da;
        SqlDataReader s;
        DataSet ds;

        public void Openconn()
        {
            string cnnstr = "data source=LAPTOP-EE8FKNGK\\SQLEXPRESS; Initial Catalog = bus; Integrated Security = SSPI";

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
            SqlCommand cmd = new SqlCommand("create table bus(bus_name varchar(10) primary key,route varchar(50),timing varchar(10));", conn);
            SqlCommand cmd2 = new SqlCommand("create table customer(c_name varchar(10),mobile int primary key,bus_name varchar(10));", conn);
            if (conn != null)
            {
                cmd.ExecuteNonQuery();
                cmd2.ExecuteNonQuery();
                Console.WriteLine("Table created");
            }
        }
        public void insertable()
        {
            SqlCommand cmd = new SqlCommand("insert into bus values('kpn','mad-cbe','10pm-7am'),('rajam','cbe-mad','10pm-7am'),('sst','cbe-blr','10pm-11am'),('balaji','mad-blr','10pm-5am');", conn);
            SqlCommand cmd2 = new SqlCommand("insert into customer values('vishvak',456788,'kpn'),('nivetha',765418,'sst');", conn);
            if (conn != null)
            {
                cmd.ExecuteNonQuery();
                cmd2.ExecuteNonQuery();
                Console.WriteLine("Inserted");
            }
        }
        public void busmain()
        {
            Console.WriteLine("1.To book a bus.\n2.View Bus details.\n3.View customer details.");
            int num=Convert.ToInt32(Console.ReadLine());
            if (num == 1)
            {
                busbook();
            }
            else if(num == 2)
            {
                Viewbus();
            }
            else if(num == 3)
            {
                viewcusdet();
            }
            else { Console.WriteLine("enter a valid number"); }
        }
        public void busbook()
        {
            Console.WriteLine("List of buses:\n");
            Console.WriteLine("1.KPN - Madres-Bangalore\n2.Rajam-Coimabatore-Chennai\n3.SST-Coimbatore-Bangalore\n4.Balaji-Chennai-Bangalore");
            Console.WriteLine("Choose a number between 1 to 4:");
            int choice = Convert.ToInt32(Console.ReadLine());

            if (choice == 1)
            {
                Console.WriteLine("Your bus KPN from Madras to Bangalore on 10am");
                Console.WriteLine("Bus fare is 1900");
            }
            else if (choice == 2)
            {
                Console.WriteLine("Your bus Rajam from Coimbatore to Chennai on 10am");
                Console.WriteLine("Bus fare is 1500");
            }
            else if (choice == 3)
            {
                Console.WriteLine("Your bus SST from Coimbatore to Chennai on 10am");
                Console.WriteLine("Bus fare is 1500");
            }
            else if (choice == 4)
            {
                Console.WriteLine("Your bus Balaji from Madras to Bangalore on 10am");
                Console.WriteLine("Bus fare is 1400");
            }
            else
            {
                Console.WriteLine("Enter a correct number:");
            }
        }
        public void Viewbus()
            {
            da = new SqlDataAdapter("select * from bus", conn);
            ds = new DataSet();
            da.Fill(ds, "bus");
            Console.WriteLine("\nBus:\n");
            foreach (DataRow dr in ds.Tables["bus"].Rows)
            {

                Console.WriteLine(dr[0].ToString() + " " + dr[1].ToString() + " " + dr[2].ToString() );
            }
        }
        public void viewcusdet()
        {
            da = new SqlDataAdapter("select * from customer", conn);
            ds = new DataSet();
            da.Fill(ds, "customer");
            Console.WriteLine("\nCustomer:\n");
            foreach (DataRow dr in ds.Tables["Customer"].Rows)
            {

                Console.WriteLine(dr[0].ToString() + " " + dr[1].ToString() + " " + dr[2].ToString());
            }
        }
    }
}
