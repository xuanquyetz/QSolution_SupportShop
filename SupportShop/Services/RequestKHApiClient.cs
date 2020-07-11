using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Http;
using Newtonsoft.Json;
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
    }
}
