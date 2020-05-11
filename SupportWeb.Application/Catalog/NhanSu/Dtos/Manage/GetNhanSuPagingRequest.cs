using SupportWeb.Application.CommonDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace SupportWeb.Application.Catalog.NhanSu.Dtos.Manage
{
   public class GetNhanSuPagingRequest:PagingRequestBase
    {
        public string Keyword { get; set; }
    }
}
