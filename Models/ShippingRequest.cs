using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WHApp_API.Models
{
    public class ShippingRequest
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int WarehouseId { get; set; }
        public Warehouse Warehouse { get; set; }
        public int CarId { get; set; }
        public Car Car { get; set; }
        public ShippingStatus ShippingStatus { get; set; }
    }
}