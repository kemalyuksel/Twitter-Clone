using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TwitterClone.Business.Abstract;
using TwitterClone.Dto.DTOs.TweetDtos;
using TwitterClone.Entity.Concrete;

namespace TwitterClone.WebUI.ViewComponents
{
    public class TweetListWUsers : ViewComponent
    {

        private readonly UserManager<AppUser> _userManager;
        private readonly ITweetService _tweetService;
        private readonly IMapper _mapper;

        public TweetListWUsers(UserManager<AppUser> userManager, IMapper mapper, ITweetService tweetService)
        {
            _userManager = userManager;
            _tweetService = tweetService;
            _mapper = mapper;
        }


        public async Task<IViewComponentResult> InvokeAsync()
        {
            var identityUser = _userManager.FindByNameAsync(User.Identity.Name).Result;

            var model = _mapper.Map<List<TweetListDto>>(await _tweetService.GetAllWithUser(x => x.PostedTime));



            return View(model);
        }


    }
}
