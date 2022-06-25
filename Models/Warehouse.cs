using System.Collections.Generic;

namespace WHApp_API.Models
{
    public class Warehouse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public double Cost { get; set; }
        public int OwnerId { get; set; }
        public Owner Owner { get; set; }
        public ICollection<RenterWarehouse> RenterWarehouses { get; set; }
        public ICollection<Product> Products { get; set; }
        public ICollection<ShippingRequest> ShippingRequests { get; set; }
    }
}