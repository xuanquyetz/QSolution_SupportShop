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

namespace SupportWeb.Application.Catalog.RequestKH
{
    public class ManageRequestKHService : IManageRequestKHService
    {
        private readonly SupportShopDbContext _context;
        public ManageRequestKHService(SupportShopDbContext context)
        {
            _context = context;
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

        public async Task< PageResult<RequestKHViewModel>> GetAllPaging(string keyword, int pageIndex, int pageSize)
        {
            throw new NotImplementedException();
        }

        public Task<PageResult<RequestKHViewModel>> GetAllPaging(GetRequestKHPagingRequest request)
        {
            throw new NotImplementedException();
        }

        public async Task<int>Update(RequestKHUpdateRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
