using Microsoft.AspNetCore.Http;
using SupportWeb.ViewModels.Catalog.RequestKH;
using SupportWeb.ViewModels.Catalog.RequestKHImage;
using SupportWeb.ViewModels.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SupportWeb.Application.Catalog.RequestKH
{
    public interface IManageRequestKHService
    {
       Task<int> Create(RequestKHCreateRequest request);
       Task< int> Update(RequestKHUpdateRequest request);
       Task< int> Delete(string Ma);
       Task<List<RequestKHViewModel>> GetAll();
       Task< PageResult<RequestKHViewModel>> GetAllPaging(GetManageRequestKHPagingRequest request);
       Task<int> AddImage(string MaRequestKH, RequestKHImageCreateRequest request);
       Task<int> RemoveImage(string MaRequestKH);
        Task<int> UpdateImage(string MaImage, RequestKhImageUpdateRequest request);
        Task<List<RequestKHImageViewModel>> GetListImage(string MaRequetKH);
        Task<List<RequestKHImageViewModel>> GetImageByMa(string MaImage);
    }
}
