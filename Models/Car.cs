using System.Collections.Generic;

namespace WHApp_API.Models
{
    public class Car
    {
        public int CarId { get; set; }
        public int CarCode { get; set; }
        public string Capacity { get; set; }
        public int DriverId { get; set; }
        public Driver Driver { get; set; }
        public ShippingRequest ShippingRequest { get; set; }
    }
}