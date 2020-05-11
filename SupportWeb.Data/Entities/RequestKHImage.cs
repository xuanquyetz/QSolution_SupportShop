using System;
using System.Collections.Generic;
using System.Text;

namespace SupportWeb.Data.Entities
{
   public class RequestKHImage
    {
        public string Ma { get; set; }
        public Guid RequestKHMa { get; set; }
        public string ImagePath { get; set; }
        public string Caption { get; set; }
        public bool IsDefault { get; set; }
        public DateTime NgayTao  { get; set; }
        public int SoTTImage { get; set; }
        public int FileSize { get; set; }
        public RequestKH RequestKH { get; set; }
    }
}
