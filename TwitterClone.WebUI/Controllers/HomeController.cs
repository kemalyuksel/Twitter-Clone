using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TwitterClone.Dto.DTOs.AppUserDtos;
using TwitterClone.Entity.Concrete;
using TwitterClone.WebUI.BaseController;

namespace TwitterClone.WebUI.Controllers
{
    public class HomeController : BaseIdentityController
    {
        private readonly SignInManager<AppUser> _signInManager;

        public HomeController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager) : base(userManager)
        {
            _signInManager = signInManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(AppUserRegisterDto model)
        {
            if (ModelState.IsValid)
            {
                AppUser user = new AppUser
                {
                    Name = model.Name,
                    SurName = model.SurName,
                    UserName = model.UserName,
                    Email = model.Email
                };

                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    var addRoleResult = await _userManager.AddToRoleAsync(user, "Member");
                    if (addRoleResult.Succeeded)
                    {

                        return RedirectToAction("Index");
                    }
                    AddError(addRoleResult.Errors);
                }

                AddError(result.Errors);

            }

            return View(model);
        }


        [HttpPost]
        public async Task<IActionResult> SignIn(AppUserLoginDto model)
        {

            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByNameAsync(model.UserName);

                if (user != null)
                {
                    var identityResult = await _signInManager.PasswordSignInAsync(model.UserName, model.Password, model.RememberMe, false);

                    if (identityResult.Succeeded)
                    {
                        var userRoles = await _userManager.GetRolesAsync(user);


                        return RedirectToAction("Index", "Home", new { area = "Member" });

                    }
                }
                ModelState.AddModelError("", "Kullanıcı adı veya şifre hatalı.");

            }


            return View("Index", model);
        }

        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index");
        }

    }
}