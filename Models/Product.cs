namespace WHApp_API.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public string ProductCode { get; set; }
        public int Volume { get; set; }
        public int RenterId { get; set; }
        public Renter Renter { get; set; }
        public ProductShipping ProductShipping { get; set; }
        public ProductInWarehouse ProductInWarehouse { get; set; }
    }
}