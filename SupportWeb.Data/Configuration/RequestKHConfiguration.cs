using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SupportWeb.Data.Entities;
using SupportWeb.Data.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace SupportWeb.Data.Configuration
{
    public class RequestKHConfiguration : IEntityTypeConfiguration<RequestKH>
    {
        public void Configure(EntityTypeBuilder<RequestKH> builder)
        {
            builder.ToTable("RequestKH");
            builder.HasKey(q => q.Ma);
            builder.HasKey(q => new { q.KhachHangMa,q.KyThuatMa,q.CodeMa});
            builder.Property(q => q.CodeMa).IsRequired(true);
            builder.Property(q => q.KhachHangMa).IsRequired(true);
            builder.Property(q => q.KyThuatMa).IsRequired(true);
            builder.Property(q => q.TrangThai).HasDefaultValue(TrangThai.DangCho);
            builder.Property(q => q.Stt).IsRequired(true);
            builder.HasOne(q => q.KhachHang).WithMany(x => x.RequestKH).HasForeignKey(x => x.KhachHangMa);
            builder.HasOne(q => q.NhanSu).WithMany(x => x.RequestKH).HasForeignKey(x => x.KyThuatMa).HasForeignKey(x => x.CodeMa);
        }
    }
}
