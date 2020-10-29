using System.Collections.Generic;
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

        public async Task<RenterWarehouse> GetRenterWarehouse(int renterId, int warehouseId)
        {
            var renterWarehouse = await _context.RenterWarehouses//.Include(rw => rw.Renter).Include(rw => rw.Warehouse)
                .FirstOrDefaultAsync(rw => rw.UserId == renterId && rw.WarehouseId == warehouseId);

            return renterWarehouse;
        }

        public async Task<Warehouse> GetWarehouse(int warehouseId)
        {
            var warehouse = await _context.Warehouses.FirstOrDefaultAsync(w => w.WarehouseId == warehouseId);

            return warehouse;
        }

        public async Task<List<Warehouse>> GetWarehouses()
        {
            var warehousesList = await _context.Warehouses.Include(w => w.Owner).ToListAsync();
            
            return warehousesList;
        }

        public async Task<Warehouse> GetWarehouseWithZones(int warehouseId)
        {
            var warehouse = await _context.Warehouses.Include(w => w.Zones).FirstOrDefaultAsync(w => w.WarehouseId == warehouseId);
                
            return warehouse;
        }

        public async Task<bool> WarehouseExists(int warehouseCode)
        {
            if(await _context.Warehouses.AnyAsync(w => w.WarehouseCode == warehouseCode))
                return true;
            return false;
        }
        public async Task<bool> ZoneExists(int warehouseId, int zoneId)
        {
            var warehouse = await _context.Warehouses.Include(w => w.Zones).FirstOrDefaultAsync(w => w.WarehouseId == warehouseId);
            foreach(Zone z in warehouse.Zones)
            {
                if(z.ZoneId == zoneId)
                    return true;
            }
            return false;
        }
    }
}