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
            // builder.HasKey(q => new { q.NhanSuPhuTrachMa });
            builder.Property(q => q.Ten).HasMaxLength(100);
            builder.Property(q => q.ThongTinSupport).HasMaxLength(200);
            builder.Property(q => q.DiaChi).HasMaxLength(500);
            builder.Property(q => q.SoDienThoai).HasDefaultValue(0).IsRequired();
            builder.Property(q => q.Email).HasMaxLength(100);
            builder.Property(q => q.NguoiChiuTrachNhiem).HasMaxLength(100);
            builder.Property(q => q.SoDienThoai).IsRequired().HasDefaultValue(0).HasMaxLength(11);
           // builder.HasOne(q => q.NhanSu).WithMany(k => k.KhachHang).HasForeignKey(q => q.NhanSuPhuTrachMa);
        }
    }
}
