
using System;
using System.Collections.Generic;
using System.Text;
using SupportWeb.Application.Catalog.RequestKH;
using System.Threading.Tasks;
using SupportWeb.ViewModels.Catalog.RequestKH;
using SupportWeb.ViewModels.Common;

namespace SupportWeb.Application.Catalog.RequestKH
{
    public interface IPublicRequestKHService
    {
        Task<PageResult<RequestKHViewModel>> GetAllByRequestKH(GetPublicRequestKHPagingRequest request);
        Task<List<RequestKHViewModel>> GetAll();
        
    }
}
