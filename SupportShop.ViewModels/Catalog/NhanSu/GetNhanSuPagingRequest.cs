
using SupportWeb.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace SupportWeb.ViewModels.Catalog.NhanSu
{
   public class GetNhanSuPagingRequest:PagingRequestBase
    {
        public string Keyword { get; set; }
    }
}
