using Microsoft.AspNetCore.Mvc;
using SampleAPI.Models;

namespace SampleAPI.Services.StudentService
{
    public class StudentService : IStudentService
    {
        private static List<Student> students = new List<Student>
            {
                new Student { StudId=1,Name="raj",city="chennai",pin=345},
                new Student { StudId=2,Name="john",city="mumbai",pin=543},
                new Student { StudId=3,Name="sam",city="cbe",pin=987}
            };

        

        /*    public  StudentService(StudentService studentService)
            {

            }*/
        public List<Student> GetAllStudentDetails()
        {
            return students;

        }
        public Student? GetStudentDetailById(int id)
        {
          
            var student = students.Find(s => s.StudId == id);
            if (student is null)
            {
                return null;
            }
            return student;
        }
        public List<Student> AddStudentDetails(Student stud)
        {
            students.Add(stud);

            return students;
        }

        public List<Student>? UpdateStudentDetailsById(int id, Student stud)
        {
            var student = students.Find(s => s.StudId == id);
            if (student is null)
            {
                return null;
            }
            student.Name = stud.Name;
            student.city = stud.city;
            student.pin = stud.pin;
            return students;
        }

        public List<Student>? DeleteStudentDetailsById(int id)
        {
            var student = students.Find(s => s.StudId == id);
            if (student is null)
            {
                return null;
            }
            students.Remove(student);
            return students;
        }
    }
}
