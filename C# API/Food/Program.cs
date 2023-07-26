using Food;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;

class Program
{
    public static void Main(string[] args)
    {
        foodportal foodportal = new foodportal();
        foodportal.OpenConn();
         //foodportal.createtable();
         //foodportal.inserttable();
       foodportal.Cusadmin();
    }
}
