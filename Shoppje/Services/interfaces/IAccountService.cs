using Microsoft.AspNetCore.Identity;
using Shoppje.Models;

namespace Shoppje.Services.interfaces
{
    public interface IAccountService
    {
        public Task<IdentityResult> RegisterUserAsync(UserModel userModel);
    }
}
