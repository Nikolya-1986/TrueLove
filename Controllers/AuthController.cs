using System.Security.Claims;
using Love.DbContext;
using Love.interfaces;
using Love.Models;
using Love.Services;
using Love.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Love.Controllers
{
    // [Route("[controller]")]
    public class AuthController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly TrueLoveDbContext _trueLoveDbContext;
        private readonly IToken _tokenService;
        public AuthController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, TrueLoveDbContext trueLoveDbContext, IToken tokenService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _trueLoveDbContext = trueLoveDbContext;
            _tokenService = tokenService;
        }
    
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new IdentityUser()
                {
                    UserName = model.Email,
                    Email = model.Email,
                };
                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, false);
                    var mainUserInfo =  new MainUserInfo()
                    {
                        Id = Guid.NewGuid(),
                        CreatedAt = DateTime.Now,
                        UpdatedAt = DateTime.Now,
                        userEmail = model.Email,
                        userName = model.Name,
                    };
                    #pragma warning disable CS8602 // Dereference of a possibly null reference.
                    _trueLoveDbContext.MainUserInfo.Add(mainUserInfo);
                    #pragma warning restore CS8602 // Dereference of a possibly null reference.
                    _trueLoveDbContext.SaveChanges();
                    return RedirectToAction("index", "Home");
                }
                
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

                ModelState.AddModelError(string.Empty, "Invalid");
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);
                HandleTokens(model);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home", new { UserEmail = model.Email });
                }
                ModelState.AddModelError(string.Empty, "Invalid credentails");
            }
            return View(model);
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();

            return RedirectToAction("Login");
        }

        private async void HandleTokens(LoginViewModel model)
        {
            var user = _trueLoveDbContext.MainUserInfo.SingleOrDefault(item => item.userEmail == model.Email);
            var userClaims = new []
            {
                new Claim(ClaimTypes.Name, user.userName),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            };
            var accessToken = _tokenService.GenerateAccessToken(userClaims);
            var refreshToken = _tokenService.GenerateRefreshToken();
            user.AccessToken = accessToken;
            user.RefreshToken = refreshToken;
            await _trueLoveDbContext.SaveChangesAsync();
        }
    }
}