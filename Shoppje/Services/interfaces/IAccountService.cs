using Microsoft.AspNetCore.Identity;
using Shoppje.Models;
using Shoppje.Models.ViewModels;

namespace Shoppje.Services.interfaces
{
    public interface IAccountService
    {
        public Task<SignInResult> PasswordSignInAsync(LoginVewModel login);
        public Task<IdentityResult> RegisterUserAsync(UserModel userModel);
        Task SignOutAsync(HttpContext httpContext);
    }
}
