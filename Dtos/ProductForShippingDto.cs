using System;

namespace WHApp_API.Dtos
{
    public class ProductForShippingDto
    {
        public DateTime ShipmentDeadline { get; set; }
        public int ProductInWarehouseId { get; set; }
    }
}