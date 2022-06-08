using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WHApp_API.Interfaces;
using WHApp_API.Models;

namespace WHApp_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAdminRepository _adminrepo;
        private readonly IAppRepository _apprepo;
        public AdminController(IAdminRepository adminrepo, IAppRepository apprepo)
        {
            _adminrepo = adminrepo;
            _apprepo = apprepo;
        }
        [Authorize(Roles = "Admin")]
        [HttpGet("get-users")]
        public async Task<IActionResult> GetUsersByUserType()
        {
            try
            {
                var usersList = await _apprepo.GetAsync<User>();
                if(usersList == null)
                    return BadRequest($"No users yet.");
                return Ok(usersList);
            }
            catch(Exception ex)
            {
                return BadRequest($"Error getting users\nError message: {ex.Message}");
            }    
        }
        [Authorize(Roles = "Admin")]
        [HttpGet("get-users/{userType}")]
        public async Task<IActionResult> GetUsersByUserType(string userType)
        {
            try
            {
                var usersList = _adminrepo.GetUsersByUserType(userType);
                if(usersList == null)
                    return BadRequest($"No {userType}s yet.");
                return Ok(usersList);
            }
            catch(Exception ex)
            {
                return BadRequest($"Error getting {userType}s\nError message: {ex.Message}");
            }    
        }
        [Authorize(Roles = "Admin")]
        [HttpPost("update-user")]
        public async Task<IActionResult> UpdateUser([FromBody]User userForUpdate)
        {
            _apprepo.Update(userForUpdate);
            if(await _apprepo.SaveAll()){
                return Ok(new { Message = "User successfully updated." });
            }
            return BadRequest("Problem updating user.");
        }
        [Authorize(Roles = "Admin")]
        [HttpDelete("delete-user/{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var userFromRepo = await _apprepo.GetByIdAsync<User>(id);
            if(userFromRepo == null)
            {
                return BadRequest("User not found");
            }
            _apprepo.Delete(userFromRepo);
            if (await _apprepo.SaveAll())
            {
                return Ok(new { Message = "User successfully deleted." });
            }
            return BadRequest("Problem deleting user");
        }
    }
}