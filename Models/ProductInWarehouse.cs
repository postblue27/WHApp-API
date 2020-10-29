namespace WHApp_API.Models
{
    public class ProductInWarehouse
    {
        public int ProductInWarehouseId { get; set; }
        public int WarehouseId { get; set; }
        public Warehouse Warehouse { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int ZoneId { get; set; }
        public Zone Zone { get; set; }
        public ProductForShipping ProductForShipping { get; set; }

        public ProductInWarehouse(int warehouseId, int productId, int zoneId)
        {
            this.WarehouseId = warehouseId;
            this.ProductId = productId;
            this.ZoneId = zoneId;
        }
    }
}