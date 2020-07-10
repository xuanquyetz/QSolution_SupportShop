using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SupportWeb.Application.Catalog.RequestKH;
using SupportWeb.Data.Enums;
using SupportWeb.ViewModels.Catalog.RequestKH;

namespace SupportWeb.BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestKHController : ControllerBase
    {
        private readonly IPublicRequestKHService _publicRequestKHService;
        private readonly IManageRequestKHService _manageRequestKHService;
        public RequestKHController(IPublicRequestKHService publicRequestKHService, IManageRequestKHService manageRequestKHService)
        {
            _publicRequestKHService = publicRequestKHService;
            _manageRequestKHService = manageRequestKHService;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var requestkh = await _publicRequestKHService.GetAll();
            return Ok(requestkh);
        }
        [HttpGet("public-paging")]
        public async Task<IActionResult> Get([FromQuery] GetPublicRequestKHPagingRequest request)
        {
            var requestkh = await _publicRequestKHService.GetAllByRequestKH(request);
            return Ok(requestkh);
        }
        [HttpGet("manager-paging")]
        public async Task<IActionResult> GetAllPaging([FromQuery] GetManageRequestKHPagingRequest request)
        {
            var requestkh = await _manageRequestKHService.GetAllPaging(request);
            return Ok(requestkh);
        }
        [HttpGet("{Ma}")]
        public async Task<IActionResult> GetByMa(Guid Ma)
        {
            var requestkh = await _manageRequestKHService.GetByMa(Ma);
            if (requestkh == null)
                return BadRequest("Khong tim thay Request KH");
            return Ok(requestkh);
        }
        [HttpGet("KH/{MaKH}/{trangThai}")]
        public async Task<IActionResult> GetByMaKHAndTrangThai(Guid MaKH, TrangThai trangThai)
        {
            var requestkh = await _publicRequestKHService.GetByKHAndTrangThai(MaKH, trangThai);
            if (requestkh == null)
                return BadRequest("Khong tim thay Request KH");
            return Ok(requestkh);
        }
        [HttpGet("KH/{MaKH}")]
        public async Task<IActionResult> GetByMaKH(Guid MaKH)
        {
            var requestkh = await _publicRequestKHService.GetByKH(MaKH);
            if (requestkh == null)
                return BadRequest("Khong tim thay Request KH");
            return Ok(requestkh);
        }


        //[HttpGet("public")]
        //public async Task<IActionResult> GetByMa_Public(GetPublicRequestKHPagingRequest request)
        //{
        //    var requestkh = await _publicRequestKHService.GetAllByRequestKH(request);
        //    if (requestkh == null)
        //        return BadRequest("Khong tim thay Request KH");
        //    return Ok(requestkh);
        //}
        [HttpPost]
        public async Task<IActionResult> Create([FromForm] RequestKHCreateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var ketquaMa = await _manageRequestKHService.Create(request);
            if (ketquaMa == null)
                return BadRequest();
            var requestKH = await _manageRequestKHService.GetByMa(ketquaMa);
            return CreatedAtAction(nameof(GetByMa), new { id = ketquaMa }, requestKH);
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromForm] RequestKHUpdateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var affectedResult = await _manageRequestKHService.Update(request);
            if (affectedResult == 0)
                return BadRequest();
            return Ok();
        }
        [HttpDelete("{Ma}")]
        public async Task<IActionResult> Delete(Guid Ma)
        {
            var affectedResult = await _manageRequestKHService.Delete(Ma);
            if (affectedResult == 0)
                return BadRequest();
            return Ok();
        }
    }
}