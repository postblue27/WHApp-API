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
        [HttpGet("get-users/{userType}")]
        public async Task<IActionResult> GetUsers(string userType)
        {
            switch(userType)
            {
                case UserTypes.Renter:
                    var rentersList = await _adminrepo.GetRenters();
                    if(rentersList == null)
                        return BadRequest("No renters yet");
                    return Ok(rentersList);
                case UserTypes.Owner:
                    var ownersList = await _adminrepo.GetOwners();
                    if(ownersList == null)
                        return BadRequest("No owners yet");
                    return Ok(ownersList);
                case UserTypes.Driver:
                    var driversList = await _adminrepo.GetDrivers();
                    if(driversList == null)
                        return BadRequest("No drivers yet");
                    return Ok(driversList);
                case UserTypes.Admin:
                    var adminsList = await _adminrepo.GetAdmins();
                    if(adminsList == null)
                        return BadRequest("No admins yet");
                    return Ok(adminsList);
            }
            return BadRequest("Error getting " + userType + "s");
        }
        [Authorize(Roles = "Admin")]
        [HttpPost("update-user/{userType}")]
        public async Task<IActionResult> UpdateUser(string userType, [FromBody]User userForUpdate)
        {
            var a = 10;
            switch(userType)
            {
                case UserTypes.Renter:
                    Renter updatedRenter = new Renter
                    {
                        UserId = userForUpdate.UserId,
                        Username = userForUpdate.Username,
                        Email = userForUpdate.Email
                    };
                    _apprepo.Update(updatedRenter);
                    if(await _apprepo.SaveAll()){
                        return Ok(updatedRenter);
                    }
                    return BadRequest("Problem updating user");
                case UserTypes.Owner:
                    Owner updatedOwner = new Owner
                    {
                        UserId = userForUpdate.UserId,
                        Username = userForUpdate.Username,
                        Email = userForUpdate.Email
                    };
                    _apprepo.Update(updatedOwner);
                    if(await _apprepo.SaveAll()){
                        return Ok(updatedOwner);
                    }
                    return BadRequest("Problem updating user");
                case UserTypes.Driver:
                    Driver updatedDriver = new Driver
                    {
                        UserId = userForUpdate.UserId,
                        Username = userForUpdate.Username,
                        Email = userForUpdate.Email
                    };
                    _apprepo.Update(updatedDriver);
                    if(await _apprepo.SaveAll()){
                        return Ok(updatedDriver);
                    }
                    return BadRequest("Problem updating user");
                case UserTypes.Admin:
                    Admin updatedAdmin = new Admin
                    {
                        UserId = userForUpdate.UserId,
                        Username = userForUpdate.Username,
                        Email = userForUpdate.Email
                    };
                    _apprepo.Update(updatedAdmin);
                    if(await _apprepo.SaveAll()){
                        return Ok(updatedAdmin);
                    }
                    return BadRequest("Problem updating user");
            }
            return BadRequest("Error updating user");
        }
        [Authorize(Roles = "Admin")]
        [HttpDelete("delete-user/{userType}/{userId}")]
        public async Task<IActionResult> DeleteUser(string userType, int userId)
        {
            switch(userType)
            {
                case UserTypes.Renter:
                    var renterToDelete = new Renter {
                        UserId = userId
                    };
                    _apprepo.Delete(renterToDelete);
                    if (await _apprepo.SaveAll())
                    {
                     return Ok(renterToDelete);
                    }
                    return BadRequest("Problem deleting user");
                case UserTypes.Owner:
                    var ownerToDelete = new Owner {
                        UserId = userId
                    };
                    _apprepo.Delete(ownerToDelete);
                    if (await _apprepo.SaveAll())
                    {
                     return Ok(ownerToDelete);
                    }
                    return BadRequest("Problem deleting user");
                case UserTypes.Driver:
                    var driverToDelete = new Driver {
                        UserId = userId
                    };
                    _apprepo.Delete(driverToDelete);
                    if (await _apprepo.SaveAll())
                    {
                     return Ok(driverToDelete);
                    }
                    return BadRequest("Problem deleting user");
                case UserTypes.Admin:
                    var adminToDelete = new Admin {
                        UserId = userId
                    };
                    _apprepo.Delete(adminToDelete);
                    if (await _apprepo.SaveAll())
                    {
                     return Ok(adminToDelete);
                    }
                    return BadRequest("Problem deleting user");
            }
            return BadRequest("Error deleting user");
        }
    }
}