    using System;
using System.Collections.Generic;
using System.Text;
using TwitterClone.Entity.Abstract;

namespace TwitterClone.Entity.Concrete
{
    public class Reply : IEntity
    {
        public int Id { get; set; }

        public int TweetId { get; set; }
        public Tweet Tweet { get; set; }

    }
}
