using System;
using System.Collections.Generic;
using System.Text;

namespace SupportWeb.ViewModels.Catalog.KhachHang
{
   public class KhachHangCreateRequest
    {
        public string Ten { set; get; }
        public int SoDienThoai { set; get; }
        public string DiaChi { set; get; }
        public string NguoiChiuTrachNhiem { set; get; }
        public string Email { set; get; }
        public string ThongTinSupport { set; get; }
        public Guid NhanSuPhuTrachMa { set; get; }
    }
}
