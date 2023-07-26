﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace DoctorManage.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly IUser _user;
        public UsersController(IUser user)
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
        //[HttpGet("{id}")]
        //public User GetIdByEmailId(string id)
        //{
        //    return _user.GetUserIdByEmail(id);
        //}

        [HttpPost]
        public async Task<ActionResult<List<User>>> AddUser(User user)
        {
            var users = await _user.AddUser(user);
            return Ok(users);
        }


        //[HttpPut("{id}")]
        //public async Task<ActionResult<User>> Put(int id, [FromForm] User doctor, IFormFile imageFile)
        //{
        //    try
        //    {
        //        doctor.Id = id;
        //        var updatedDoctor = await _user.UpdateDoctor(doctor, imageFile);
        //        return Ok(updatedDoctor);
        //    }
        //    catch (ArgumentException ex)
        //    {
        //        ModelState.AddModelError("", ex.Message);
        //        return BadRequest(ModelState);
        //    }
        //}

        [HttpPut("{id}")]
        public IActionResult UpdateUser(int id, User user)
        {
            try
            {
                _user.UpdateUser(id, user);
                return Ok();
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<User>>> DeleteUserById(int id)
        {
            var users = await _user.DeleteUserById(id);
            if (users is null)
            {
                return NotFound("userid not matching");
            }
            return Ok(users);
        }
    }
}
