using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TwitterClone.Business.Abstract;
using TwitterClone.Entity.Concrete;
using TwitterClone.WebUI.BaseController;

namespace TwitterClone.WebUI.Areas.Member.Controllers
{
    [Area("Member")]
    public class FollowerController : BaseIdentityController
    {

        private readonly IMapper _mapper;
        private readonly IFollowerService _followerService;
        private readonly IAppUserService _userService;

        public FollowerController(UserManager<AppUser> userManager, IMapper mapper, IFollowerService followerService,
            IAppUserService userService) : base(userManager)
        {
            _userService = userService;
            _followerService = followerService;
            _mapper = mapper;
        }


        public IActionResult Index()
        {
            return View();
        }




    }
}