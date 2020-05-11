using SupportWeb.Application.CommonDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace SupportWeb.Application.Catalog.RequestKH.Dtos.Public
{
   public class GetRequestKHPagingRequest:PagingRequestBase
    {
        public string Ma { set; get; }
        public string Keyword { set; get; }
    }
}
