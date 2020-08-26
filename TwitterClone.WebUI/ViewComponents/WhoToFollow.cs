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
    public class WhoToFollow : ViewComponent
    {

        private readonly UserManager<AppUser> _userManager;
        private readonly IAppUserService _userService;
        private readonly IMapper _mapper;

        public WhoToFollow(UserManager<AppUser> userManager, IMapper mapper, IAppUserService userService)
        {
            _userManager = userManager;
            _userService = userService;
            _mapper = mapper;
        }


        public async Task<IViewComponentResult> InvokeAsync()
        {
            var identityUser = _userManager.FindByNameAsync(User.Identity.Name).Result;

            var whoToFollows = _mapper.Map<List<AppUserListDto>>(await _userService.GetOtherUsers(identityUser.Id));


            return View(whoToFollows);
        }

    }
}
