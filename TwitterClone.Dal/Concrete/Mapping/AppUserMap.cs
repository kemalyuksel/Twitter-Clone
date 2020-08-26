using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using TwitterClone.Entity.Concrete;

namespace TwitterClone.Dal.Concrete.Mapping
{
    public class AppUserMap : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {

            builder.Property(x => x.Name).HasMaxLength(50).IsRequired();
            builder.Property(x => x.SurName).HasMaxLength(50).IsRequired();
            builder.Property(x => x.HeaderPicture).HasMaxLength(100).IsRequired();
            builder.Property(x => x.ProfilePicture).HasMaxLength(100).IsRequired();
            builder.Property(x => x.Biography).HasMaxLength(200);


            builder.HasMany(x => x.Likes).WithOne(x => x.AppUser).HasForeignKey(x => x.AppUserId);
            builder.HasMany(x => x.Tweets).WithOne(x => x.AppUser).HasForeignKey(x => x.AppUserId);
            builder.HasMany(x => x.Followers).WithOne(x => x.AppUser).HasForeignKey(x => x.AppUserId);

        }
    }
}
