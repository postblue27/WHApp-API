namespace WHApp_API.Models
{
    public class RenterWarehouse
    {
        public int RenterWarehouseId { get; set; }
        public int UserId { get; set; }
        public Renter Renter { get; set; }
        public int WarehouseId { get; set; }
        public Warehouse Warehouse { get; set; }
    }
}