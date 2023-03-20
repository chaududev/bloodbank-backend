using Application.IService;
using BloodBank.Mapper;
using BloodBank.ViewModels;
using Domain.Model.Base;
using Domain.Model.Posts;
using Domain.Model.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Web;
namespace BloodBank.ApiControllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IUserService UserService;
        readonly MappingService<User, UserViewModel> mapperUser;
        public AuthController(UserManager<User> userManager, RoleManager<IdentityRole> roleManager, SignInManager<User> signInManager, IUserService UserService)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
            this.UserService = UserService;
            this.mapperUser = new MappingService<User, UserViewModel>();
        }
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginViewModel model)
        {
            User user = await _userManager.FindByNameAsync(model.Username);
            

            if (user == null)
            {
                return BadRequest("Username doesn't exist");
            }

            var result = await _signInManager.PasswordSignInAsync(user, model.Password, false, false);

            if (!result.Succeeded)
            {
                return BadRequest("Invalid credentials");
            }
            try
            {
                var roles = await _userManager.GetRolesAsync(user);
                var roleName = roles.FirstOrDefault();
                JWToken token = UserService.GenerateJwtToken(user,roleName);
                UserViewModel User = mapperUser.Map(user);
                JWTokenViewModel tokenViewModel = new JWTokenViewModel
                {
                    Token = token.Token,
                    Expires = token.Expires,
                    User = User
                };
                return Ok(tokenViewModel);
            }

            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        [Route("logout")]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();

            return Ok();
        }
        
        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] RegisterViewModel model)
        {
            var user = new User(model.Username, model.FullName, model.Email, model.Birthday, model.Address);
            User userFind = await _userManager.FindByNameAsync(model.Username);
            if (userFind != null)
            {
                return BadRequest("Username exist");
            }
            var result = await _userManager.CreateAsync(user, model.Password);

            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }
            else
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
                    return Ok();
                }
                else
                {
                    return BadRequest("Failed");
                }
            }
        }
        
    }
}
