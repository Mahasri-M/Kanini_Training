using Microsoft.EntityFrameworkCore;
using WebAPIWithEFDBFirst.Models;

namespace WebAPIWithEFDBFirst.Repository.StudentService
{
    public class StudentService : IStudentService
    {
        public StudentDbContext _studentDataContext;

        /* private static List<Student> students = new List<Student>
{
new Student { StudId=1,Name="raj",city="chennai",pin=345},
new Student { StudId=2,Name="john",city="mumbai",pin=543},
new Student { StudId=3,Name="sam",city="cbe",pin=987}
};*/

        public StudentService(StudentDbContext studentDataContext)
        {
            _studentDataContext = studentDataContext;
        }

        public async Task<List<Student>> GetAllStudentDetails()
        {
            var students = await _studentDataContext.Students.ToListAsync();
            return students;

        }
        public async Task<Student?> GetStudentDetailById(int id)
        {

            var student = await _studentDataContext.Students.FindAsync(id);
            if (student is null)
            {
                return null;
            }
            return student;
        }
        public async Task<List<Student>> AddStudentDetails(Student stud)
        {
            _studentDataContext.Students.Add(stud);
            await _studentDataContext.SaveChangesAsync();

            return await _studentDataContext.Students.ToListAsync();
        }

        public async Task<List<Student>?> UpdateStudentDetailsById(int id, Student stud)
        {
            var student = await _studentDataContext.Students.FindAsync(id);
            if (student is null)
            {
                return null;
            }
            student.Name = stud.Name;
            student.City = stud.City;
            student.Pin = stud.Pin;
            await _studentDataContext.SaveChangesAsync();
            return await _studentDataContext.Students.ToListAsync();
        }

        public async Task<List<Student>?> DeleteStudentDetailsById(int id)
        {
            var student = await _studentDataContext.Students.FindAsync(id);
            if (student is null)
            {
                return null;
            }
            _studentDataContext.Remove(student);
            await _studentDataContext.SaveChangesAsync();
            return await _studentDataContext.Students.ToListAsync();
        }
    }
}

