using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WHApp_API.Interfaces;
using WHApp_API.Models;

namespace WHApp_API.Data
{
    public class WarehouseRepository : IWarehouseRepository
    {
        private readonly DataContext _context;
        public WarehouseRepository(DataContext context)
        {
            _context = context;

        }

        public async Task<List<Warehouse>> GetOwnerWarehouses(int ownerId)
        {
            return await _context.Warehouses.Where(w => w.OwnerId == ownerId).ToListAsync();
        }

        public async Task<RenterWarehouse> GetRenterWarehouse(int renterId, int warehouseId)
        {
            var renterWarehouse = await _context.RenterWarehouses//.Include(rw => rw.Renter).Include(rw => rw.Warehouse)
                .FirstOrDefaultAsync(rw => rw.Id == renterId && rw.WarehouseId == warehouseId);

            return renterWarehouse;
        }

        public async Task<List<RenterWarehouse>> GetRenterWarehouses(int renterId)
        {
            return await _context.RenterWarehouses.Where(rw => rw.Id == renterId).Include(rw => rw.Renter).Include(rw => rw.Warehouse).ToListAsync();
        }

        public async Task<Warehouse> GetWarehouse(int warehouseId)
        {
            var warehouse = await _context.Warehouses.FirstOrDefaultAsync(w => w.Id == warehouseId);

            return warehouse;
        }

        public async Task<List<Warehouse>> GetWarehouses()
        {
            var warehousesList = await _context.Warehouses.Include(w => w.Owner).ToListAsync();
            
            return warehousesList;
        }

        // public async Task<Warehouse> GetWarehouseWithZones(int warehouseId)
        // {
        //     var warehouse = await _context.Warehouses.Include(w => w.Zones).FirstOrDefaultAsync(w => w.Id == warehouseId);
                
        //     return warehouse;
        // }

        public async Task<bool> WarehouseExists(int id)
        {
            if(await _context.Warehouses.AnyAsync(w => w.Id == id))
                return true;
            return false;
        }
        // public async Task<bool> ZoneExists(int warehouseId, int zoneId)
        // {
        //     var warehouse = await _context.Warehouses.Include(w => w.Zones).FirstOrDefaultAsync(w => w.Id == warehouseId);
        //     foreach(Zone z in warehouse.Zones)
        //     {
        //         if(z.ZoneId == zoneId)
        //             return true;
        //     }
        //     return false;
        // }
    }
}