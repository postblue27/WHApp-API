using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using WHApp_API.Interfaces;
using WHApp_API.Models;

namespace WHApp_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _repo;
        private readonly IConfiguration _config;
        public AuthController(IAuthRepository repo, IConfiguration config)
        {
            _repo = repo;
            _config = config;
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
        // [HttpPost("login")]
        // public async Task<IActionResult> Login(UserForLoginDto userForLoginDto)
        // {
        //     //throw new Exception("my error message");

        //     userForLoginDto.Username = userForLoginDto.Username.ToLower();

        //     var userFromRepo = await _repo.Login(userForLoginDto.Username, userForLoginDto.Password);

        //     if (userFromRepo == null)
        //         return Unauthorized();

        //     var claims = new[]
        //     {
        //         new Claim(ClaimTypes.NameIdentifier, userFromRepo.Id.ToString()),
        //         new Claim(ClaimTypes.Name, userFromRepo.UserName)
        //     };

        //     var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.GetSection("AppSettings:Token").Value));

        //     var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

        //     var tokenDescriptor = new SecurityTokenDescriptor
        //     {
        //         Subject = new ClaimsIdentity(claims),
        //         Expires = DateTime.Now.AddDays(1),
        //         SigningCredentials = creds
        //     };

        //     var tokenHandler = new JwtSecurityTokenHandler();

        //     var token = tokenHandler.CreateToken(tokenDescriptor);

        //     return Ok(new
        //     {
        //         token = tokenHandler.WriteToken(token)
        //     });
        // }
    }
}