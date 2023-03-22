using Application.IService;
using BloodBank.Mapper;
using BloodBank.ViewModels;
using Domain.Model.Base;
using Domain.Model.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;

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
                JWToken token = UserService.GenerateJwtToken(user, roleName);
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
        [Authorize(Roles = "ADMIN")]
        public async Task<IActionResult> Register([FromBody] RegisterViewModel model)
        {
            var user = new User(model.UserName, model.FullName, model.Email, model.Birthday, model.Address);
            if (model.HospitalId != null) { user.SetHospital(model.HospitalId); }
            User userFind = await _userManager.FindByNameAsync(model.UserName);
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
                var role = await _roleManager.FindByNameAsync(model.Role.ToString());
                if (role == null)
                {
                    role = new IdentityRole()
                    {
                        Name = model.Role.ToString(),
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
        [HttpPut("{id}")]
        [Authorize(Roles = "ADMIN")]
        public async Task<IActionResult> Edit(string id, [FromBody] UserEditViewModel model)
        {

            User userFind = await _userManager.FindByIdAsync(id);
            if (userFind == null)
            {
                return BadRequest("User not exist");
            }
            userFind.Update(model.UserName, model.FullName, model.Email, model.Birthday, model.Address);
            if (model.HospitalId != null) { userFind.SetHospital(model.HospitalId); }
            if (model.Password != null)
            {
                var newPasswordHash = _userManager.PasswordHasher.HashPassword(userFind, model.Password);
                userFind.PasswordHash = newPasswordHash;
            }
            var rs = await _userManager.UpdateAsync(userFind);

            if (!rs.Succeeded)
            {
                return BadRequest(rs.Errors);
            }
            var roles = await _userManager.GetRolesAsync(userFind);
            string oleRole = roles[0];
            if (String.CompareOrdinal(model.Role.ToString(), oleRole) != 0)
            {
                var result = await _userManager.RemoveFromRolesAsync(userFind, roles);
                if (result.Succeeded)
                {
                    var roleName = await _roleManager.FindByNameAsync(model.Role.ToString());
                    if (roleName == null)
                    {
                        roleName = new IdentityRole()
                        {
                            Name = model.Role.ToString(),
                        };

                        var responseRole = await _roleManager.CreateAsync(roleName);
                    }
                    var responseAddRoleToUser = await _userManager.AddToRoleAsync(userFind, roleName.Name);
                    if (responseAddRoleToUser.Succeeded)
                    {
                        return Ok();
                    }
                    else
                    {
                        return BadRequest(result.Errors);
                    }
                }
                return BadRequest("Failed");
            }
            return Ok();
        }
        [HttpGet]
        [Authorize(Roles = "ADMIN")]
        public async Task<IActionResult> Get(string? role, int? hospitalId, int? pageSize, int? page)
        {
            try
            {
                IEnumerable<User> users = await _userManager.Users.Include(e => e.Hospital).ToListAsync();
                if (role != null)
                {
                    users = (IEnumerable<User>)await _userManager.GetUsersInRoleAsync(role);
                }
                if (hospitalId != null)
                {
                    users = users.Where(e => e.HospitalId == hospitalId).ToList();
                }
                var total = users.Count();
                //users =users.Skip((page??1 - 1) * pageSize??int.MaxValue).Take(pageSize??int.MaxValue);
                var count = users.Count();
                var result = new List<UserViewModel>();
                foreach (var user in users)
                {
                    var roles = await _userManager.GetRolesAsync(user);
                    string oleRole = roles[0].ToUpper();
                    UserViewModel userWithRoles = mapperUser.Map(user);
                    userWithRoles.Role = (Role)Enum.Parse(typeof(Role), oleRole);
                    result.Add(userWithRoles);
                }
                IEnumerable<UserViewModel> data = result;
                return Ok(new PagingResponse()
                {
                    Count = count,
                    TotalCount = total,
                    Data = data
                });
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpDelete("{id}")]
        [Authorize(Roles = "ADMIN")]
        public async Task<IActionResult> Delele(string id)
        {
            User user = await _userManager.FindByIdAsync(id);

            if (user == null)
            {
                return BadRequest("Username doesn't exist");
            }
            else
            {
                var response = await _userManager.DeleteAsync(user);
                if (response.Succeeded)
                {
                    return Ok();
                }
                else
                {
                    return BadRequest("Failed");
                }
            }
        }
        [HttpPost("ChangeRole")]
        [Authorize(Roles = "ADMIN")]
        public async Task<IActionResult> ChangeRole(string id, string role)
        {
            User user = await _userManager.FindByIdAsync(id);
            role = role.ToUpper();
            if (user == null)
            {
                return BadRequest("Username doesn't exist");
            }
            if (String.CompareOrdinal(role, "ADMIN") != 0 && String.CompareOrdinal(role, "USER") != 0 && String.CompareOrdinal(role, "STAFF") != 0 && String.CompareOrdinal(role, "HOSPITAL") != 0)
            {
                return BadRequest("Role invalid");
            }
            else
            {
                var roles = await _userManager.GetRolesAsync(user);
                var result = await _userManager.RemoveFromRolesAsync(user, roles);
                if (result.Succeeded)
                {
                    var roleName = await _roleManager.FindByNameAsync(role);
                    if (roleName == null)
                    {
                        roleName = new IdentityRole()
                        {
                            Name = role,
                        };

                        var responseRole = await _roleManager.CreateAsync(roleName);
                    }
                    var responseAddRoleToUser = await _userManager.AddToRoleAsync(user, roleName.Name);
                    if (responseAddRoleToUser.Succeeded)
                    {
                        return Ok();
                    }
                    else
                    {
                        return BadRequest("Failed");
                    }
                }
                return BadRequest("Failed");
            }
        }

    }
}