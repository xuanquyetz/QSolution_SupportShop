using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Http;
using Newtonsoft.Json;
using SupportWeb.Application.Catalog.RequestKH;
using SupportWeb.ViewModels.Catalog.RequestKH;
using SupportWeb.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace SupportShop.Services
{
    public class RequestKHApiClient : IRequestKHApiClient
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuratiton;
        public RequestKHApiClient(IHttpClientFactory httpClientFactory,IConfiguration configuration)
        {
            _httpClientFactory = httpClientFactory; //Viet theo cach DI
            _configuratiton = configuration;
        }
        public async Task<PageResult<RequestKHViewModel>> GetManageRequestKHPaging(GetManageRequestKHPagingRequest request)
        {
            //var json = JsonConvert.SerializeObject(request);
            //var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuratiton["KetNoiDiaChi"]);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", request.BearerToken);
            var response = await client.GetAsync($"api/RequestKH/manager-paging?pageIndex=" +
                $"{request.PageIndex}&pageSize={request.PageSize}&keyword={request.Keyword}");//,httpContent
            var body = await response.Content.ReadAsStringAsync();
            var requestKH = JsonConvert.DeserializeObject<PageResult<RequestKHViewModel>>(body);
            return requestKH;
        }
        [HttpGet(Name = "GetRanking")]
        public async Task<IActionResult> GetAPINgoai()
        {
            var cl = new HttpClient();
            var result = cl.GetAsync("http://115.79.29.62:6000/api/Common/get-all-cities").Result;
            var body = await result.Content.ReadAsStringAsync();
            var iii = JsonConvert.DeserializeObject<IActionResult>(body);

            return iii;
        }

        public async Task<ApiResult<bool>> CreateRequestKH(RequestKHCreateRequest request)
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuratiton["KetNoiDiaChi"]);

            var json = JsonConvert.SerializeObject(request);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PostAsync($"/api/RequestKH", httpContent);
            var result = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<ApiSuccessResult<bool>>(result);

            return JsonConvert.DeserializeObject<ApiErrorResult<bool>>(result);
        }

        public Task<ApiResult<bool>> UpdateRequestKH(Guid Ma, RequestKHUpdateRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResult<RequestKHViewModel>> GetByMa(Guid Ma)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResult<bool>> Delete(Guid Ma)
        {
            throw new NotImplementedException();
        }
    }
}
