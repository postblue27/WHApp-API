using System.Collections.Generic;
using WHApp_API.Models;

namespace WHApp_API.Dtos
{
    public class ZonesToCreateDto
    {
        public ICollection<Zone> Zones { get; set; }
    }
}