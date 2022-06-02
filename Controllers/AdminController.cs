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
        // [Authorize(Roles = "Admin")]
        [HttpGet("get-users/{userType}")]
        public async Task<IActionResult> GetUsersByUserType(string userType)
        {
            try
            {
                var usersList = await _adminrepo.GetUsersByUserType(userType);
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
        [HttpPost("update-user/{userType}")]
        public async Task<IActionResult> UpdateUser(string userType, [FromBody]User userForUpdate)
        {
            var a = 10;
            switch(userType)
            {
                case UserTypes.Renter:
                    Renter updatedRenter = new Renter
                    {
                        Id = userForUpdate.Id,
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
                        Id = userForUpdate.Id,
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
                        Id = userForUpdate.Id,
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
                        Id = userForUpdate.Id,
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
        [HttpDelete("delete-user/{userType}/{Id}")]
        public async Task<IActionResult> DeleteUser(string userType, int Id)
        {
            switch(userType)
            {
                case UserTypes.Renter:
                    var renterToDelete = new Renter {
                        Id = Id
                    };
                    _apprepo.Delete(renterToDelete);
                    if (await _apprepo.SaveAll())
                    {
                     return Ok(renterToDelete);
                    }
                    return BadRequest("Problem deleting user");
                case UserTypes.Owner:
                    var ownerToDelete = new Owner {
                        Id = Id
                    };
                    _apprepo.Delete(ownerToDelete);
                    if (await _apprepo.SaveAll())
                    {
                     return Ok(ownerToDelete);
                    }
                    return BadRequest("Problem deleting user");
                case UserTypes.Driver:
                    var driverToDelete = new Driver {
                        Id = Id
                    };
                    _apprepo.Delete(driverToDelete);
                    if (await _apprepo.SaveAll())
                    {
                     return Ok(driverToDelete);
                    }
                    return BadRequest("Problem deleting user");
                case UserTypes.Admin:
                    var adminToDelete = new Admin {
                        Id = Id
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