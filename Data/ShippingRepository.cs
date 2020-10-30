using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WHApp_API.Interfaces;
using WHApp_API.Models;

namespace WHApp_API.Data
{
    public class ShippingRepository : IShippingRepository
    {
        private readonly DataContext _context;
        public ShippingRepository(DataContext context)
        {
            _context = context;

        }
        public async Task<bool> CarExists(int carCode)
        {
            if(await _context.Cars.AnyAsync(c => c.CarCode == carCode))
                return true;
            return false;
        }
        public async Task<List<Car>> GetCars()
        {
            var carsList = await _context.Cars.Include(w => w.Driver).ToListAsync();
            
            return carsList;
        }
    }
}