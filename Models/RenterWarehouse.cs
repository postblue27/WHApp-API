namespace WHApp_API.Models
{
    public class RenterWarehouse
    {
        public int Id { get; set; }
        public int RenterId { get; set; }
        public Renter Renter { get; set; }
        public int WarehouseId { get; set; }
        public Warehouse Warehouse { get; set; }
    }
}