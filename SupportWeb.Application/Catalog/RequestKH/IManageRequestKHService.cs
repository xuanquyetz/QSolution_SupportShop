using SupportWeb.Application.Catalog.RequestKH.Dtos;
using SupportWeb.Application.Catalog.RequestKH.Dtos.Manage;
using SupportWeb.Application.CommonDtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SupportWeb.Application.Catalog.RequestKH
{
    public interface IManageRequestKHService
    {
       Task<int> Create(RequestKHCreateRequest request);
       Task< int> Update(RequestKHUpdateRequest request);
       Task< int> Delete(string Ma);
       Task<List<RequestKHViewModel>> GetAll();
       Task< PageResult<RequestKHViewModel>> GetAllPaging(GetRequestKHPagingRequest request);
    }
}
