using System;
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
        // public async Task<List<Owner>> GetOwners()
        // {
        //     return await _context.Owners.ToListAsync();
        // }
        // public async Task<List<Renter>> GetRenters()
        // {
        //     return await _context.Renters.ToListAsync();
        // }
        // public async Task<List<Driver>> GetDrivers()
        // {
        //     return await _context.Drivers.ToListAsync();
        // }
        // public async Task<List<Admin>> GetAdmins()
        // {
        //     return await _context.Admins.ToListAsync();
        // }
        public async Task<List<User>> GetUsersByUserTypeAsync(string userTypeString)
        {
            return await _context.Users.Where(u => u.UserType == userTypeString).ToListAsync();
        }




        // public async Task<Owner> GetOwnerById(int Id)
        // {
        //     return await _context.Owners.FirstOrDefaultAsync(u => u.Id == Id);
        // }
        // public async Task<Renter> GetRenterById(int Id)
        // {
        //     return await _context.Renters.FirstOrDefaultAsync(u => u.Id == Id);
        // }
        // public async Task<Driver> GetDriverById(int Id)
        // {
        //     return await _context.Drivers.FirstOrDefaultAsync(u => u.Id == Id);
        // }
        // public async Task<Admin> GetAdminById(int Id)
        // {
        //     return await _context.Admins.FirstOrDefaultAsync(u => u.Id == Id);
        // }
    }
}