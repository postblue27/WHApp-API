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
            // return await _context.Owners.Join(_context.Renters)
            return await _context.Owners.ToListAsync();
        }
    }
}