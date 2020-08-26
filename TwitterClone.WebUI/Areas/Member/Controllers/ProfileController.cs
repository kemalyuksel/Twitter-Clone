using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TwitterClone.Business.Abstract;
using TwitterClone.Dto.DTOs.AppUserDtos;
using TwitterClone.Entity.Concrete;
using TwitterClone.WebUI.BaseController;

namespace TwitterClone.WebUI.Areas.Member.Controllers
{
    [Area("Member")]
    public class ProfileController : BaseIdentityController
    {

        private readonly IMapper _mapper;
        private readonly ITweetService _tweetService;
        private readonly IAppUserService _userService;

        public ProfileController(UserManager<AppUser> userManager, IAppUserService userService, IMapper mapper,
            ITweetService tweetService) : base(userManager)
        {
            _userService = userService;
            _mapper = mapper;
            _tweetService = tweetService;
        }

        public async Task<IActionResult> Index()
        {
            TempData["Active"] = "Profile";
            var user = await GetLoggedUser();


            return View();
        }

        public async Task<IActionResult> VisitorProfile(int? id)
        {
            var loggedUser = await GetLoggedUser();

            var user = await _userManager.FindByIdAsync(id.ToString());

            if (id != null)
            {
                var model = _mapper.Map<AppUserProfileHeaderDto>(user);

                model.Tweets = await _tweetService.GetAllWithUser(user.UserName);


                return View(model);
            }

            return RedirectToAction("Home", "Index");

        }



        [HttpGet]
        public async Task<IActionResult> UpdateHeader()
        {
            TempData["Active"] = "Profile";
            var loggedUser = await GetLoggedUser();

            return View(_mapper.Map<AppUserProfileUpdateDto>(await GetLoggedUser()));

        }


        [HttpPost]
        public async Task<IActionResult> UpdateHeader(AppUserProfileUpdateDto model, IFormFile Picture, IFormFile HeaderPic)
        {

            var loggedUser = await GetLoggedUser();


            if (ModelState.IsValid)
            {
                var updatedUser = _userManager.Users.FirstOrDefault(x => x.Id == model.Id);

                if (Picture != null )
                {

                    var fileName = Picture.FileName.Split(".jpg");
                    string extension = Path.GetExtension(fileName + ".png");
                    string picName = Guid.NewGuid() + extension;
                    string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/userpp/" + picName);

                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await Picture.CopyToAsync(stream);
                    }

                    updatedUser.ProfilePicture = picName;
                }
                if (HeaderPic != null)
                {
                    var fileName = HeaderPic.FileName.Split(".jpg");
                    string extension = Path.GetExtension(fileName + ".png");
                    string picName = Guid.NewGuid() + extension;
                    string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/header/" + picName);

                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await HeaderPic.CopyToAsync(stream);
                    }

                    updatedUser.HeaderPicture = picName;
                }

                updatedUser.Biography = model.Biography;
                updatedUser.Name = model.Name;
                updatedUser.SurName = model.SurName;


                var result = await _userManager.UpdateAsync(updatedUser);

                if (result.Succeeded)
                {
                    TempData["updateMessage"] = "Updated has been successfull.";
                    return RedirectToAction("UpdateHeader");
                }

                AddError(result.Errors);

            }


            return View(model);

        }






    }
}