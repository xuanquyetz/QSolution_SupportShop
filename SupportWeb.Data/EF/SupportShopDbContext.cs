using Microsoft.EntityFrameworkCore;
using SupportWeb.Data.Entities;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using SupportWeb.Data.Configuration;
using SupportWeb.Data.Extensions;

namespace SupportWeb.Data.EF
{
    public class SupportShopDbContext : DbContext
    {
        public SupportShopDbContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Configure using Fluent API-- Cau hinh bang Fluent API
            modelBuilder.ApplyConfiguration(new KhachHangConfiguration());
            modelBuilder.ApplyConfiguration(new NhanSuConfiguration());
            modelBuilder.ApplyConfiguration(new RequestKHConfiguration());
            //Data seeding ======= NAY LAM CACH CU
            /*
            modelBuilder.Entity<NhanSu>().HasData(
                new NhanSu() { }
                );
                */
            modelBuilder.Seed();
            //base.OnModelCreating(modelBuilder);
        }
        public DbSet<NhanSu> NhanSus { set; get; }
        public DbSet<KhachHang> KhachHangs { set; get; }
        public DbSet<RequestKH> RequestKHs { set; get; }
    }

}
