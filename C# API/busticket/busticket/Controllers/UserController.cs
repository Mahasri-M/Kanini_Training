
using busticket.Models;
using busticket.Services.UserRepo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace busticket.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   // [Authorize]
    public class UserController : ControllerBase
    {
        private readonly IUser _user;
        public UserController(IUser user)
        {
            _user = user;
        }
        [HttpGet]
        public IEnumerable<User> Get()
        {
            return _user.GetAllUsers();
        }
        [HttpGet("{id}")]
        public User GetById(int id)
        {
            return _user.GetUserById(id);
        }
        [HttpPost]
        public async Task<ActionResult<List<User>>> AddUserDetails(User user)
        {
            var users = await _user.AddUserDetails(user);
            return Ok(users);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<User>?>> UpdateUserDetailsById(int id, User user)
        {
            var users = await _user.UpdateUserDetailsById(id,user);
            if (users is null)
            {
                return NotFound("Users id not matching");
            }
            return Ok(users);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<User>>> DeleteUserDetailsById(int id)
        {
            var users = await _user.DeleteUserDetailsById(id);
            if (users is null)
            {
                return NotFound("userid not matching");
            }
            return Ok(users);
        }
    }
}
