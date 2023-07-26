using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCodeFirst
{
    internal class CRUDOpera
    {
        public void InsertRecordsInCourseEntity()
        {
            using (var context =new CollegeContext())
            {
                var cour = new Course()
                {
                    CourseId = 101,
                    Name="CSE"
                };
                context.students.Add(cour);
                context.SaveChanges();
            }
        }

        public void InsertRecordsInStudentEntity()
        {
            using (var context = new CollegeContext())
            {
                var stud = new student()
                {
                    StudentId = 1002,
                    Name = "Ram"
                };
                context.students.Add(stud);
                context.SaveChanges();
            }
        }
        public void UpdateRecordsInStudentEntity()
        {
            using(var context= new CollegeContext())
            {
               var st= context.students.First<student>();
                st.Age = 22;
                context.SaveChanges();
            }
        }
        public void DeleteRecordsInStudentEntity()
        {
            using (var context = new CollegeContext())
            {
                var st = context.students.First<student>();
                context.students.Remove(st);
                context.SaveChanges();
            }
        }
        public void ReadDataFromStudentEntity(string stname)
        {
            var context = new CollegeContext();
            var st=context.students.Where(s=>s.Name==stname);
            foreach (var s in st)
            {
                Console.WriteLine(s.Name);
            }
        }
    }
}
