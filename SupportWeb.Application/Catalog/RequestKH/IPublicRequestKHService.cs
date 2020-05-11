
using SupportWeb.Application.Catalog.RequestKH.Dtos.Public;
using SupportWeb.Application.CommonDtos;
using System;
using System.Collections.Generic;
using System.Text;
using SupportWeb.Application.Catalog.RequestKH;
using SupportWeb.Application.Catalog.RequestKH.Dtos;
using System.Threading.Tasks;

namespace SupportWeb.Application.Catalog.RequestKH
{
    public interface IPublicRequestKHService
    {
        Task<PageResult<RequestKHViewModel>> GetAllByRequestKH(GetRequestKHPagingRequest request);
    }
}
