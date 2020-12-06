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
        public AdminController(IAdminRepository adminrepo, IAppRepository apprepo,
        RoleManager<Role> roleManager)
        {
            _roleManager = roleManager;
            _adminrepo = adminrepo;
            _apprepo = apprepo;
        }
    [HttpGet("get-roles")]
    public async Task<IActionResult> GetRoles()
    {
        return Ok(_roleManager.Roles);
    }
    // [Authorize(Roles = "Admin")]
    // [HttpGet("get-users/{userType}")]
    // //TODO GetUsersByRole
    // public async Task<IActionResult> GetUsers(string userType)
    // {
    //     var usersList = await _adminrepo.GetUsers();
    //     if(usersList == null)
    //         return BadRequest("No users yet");
    //     return Ok(usersList);
    //     return BadRequest("Error getting " + userType + "s");
    // }
    // [Authorize(Roles = "Admin")]
    // [HttpPost("update-user/{userType}")]
    // public async Task<IActionResult> UpdateUser(string userType, [FromBody]User userForUpdate)
    // {
    //     switch(userType)
    //     {
    //         case UserTypes.Renter:
    //             Renter updatedRenter = new Renter
    //             {
    //                 UserId = userForUpdate.UserId,
    //                 Username = userForUpdate.Username,
    //                 Email = userForUpdate.Email
    //             };
    //             _apprepo.Update(updatedRenter);
    //             if(await _apprepo.SaveAll()){
    //                 return Ok(updatedRenter);
    //             }
    //             return BadRequest("Problem updating user");
    //         case UserTypes.Owner:
    //             Owner updatedOwner = new Owner
    //             {
    //                 UserId = userForUpdate.UserId,
    //                 Username = userForUpdate.Username,
    //                 Email = userForUpdate.Email
    //             };
    //             _apprepo.Update(updatedOwner);
    //             if(await _apprepo.SaveAll()){
    //                 return Ok(updatedOwner);
    //             }
    //             return BadRequest("Problem updating user");
    //         case UserTypes.Driver:
    //             Driver updatedDriver = new Driver
    //             {
    //                 UserId = userForUpdate.UserId,
    //                 Username = userForUpdate.Username,
    //                 Email = userForUpdate.Email
    //             };
    //             _apprepo.Update(updatedDriver);
    //             if(await _apprepo.SaveAll()){
    //                 return Ok(updatedDriver);
    //             }
    //             return BadRequest("Problem updating user");
    //         case UserTypes.Admin:
    //             Admin updatedAdmin = new Admin
    //             {
    //                 UserId = userForUpdate.UserId,
    //                 Username = userForUpdate.Username,
    //                 Email = userForUpdate.Email
    //             };
    //             _apprepo.Update(updatedAdmin);
    //             if(await _apprepo.SaveAll()){
    //                 return Ok(updatedAdmin);
    //             }
    //             return BadRequest("Problem updating user");
    //     }
    //     return BadRequest("Error updating user");
    // }
    // [Authorize(Roles = "Admin")]
    // [HttpDelete("delete-user/{userType}/{userId}")]
    // public async Task<IActionResult> DeleteUser(string userType, int userId)
    // {
    //     switch(userType)
    //     {
    //         case UserTypes.Renter:
    //             var renterToDelete = new Renter {
    //                 UserId = userId
    //             };
    //             _apprepo.Delete(renterToDelete);
    //             if (await _apprepo.SaveAll())
    //             {
    //              return Ok(renterToDelete);
    //             }
    //             return BadRequest("Problem deleting user");
    //         case UserTypes.Owner:
    //             var ownerToDelete = new Owner {
    //                 UserId = userId
    //             };
    //             _apprepo.Delete(ownerToDelete);
    //             if (await _apprepo.SaveAll())
    //             {
    //              return Ok(ownerToDelete);
    //             }
    //             return BadRequest("Problem deleting user");
    //         case UserTypes.Driver:
    //             var driverToDelete = new Driver {
    //                 UserId = userId
    //             };
    //             _apprepo.Delete(driverToDelete);
    //             if (await _apprepo.SaveAll())
    //             {
    //              return Ok(driverToDelete);
    //             }
    //             return BadRequest("Problem deleting user");
    //         case UserTypes.Admin:
    //             var adminToDelete = new Admin {
    //                 UserId = userId
    //             };
    //             _apprepo.Delete(adminToDelete);
    //             if (await _apprepo.SaveAll())
    //             {
    //              return Ok(adminToDelete);
    //             }
    //             return BadRequest("Problem deleting user");
    //     }
    //     return BadRequest("Error deleting user");
    // }
}
}