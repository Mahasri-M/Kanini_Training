using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppointmentManage.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        private readonly IPatient _user;
        public PatientController(IPatient user)
        {
            _user = user;
        }
        [HttpGet]
        public IEnumerable<Patient> Get()
        {
            return _user.GetAllPatients();
        }
        //[HttpGet("{id}")]
        //public Patient GetById(int id)
        //{
        //    return _user.GetPatientById(id);
        //}

        [HttpGet("{id}")]
        public Patient GetByDoctorId(int id)
        {
            return _user.GetPatientByDoctorId(id);
        }

        [HttpPost]
        public async Task<ActionResult<List<Patient>>> AddPatient(Patient user)
        {
            var users = await _user.Addpatient(user);
            return Ok(users);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Patient>>> DeletePatientById(int id)
        {
            var users = await _user.DeletePatientById(id);
            if (users is null)
            {
                return NotFound("userid not matching");
            }
            return Ok(users);
        }
    }
}
