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

        public async Task<bool> UserExists(string username, string userType)
        {
            switch(userType)
            {
                case "Renter":
                    if(await _context.Renters.AnyAsync(u => u.Username == username))
                        return true;
                        break;
                case "Owner":
                    if(await _context.Owners.AnyAsync(u => u.Username == username))
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
                case "Renter":
                    user = await _context.Renters.FirstOrDefaultAsync(r => r.Username == username);
                        break;
                case "Owner":
                    user = await _context.Owners.FirstOrDefaultAsync(o => o.Username == username);
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
    }
}