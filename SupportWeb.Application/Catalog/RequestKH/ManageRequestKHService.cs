using SupportWeb.Application.CommonDtos;
using SupportWeb.Data.EF;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SupportWeb.Data.Entities;
using Microsoft.VisualBasic.CompilerServices;
using SupportWeb.Application.Catalog.RequestKH.Dtos.Manage;
using SupportWeb.Application.Catalog.RequestKH.Dtos;
using SuppportShop.Utilities.Exceptions;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;

namespace SupportWeb.Application.Catalog.RequestKH
{
    public class ManageRequestKHService : IManageRequestKHService
    {
        private readonly SupportShopDbContext _context;
        public ManageRequestKHService(SupportShopDbContext context)
        {
            _context = context;
        }

        public Task<int> AddImage(string MaRequestKH, List<IFormFile> files)
        {
            throw new NotImplementedException();
        }

        public async Task<int> Create(RequestKHCreateRequest request)
        {
            var requestKH = new Data.Entities.RequestKH()
            {
                Ten = request.Ten,
                TrangThai = request.TrangThai,
                CodeMa = request.CodeMa,
                KyThuatMa=request.KyThuatMa,
                KhachHangMa=request.KhachHangMa,
                FormThucHien=request.FormThucHien,
                GhiChu=request.GhiChu,
                NguoiYeuCau=request.NguoiYeuCau,
                NgayTao=DateTime.Now,
                NgayHoanThanh=request.NgayHoanThanh
            };
            _context.RequestKHs.Add(requestKH);
           return await _context.SaveChangesAsync();
        }

        public async Task<int> Delete(string Ma)
        {
            var requestKH = await _context.RequestKHs.FindAsync(Ma);
            if (requestKH == null) throw new SupportShopException($"Không tìm thấy request can xoa:{Ma}");
            _context.RequestKHs.Remove(requestKH);
         return await _context.SaveChangesAsync();
        }

        public async Task<List<RequestKHViewModel>> GetAll()
        {
            throw new NotImplementedException();
        }

        //public async Task<PageResult<RequestKHViewModel>> GetAllPaging(string keyword, int pageIndex, int pageSize)
        //{
           
        //}

        public async Task<PageResult<RequestKHViewModel>> GetAllPaging(GetRequestKHPagingRequest request)
        {
            var query = from rq in _context.RequestKHs
                        join kh in _context.KhachHangs on rq.KhachHangMa equals kh.Ma
                        join ns in _context.NhanSus on rq.KyThuatMa equals ns.Ma
                        select new { rq, kh, ns };
            if (!string.IsNullOrEmpty(request.Keyword))
                query = query.Where(q => q.rq.Ten.Contains(request.Keyword));
            int TongSoHang = await query.CountAsync();
            var data = await query.Skip((request.PageIndex - 1) * request.PageSize).Take(request.PageSize).Select(k=>new RequestKHViewModel()
            { 
                
                Stt=k.rq.Stt,
                Ma = k.rq.Ma,
                Ten=k.rq.Ten,
                TrangThai=k.rq.TrangThai,
                TenCode=k.ns.HoTen,
                TenTrienKhai=k.ns.HoTen,
                TenKhachHang=k.kh.Ten,
                FormThucHien=k.rq.FormThucHien,
                GhiChu=k.rq.GhiChu,
                NgayTao=k.rq.NgayTao,
                NgayHoanThanh=k.rq.NgayHoanThanh,
                NguoiYeuCau=k.rq.NguoiYeuCau,
                
            }).ToListAsync();
            var pagedResult = new PageResult<RequestKHViewModel>()
            {
                TotalRecord = TongSoHang,
                Items = data
            };
            return pagedResult;
        }

        public Task<List<RequestKHImageViewModel>> GetListImage(string MaRequetKH)
        {
            throw new NotImplementedException();
        }

        public Task<int> RemoveImage(string MaRequestKH)
        {
            throw new NotImplementedException();
        }

        public async Task<int>Update(RequestKHUpdateRequest request)
        {
            var requestKh = await _context.RequestKHs.FindAsync(request.Ma);
            if(requestKh==null) throw new SupportShopException($"Không tìm thấy request can update :{request.Ma}");
            requestKh.Ten = request.Ten;
            requestKh.Stt = request.Stt;
            requestKh.TrangThai = request.TrangThai;
            requestKh.FormThucHien = request.FormThucHien;
            requestKh.GhiChu = request.GhiChu;
            requestKh.NgayHoanThanh = request.NgayHoanThanh;
            request.NguoiYeuCau = request.NguoiYeuCau;
         return  await _context.SaveChangesAsync();
        }

        public Task<int> UpdateImage(string MaImage, string caption, bool isDefault)
        {
            throw new NotImplementedException();
        }
    }
}
