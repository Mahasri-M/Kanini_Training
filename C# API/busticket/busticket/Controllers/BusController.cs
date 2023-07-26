using busticket.Migrations;
using busticket.Models;
using busticket.Services.BusRepo;
using busticket.Services.UserRepo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace busticket.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BusController : ControllerBase
    {
        private readonly IBus _user;
        public BusController(IBus user)
        {
            _user = user;
        }
        [HttpGet]
        public IEnumerable<Busdetails> Get()
        {
            return _user.GetAllBuses();
        }
        [HttpGet("{id}")]
        public Busdetails GetById(int id)
        {
            return _user.GetBusById(id);
        }
        [HttpPost]
        public async Task<ActionResult<List<Busdetails>>> AddBusDetails(Busdetails user)
        {
            var users = await _user.AddBusDetails(user);
            return Ok(users);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<List<Busdetails>?>> UpdateBusDetailsById(int id, Busdetails user)
        {
            var users = await _user.UpdateBusDetailsById(id, user);
            if (users is null)
            {
                return NotFound("Users id not matching");
            }
            return Ok(users);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Busdetails>>> DeleteBusDetailsById(int id)
        {
            var users = await _user.DeleteBusDetailsById(id);
            if (users is null)
            {
                return NotFound("userid not matching");
            }
            return Ok(users);
        }
        //boarding destination
        [HttpGet("filterbyboardingdestination")]
        public IEnumerable<Busdetails> FilterBD(string boarding, string destination)
        {
            return _user.FilterByBoardingAndDestination(boarding, destination);
        }
    }
}
