using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using TwitterClone.Entity.Concrete;

namespace TwitterClone.Dal.Concrete.Mapping
{
    public class RetweetMap : IEntityTypeConfiguration<Retweet>
    {
        public void Configure(EntityTypeBuilder<Retweet> builder)
        {
            builder.HasKey(x => new { x.TweetId, x.Id });
        }
    }
}
