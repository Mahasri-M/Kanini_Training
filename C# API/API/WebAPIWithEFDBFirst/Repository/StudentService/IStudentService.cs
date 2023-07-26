using WebAPIWithEFDBFirst.Models;

namespace WebAPIWithEFDBFirst.Repository.StudentService
{
    public interface IStudentService
    {
        Task<List<Student>> GetAllStudentDetails();

        Task<Student?> GetStudentDetailById(int id);

        Task<List<Student>> AddStudentDetails(Student stud);

        Task<List<Student>?> UpdateStudentDetailsById(int id, Student stud);

        Task<List<Student>?> DeleteStudentDetailsById(int id);
    }
}
