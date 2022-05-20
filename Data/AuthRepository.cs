using System;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WHApp_API.Dtos;
using WHApp_API.Interfaces;
using WHApp_API.Models;

namespace WHApp_API.Data
{
    public class AuthRepository : IAuthRepository
    {
        private readonly DataContext _context;
        public AuthRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<object> Register(UserForRegisterDto userForRegisterDto)
        {
            User user = new User(userForRegisterDto.Username, userForRegisterDto.Email);
            byte[] passwordHash, passwordSalt;

            CreatePasswordHash(userForRegisterDto.Password, out passwordHash, out passwordSalt);

            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;
            
            var userTypeFullName = Extensions.GetUserTypeFullName(typeof(Renter).Namespace, userForRegisterDto.UserType);
            var typedUser = Extensions.GetTypedUserInstance(userForRegisterDto, userTypeFullName);
            _context.Add(typedUser);
            await _context.SaveChangesAsync();
            return Task.FromResult(typedUser);
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using(var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        public async Task<bool> UserExists(string username, string userType)
        {
            switch(userType)
            {
                case UserTypes.Renter:
                    if(await _context.Renters.AnyAsync(u => u.Username == username))
                        return true;
                        break;
                case UserTypes.Owner:
                    if(await _context.Owners.AnyAsync(u => u.Username == username))
                        return true;
                        break;
                case UserTypes.Driver:
                    if(await _context.Drivers.AnyAsync(u => u.Username == username))
                        return true;
                        break;
                case UserTypes.Admin:
                    if(await _context.Admins.AnyAsync(u => u.Username == username))
                        return true;
                        break;
            }
            return false;
        }
        public async Task<User> Login(string username, string userType, string password)
        {
            var user = new User();
            switch(userType)
            {
                case UserTypes.Renter:
                    user = await _context.Renters.FirstOrDefaultAsync(r => r.Username == username);
                        break;
                case UserTypes.Owner:
                    user = await _context.Owners.FirstOrDefaultAsync(o => o.Username == username);
                        break;
                case UserTypes.Driver:
                    user = await _context.Drivers.FirstOrDefaultAsync(o => o.Username == username);
                        break;
                case UserTypes.Admin:
                    user = await _context.Admins.FirstOrDefaultAsync(o => o.Username == username);
                        break;
            }

            if(user == null)
                return null;

            if(!VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
                return null;

            return user;
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

        public async Task<User> GetUser(string username, string userType)
        {
            var user = new User();
            switch(userType)
            {
                case UserTypes.Renter:
                    user = await _context.Renters.FirstOrDefaultAsync(r => r.Username == username);
                        break;
                case UserTypes.Owner:
                    user = await _context.Owners.FirstOrDefaultAsync(o => o.Username == username);
                        break;
                case UserTypes.Driver:
                    user = await _context.Drivers.FirstOrDefaultAsync(o => o.Username == username);
                        break;
                case UserTypes.Admin:
                    user = await _context.Admins.FirstOrDefaultAsync(o => o.Username == username);
                        break;
            }

            if(user == null)
                return null;

            return user;
        }
    }
}