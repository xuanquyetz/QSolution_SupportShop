using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System;
using System.Collections.Generic;
using System.Text;

namespace SupportWeb.Data.Entities
{
  public  class KhachHang
    {
        public Guid Ma { set; get; }
        public string Ten { set; get; }
        public int SoDienThoai { set; get; }
        public string DiaChi { set; get; }
        public string NguoiChiuTrachNhiem { set; get; }
        public string Email { set; get; }
        public string ThongTinSupport { set; get; }
        public Guid NhanSuPhuTrachMa { set; get; }
        public List<RequestKH> RequestKH { set; get; }
       // public NhanSu NhanSu { set; get; }
    }
}
