using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SupportWeb.Application.Catalog.KhachHang;
using SupportWeb.ViewModels.Catalog.KhachHang;

namespace SupportWeb.BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KhachHangController : ControllerBase
    {
        private readonly IManageKhachHangService _manageKhachHangService;
        public KhachHangController(IManageKhachHangService manageKhachHangService)
        {
            _manageKhachHangService = manageKhachHangService;
        }
        [HttpGet("manage-paging")]
        public async Task<IActionResult> Get([FromQuery] GetKhachHangPagingRequest request)
        {
            var khachHang = await _manageKhachHangService.GetAllPaging(request);
            return Ok(khachHang);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromForm] KhachHangCreateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var ketquaMa = await _manageKhachHangService.Create(request);
            if (ketquaMa == null)
                return BadRequest();
            var khachHang = await _manageKhachHangService.GetByMa(ketquaMa);
            return CreatedAtAction(nameof(GetByMa), new { id = ketquaMa }, khachHang);
        }
        [HttpGet("{Ma}")]
        public async Task<IActionResult> GetByMa(Guid Ma)
        {
            var khachHang = await _manageKhachHangService.GetByMa(Ma);
            if (khachHang == null)
                return BadRequest("Khong tim thay Request KH");
            return Ok(khachHang);
        }
        [HttpDelete("{Ma}")]
        public async Task<IActionResult> Delete(Guid Ma)
        {
            var affectedResult = await _manageKhachHangService.Delete(Ma);
            if (affectedResult == 0)
                return BadRequest();
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromForm] KhachHangUpdateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var affectedResult = await _manageKhachHangService.Update(request);
            if (affectedResult == 0)
                return BadRequest();
            return Ok();
        }
    }
}
