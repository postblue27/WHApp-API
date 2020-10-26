using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WHApp_API.Interfaces;
using WHApp_API.Models;

namespace WHApp_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _repo;
        public AuthController(IAuthRepository repo)
        {
            _repo = repo;
        }
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromHeader]string username, 
            [FromHeader]string userType, [FromHeader]string password)
        {
            username = username.ToLower();

            if (await _repo.UserExists(username))
                return BadRequest("User already exists.");

            var createdUser = await _repo.Register(username, userType, password);
            return Ok(createdUser);
        }
        [HttpGet]
        public async Task<IActionResult> GetSmth(string s)
        {
            return Ok(s);
        }
    }
}