using System.Collections.Generic;
using System.Threading.Tasks;
using WHApp_API.Models;

namespace WHApp_API.Interfaces
{
    public interface IWarehouseRepository
    {
        Task<List<Warehouse>> GetWarehouses();
        Task<List<Warehouse>> GetOwnerWarehouses(int ownerId);
        Task<List<RenterWarehouse>> GetRenterWarehouses(int renterId);
        Task<RenterWarehouse> GetRenterWarehouse(int RenterId, int WarehouseId);
        Task<Warehouse> GetWarehouse(int WarehouseId);
        // Task<Warehouse> GetWarehouseWithZones(int WarehouseId);
        // Task<bool> ZoneExists(int warehouseId, int zoneId);
        Task<bool> WarehouseExists(int warehouseCode);
    }
}