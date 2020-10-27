using System.Collections.Generic;

namespace WHApp_API.Models
{
    public class Zone
    {
        public int ZoneId { get; set; }
        public string ZoneName { get; set; }
        public int Capacity { get; set; }
        public int WarehouseId { get; set; }
        public Warehouse Warehouse { get; set; }
        public ICollection<ProductInWarehouse> ProductsInWarehouse { get; set; }
    }
}