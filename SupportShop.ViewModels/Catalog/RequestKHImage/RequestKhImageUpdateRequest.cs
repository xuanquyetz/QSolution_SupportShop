using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace SupportWeb.ViewModels.Catalog.RequestKHImage
{
   public class RequestKhImageUpdateRequest
    {
        public string Ma { get; set; }
        public string Caption { get; set; }
        public bool IsDefault { get; set; }
        public int SoTTImage { get; set; }
        public IFormFile HinhNho { set; get; }
    }
}
