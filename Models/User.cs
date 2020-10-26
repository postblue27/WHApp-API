using System.Collections.Generic;

namespace WHApp_API.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public string UserType { get; set; }
        public ICollection<RenterWarehouse> RenterWarehouses { get; set; }
        public ICollection<Warehouse> UserWarehouses { get; set; }

        public User(){}
        public User(string username)
        {
            this.Username = username;
        }
        public User(string username, string userType)
        {
            this.Username = username;
            this.UserType = userType;
        }
    }
}