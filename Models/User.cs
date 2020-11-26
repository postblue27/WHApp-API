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

        public User(){}
        public User(string username)
        {
            this.Username = username;
        }
        public User(string username, string email)
        {
            this.Username = username;
            this.Email = email;
        }
    }
}