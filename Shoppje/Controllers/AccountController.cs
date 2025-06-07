using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Shoppje.Models;

namespace Shoppje.Controllers
{
    public class AccountController : Controller
    {
        private UserManager<AppUserModel> _userManage;
        private SignInManager<AppUserModel> _signInManager;
        private readonly ILogger<AccountController> _logger;
        public AccountController(UserManager<AppUserModel> userManage, SignInManager<AppUserModel> signInManager, ILogger<AccountController> logger)
        {
            _userManage = userManage;
            _signInManager = signInManager;
            _logger = logger;
        }
        public IActionResult Index()
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
                AppUserModel newUser = new AppUserModel { UserName = user.UserName, Email = user.Email };
                IdentityResult result = await _userManage.CreateAsync(newUser, user.Password);
                if (result.Succeeded)
                {
                    TempData["success"] = "Register user successfully";
                    return Redirect("/account/");
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


