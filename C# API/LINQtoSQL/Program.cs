﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQtoSQL
{
    internal class Program
    {
        static void Main(string[] args)
        {
          Stud_Details stud = new Stud_Details();
            // stud.ReadDataFromSQLServer();
            // stud.CountMinMaxAvg();
            stud.Joins();

            Console.ReadLine();
        }
    }
}
