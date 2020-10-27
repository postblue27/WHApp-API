namespace WHApp_API.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public string ProductCode { get; set; }
        public ProductForShipping ProductForShipping { get; set; }
        public ProductInWarehouse ProductInWarehouse { get; set; }
    }
}