using System.Collections.Generic;

namespace WHApp_API.Models
{
    public class Driver : User
    {
        public ICollection<Car> Cars { get; set; }
    }
}