using System.Collections.Generic;

namespace WHApp_API.Models
{
    public class Renter : User
    {
        public ICollection<RenterWarehouse> RenterWarehouses { get; set; }        
    }
}