using Microsoft.EntityFrameworkCore;
using SupportWeb.Data.Entities;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using SupportWeb.Data.Configuration;
using SupportWeb.Data.Extensions;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace SupportWeb.Data.EF
{
    public class SupportShopDbContext : IdentityDbContext<AppUser,AppRole,Guid>
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
            modelBuilder.ApplyConfiguration(new AppRoleConfiguration());
            modelBuilder.ApplyConfiguration(new AppUserConfiguration());
            modelBuilder.ApplyConfiguration(new RequestKHImageConfiguration());
            modelBuilder.Entity<IdentityUserClaim<Guid>>().ToTable("AppUserClaim");
            modelBuilder.Entity<IdentityUserLogin<Guid>>().ToTable("AppUserLogin").HasKey(q=>q.UserId);
            modelBuilder.Entity<IdentityUserRole<Guid>>().ToTable("AppUserRole").HasKey(q=>new{q.UserId, q.RoleId });
            modelBuilder.Entity<IdentityRoleClaim<Guid>>().ToTable("AppRoleClaim");
            modelBuilder.Entity<IdentityUserToken<Guid>>().ToTable("AppUserToken").HasKey(q=>q.UserId);
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
        public DbSet<RequestKHImage> RequestKHImages { set; get; }
    }

}
