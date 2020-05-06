using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SupportWeb.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SupportWeb.Data.Configuration
{
    public class KhachHangConfiguration : IEntityTypeConfiguration<KhachHang>
    {
        public void Configure(EntityTypeBuilder<KhachHang> builder)
        {
            builder.ToTable("KhacHang");
            builder.HasKey(q => q.Ma);
            builder.HasKey(q => new { q.NhanSuPhuTrachMa });
            builder.Property(q => q.SoDienThoai).IsRequired().HasDefaultValue(0).HasMaxLength(11);
            builder.HasOne(q => q.NhanSu).WithMany(k => k.KhachHang).HasForeignKey(q => q.NhanSuPhuTrachMa);
        }
    }
}
