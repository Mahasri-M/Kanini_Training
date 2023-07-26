
using Basic;
using DBConnect;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;

class Program:ConfigurationSection
{
    public static void Main(string[] args)
    {
     danny danny = new danny();
        danny.OpenConn();
      danny.ReadingMenu();
        danny.ReadingMembers();
        danny.ReadingSales();
        danny.fetch();

        /*DBDisconnected dbd = new DBDisconnected();
        dbd.OpenConn();
        dbd.ReadData();
        //  dbd.InsertRecord();
        //   dbd.UpdateRecord();
        //  dbd.DeleteRecord();
        */

        //String s1=ConfigurationManager.AppSettings["num1"];
        //String s2 = ConfigurationManager.AppSettings["num2"];

        /*StringBuilder cnnstr = new StringBuilder("data source=");

        Console.WriteLine("Enter data source");
        cnnstr.Append(Console.ReadLine());
        cnnstr.Append(";Initial Catalog=");
        Console.WriteLine("enter db name");
        cnnstr.Append(Console.ReadLine());
        cnnstr.Append("'Integrated Security=SSPI;");
        Console.WriteLine(cnnstr);*/
        // String cnnstr = ConfigurationManager.ConnectionStrings["StudentManagement"].ConnectionString;
        // DB db = new DB();
        // db.OpenConn(cnnstr.ToString());
        /* db.OpenConn();
         // db.CreateTable();
         db.InsertTable();
         //  db.UpdateTable();
         db.DeleteTable();
         // dbd.CountOfStud();
        dbd.FetchStudDet();
         db.ReadTable();
         db.CloseConn();
        */
    }


}

