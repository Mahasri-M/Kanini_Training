using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPIWithEFDBFirst.Models;
using WebAPIWithEFDBFirst.Repository.StudentService;

namespace WebAPIWithEFDBFirst.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;

        /* private static List<Student> students = new List<Student>
 {
 new Student { StudId=1,Name="raj",city="chennai",pin=345},
 new Student { StudId=2,Name="john",city="mumbai",pin=543},
 new Student { StudId=3,Name="sam",city="cbe",pin=987}
 };*/
        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }
        [HttpGet]
        public async Task<ActionResult<List<Student>>> GetAllStudentDetails()
        {

            return await _studentService.GetAllStudentDetails();
            // var stud=students.Where(s=>s.StudId=)
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<List<Student>>> GetStudentDetailById(int id)
        {
            // var student = students.Where(s=>s.StudId==id).FirstOrDefault();

            //var student = students.Find(s => s.StudId == id);

            var student = await _studentService.GetStudentDetailById(id);
            if (student is null)
            {
                return NotFound("Studid not matching");
            }
            return Ok(student);
        }
        [HttpPost]
        public async Task<ActionResult<List<Student>>> AddStudentDetails(Student stud)
        {
            // var stud = new Student { StudId = 4, Name = "tom", city = "cbe", pin = 9874};
            //students.Add(stud);
            var students = await _studentService.AddStudentDetails(stud);
            return Ok(students);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<Student>?>> UpdateStudentDetailsById(int id, Student stud)
        {
            //var student = students.Find(s => s.StudId == id);

            var students = await _studentService.UpdateStudentDetailsById(id, stud);
            if (students is null)
            {
                return NotFound("Studid not matching");
            }
            /* student.Name = stud.Name;
             student.city = stud.city;
             student.pin = stud.pin;*/
            return Ok(students);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Student>>> DeleteStudentDetailsById(int id)
        {
            //var student = students.Find(s => s.StudId == id);
            var students = await _studentService.DeleteStudentDetailsById(id);
            if (students is null)
            {
                return NotFound("Studid not matching");
            }
            //students.Remove(student);
            return Ok(students);
        }
        /* [HttpDelete]
         public async Task<ActionResult> DeleteAllStudentDetails()
         {
             foreach(var student in students)
                 students.Remove(student);
             return Ok();
         }
     }*/
    }
}


