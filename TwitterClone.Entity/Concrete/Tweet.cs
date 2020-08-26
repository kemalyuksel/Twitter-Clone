using System;
using System.Collections.Generic;
using System.Text;
using TwitterClone.Entity.Abstract;

namespace TwitterClone.Entity.Concrete
{
    public class Tweet : IEntity
    {
        public int Id { get; set; }
        public string Post { get; set; }
        public DateTime PostedTime { get; set; } = DateTime.Now;

        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }

        public List<Like> Likes { get; set; }
        public List<Reply> Replies { get; set; }
        public List<Retweet> Retweets { get; set; }


    }
}
