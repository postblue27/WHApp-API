namespace WHApp_API.Models
{
    public class Admin : User
    {
        // public Admin() {}
        public int AdminIdd { get; set; } = 1;
        // public Admin(User user)
        // {
        //     this.Username = user.Username;
        //     this.Email = user.Email;
        //     this.PasswordHash = user.PasswordHash;
        //     this.PasswordSalt = user.PasswordSalt;
        // }
    }
}