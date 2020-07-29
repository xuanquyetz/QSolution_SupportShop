using Microsoft.AspNetCore.Http;
using SupportWeb.Data.Enums;
using SupportWeb.ViewModels.Catalog.RequestKH;
using SupportWeb.ViewModels.Catalog.RequestKHImage;
using SupportWeb.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SupportWeb.Application.Catalog.RequestKH
{
    public interface IManageRequestKHService
    {
       Task<Guid> Create(RequestKHCreateRequest request);
       Task< int> Update(RequestKHUpdateRequest request);
       Task< int> Delete(Guid Ma);
       Task<List<RequestKHViewModel>> GetAll();
       Task< PageResult<RequestKHViewModel>> GetAllPaging(GetManageRequestKHPagingRequest request);
       Task<int> AddImage(string MaRequestKH, RequestKHImageCreateRequest request);
       Task<int> RemoveImage(string MaRequestKH);
        Task<int> UpdateImage(string MaImage, RequestKhImageUpdateRequest request);
        Task<List<RequestKHImageViewModel>> GetListImage(string MaRequetKH);
        Task<List<RequestKHImageViewModel>> GetImageByMa(string MaImage);
        Task<RequestKHViewModel> GetByMa(Guid Ma);
        Task<RequestKHViewModel> GetByTrangThaiAndKH(Guid MaKH );
    }
}
