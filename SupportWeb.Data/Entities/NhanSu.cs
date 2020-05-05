using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SupportWeb.Data.Entities
{ 
    public class NhanSu
    {
        public string Ma { set; get; }
        public string HoTen { set; get; }
        public string ChucVu { set; get; }
        public string MaBoPhan { set; get; }

    }
}
