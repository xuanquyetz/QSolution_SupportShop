using SupportWeb.Application.CommonDtos;
using SupportWeb.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SupportWeb.Application.Catalog.RequestKH.Dtos.Manage
{
    public class GetRequestKHPagingRequest : PagingRequestBase
    {
        public string Keyword { get; set; }
       //public List<NhanSu> MaNhanSu { set; get; }
        public List<KhachHang> MaKhachHang { set; get; }
    }
}
