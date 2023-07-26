using Hotel_Booking_System.Models;

namespace Hotel_Booking_System.Repositories.Employee_Repositories
{
    public interface IEmployee
    {
        public IEnumerable<Employee> GetAllEmployees();
        public Employee GetEmployeesById(int Employee_Id);
        public Employee PostEmployee(Employee employee);
        public Employee PutEmployee(int Employee_Id, Employee employee);
        public Employee DeleteEmployee(int Employee_Id);
    }
}
