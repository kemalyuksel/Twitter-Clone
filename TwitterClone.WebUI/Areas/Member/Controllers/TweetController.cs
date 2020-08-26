using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TwitterClone.Business.Abstract;
using TwitterClone.Dto.DTOs.TweetDtos;
using TwitterClone.Entity.Concrete;
using TwitterClone.WebUI.BaseController;

namespace TwitterClone.WebUI.Areas.Member.Controllers
{
    [Area("Member")]
    public class TweetController : BaseIdentityController
    {

        private readonly ITweetService _tweetService;
        private readonly IMapper _mapper;

        public TweetController(ITweetService tweetService, UserManager<AppUser> userManager, IMapper mapper) : base(userManager)
        {
            _mapper = mapper;
            _tweetService = tweetService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> AddTweet()
        {
            var user = await GetLoggedUser();
            TempData["pp"] = user.ProfilePicture;

            return PartialView();
        }


        [HttpPost]
        public async Task<IActionResult> AddTweet(TweetAdddto tweetAdddto)
        {

            var user = await GetLoggedUser();

            if (ModelState.IsValid)
            {
                tweetAdddto.AppUserId = user.Id;
                tweetAdddto.PostedTime = DateTime.Now;
                await _tweetService.AddAsync(_mapper.Map<Tweet>(tweetAdddto));
                return RedirectToAction("Index", "Home");
            }


            return RedirectToAction("Index", "Home", tweetAdddto);
        }


        [HttpPost]
        public async Task<IActionResult> DeleteTweet(int id)
        {

            var user = await GetLoggedUser();

            var tweet = await _tweetService.FindByIdAsync(id);

            await _tweetService.RemoveAsync(_mapper.Map<Tweet>(tweet));

            return RedirectToAction("Index", "Profile");
        }


    }
}