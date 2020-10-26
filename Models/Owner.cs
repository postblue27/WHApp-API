using System.Collections.Generic;

namespace WHApp_API.Models
{
    public class Owner : User
    {
        public ICollection<Warehouse> OwnerWarehouses { get; set; }
    }
}