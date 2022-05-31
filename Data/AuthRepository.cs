using System;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WHApp_API.Dtos;
using WHApp_API.Helpers.CustomExceptions;
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
        public async Task<User> Login(string username, string userType, string password)
        {
            var user = await _context.Users.FirstOrDefaultAsync(r => r.Username == username);
            Console.WriteLine(user.GetType());
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
            // switch(userType)
            // {
            //     case UserTypes.Renter:
            //         user = await _context.Renters.FirstOrDefaultAsync(r => r.Username == username);
            //             break;
            //     case UserTypes.Owner:
            //         user = await _context.Owners.FirstOrDefaultAsync(o => o.Username == username);
            //             break;
            //     case UserTypes.Driver:
            //         user = await _context.Drivers.FirstOrDefaultAsync(o => o.Username == username);
            //             break;
            //     case UserTypes.Admin:
            //         user = await _context.Admins.FirstOrDefaultAsync(o => o.Username == username);
            //             break;
            // }

            if(user == null)
                return null;

            return user;
        }
    }
}