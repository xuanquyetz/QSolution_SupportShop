
using SupportWeb.ViewModels.Catalog.NhanSu;
using SupportWeb.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SupportWeb.Application.Catalog.NhanSu
{
    public interface IManageNhanSuService
    {
        Task<Guid> Create(NhanSuCreateRequest request);
        Task<int> Update(NhanSuUpdateRequest request);
        Task<int> Delete(Guid Ma);
        Task<List<NhanSuViewModel>> GetAll();
        Task<PageResult<NhanSuViewModel>> GetAllPaging(GetNhanSuPagingRequest request);
        Task<NhanSuViewModel> GetByMa(Guid Ma);
    }
}
