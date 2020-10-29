namespace WHApp_API.Dtos
{
    public class ProductToAddDto
    {
        public string ProductName { get; set; }
        public string Description { get; set; }
        public string ProductCode { get; set; }
        public int Volume { get; set; }
        public string Username { get; set; }
        public int WarehouseId { get; set; }
        public int ZoneId { get; set; }
    }
}