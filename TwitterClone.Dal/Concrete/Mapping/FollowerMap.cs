using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using TwitterClone.Entity.Concrete;

namespace TwitterClone.Dal.Concrete.Mapping
{
    public class FollowerMap : IEntityTypeConfiguration<Follower>
    {
        public void Configure(EntityTypeBuilder<Follower> builder)
        {


            builder.HasKey(x => new { x.AppUserId, x.Id });

        }
    }
}
