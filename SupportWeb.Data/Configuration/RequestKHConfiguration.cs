using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SupportWeb.Data.Entities;
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
            builder.Property(q => q.CodeMa).IsRequired(true);
            builder.Property(q => q.KhachHangMa).IsRequired(true);
            builder.Property(q => q.KyThuatMa).IsRequired(true);
            builder.Property(q => q.TrangThai).IsRequired(true);
            builder.Property(q => q.Stt).IsRequired(true);
        }
    }
}
