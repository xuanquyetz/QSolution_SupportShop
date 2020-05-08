using SupportWeb.Data.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SupportWeb.Data.Entities
{ 
    public class NhanSu
    {
        public Guid Ma { set; get; }
        public string HoTen { set; get; }
        public string ChucVu { set; get; }
        public BoPhan BoPhan { set; get; }
        public int SoDienThoai { set; get; }
        public DateTime? NgaySinh { set; get; }
        public List<RequestKH> RequestKH { set; get; }
        //public List<KhachHang> KhachHang { set; get; }
    }
}
