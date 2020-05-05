using SupportWeb.Data.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace SupportWeb.Data.Entities
{
    public class RequestKH
    {
        public int Stt { set; get; }
        public string Ma { set; get; }
        public string Ten { set; get; }
        public TrangThai TrangThai { set; get; }
        public string CodeMa { set; get; }
        public string KyThuatMa { set; get; }
        public string KhachHangMa { set; get; }
        public string FormThucHien { set; get; }
        public string GhiChu { set; get; }
        public string NguoiYeuCau { set; get; }
    }
}
