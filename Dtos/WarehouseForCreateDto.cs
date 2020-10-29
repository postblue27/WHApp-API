namespace WHApp_API.Dtos
{
    public class WarehouseForCreateDto
    {
        public int WarehouseCode { get; set; }
        public string Location { get; set; }
        public int Capacity { get; set; }
        public int OwnerId { get; set; }
    }
}