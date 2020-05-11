using SupportWeb.Data.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace SupportWeb.Application.Catalog.NhanSu.Dtos
{
   public class NhanSuViewModel
    {
        public Guid Ma { set; get; }
        public string HoTen { set; get; }
        public string ChucVu { set; get; }
        public BoPhan BoPhan { set; get; }
        public int SoDienThoai { set; get; }
        public DateTime? NgaySinh { set; get; }
    }
}
