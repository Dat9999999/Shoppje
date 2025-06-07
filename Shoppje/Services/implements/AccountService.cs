using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Shoppje.Models;
using Shoppje.Models.ViewModels;
using Shoppje.Services.interfaces;

namespace Shoppje.Services.implements
{
    public class AccountService : IAccountService
    {
        private UserManager<AppUserModel> _userManage;
        private SignInManager<AppUserModel> _signInManager;

        public AccountService(UserManager<AppUserModel> userManage, SignInManager<AppUserModel> signInManager)
        {
            _userManage = userManage;
            _signInManager = signInManager;
        }

        public async Task<SignInResult> PasswordSignInAsync(LoginVewModel login)
        {
            SignInResult result = await _signInManager.PasswordSignInAsync(login.UserName, login.Password, false, false);
            return result;
        }

        public async Task<IdentityResult> RegisterUserAsync(UserModel user)
        {
            AppUserModel newUser = new AppUserModel { UserName = user.UserName, Email = user.Email };
            IdentityResult result = await _userManage.CreateAsync(newUser, user.Password);
            return result;
        }

        public async Task SignOutAsync(HttpContext httpContext)
        {
            await _signInManager.SignOutAsync();
            await httpContext.SignOutAsync();
        }
    }
}
