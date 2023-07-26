using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crud
{
    internal class DB
    {
        SqlConnection conn;
        public void OpenConn(string cnnstr)
        {
            ConfigurationManager.RefreshSection("connectionStrings");
            //conn = new SqlConnection
            // (@"Data Source=LAPTOP-EE8FKNGK\SQLEXPRESS;
            //Initial Catalog=student;Integrated Security=True");
            Console.WriteLine(cnnstr);
            conn = new SqlConnection(cnnstr);
            try
            {
                conn.Open();
                Console.WriteLine("DB Connected..");
            }
            catch (SqlException ex)
            {
                Console.WriteLine("conn not esta");
            }
        }
        public void CreateTable()
        {
            SqlCommand cmd = new SqlCommand("create table " +
                "stud_details(rno int,name nvarchar(20))", conn);
            if (conn != null)
            {
                cmd.ExecuteNonQuery();
                Console.WriteLine("Table created");
            }


        }
        public void InsertTable()
        {
            SqlCommand cmd = new SqlCommand("insert into " +
               "stud_details values(1000,'aaa')", conn);
            if (conn != null)
            {
                cmd.ExecuteNonQuery();
                Console.WriteLine("Row inserted");
            }
        }
        public void UpdateTable()
        {
            SqlCommand cmd = new SqlCommand("update " +
                           "stud_details set rno=101 where name='aaa'", conn);
            if (conn != null)
            {
                cmd.ExecuteNonQuery();
                Console.WriteLine("Row updated");
            }
        }
        public void DeleteTable()
        {
            SqlCommand cmd = new SqlCommand("delete stud_details", conn);
            if (conn != null)
            {
                cmd.ExecuteNonQuery();
                Console.WriteLine("Row deleted");
            }
        }
        public void ReadTable()
        {
            SqlCommand cmd = new SqlCommand("select * from stud_details", conn);
            SqlDataReader sdr;
            if (conn != null)
            {
                sdr = cmd.ExecuteReader();


                if (!sdr.HasRows)
                {
                    Console.WriteLine("Data set is empty");
                }
                while (sdr.Read())
                {
                    Console.WriteLine(sdr["rno"] + " " + sdr["name"]);
                }
            }
        }
        public void CloseConn()
        {
            if (conn != null)
            {
                conn.Close();
            }
        }
    }
}
