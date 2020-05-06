using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System;
using System.Collections.Generic;
using System.Text;

namespace SupportWeb.Data.Entities
{
  public  class KhachHang
    {
        public string Ma { set; get; }
        public string Ten { set; get; }
        public int SoDienThoai { set; get; }
        public string DiaChi { set; get; }
        public string NguoiChiuTrachNhiem { set; get; }
        public string Email { set; get; }
        public string ThongTinSupport { set; get; }
    }
}
