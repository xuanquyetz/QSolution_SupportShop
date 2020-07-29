
using Microsoft.EntityFrameworkCore;
using SupportWeb.Application.Common;
using SupportWeb.Data.EF;
using SupportWeb.ViewModels.Catalog.NhanSu;
using SupportWeb.ViewModels.Common;
using SuppportShop.Utilities.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupportWeb.Application.Catalog.NhanSu
{
    public class ManageNhanSuService : IManageNhanSuService
    {
        private readonly SupportShopDbContext _context;
        private readonly IStorageService _storageService;
        public ManageNhanSuService(SupportShopDbContext context, IStorageService storageService )
        {
            _context = context;
            _storageService = storageService;
        }
        public async Task<Guid> Create(NhanSuCreateRequest request)
        {
            var nhansu = new Data.Entities.NhanSu()
            {
                HoTen=request.HoTen,
                ChucVu=request.ChucVu,
                BoPhan=request.BoPhan,
                SoDienThoai=request.SoDienThoai,
                NgaySinh=request.NgaySinh,
                
            };
            _context.NhanSus.Add(nhansu);
            await _context.SaveChangesAsync();
            return nhansu.Ma;
        }

        public async Task<int> Delete(Guid Ma)
        {
            var nhansu = await _context.NhanSus.FindAsync(Ma);
            if (nhansu == null) throw new SupportShopException($"Không tìm thấy nhan su can xoa:{Ma}");
            _context.NhanSus.Remove(nhansu);
            return await _context.SaveChangesAsync();
        }

        public Task<List<NhanSuViewModel>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<PageResult<NhanSuViewModel>> GetAllPaging(GetNhanSuPagingRequest request)
        {
            var nhanSu = from ns in _context.NhanSus select new { ns };
            if (!string.IsNullOrEmpty(request.Keyword))
                nhanSu =  nhanSu.Where(l => l.ns.HoTen.Contains(request.Keyword));
                int TongSoHang = await nhanSu.CountAsync();
            var data = await nhanSu.Skip((request.PageIndex - 1) * request.PageSize).Take(request.PageSize).Select(k => new NhanSuViewModel()
            {
                Ma=k.ns.Ma,
                HoTen=k.ns.HoTen,
                ChucVu=k.ns.ChucVu,
                NgaySinh=k.ns.NgaySinh,
                BoPhan=k.ns.BoPhan,
                SoDienThoai=k.ns.SoDienThoai
            }).ToListAsync();
            var pagedResult = new PageResult<NhanSuViewModel>()
          {
              TotalRecord = TongSoHang,
              Items = data
           };
            return pagedResult;
        }

        public async Task<NhanSuViewModel> GetByMa(Guid Ma)
        {
            var nhanSu = await _context.NhanSus.FindAsync(Ma);
            var nhansuViewModel = new NhanSuViewModel()
            {
                Ma = nhanSu.Ma,
                HoTen = nhanSu.HoTen,
                ChucVu = nhanSu.ChucVu,
                SoDienThoai = nhanSu.SoDienThoai,
                BoPhan = nhanSu.BoPhan,
                NgaySinh = nhanSu.NgaySinh,
            };
            return nhansuViewModel;
        }

        public async Task<int> Update(NhanSuUpdateRequest request)
        {
            var nhanSu = await _context.NhanSus.FindAsync(request.Ma);
            if (nhanSu == null) throw new SupportShopException($"Không tìm thấy request can update :{request.Ma}");
            nhanSu.HoTen = request.HoTen;
            nhanSu.ChucVu = request.ChucVu;
            nhanSu.SoDienThoai = request.SoDienThoai;
            nhanSu.BoPhan = request.BoPhan;
            nhanSu.NgaySinh = request.NgaySinh;
            return await _context.SaveChangesAsync();
        }
        
    }
}
