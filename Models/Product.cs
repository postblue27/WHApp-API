namespace WHApp_API.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public string ProductCode { get; set; }
        public int Volume { get; set; }
        public int Id { get; set; }
        public Renter Renter { get; set; }
        public ProductShipping ProductShipping { get; set; }
        public ProductInWarehouse ProductInWarehouse { get; set; }
        public Product(){}
        public Product(Product product)
        {
            this.ProductName = product.ProductName;
            this.Description = product.Description;
            this.ProductCode = product.ProductCode;
            this.Volume = product.Volume;
            this.Id = product.Id;
        }
        public Product(string ProductName, string Description,
                string ProductCode, int Volume, int Id)
        {
            this.ProductName = ProductName;
            this.Description = Description;
            this.ProductCode = ProductCode;
            this.Volume = Volume;
            this.Id = Id;
        }
    }
}