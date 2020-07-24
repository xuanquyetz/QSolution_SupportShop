using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SupportWeb.ViewModels.Catalog.RequestKH;
using SupportWeb.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SupportShop.Services
{
    public interface IRequestKHApiClient
    {
        Task<PageResult<RequestKHViewModel>> GetManageRequestKHPaging(GetManageRequestKHPagingRequest request);
        Task<IActionResult> GetAPINgoai();
    }
}
