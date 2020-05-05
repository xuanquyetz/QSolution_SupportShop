using Microsoft.EntityFrameworkCore;
using SupportWeb.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SupportWeb.Data.EF
{
    public class SupportShopDbContext : DbContext
    {
        public SupportShopDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<NhanSu> NhanSus { set; get; }
        public DbSet<KhachHang> KhachHangs { set; get; }
        public DbSet<RequestKH> RequestKHs { set; get; }
    }

}
