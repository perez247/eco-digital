using System.Threading.Tasks;
using Code.Core.Models;

namespace Code.Core.Interfaces
{
    public interface IAuthRepository
    {
        Task<User> Login(string emailUsername, string password);
        Task<User> Register(User user, string password);
    }
}