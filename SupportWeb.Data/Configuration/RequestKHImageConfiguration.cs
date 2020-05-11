using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SupportWeb.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SupportWeb.Data.Configuration
{
    class RequestKHImageConfiguration : IEntityTypeConfiguration<RequestKHImage>
    {
        public void Configure(EntityTypeBuilder<RequestKHImage> builder)
        {
            builder.ToTable("RequetKHImage");
            builder.HasKey(q => q.Ma);
            builder.Property(q => q.ImagePath).HasMaxLength(200).IsRequired(true);
            builder.Property(q => q.Caption).HasMaxLength(200).IsRequired();
            builder.HasOne(q => q.RequestKH).WithMany(k => k.RequestKHImage).HasForeignKey(q => q.RequestKHMa);
        }
    }
}
