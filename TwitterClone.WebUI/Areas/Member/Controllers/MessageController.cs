using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using TwitterClone.Business.Abstract;
using TwitterClone.Dto.DTOs.AppUserDtos;
using TwitterClone.Dto.DTOs.MessageDtos;
using TwitterClone.Entity.Concrete;
using TwitterClone.WebUI.BaseController;

namespace TwitterClone.WebUI.Areas.Member.Views.Controllers
{
    [Area("Member")]
    public class MessageController : BaseIdentityController
    {
        private readonly IMapper _mapper;
        private readonly IAppUserService _userService;
        private readonly INotificationService _notificationService;
        private readonly IMessageService _messageService;


        public MessageController(UserManager<AppUser> userManager, IMapper mapper, IAppUserService userService,
            IMessageService messageService, INotificationService notificationService) : base(userManager)
        {
            _messageService = messageService;
            _notificationService = notificationService;
            _userService = userService;
            _mapper = mapper;
        }


        public async Task<IActionResult> Index()
        {
            TempData["Active"] = "Message";
            var user = await GetLoggedUser();


            var model = _mapper.Map<List<UserMessagesDto>>(await _messageService.GetAllAsync(x => x.RefId == user.Id, x => x.PostedTime));


            return View(model);
        }

        public async Task<IActionResult> MessageDetail(int id)
        {
            TempData["Active"] = "Message";
            var activeUser = await GetLoggedUser();
            TempData["userId"] = id;



            var model = _mapper.Map<List<Message>>(await _messageService.GetOneToOneMessages(activeUser.Id, id));

            return View(model);

        }

        [HttpPost]
        public async Task<IActionResult> AddMessage(string s)
        {
            TempData["Active"] = "Message";
            var activeUser = await GetLoggedUser();

            int secondUserId = (int)TempData["userId"];

            var secondUser = await _userManager.FindByIdAsync(secondUserId.ToString());

            if (!string.IsNullOrWhiteSpace(s))
            {
                var msj = new Message();
                msj.Description = s;
                await _messageService.AddMessage(msj, activeUser.Id, secondUserId);

                await _notificationService.AddAsync(new Notification
                {
                    Description = $"{"@" + activeUser.UserName} ",
                    AppUserId = secondUser.Id,
                });

               



            }


            return RedirectToAction("MessageDetail", new { id = secondUserId });

        }



    }
}