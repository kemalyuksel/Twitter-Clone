using System;
using System.Collections.Generic;
using System.Text;
using TwitterClone.Entity.Abstract;

namespace TwitterClone.Entity.Concrete
{
    public class Like : IEntity
    {
        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }

        public int TweeetId { get; set; }
        public Tweet Tweet { get; set; }
    }
}
