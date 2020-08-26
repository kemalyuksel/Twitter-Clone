using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using TwitterClone.Entity.Abstract;

namespace TwitterClone.Entity.Concrete
{
    public class AppUser : IdentityUser<int>, IEntity
    {
        public string Name { get; set; }
        public string SurName { get; set; }
        public string Biography { get; set; }
        public string ProfilePicture { get; set; } = "defaultpp.jpeg";
        public string HeaderPicture { get; set; } = "defaultheader.jpeg";
        public DateTime CreatedTime { get; set; } = DateTime.Now;


        public List<Like> Likes { get; set; }
        public List<Message> Messages { get; set; }
        public List<Notification> Notifications { get; set; }
        public List<Tweet> Tweets { get; set; }
        public List<Follower> Followers { get; set; }



    }
}
