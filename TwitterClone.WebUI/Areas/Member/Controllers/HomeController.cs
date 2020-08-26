using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TwitterClone.Business.Abstract;
using TwitterClone.Dto.DTOs.AppUserDtos;
using TwitterClone.Dto.DTOs.TweetDtos;
using TwitterClone.Entity.Concrete;
using TwitterClone.WebUI.BaseController;

namespace TwitterClone.WebUI.Areas.Member.Controllers
{
    [Area("Member")]
    public class HomeController : BaseIdentityController
    {

        private readonly IMapper _mapper;
        private readonly ITweetService _tweetService;
        private readonly IAppUserService _userService;

        public HomeController(UserManager<AppUser> userManager, IMapper mapper, ITweetService tweetService,
            IAppUserService userService) : base(userManager)
        {
            _userService = userService;
            _tweetService = tweetService;
            _mapper = mapper;
        }



        public async Task<IActionResult> Index()
        {
            TempData["Active"] = "Home";
            var user = await GetLoggedUser();
            TempData["pp"] = user.ProfilePicture;



            return View();
        }


        public async Task<IActionResult> Search(string s)
        {
            TempData["Active"] = "Home";
            var user = await GetLoggedUser();

            ViewBag.ıd = user.Id;
            ViewBag.key = s;

            if (string.IsNullOrWhiteSpace(s))
            {
                return RedirectToAction("Index");
            }
            var model = _mapper.Map<List<AppUserListDto>>(await _userService.GetAllAsync
                (x => x.Name.ToLower().Contains(s.ToLower()) || x.SurName.ToLower().Contains(s.ToLower()) || x.UserName.ToLower().Contains(s.ToLower())));

            return View(model);
        }






    }
}