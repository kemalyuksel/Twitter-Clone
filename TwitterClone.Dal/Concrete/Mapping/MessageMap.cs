using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using TwitterClone.Entity.Concrete;

namespace TwitterClone.Dal.Concrete.Mapping
{
    public class MessageMap : IEntityTypeConfiguration<Message>
    {
        public void Configure(EntityTypeBuilder<Message> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Description).HasMaxLength(1000).IsRequired();



            builder.HasOne(x => x.AppUser).WithMany(x => x.Messages).HasForeignKey(x => x.AppUserId);

        }
    }
}
