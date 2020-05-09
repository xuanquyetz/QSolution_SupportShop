using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SupportWeb.Data.Entities;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace SupportWeb.Data.Configuration
{
    class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.ToTable("AppUser");
            builder.Property(q => q.Ho).HasMaxLength(200).IsRequired();
            builder.Property(q => q.Ten).HasMaxLength(200).IsRequired();
            builder.Property(q => q.NgaySinh).IsRequired();
        }
    }
}
