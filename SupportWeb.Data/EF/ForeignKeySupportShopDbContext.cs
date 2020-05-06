using Microsoft.EntityFrameworkCore;
using SupportWeb.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SupportWeb.Data.EF
{
    public class ForeignKeySupportShopDbContext : DbContext
    {
        public ForeignKeySupportShopDbContext( DbContextOptions options) : base(options)
        {
        }
        public DbSet<KhachHang> KhachHangs { set; get; }
        public DbSet<RequestKH> RequestKHs { set; get; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<KhachHang>().HasForeignKey();
            base.OnModelCreating(modelBuilder);
        }
    }
}
