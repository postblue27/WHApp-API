using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
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
        private readonly RoleManager<Role> _roleManager;
        private readonly UserManager<User> _userManager;
        public AdminController(IAdminRepository adminrepo, IAppRepository apprepo,
        
        RoleManager<Role> roleManager, UserManager<User> userManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _adminrepo = adminrepo;
            _apprepo = apprepo;
        }
    [Authorize(Roles = "Admin")]
    [HttpGet("get-roles")]
    public async Task<IActionResult> GetRoles()
    {
        return Ok(_roleManager.Roles);
    }
    [Authorize(Roles = "Admin")]
    [HttpGet("get-users")]
    //TODO GetUsersByRole
    public async Task<IActionResult> GetUsers()
    {
        var usersList = await _adminrepo.GetUsers();
        if (usersList == null)
            return BadRequest("No users yet");
        return Ok(usersList);
    }
    [Authorize(Roles = "Admin")]
    [HttpPost("update-user")]
    public async Task<IActionResult> UpdateUser([FromBody] User userForUpdate)
    {
        _apprepo.Update(userForUpdate);
        if (await _apprepo.SaveAll())
        {
            return Ok(userForUpdate);
        }
        return BadRequest("Problem updating user");
    }
    [Authorize(Roles = "Admin")]
    [HttpDelete("delete-user")]
    public async Task<IActionResult> DeleteUser(User userToDelete)
    {
        _apprepo.Delete(userToDelete);
        if (await _apprepo.SaveAll())
        {
            return Ok(userToDelete);
        }
        return BadRequest("Problem deleting user");
    }
}
}