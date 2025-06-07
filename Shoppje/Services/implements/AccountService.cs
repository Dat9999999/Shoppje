using Microsoft.AspNetCore.Identity;
using Shoppje.Models;
using Shoppje.Services.interfaces;

namespace Shoppje.Services.implements
{
    public class AccountService : IAccountService
    {
        private UserManager<AppUserModel> _userManage;
        public AccountService(UserManager<AppUserModel> userManage)
        {
            _userManage = userManage;
        }
        public async Task<IdentityResult> RegisterUserAsync(UserModel user)
        {
            AppUserModel newUser = new AppUserModel { UserName = user.UserName, Email = user.Email };
            IdentityResult result = await _userManage.CreateAsync(newUser, user.Password);
            return result;
        }
    }
}
