﻿using BloodBank.ViewModels;
using Domain.Model.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using System.Net.Http;

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
        public async Task<IActionResult> LoginAsync(LoginViewModel login)
        {
            var user = await _userManager.FindByNameAsync(login.Username);
            if (user == null)
            {
                TempData["Message"] = "Username doesn't exist !";
            }
            else
            {
                user = await _userManager.FindByNameAsync(login.Username);
                var response = await _signInManager.PasswordSignInAsync(user, login.Password, true, true);
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
        public async Task<IActionResult> RegisterAsync(RegisterViewModel model)
        {
            var user = new User(model.UserName, model.FullName, model.Email, model.Birthday, model.Address);
            var userCurrent = await _userManager.FindByNameAsync(model.UserName);
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors);
                foreach (var error in errors)
                {
                    ViewData["Message"] = error.ErrorMessage;
                }
            }

            else if (userCurrent != null)
            {
                ViewData["Message"] = "Username is exist !";
            }
            else 
            {
                var createResponse = await _userManager.CreateAsync(user, model.Password);
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
                else ViewData["Message"] = "Register Failed ! Please check and try again !";
            }
            return View();
        }
    }
}