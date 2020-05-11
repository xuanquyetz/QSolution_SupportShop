using System;
using System.Collections.Generic;
using System.Text;

namespace SupportWeb.Application.Catalog.RequestKH.Dtos
{
   public class RequestKHImageViewModel
    {
     
        public Guid RequestKHMa { get; set; }
        public string ImagePath { get; set; }
        public string Caption { get; set; }
        public bool IsDefault { get; set; }
        public DateTime NgayTao { get; set; }
        public int SoTTImage { get; set; }
        public int FileSize { get; set; }
        
    }
}
