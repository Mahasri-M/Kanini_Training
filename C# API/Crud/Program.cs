using Crud;
using System.Data;
using System.Data.SqlClient;
using System.Text;

class Program
{
    public static void Main(string[] args)
    {
        StringBuilder cnnstr = new StringBuilder("data source=");
 
            Console.WriteLine("Enter data source");
        cnnstr.Append(Console.ReadLine());
        cnnstr.Append(";Initial Catalog=");
        Console.WriteLine("enter db name");
        cnnstr.Append(Console.ReadLine());
        cnnstr.Append("'Integrated Security=SSPI;");
        Console.WriteLine(cnnstr);
        DB db = new DB();
        db.OpenConn(cnnstr.ToString());
       /* db.OpenConn();
        // db.CreateTable();
        db.InsertTable();
        //  db.UpdateTable();
        db.DeleteTable();
        db.ReadTable();
        db.CloseConn();
       */
    }


}

