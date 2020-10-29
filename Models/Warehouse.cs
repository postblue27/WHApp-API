using System.Collections.Generic;

namespace WHApp_API.Models
{
    public class Warehouse
    {
        public int WarehouseId { get; set; }
        public int WarehouseCode { get; set; }
        public string Location { get; set; }
        public int Capacity { get; set; }
        public int OwnerId { get; set; }
        public Owner Owner { get; set; }
        public ICollection<RenterWarehouse> RenterWarehouses { get; set; }
        public ICollection<ProductInWarehouse> ProductsInWarehouse { get; set; }
        public ICollection<Zone> Zones { get; set; }
    }
}