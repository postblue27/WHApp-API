using System.Threading.Tasks;
using WHApp_API.Dtos;
using WHApp_API.Models;

namespace WHApp_API.Interfaces
{
    public interface IAuthRepository
    {
        Task<object> Register(UserForRegisterDto userForRegisterDto);
        Task<bool> UserExists(string username, string userType);
        Task<User> Login(string username, string userType, string password);
        Task<User> GetUser(string username, string userType);
    }
}