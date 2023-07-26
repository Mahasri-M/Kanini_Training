using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBConnect
{
    internal class danny
    {
        SqlConnection conn;
        SqlCommand table1, table2, table3;
        SqlDataAdapter da;
        DataSet ds;
       
        public void OpenConn()
        {

            string cnnstr = "data source=LAPTOP-EE8FKNGK\\SQLEXPRESS; Initial Catalog = adoass; Integrated Security = SSPI";
           
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

     
        public void ReadingSales()
        {
            da = new SqlDataAdapter("select * from Sales", conn);
            ds = new DataSet();
           da.Fill(ds, "Sales");
            Console.WriteLine("\nSales data:\n");
            foreach (DataRow dr in ds.Tables["Sales"].Rows)
            {
                      
                Console.WriteLine(dr[0].ToString() +" "+ dr[1].ToString()+" " + dr[2].ToString()+" " + dr[3].ToString());
            }
          
        }
        public void ReadingMenu()
        {
            da = new SqlDataAdapter("select * from menu", conn);
            ds = new DataSet();
            da.Fill(ds, "Menu");
            Console.WriteLine("\nMenu data:\n");
            foreach (DataRow dr in ds.Tables["menu"].Rows)
            {

                Console.WriteLine(dr[0].ToString() + " " + dr[1].ToString() + " " + dr[2].ToString());
            }

        }
        public void ReadingMembers()
        {
            da = new SqlDataAdapter("select * from members", conn);
            ds = new DataSet();
            da.Fill(ds, "Members");
            Console.WriteLine("\nMembers data:\n");
            foreach (DataRow dr in ds.Tables["members"].Rows)
            {

                Console.WriteLine(dr[0].ToString() + " " + dr[1].ToString() + " " + dr[2].ToString()+" " + dr[3].ToString());
            }

        }
        public void fetch()
        {
            Console.WriteLine("\nSelect any numbers between 1-5:\n");
            Console.WriteLine("1. Display the total amount each customer spent at the restaurant?\n" +
                "2. Display the number of days each customer has visited the restaurant?\n" +
                "3. Display the most purchased item on the menu\n" +
                "4. Display the total items and amount spent by each member?\n"+
               "5. If each $1 spent equates to 10 points display the points each customer has earned.\n");
            int number = Convert.ToInt32(Console.ReadLine());
            if(number ==1) {
                OpenConn();
                Q1();
            }
            else if(number ==2)
            {
                OpenConn();
                Q2();
            }
            else if (number ==3)
            {
                OpenConn();
                Q3();
            }
            else if(number == 4)
            {
                OpenConn();
                Q4();
            }
            else if(number == 5)
            {
                OpenConn();
                Q5();
            }
            else
            {
                Console.WriteLine("Enter a valid number:");
            }
        }
        public void Q1()
        {
            SqlCommand q1 = new SqlCommand("select C_name, SUM(amt)  from Members join Sales on Members.Cus_id=Sales.Cus_id group by C_name;", conn);
            if (conn != null)
            {
                SqlDataReader s = q1.ExecuteReader();
                Console.WriteLine("Total amount each customer spent at the restaurant:\n");
                while (s.Read())
                {
                    Console.WriteLine(s[0] + "    " + s[1]+ " "+"rupees");
                }
            }

            conn.Close();

        }
        public void Q2()
        {

            SqlCommand q2 = new SqlCommand("select C_name, count(distinct purchase_date) from Sales join Members on Members.Cus_id=Sales.Cus_id group by C_name;", conn);
            if (conn != null)
            {
                SqlDataReader s = q2.ExecuteReader();
                Console.WriteLine("Number of days each customer has visited the restaurant:\n");
                while (s.Read())
                {

                    Console.WriteLine(s[0] + " " + s[1]+" "+"days");
                }
            }
            conn.Close();
        }

        public void Q3()
        {

            SqlCommand q3 = new SqlCommand("select Top 1 P_name, sum(amt) from Sales join Menu on Menu.P_id=Sales.P_id group by P_name ;", conn);
            if (conn != null)
            {
                SqlDataReader s = q3.ExecuteReader();
                Console.WriteLine("Most purchased item on the menu:\n");
                while (s.Read())
                {

                    Console.WriteLine(s[0] + " " + s[1]+" "+"rupees");
                }
            }
            conn.Close();

        }

        public void Q4()
        {
          
            SqlCommand q4 = new SqlCommand("select C_name,count(p_id), SUM(amt)  FROM Members JOIN Sales ON Members.Cus_id = Sales.Cus_id group by C_name;", conn);
            if (conn != null)
            {
                SqlDataReader s = q4.ExecuteReader();
                Console.WriteLine("Total items and amount spent by each member:\n");
                while (s.Read())
                {

                    Console.WriteLine(s[0] + " " + s[1]+"items and"+" " + s[2]+" "+"rupees");
                }
            }
            conn.Close();
        }
        public void Q5()
        {
      
            SqlCommand q5 = new SqlCommand("select C_name, Sum(amt * 10) from Sales join Members on Sales.Cus_id=Members.Cus_id group by C_name;", conn);
            if (conn != null)
            {
                SqlDataReader s = q5.ExecuteReader();
                Console.WriteLine("Total points each customer has earned:\n");
                while (s.Read())
                {

                    Console.WriteLine(s[0] + " " + s[1] + " "+"points");
                }
            }
            conn.Close();
        }



    }
}

