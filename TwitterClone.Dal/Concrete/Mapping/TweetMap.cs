using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using TwitterClone.Entity.Concrete;

namespace TwitterClone.Dal.Concrete.Mapping
{
    public class TweetMap : IEntityTypeConfiguration<Tweet>
    {
        public void Configure(EntityTypeBuilder<Tweet> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Post).HasColumnType("ntext").IsRequired();

            builder.HasMany(x => x.Likes).WithOne(x => x.Tweet).HasForeignKey(x => x.TweeetId).OnDelete(DeleteBehavior.NoAction);
            builder.HasMany(x => x.Replies).WithOne(x => x.Tweet).HasForeignKey(x => x.TweetId);
            builder.HasMany(x => x.Retweets).WithOne(x => x.Tweet).HasForeignKey(x => x.TweetId);
            builder.HasOne(x => x.AppUser).WithMany(x => x.Tweets).HasForeignKey(x => x.AppUserId);

        }
    }
}
