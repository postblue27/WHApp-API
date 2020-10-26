using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WHApp_API.Interfaces;
using WHApp_API.Models;

namespace WHApp_API.Data
{
    public class AuthRepository : IAuthRepository
    {private readonly DataContext _context;
        public AuthRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<User> Register(string username, string userType, string password)
        {
            User user = new User(username);
            byte[] passwordHash, passwordSalt;

            CreatePasswordHash(password, out passwordHash, out passwordSalt);

            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            switch(userType)
            {
                case "Renter":
                    Renter renter = new Renter(user);
                    await _context.Renters.AddAsync(renter);
                    await _context.SaveChangesAsync();
                    return renter;
                case "Owner":
                    Owner owner = new Owner(user);  
                    // Owner owner = new User(username);
                    User u = new Owner(user);
                    await _context.Owners.AddAsync(owner);
                    await _context.SaveChangesAsync();    
                    return owner;
                default:
                    return user;
            }
        }
        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using(var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        public async Task<bool> UserExists(string username)
        {
            if(await _context.Renters.AnyAsync(u => u.Username == username)
                || await _context.Owners.AnyAsync(u => u.Username == username))
            {
                return true;
            }

            return false;
        }
    }
}