using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace WHApp_API.Models
{
    public class User : IdentityUser<int>
    {
        public ICollection<Car> DriverCars { get; set; }
        public ICollection<Warehouse> OwnerWarehouses { get; set; }
        public ICollection<RenterWarehouse> RenterWarehouses { get; set; } 
        public ICollection<Product> RenterProducts { get; set; }  
        public ICollection<UserRole> UserRoles { get; set; }

        public User(){}
        public User(string username, string email)
        {
            this.UserName = username;
            this.Email = email; 
        }
        
    }
}