
using SupportWeb.Data.EF;
using SupportWeb.ViewModels.Catalog.NhanSu;
using SupportWeb.ViewModels.Common;
using SuppportShop.Utilities.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SupportWeb.Application.Catalog.NhanSu
{
    public class ManageNhanSuService : IManageNhanSuService
    {
        private readonly SupportShopDbContext _context;
        public ManageNhanSuService(SupportShopDbContext context)
        {
            _context = context;
        }
        public async Task<int> Create(NhanSuCreateRequest request)
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
         return await _context.SaveChangesAsync();
        }

        public async Task<int> Delete(string Ma)
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

        public Task<PageResult<NhanSuViewModel>> GetAllPaging(GetNhanSuPagingRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<int> Update(NhanSuUpdateRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
