namespace WHApp_API.Models
{
    public class ProductInWarehouse
    {
        public int Id { get; set; }
        public int WarehouseId { get; set; }
        public Warehouse Warehouse { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public ProductForShipping ProductForShipping { get; set; }

        public ProductInWarehouse(int warehouseId, int productId)
        {
            this.WarehouseId = warehouseId;
            this.ProductId = productId;
        }
    }
}