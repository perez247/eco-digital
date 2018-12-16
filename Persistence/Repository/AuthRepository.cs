using System.Threading.Tasks;
using Code.Core.Interfaces;
using Code.Core.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Code.Persistence.Repository
{
    public class AuthRepository : IAuthRepository
    {
        private readonly DataContext _dbContext;
        private readonly UserManager<User> _userManager;

        public AuthRepository(DataContext dbContext, UserManager<User> userManager)
        {
            _dbContext = dbContext;
            _userManager = userManager;
        }


        public async Task<User> Login(string emailUsername, string password)
        {
            var user = await _userManager.Users.FirstOrDefaultAsync(u => u.NormalizedUserName == emailUsername.ToUpper() || u.Email.ToUpper() == emailUsername.ToUpper());
            if(user == null)
                return null;
            
            if(await _userManager.CheckPasswordAsync(user, password))
                return user;

            return null;
        }
    }
}