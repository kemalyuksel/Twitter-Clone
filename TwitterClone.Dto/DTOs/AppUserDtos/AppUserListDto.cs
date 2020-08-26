using System;
using System.Collections.Generic;
using System.Text;

namespace TwitterClone.Dto.DTOs.AppUserDtos
{
    public class AppUserListDto
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public string ProfilePicture { get; set; }
        public string Biography { get; set; }
    }
}
