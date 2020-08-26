using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TwitterClone.Business.Abstract;
using TwitterClone.Dto.DTOs.NotificationDtos;
using TwitterClone.Entity.Concrete;

namespace TwitterClone.WebUI.ViewComponents
{
    public class LeftNavbar : ViewComponent
    {

        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;
        private readonly INotificationService _notificationService;

        public LeftNavbar(UserManager<AppUser> userManager, IMapper mapper, INotificationService notificationService)
        {
            _userManager = userManager;
            _notificationService = notificationService;
            _mapper = mapper;
        }


        public async Task<IViewComponentResult> InvokeAsync()
        {
            var identityUser = _userManager.FindByNameAsync(User.Identity.Name).Result;

            ViewBag.notifyCount = _mapper.Map<List<NotificationListDto>>(await _notificationService.GetAllUnViewed(identityUser.Id)).Count();

            return View();
        }

    }
}
