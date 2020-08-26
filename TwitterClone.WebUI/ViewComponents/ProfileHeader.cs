using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TwitterClone.Business.Abstract;
using TwitterClone.Dto.DTOs.AppUserDtos;
using TwitterClone.Entity.Concrete;

namespace TwitterClone.WebUI.ViewComponents
{

    public class ProfileHeader : ViewComponent
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly ITweetService _tweetService;
        private readonly IMapper _mapper;

        public ProfileHeader(UserManager<AppUser> userManager, IMapper mapper, ITweetService tweetService)
        {
            _userManager = userManager;
            _tweetService = tweetService;
            _mapper = mapper;
        }


        public async Task<IViewComponentResult> InvokeAsync()
        {
            var identityUser = _userManager.FindByNameAsync(User.Identity.Name).Result;

            var model = _mapper.Map<AppUserProfileHeaderDto>(identityUser);



            model.Tweets = await _tweetService.GetAllWithUser(identityUser.UserName);


            return View(model);
        }
    }
}