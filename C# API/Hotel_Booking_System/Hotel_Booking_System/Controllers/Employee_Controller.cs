using Hotel_Booking_System.Models;
using Hotel_Booking_System.Repositories.Employee_Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hotel_Booking_System.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class Employee_Controller : ControllerBase
    {
        private readonly IEmployee emp;
        public Employee_Controller(IEmployee emp)
        {
            this.emp = emp;
        }
        [HttpGet]
        public IEnumerable<Employee> Get()
        {
            return emp.GetAllEmployees();
        }

        [HttpGet("{id}")]
        public Employee GetById(int id)
        {
            return emp.GetEmployeesById(id);
        }

        [HttpPost]
        public Employee PostEmployee(Employee employee)
        {
            return emp.PostEmployee(employee);
        }
        [HttpPut("{id}")]
        public Employee PutEmployee(int id, Employee employee)
        {
            return emp.PutEmployee(id, employee);
        }
        [HttpDelete("{id}")]
        public Employee DeleteEmployee(int id)
        {
            return emp.DeleteEmployee(id);
        }

    }
}

