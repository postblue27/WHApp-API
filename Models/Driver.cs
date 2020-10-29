using System.Collections.Generic;

namespace WHApp_API.Models
{
    public class Driver : User
    {
        public ICollection<Car> Cars { get; set; }
        public Driver() {}
        public Driver(User user)
        {
            this.Username = user.Username;
            this.Email = user.Email;
            this.PasswordHash = user.PasswordHash;
            this.PasswordSalt = user.PasswordSalt;
        }
    }
}