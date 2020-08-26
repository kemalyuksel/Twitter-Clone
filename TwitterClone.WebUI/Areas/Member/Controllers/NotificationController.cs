using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TwitterClone.Business.Abstract;
using TwitterClone.Dto.DTOs.AppUserDtos;
using TwitterClone.Dto.DTOs.NotificationDtos;
using TwitterClone.Entity.Concrete;
using TwitterClone.WebUI.BaseController;

namespace TwitterClone.WebUI.Areas.Member.Controllers
{
    [Area("Member")]
    public class NotificationController : BaseIdentityController
    {
        private readonly INotificationService _notificationService;
        private readonly IMapper _mapper;
        private readonly IAppUserService _userService;

        public NotificationController(INotificationService notificationService, UserManager<AppUser> userManager,
            IAppUserService userService, IMapper mapper) : base(userManager)
        {
            _notificationService = notificationService;
            _userService = userService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            TempData["Active"] = "Notification";
            var user = await GetLoggedUser();


            var model = _mapper.Map<List< NotificationListDto >>(await _notificationService.GetAllUnViewed(user.Id));

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Index(int id)
        {
            TempData["Active"] = "Notification";

            var updatedNotification = await _notificationService.FindByIdAsync(id);
            updatedNotification.Status = true;

            await _notificationService.UpdateAsync(updatedNotification);

            return RedirectToAction("Index","Message");
        }


    }
}