
using SupportWeb.Data.EF;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SupportWeb.ViewModels.Catalog.RequestKH;
using SupportWeb.ViewModels.Common;

namespace SupportWeb.Application.Catalog.RequestKH
{
    public class PublicRequestKHService:IPublicRequestKHService
    {
        private readonly SupportShopDbContext _context;
        public PublicRequestKHService(SupportShopDbContext context)
        {
            _context = context;
        }

        public async Task<List<RequestKHViewModel>> GetAll()
        {
            var query = from rq in _context.RequestKHs
                        join kh in _context.KhachHangs on rq.KhachHangMa equals kh.Ma
                        join ns in _context.NhanSus on rq.KyThuatMa equals ns.Ma
                        select new { rq, kh, ns };
            var data = await query.Select(k => new RequestKHViewModel()
            {

                Stt = k.rq.Stt,
                Ma = k.rq.Ma,
                Ten = k.rq.Ten,
                TrangThai = k.rq.TrangThai,
                TenCode = k.ns.HoTen,
                TenTrienKhai = k.ns.HoTen,
                TenKhachHang = k.kh.Ten,
                FormThucHien = k.rq.FormThucHien,
                GhiChu = k.rq.GhiChu,
                NgayTao = k.rq.NgayTao,
                NgayHoanThanh = k.rq.NgayHoanThanh,
                NguoiYeuCau = k.rq.NguoiYeuCau,

            }).ToListAsync();
            return data;
        }

        public async Task<PageResult<RequestKHViewModel>> GetAllByRequestKH(GetPublicRequestKHPagingRequest request)
        {
            var query = from rq in _context.RequestKHs
                        join kh in _context.KhachHangs on rq.KhachHangMa equals kh.Ma
                        join ns in _context.NhanSus on rq.KyThuatMa equals ns.Ma
                        select new { rq, kh, ns };
            if (!string.IsNullOrEmpty(request.Keyword))
                query = query.Where(q => q.rq.Ten.Contains(request.Keyword));
            int TongSoHang = await query.CountAsync();
            var data = await query.Skip((request.PageIndex - 1) * request.PageSize).Take(request.PageSize).Select(k => new RequestKHViewModel()
            {

                Stt = k.rq.Stt,
                Ma = k.rq.Ma,
                Ten = k.rq.Ten,
                TrangThai = k.rq.TrangThai,
                TenCode = k.ns.HoTen,
                TenTrienKhai = k.ns.HoTen,
                TenKhachHang = k.kh.Ten,
                FormThucHien = k.rq.FormThucHien,
                GhiChu = k.rq.GhiChu,
                NgayTao = k.rq.NgayTao,
                NgayHoanThanh = k.rq.NgayHoanThanh,
                NguoiYeuCau = k.rq.NguoiYeuCau,

            }).ToListAsync();
            var pagedResult = new PageResult<RequestKHViewModel>()
            {
                TotalRecord = TongSoHang,
                Items = data
            };
            return pagedResult;
        }
    }
    
}
