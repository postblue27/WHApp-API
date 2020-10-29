using System.Collections.Generic;

namespace WHApp_API.Models
{
    public class ProductShipping
    {
        public int ProductShippingId { get; set; }
        public int CarId { get; set; }
        public Car Car { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public string Destination { get; set; }
    }
}