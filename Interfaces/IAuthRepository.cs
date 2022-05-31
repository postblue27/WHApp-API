using System.Threading.Tasks;
using WHApp_API.Dtos;
using WHApp_API.Models;

namespace WHApp_API.Interfaces
{
    public interface IAuthRepository
    {
        Task<User> RegisterAsync(UserForRegisterDto userForRegisterDto);
        Task<bool> UserExistsAsync(string username);
        Task<User> Login(string username, string userType, string password);
        Task<User> GetUser(string username, string userType);
    }
}