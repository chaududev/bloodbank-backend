using Domain.Model.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BloodBank.Controllers
{
    [AllowAnonymous]
    public class AuthController : Controller
    {

        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<User> _signInManager;
        public AuthController(UserManager<User> userManager, RoleManager<IdentityRole> roleManager, SignInManager<User> signInManager)
        {
            this._userManager = userManager;
            this._roleManager = roleManager;
            this._signInManager = signInManager;
        }
        public IActionResult Index()
        {
            ViewBag.Message = TempData["Message"];
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> LoginAsync(string username, string password)
        {
            var user = await _userManager.FindByNameAsync(username);
            if (user == null)
            {
                TempData["Message"] = "Username doesn't exist !";
            }
            else
            {
                var response = await _signInManager.PasswordSignInAsync(user, password, true, true);
                if (response.Succeeded)
                {
                    return Redirect("/");
                }
                else
                {
                    TempData["Message"] = "The Username or Password is Incorrect!";
                }
            }
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> LogoutAsync()
        {
            await _signInManager.SignOutAsync();
            return Redirect("/");
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> RegisterAsync(string username, string password, string fullname,DateTime birthday)
        {
            var user = new User()
            {
                UserName = username,
                EmailConfirmed = true
            };
            user.Set(fullname,birthday);
            var userCurrent = await _userManager.FindByNameAsync(username);
            if (userCurrent != null)
            {
                ViewData["Message"] = "Username is exist !";
            }
            var createResponse = await _userManager.CreateAsync(user, password);
            if (createResponse.Succeeded)
            {
                var role = await _roleManager.FindByNameAsync("USER");
                if (role == null)
                {
                    role = new IdentityRole()
                    {
                        Name = "USER",
                    };

                    var responseRole = await _roleManager.CreateAsync(role);
                }
                var responseAddRoleToUser = await _userManager.AddToRoleAsync(user, role.Name);
                if (responseAddRoleToUser.Succeeded)
                {
                    ViewData["Message"] = "Register Success!";
                }
                else
                {
                    ViewData["Message"] = "Register Failed ! Please check and try again !";
                }
            }
            return View();
        }
    }
}
