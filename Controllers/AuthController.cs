using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using WHApp_API.Dtos;
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
        public async Task<IActionResult> Register(UserForRegisterDto userForRegisterDto)
        {
            try{
                var createdUser = await _repo.RegisterAsync(userForRegisterDto);
                return Ok(
                    new { 
                        Message = $"{createdUser.UserType} successfully created."
                    }
                );
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.GetType().ToString());
                switch (ex.GetType().ToString())
                {
                    case "System.TypeLoadException":
                        return BadRequest($"Error loading user type \"{userForRegisterDto.UserType}\". Check the spelling of the user type.");
                    case "System.ArgumentNullException":
                        return BadRequest($"Some of the arguments were not provided. Check your payload.");
                    case "WHApp_API.Helpers.CustomExceptions.UserExistsException":
                        return BadRequest(ex.Message);
                }
            }
            return BadRequest("Something went wrong...");
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login(UserForLoginDto userForLoginDto)
        {
            try
            {
                var token = await _repo.LoginAsync(userForLoginDto.Username, userForLoginDto.UserType, userForLoginDto.Password);
                return Ok(new
                {
                    token = token
                });
            }
            catch(Exception ex)
            {
                return Unauthorized(ex.Message);
            }
        }
    }
}