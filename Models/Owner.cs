using System.Collections.Generic;

namespace WHApp_API.Models
{
    public class Owner : User
    {
        public ICollection<Warehouse> Warehouses { get; set; }
        public Owner()
        {
            
        }
        public Owner(User user)
        {
            this.Username = user.Username;
            this.Email = user.Email;
            this.PasswordHash = user.PasswordHash;
            this.PasswordSalt = user.PasswordSalt;
        }
    }
}