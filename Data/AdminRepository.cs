using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WHApp_API.Interfaces;
using WHApp_API.Models;

namespace WHApp_API.Data
{
    public class AdminRepository : IAdminRepository
    {
        private readonly DataContext _context;
        public AdminRepository(DataContext context)
        {
            _context = context;

        }
        public async Task<List<Owner>> GetOwners()
        {
            return await _context.Owners.ToListAsync();
        }
        public async Task<List<Renter>> GetRenters()
        {
            return await _context.Renters.ToListAsync();
        }
        public async Task<List<Driver>> GetDrivers()
        {
            return await _context.Drivers.ToListAsync();
        }
        public async Task<List<Admin>> GetAdmins()
        {
            return await _context.Admins.ToListAsync();
        }





        public async Task<Owner> GetOwnerById(int userId)
        {
            return await _context.Owners.FirstOrDefaultAsync(u => u.UserId == userId);
        }
        public async Task<Renter> GetRenterById(int userId)
        {
            return await _context.Renters.FirstOrDefaultAsync(u => u.UserId == userId);
        }
        public async Task<Driver> GetDriverById(int userId)
        {
            return await _context.Drivers.FirstOrDefaultAsync(u => u.UserId == userId);
        }
        public async Task<Admin> GetAdminById(int userId)
        {
            return await _context.Admins.FirstOrDefaultAsync(u => u.UserId == userId);
        }
    }
}