using System;

namespace WHApp_API.Models
{
    public class ProductForShipping
    {
        public int ProductForShippingId { get; set; }
        public DateTime ShipmentDeadline { get; set; }
        public int ProductInWarehouseId { get; set; }
        public ProductInWarehouse ProductInWarehouse { get; set; }
    }
}