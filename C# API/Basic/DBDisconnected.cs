using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBConnect
{
    internal class DBDisconnected
    {
        SqlConnection conn;
        SqlDataAdapter da;
        DataSet ds;

        public void OpenConn()
        {

            string cnnstr = "data source=LAPTOP-EE8FKNGK\\SQLEXPRESS; Initial Catalog = student; Integrated Security = SSPI";
           /* new SqlConnection
            (@"Data Source=LAPTOP-EE8FKNGK\SQLEXPRESS;
            Initial Catalog=student;Integrated Security=SSPI");*/ 
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
        public void ReadData()
        {
            da= new SqlDataAdapter("select * from stud_details", conn);
            ds = new DataSet();
            da.Fill(ds,"stud_details");
            //Console.WriteLine(ds.Tables["stud_details"].Columns[0].ColumnName);
            foreach(DataRow dr in ds.Tables["stud_details"].Rows)
            {
                Console.WriteLine(dr[0].ToString() + dr[1].ToString());
            }
            conn.Close();
        }
        public void InsertRecord()
        {
            SqlCommandBuilder scb = new SqlCommandBuilder(da);
            int rno = 103;
            string nm = "ccc";
           // ds.Tables["stud_details"].Columns["rno"].Unique = true;
           // ds.Tables["stud_details"].Columns["name"].DefaultValue = "xxx";
            DataRow dr = ds.Tables["stud_details"].NewRow();
            dr[0]=rno; dr[1]=nm;

            ds.Tables["stud_details"].Rows.Add(dr);
            da.Update(ds, "stud_details");
            Console.WriteLine("Inserted");
            conn.Close();
        }
        public void UpdateRecord(int rno)
        {
            SqlCommandBuilder scb = new SqlCommandBuilder(da);
            foreach (DataRow dr in ds.Tables["stud_details"].Rows)
            {
                if (Int32.Parse( dr["rno"].ToString())==rno)
                {
                    dr["name"] = "fff";
                    break;
                }
            }
            da.Update(ds, "stud_details");
            Console.WriteLine("Updated");
            conn.Close();
            ReadData();
        }
        public void DeleteRecord()
        {

            SqlCommandBuilder scb = new SqlCommandBuilder(da);
            foreach (DataRow dr in ds.Tables["stud_details"].Rows)
            {
                //if (Int32.Parse(dr["rno"].ToString()) == rno)
                {
                    dr.Delete();
                }
            }
          
            da.Update(ds, "stud_details");
            Console.WriteLine("Deleted"); 
            conn.Close();
            //ReadData();
        }
    }
}
