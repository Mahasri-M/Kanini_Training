using Hotel_Booking_System.Models;
using Microsoft.EntityFrameworkCore;

namespace Hotel_Booking_System.Repositories.Employee_Repositories
{
    public class Employee_Repository:IEmployee
    {
        private readonly HotelContext _employeeContext;
        public Employee_Repository(HotelContext context)
        {
            _employeeContext = context;
        }
        //GetAllEmployee
        public IEnumerable<Employee> GetAllEmployees()
        {
            return _employeeContext.Employees.ToList();
        }
        //GetEmployeeById
        public Employee GetEmployeesById(int Employee_Id)
        {
            return _employeeContext.Employees.FirstOrDefault(x => x.Employee_Id == Employee_Id);
        }
        //PostEmployee
        public Employee PostEmployee(Employee employee)
        {
            var emp = _employeeContext.Hotels.Find(employee.Hotel.Hotel_Id);
            employee.Hotel = emp;
            _employeeContext.Add(employee);
            _employeeContext.SaveChanges();
            return employee;
        }
        //PutEmployee
        public Employee PutEmployee(int Employee_Id, Employee employee)
        {
            var emp = _employeeContext.Hotels.Find(employee.Hotel.Hotel_Id);
            employee.Hotel = emp;
            _employeeContext.Entry(employee).State = EntityState.Modified;
            _employeeContext.SaveChangesAsync();
            return employee;
        }
        //DeleteEmployee
        public Employee DeleteEmployee(int Employee_Id)
        {
            var emp = _employeeContext.Employees.Find(Employee_Id);
            _employeeContext.Employees.Remove(emp);
            _employeeContext.SaveChanges();
            return emp;
        }
    }
}
