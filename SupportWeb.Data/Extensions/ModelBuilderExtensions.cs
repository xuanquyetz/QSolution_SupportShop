using Microsoft.EntityFrameworkCore;
using SupportWeb.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SupportWeb.Data.Extensions
{
   public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<NhanSu>().HasData(
            new NhanSu()
            {
                Ma=new Guid ("AED723A2-9AD3-4F2A-8753-DA1B06EA5520"),
                HoTen ="Đinh Xuân Quyết",
                SoDienThoai=0963555396,
                BoPhan=Enums.BoPhan.Support,
                ChucVu="Leader",
            },
            new NhanSu()
            {
                Ma=new Guid("FBA9D758-5204-4E31-A2EA-D1466E947F23"),
                HoTen = "Trần Gia Bảo",
                SoDienThoai = 0,
                BoPhan = Enums.BoPhan.Support,
                ChucVu = "Leader",
            }
        );
        }
    }
}
