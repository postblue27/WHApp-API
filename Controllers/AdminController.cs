using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WHApp_API.Interfaces;

namespace WHApp_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAdminRepository _adminrepo;
        public AdminController(IAdminRepository adminrepo)
        {
            _adminrepo = adminrepo;
        }
        [Authorize(Roles = "Admin")]
        [HttpGet("get-owners")]
        public async Task<IActionResult> GetProductsInWarehouse()
        {
            var ownersList = await _adminrepo.GetOwners();

            if(ownersList == null)
                return BadRequest("No owners yet");

            return Ok(ownersList);
        }
    }
}