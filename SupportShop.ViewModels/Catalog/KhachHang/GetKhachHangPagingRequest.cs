using SupportWeb.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace SupportWeb.ViewModels.Catalog.KhachHang
{
  public class GetKhachHangPagingRequest: PagingRequestBase
    {
        public string Ma { set; get; }
        public string Keyword { set; get; }

    }
}
