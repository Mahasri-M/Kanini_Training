using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basic
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
            
        }
        public void InsertRecord()
        {

        }
    }
}
