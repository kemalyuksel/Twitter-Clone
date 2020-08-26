using System;
using System.Collections.Generic;
using System.Text;
using TwitterClone.Entity.Abstract;

namespace TwitterClone.Entity.Concrete
{
    public class Follower : IEntity
    {
        public int Id { get; set; }

        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }



    }
}
