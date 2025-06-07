using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Shoppje.Models;
using Shoppje.Services.interfaces;

namespace Shoppje.Controllers
{
    public class AccountController : Controller
    {
        private UserManager<AppUserModel> _userManage;
        private SignInManager<AppUserModel> _signInManager;
        private readonly IAccountService _accountService;
        private readonly ILogger<AccountController> _logger;
        public AccountController(UserManager<AppUserModel> userManage, SignInManager<AppUserModel> signInManager,
            ILogger<AccountController> logger, IAccountService accountService)
        {
            _userManage = userManage;
            _signInManager = signInManager;
            _logger = logger;
            _accountService = accountService;
        }
        public IActionResult login()
        {
            return View();
        }
        public async Task<IActionResult> Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> RegisterProcessing(UserModel user)
        {
            if (ModelState.IsValid)
            {
                IdentityResult result = _accountService.RegisterUserAsync(user).Result;
                if (result.Succeeded)
                {
                    TempData["success"] = "Register user successfully";
                    return Redirect("/account/login");
                }
                foreach (IdentityError error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            _logger.LogWarning("User registration failed. Errors: {Errors}", ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage));
            _logger.LogInformation("User registration failed. ModelState is valid: {IsValid}", ModelState.IsValid);
            // Return the view with the model to show errors
            return View("Register", user);
        }
    }
}


