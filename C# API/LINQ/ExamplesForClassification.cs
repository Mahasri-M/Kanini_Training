using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace LINQ
{
    internal class ExamplesForClassification
    {
        public void example1()
        {
            List<string> courses = new List<string>();
            courses.Add("C++ Tutorials");
            courses.Add("C# Tutorials");
            courses.Add("Learn SQL");
            courses.Add("VC++ Tutorials");
            courses.Add("Web Technologies");

            /* var tutcourses = from c in courses
                              where c.Contains("Tutorials")
                              select c;*/

            var tutcourses = courses.Where(c => c.Contains("Tutorials")).ToList();
            foreach (var tut in tutcourses)
            {
                Console.WriteLine(tut);
            }
        }
            public void FliteringWhere()
            {
                IList<Student> studentList = new List<Student>() {
                new Student() { StudentID = 1, StudentName = "AAA", Age = 13} ,
                new Student() { StudentID = 2, StudentName = "BBB",  Age = 21 } ,
                new Student() { StudentID = 3, StudentName = "CCC",  Age = 18 } ,
                new Student() { StudentID = 4, StudentName = "DDD" , Age = 20} ,
                new Student() { StudentID = 5, StudentName = "EEE" , Age = 15 }
            };
            var filteredResult=from s in studentList
                               where s.Age>12
                               where s.Age<20
                               select s;

                foreach(var std in filteredResult)
                {
                    Console.WriteLine(std.StudentName);
                }

                   }
        public void filteringoftype()
        {
            IList elements = new ArrayList();
            elements.Add(1);
            elements.Add("two");
            elements.Add(3);
            elements.Add(4);
            elements.Add("five");

          /*  var strings = from e in elements.OfType<string>() select e;
            var numbers = from e in elements.OfType<int>() select e;
          */
            var numbers = elements.OfType<int>();
            var strings=elements.OfType<string>();

            foreach(string str in strings)
                Console.WriteLine(str);
            foreach(int num in numbers)
                Console.WriteLine(num);

        }
        public void SortingOrderBy()
        {
            IList<Student> studentList = new List<Student>() {
                new Student() { StudentID = 1, StudentName = "ZZZ", Age = 13} ,
                new Student() { StudentID = 2, StudentName = "BBB",  Age = 21 } ,
                new Student() { StudentID = 3, StudentName = "CCC",  Age = 18 } ,
                new Student() { StudentID = 4, StudentName = "ZZZ" , Age = 20} ,
                new Student() { StudentID = 5, StudentName = "YYY" , Age = 15 }
            };
            /*
            var result=from student in studentList
                       orderby student.StudentName descending
                       select student;
            */
            var result=studentList.OrderByDescending(s => s.StudentName).ThenBy(s=>s.Age);
            foreach (var std in result)
            {
                Console.WriteLine(std.StudentName+" "+std.Age);
            }
        }
        public void grouping()
        {
            IList<Student> studentList = new List<Student>() {
                new Student() { StudentID = 1, StudentName = "ZZZ", Age = 13} ,
                new Student() { StudentID = 2, StudentName = "BBB",  Age = 21 } ,
                new Student() { StudentID = 3, StudentName = "CCC",  Age = 18 } ,
                new Student() { StudentID = 4, StudentName = "ZZZ" , Age = 20} ,
                new Student() { StudentID = 5, StudentName = "YYY" , Age = 15 }
            };

            // var result= from s in studentList group s by s.StudentName;

            var result = studentList.ToLookup(s=> s.StudentName);
            foreach (var s in result)
            {
                Console.WriteLine(s.Key);
                foreach (var x in s)
                    Console.WriteLine(x.StudentID+" "+ x.Age);
            }
        }
    }
}
