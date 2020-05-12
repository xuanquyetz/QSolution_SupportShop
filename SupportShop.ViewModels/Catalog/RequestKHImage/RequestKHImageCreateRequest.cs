using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace SupportWeb.ViewModels.Catalog.RequestKHImage
{
   public class RequestKHImageCreateRequest
    {
        public string Caption { get; set; }
        public bool IsDefault { get; set; }
        public int SoTTImage { get; set; }
        public IFormFile ImageFile { set; get; }
    }
}
