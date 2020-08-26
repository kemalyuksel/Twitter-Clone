using System;
using System.Collections.Generic;
using System.Text;
using TwitterClone.Entity.Concrete;

namespace TwitterClone.Dto.DTOs.AppUserDtos
{
    public class AppUserProfileHeaderDto
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public string ProfilePicture { get; set; } 
        public string HeaderPicture { get; set; }
        public string Biography { get; set; }
        public DateTime CreatedTime { get; set; }

        public List<Tweet> Tweets { get; set; }

    }
}
