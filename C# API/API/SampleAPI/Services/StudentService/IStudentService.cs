using SampleAPI.Models;

namespace SampleAPI.Services.StudentService
{
    public interface IStudentService
    {
        List<Student> GetAllStudentDetails();

        Student? GetStudentDetailById(int id);

        List<Student> AddStudentDetails(Student stud);

        List<Student>? UpdateStudentDetailsById(int id, Student stud);

        List<Student>? DeleteStudentDetailsById(int id);
        
        }
}
