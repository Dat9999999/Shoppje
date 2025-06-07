using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Shoppje.Models;
using Shoppje.Models.ViewModels;
using Shoppje.Services.interfaces;

namespace Shoppje.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;
        private readonly ILogger<AccountController> _logger;
        public AccountController(
            ILogger<AccountController> logger, IAccountService accountService)
        {
            _logger = logger;
            _accountService = accountService;
        }
        public IActionResult login(string returnUrl)
        {
            return View(new LoginVewModel { ReturnUrl = returnUrl });
        }

        public async Task<IActionResult> loginProcessingAsync(LoginVewModel login)
        {
            if (ModelState.IsValid)
            {
                Microsoft.AspNetCore.Identity.SignInResult result = _accountService.PasswordSignInAsync(login).Result;
                if (result.Succeeded)
                {
                    return Redirect(login.ReturnUrl ?? "/");
                }
                
            }
            _logger.LogWarning("User registration failed. Errors: {Errors}", ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage));
            _logger.LogInformation("User registration failed. ModelState is valid: {IsValid}", ModelState.IsValid);
            TempData["error"] = "Login failed. Please check your username and password.";
            // Return the view with the model to show errors
            return View("login", login);
        }
        public async Task<IActionResult> Logout(string returnUrl = "/")
        {
            var httpContext = HttpContext;
            await _accountService.SignOutAsync(httpContext);
            TempData["success"] = "Logout successfully";
            return Redirect(returnUrl);
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


