using Microsoft.EntityFrameworkCore;
using SupportWeb.Application.Common;
using SupportWeb.Data.EF;
using SupportWeb.ViewModels.Catalog.KhachHang;
using SupportWeb.ViewModels.Common;
using SuppportShop.Utilities.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupportWeb.Application.Catalog.KhachHang
{
   public class ManageKhachHangService:IManageKhachHangService
    {
        private readonly SupportShopDbContext _context;
        private readonly IStorageService _storageService;
        public ManageKhachHangService(SupportShopDbContext context, IStorageService storageService)
        {
            _context = context;
            _storageService = storageService;
        }

        public async Task<Guid> Create(KhachHangCreateRequest request)
        {
            var khachHang = new Data.Entities.KhachHang()
            {
                Ten = request.Ten,
                SoDienThoai = request.SoDienThoai,
                DiaChi = request.DiaChi,
                NguoiChiuTrachNhiem = request.NguoiChiuTrachNhiem,
                Email = request.Email,
                ThongTinSupport=request.ThongTinSupport,
                NhanSuPhuTrachMa= request.NhanSuPhuTrachMa
            };
            _context.KhachHangs.Add(khachHang);
            await _context.SaveChangesAsync();
            return khachHang.Ma;
        }

        public async Task<int> Delete(Guid Ma)
        {
            var khachHang = await _context.KhachHangs.FindAsync(Ma);
            if (khachHang == null) throw new SupportShopException($"Không tìm thấy nhan su can xoa:{Ma}");
            _context.KhachHangs.Remove(khachHang);
            return await _context.SaveChangesAsync();
        }

        public async Task<List<KhachHangViewModel>> GetAll()
        {
            return null;
        }

        public async Task<PageResult<KhachHangViewModel>> GetAllPaging(GetKhachHangPagingRequest request)
        {
            var khachHang = from kh in _context.KhachHangs select new { kh };
            if (!string.IsNullOrEmpty(request.Keyword))
                khachHang = khachHang.Where(l => l.kh.Ten.Contains(request.Keyword));
            int TongSoHang = await khachHang.CountAsync();
            var data = await khachHang.Skip((request.PageIndex - 1) * request.PageSize).Take(request.PageSize).Select(k => new KhachHangViewModel()
            {
                Ma = k.kh.Ma,
                Ten = k.kh.Ten,
                DiaChi = k.kh.DiaChi,
                SoDienThoai = k.kh.SoDienThoai,
                NguoiChiuTrachNhiem = k.kh.NguoiChiuTrachNhiem,
                Email = k.kh.Email,
                ThongTinSupport=k.kh.ThongTinSupport,
                NhanSuPhuTrachMa=k.kh.NhanSuPhuTrachMa
            }).ToListAsync();
            var pagedResult = new PageResult<KhachHangViewModel>()
            {
                TotalRecord = TongSoHang,
                Items = data
            };
            return pagedResult;
        }

        public async Task<KhachHangViewModel> GetByMa(Guid Ma)
        {
            var khachHang = await _context.KhachHangs.FindAsync(Ma);
            var khacHangViewModel = new KhachHangViewModel()
            {
                Ma = khachHang.Ma,
                Ten = khachHang.Ten,
                DiaChi = khachHang.DiaChi,
                SoDienThoai = khachHang.SoDienThoai,
                NguoiChiuTrachNhiem = khachHang.NguoiChiuTrachNhiem,
                Email = khachHang.Email,
                ThongTinSupport=khachHang.ThongTinSupport,
                NhanSuPhuTrachMa=khachHang.NhanSuPhuTrachMa,
            };
            return khacHangViewModel;
        }

        public async Task<int> Update(KhachHangUpdateRequest request)
        {
            var khachHang = await _context.KhachHangs.FindAsync(request.Ma);
            if (khachHang == null) throw new SupportShopException($"Không tìm thấy request can update :{request.Ma}");
            khachHang.Ten = request.Ten;
            khachHang.DiaChi = request.DiaChi;
            khachHang.SoDienThoai = request.SoDienThoai;
            khachHang.NguoiChiuTrachNhiem = request.NguoiChiuTrachNhiem;
            khachHang.Email = request.Email;
            khachHang.ThongTinSupport = request.ThongTinSupport;
            khachHang.NhanSuPhuTrachMa = request.NhanSuPhuTrachMa;
            return await _context.SaveChangesAsync();
        }
    }
}
