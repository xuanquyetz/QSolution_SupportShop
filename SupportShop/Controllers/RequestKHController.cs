using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using SupportShop.Services;
using SupportWeb.ViewModels.Catalog.RequestKH;

namespace SupportShop.Controllers
{
    public class RequestKHController : Controller
    {
        private readonly IRequestKHApiClient _requestKHApiClient;
        private readonly IConfiguration _configuration;
        public RequestKHController(IRequestKHApiClient requestKHApiClient, IConfiguration configuration)
        {
            _requestKHApiClient = requestKHApiClient;
            _configuration = configuration;
        }
        public async Task <IActionResult> Index( string keyword, int pageIndex=1, int pageSize=10)
        { 
            var cl = new HttpClient();
            var result = cl.GetAsync("http://115.79.29.62:6000/api/Common/get-all-cities").Result;

            var sesstion = HttpContext.Session.GetString("token");
            var request = new GetManageRequestKHPagingRequest()
            {
                BearerToken = sesstion,
                Keyword = keyword,
                PageIndex = pageIndex,
                PageSize = pageSize
            };
            var data =  await _requestKHApiClient.GetManageRequestKHPaging(request);
            return View(data);
        }
        public async Task<IActionResult> Index2()
        {
            
            return null;
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(RequestKHCreateRequest request)
        {
            if (!ModelState.IsValid)
                return View();

            var result = await _requestKHApiClient.CreateRequestKH(request);
            if (result.IsSuccessed)
            {
                TempData["result"] = "Thêm thành công";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", result.Message);
            return View(request);
        }
    }
}