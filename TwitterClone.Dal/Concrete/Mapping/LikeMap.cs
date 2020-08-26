using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using TwitterClone.Entity.Concrete;

namespace TwitterClone.Dal.Concrete.Mapping
{
    public class LikeMap : IEntityTypeConfiguration<Like>
    {
        public void Configure(EntityTypeBuilder<Like> builder)
        {
            builder.HasKey(x => new { x.AppUserId, x.TweeetId });
        }
    }
}
