using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WHApp_API.Dtos;
using WHApp_API.Interfaces;
using WHApp_API.Models;

namespace WHApp_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IAppRepository _apprepo;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<Role> _roleManager;
        public AppController(IAppRepository apprepo, IMapper mapper,
        
        UserManager<User> userManager, RoleManager<Role> roleManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _mapper = mapper;
            _apprepo = apprepo;
        }
    [HttpGet("get-roles")]
    public async Task<IActionResult> GetRoles()
    {
        var roles = _roleManager.Roles;
        return Ok(roles);
    }
}
}