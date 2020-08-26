using System;
using System.Collections.Generic;
using System.Text;

namespace TwitterClone.Dto.DTOs.AppUserDtos
{
    public class AppUserLoginDto
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}
