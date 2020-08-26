using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TwitterClone.Dal.Concrete.Mapping;
using TwitterClone.Entity.Concrete;

namespace TwitterClone.Dal.Concrete.Context
{
    public class TwitterContext : IdentityDbContext<AppUser, AppRole, int>
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=KEMSTROISI;database=TwitterDb;Integrated Security=true");
        }


        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder.ApplyConfiguration(new AppUserMap());
            builder.ApplyConfiguration(new FollowerMap());
            builder.ApplyConfiguration(new LikeMap());
            builder.ApplyConfiguration(new ReplyMap());
            builder.ApplyConfiguration(new RetweetMap());
            builder.ApplyConfiguration(new TweetMap());
            builder.ApplyConfiguration(new MessageMap());
            builder.ApplyConfiguration(new NotificationMap());

            base.OnModelCreating(builder);
        }


        public DbSet<Follower> Followers { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Like> Likes { get; set; }
        public DbSet<Reply> Replies { get; set; }
        public DbSet<Retweet> Retweets { get; set; }
        public DbSet<Tweet> Tweets { get; set; }

    }
}
