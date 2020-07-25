using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SupportWeb.Application.Catalog.NhanSu;
using SupportWeb.ViewModels.Catalog.NhanSu;

namespace SupportWeb.BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NhanSuController : ControllerBase
    {
        private readonly IManageNhanSuService _manageNhanSuService;
        public NhanSuController( IManageNhanSuService manageNhanSuService)
        {
            _manageNhanSuService = manageNhanSuService;
        }
        [HttpGet("manage-paging")]
        public async Task<IActionResult> Get([FromQuery] GetNhanSuPagingRequest request)
        {
            var nhanSu = await _manageNhanSuService.GetAllPaging(request);
            return Ok(nhanSu);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromForm] NhanSuCreateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var ketquaMa = await _manageNhanSuService.Create(request);
            if (ketquaMa == null)
                return BadRequest();
            var nhanSu = await _manageNhanSuService.GetByMa(ketquaMa);
            return CreatedAtAction(nameof(GetByMa), new { id = ketquaMa }, nhanSu);
        }
        [HttpGet("{Ma}")]
        public async Task<IActionResult> GetByMa(Guid Ma)
        {
            var nhansu = await _manageNhanSuService.GetByMa(Ma);
            if (nhansu == null)
                return BadRequest("Khong tim thay Request KH");
            return Ok(nhansu);
        }
        [HttpDelete("{Ma}")]
        public async Task<IActionResult> Delete(Guid Ma)
        {
            var affectedResult = await _manageNhanSuService.Delete(Ma);
            if (affectedResult == 0)
                return BadRequest();
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromForm] NhanSuUpdateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var affectedResult = await _manageNhanSuService.Update(request);
            if (affectedResult == 0)
                return BadRequest();
            return Ok();
        }
    }
}
