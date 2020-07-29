using SupportWeb.Application;
using SupportWeb.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace SupportWeb.ViewModels.Catalog.RequestKH
{
   public class GetManageRequestKHPagingRequest:PagingRequestBase
    {
        public string Ma { set; get; }
        public string Keyword { set; get; }
    }
}
