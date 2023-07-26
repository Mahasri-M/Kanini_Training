using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SocialMedia.Models;
using SocialMedia.Repository;

namespace SocialMedia.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUsers _repository;
        public UserController(IUsers repository)
        {
            _repository = repository;
        }
        [HttpGet("{id}")]
        public IActionResult GetUserById(int id)
        {
            var user = _repository.GetUserById(id);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpGet]
        public IActionResult GetAllUsers()
        {
            var users = _repository.GetAllUsers();
            return Ok(users);
        }

        [HttpPost]
        public IActionResult CreateUser(User user)
        {
            _repository.CreateUser(user);
            return CreatedAtAction(nameof(GetUserById), new { id = user.Id }, user);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateUser(int id, User updatedUser)
        {
            var existingUser = _repository.GetUserById(id);
            if (existingUser == null)
            {
                return NotFound();
            }

            existingUser.Username = updatedUser.Username;
            existingUser.Password = updatedUser.Password;
            // Update other properties as needed

            _repository.UpdateUser(existingUser);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            var user = _repository.GetUserById(id);
            if (user == null)
            {
                return NotFound();
            }

            _repository.DeleteUser(user);

            return NoContent();
        }
    }
}




   
       

       
