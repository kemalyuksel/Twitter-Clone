using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using TwitterClone.Entity.Concrete;

namespace TwitterClone.Dal.Concrete.Mapping
{
    public class NotificationMap : IEntityTypeConfiguration<Notification>
    {
        public void Configure(EntityTypeBuilder<Notification> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Description).HasMaxLength(100).IsRequired();


            builder.HasOne(x => x.AppUser).WithMany(x => x.Notifications).HasForeignKey(x => x.AppUserId);

        }
    }
}
