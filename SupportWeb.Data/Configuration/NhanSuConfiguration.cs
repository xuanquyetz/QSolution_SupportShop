﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SupportWeb.Data.Entities;
using SupportWeb.Data.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace SupportWeb.Data.Configuration
{
    public class NhanSuConfiguration : IEntityTypeConfiguration<NhanSu>
    {
        public void Configure(EntityTypeBuilder<NhanSu> builder)
        {
            builder.ToTable("NhanSu");
            builder.HasKey(q => q.Ma);
            builder.Property(q => q.SoDienThoai).IsRequired().HasDefaultValue(0).HasMaxLength(11);
            builder.Property(q => q.BoPhan).HasDefaultValue(BoPhan.Support);
        }
    }
}
