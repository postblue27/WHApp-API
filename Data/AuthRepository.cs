using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WHApp_API.Dtos;
using WHApp_API.Helpers.CustomExceptions;
using WHApp_API.Interfaces;
using WHApp_API.Models;
using System.Text;
using Microsoft.Extensions.Configuration;
using System.IdentityModel.Tokens.Jwt;

namespace WHApp_API.Data
{
    public class AuthRepository : IAuthRepository
    {
        private readonly DataContext _context;
        private readonly IConfiguration _config;

        public AuthRepository(DataContext context, IConfiguration config)
        {
            _context = context;
            _config = config;
        }

        public async Task<User> RegisterAsync(UserForRegisterDto userForRegisterDto)
        {
            if(await UserExistsAsync(userForRegisterDto.Username))
            {
                throw new UserExistsException();
            }
            User user = new User(userForRegisterDto.Username, userForRegisterDto.Email);
            byte[] passwordHash, passwordSalt;

            CreatePasswordHash(userForRegisterDto.Password, out passwordHash, out passwordSalt);

            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;
            
            var userTypeFullName = Extensions.GetTypeByFullName(typeof(Renter).Namespace, userForRegisterDto.UserType);
            var typedUser = Extensions.GetTypedUserInstance(user, userTypeFullName);
            _context.Add(typedUser);
            await _context.SaveChangesAsync();
            return typedUser;
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using(var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        public async Task<bool> UserExistsAsync(string username)
        {
            if(await _context.Users.AnyAsync(u => u.Username.ToLower() == username.ToLower()))
                return true;
            return false;
        }
        public async Task<string> LoginAsync(string username, string userType, string password)
        {
            var user = await _context.Users.FirstOrDefaultAsync(r => r.Username.ToLower() == username.ToLower());
            if(user == null)
                throw new Exception("User with this username is not found.");
            if(!user.UserType.Equals(userType))
                throw new Exception("User type mismatch.");

            if(!VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
                throw new Exception("Wrong password.");

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.Role, user.UserType)
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.GetSection("AppSettings:Token").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = creds
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }

        public bool VerifyPasswordHash(string password, byte[] PasswordHash, byte[] PasswordSalt)
        {
            using(var hmac = new System.Security.Cryptography.HMACSHA512(PasswordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for(int i = 0; i < computedHash.Length; i++)
                {
                    if(computedHash[i] != PasswordHash[i])
                        return false;
                }

                return true;
            }
        }

        public async Task<User> GetUser(string username)
        {
            var user = await _context.Users.FirstOrDefaultAsync(r => r.Username.ToLower() == username.ToLower());

            if(user == null)
                return null;

            return user;
        }
    }
}