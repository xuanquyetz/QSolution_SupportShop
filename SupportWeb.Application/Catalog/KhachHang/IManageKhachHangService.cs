using SupportWeb.ViewModels.Catalog.KhachHang;
using SupportWeb.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SupportWeb.Application.Catalog.KhachHang
{
   public interface IManageKhachHangService
    {
        Task<Guid> Create(KhachHangCreateRequest request);
        Task<int> Update(KhachHangUpdateRequest request);
        Task<int> Delete(Guid Ma);
        Task<List<KhachHangViewModel>> GetAll();
        Task<PageResult<KhachHangViewModel>> GetAllPaging(GetKhachHangPagingRequest request);
        Task<KhachHangViewModel> GetByMa(Guid Ma);
    }
}
