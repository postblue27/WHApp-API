using System.Collections.Generic;

namespace WHApp_API.Models
{
    public class Renter : User
    {
        public ICollection<RenterWarehouse> RenterWarehouses { get; set; }        
        public Renter()
        {
            
        }
        public Renter(User user)
        {
            this.Username = user.Username;
            this.Email = user.Email;
            this.PasswordHash = user.PasswordHash;
            this.PasswordSalt = user.PasswordSalt;
        }
    }
}