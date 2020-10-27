using System.Threading.Tasks;
using WHApp_API.Models;

namespace WHApp_API.Interfaces
{
    public interface IAuthRepository
    {
        Task<User> Register(string username, string userType, string password);
        Task<bool> UserExists(string username, string userType);
        Task<User> Login(string username, string userType, string password);
    }
}