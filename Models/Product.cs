namespace WHApp_API.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public int Capacity { get; set; }
        public int RenterId { get; set; }
        public Renter Renter { get; set; }
        public ProductShipping ProductShipping { get; set; }
        public ProductInWarehouse ProductInWarehouse { get; set; }
        public Product(){}
        public Product(Product product)
        {
            this.ProductName = product.ProductName;
            this.Description = product.Description;
            this.Capacity = product.Capacity;
            this.Id = product.Id;
        }
        public Product(string ProductName, string Description,
                string ProductCode, int Capacity, int Id)
        {
            this.ProductName = ProductName;
            this.Description = Description;
            this.Capacity = Capacity;
            this.Id = Id;
        }
    }
}