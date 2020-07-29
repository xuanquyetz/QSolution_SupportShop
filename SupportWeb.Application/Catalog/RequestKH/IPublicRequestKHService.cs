
using System;
using System.Collections.Generic;
using System.Text;
using SupportWeb.Application.Catalog.RequestKH;
using System.Threading.Tasks;
using SupportWeb.ViewModels.Catalog.RequestKH;
using SupportWeb.ViewModels.Common;
using SupportWeb.Data.Enums;

namespace SupportWeb.Application.Catalog.RequestKH
{
    public interface IPublicRequestKHService
    {
        Task<PageResult<RequestKHViewModel>> GetAllByRequestKH(GetPublicRequestKHPagingRequest request);
        Task<List<RequestKHViewModel>> GetAll();
        Task<List<RequestKHViewModel>> GetByKH(Guid MaKH);
        Task<List<RequestKHViewModel>> GetByKHAndTrangThai(Guid MaKH, TrangThai trangThai);

    }
}
