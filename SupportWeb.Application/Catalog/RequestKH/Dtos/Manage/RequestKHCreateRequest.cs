using SupportWeb.Data.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace SupportWeb.Application.Catalog.RequestKH.Dtos.Manage
{
    public class RequestKHCreateRequest
    {
        public int Stt { set; get; }
        //public Guid Ma { set; get; }
        public string Ten { set; get; }
        public TrangThai TrangThai { set; get; }
        public Guid CodeMa { set; get; }
        public Guid KyThuatMa { set; get; }
        public Guid KhachHangMa { set; get; }
        public string FormThucHien { set; get; }
        public string GhiChu { set; get; }
        public string NguoiYeuCau { set; get; }
        public DateTime? NgayTao { set; get; }
        public DateTime? NgayHoanThanh { set; get; }
        public Guid MaNhanSu { set; get; }
        public Guid MaKhachHang { set; get; }
    }
}
