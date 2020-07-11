
using SupportWeb.Data.EF;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SupportWeb.Data.Entities;
using Microsoft.VisualBasic.CompilerServices;
using SuppportShop.Utilities.Exceptions;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.VisualBasic;
using SupportWeb.ViewModels.Catalog.RequestKH;
using SupportWeb.ViewModels.Common;
using SupportWeb.ViewModels.Catalog.RequestKHImage;
using System.Net.Http.Headers;
using SupportWeb.Application.Common;
using SupportWeb.Data.Enums;

namespace SupportWeb.Application.Catalog.RequestKH
{
    public class ManageRequestKHService : IManageRequestKHService
    {
        private readonly SupportShopDbContext _context;
        private readonly IStorageService _storageService;
        public ManageRequestKHService(SupportShopDbContext context, IStorageService storageService)
        {
            _context = context;
            _storageService = storageService;
        }
        public Task<int> AddImage(string MaRequestKH, RequestKHImageCreateRequest request)
        {
            throw new NotImplementedException();
        }

        public async Task<Guid> Create(RequestKHCreateRequest request)
        {
            var requestKH = new Data.Entities.RequestKH()
            {
                Ten = request.Ten,
                Stt=request.Stt,
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
            //Save Image
            if (request.HinhNho != null)
            {
                string Nam = DateTime.Now.Year.ToString();
                string Thang = DateTime.Now.Month.ToString();
                string Ngay = DateTime.Now.Day.ToString();
                string Gio = DateTime.Now.Hour.ToString();
                string Phut = DateTime.Now.Minute.ToString();
                string Giay = DateTime.Now.Second.ToString();
                string MiliGiay = DateTime.Now.Millisecond.ToString();
               
                requestKH.RequestKHImage = new List<RequestKHImage>()
                {
                    new RequestKHImage()
                    {
                        //Ma=requestKH.Ma+DateTime.Now.ToString(),
                        Ma=Nam+Thang+Ngay+Gio+Phut+Giay+MiliGiay,
                        Caption="Image request",
                        NgayTao=DateTime.Now,
                        FileSize=request.HinhNho.Length,
                        ImagePath= await this.SaveFile(request.HinhNho),
                        IsDefault=true,
                        SoTTImage=1
                    }
                };
            }
                _context.RequestKHs.Add(requestKH);

                await _context.SaveChangesAsync();

                return requestKH.Ma;
            
        }

        public async Task<int> Delete(Guid Ma)
        {
            var requestKH = await _context.RequestKHs.FindAsync(Ma);
            if (requestKH == null) throw new SupportShopException($"Không tìm thấy request can xoa:{Ma}");
            var hinhanh = _context.RequestKHImages.Where(q => q.RequestKHMa == Ma);
            foreach (var item in hinhanh)
            {
               await _storageService.DeleteFileAsync(item.ImagePath);
            }
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

        public async Task<PageResult<RequestKHViewModel>> GetAllPaging(GetManageRequestKHPagingRequest request)
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

        public async Task<RequestKHViewModel> GetByMa(Guid Ma)
        {
            var requestkh = await _context.RequestKHs.FindAsync(Ma);
            var reqestKHViewModel = new RequestKHViewModel()
            {
                Ma = requestkh.Ma,
                Ten = requestkh.Ten,
                Stt = requestkh.Stt,
                TrangThai = requestkh.TrangThai,
                CodeMa = requestkh.CodeMa,
                KyThuatMa = requestkh.KyThuatMa,
                KhachHangMa = requestkh.KhachHangMa,
                FormThucHien = requestkh.FormThucHien,
                GhiChu = requestkh.GhiChu,
                NguoiYeuCau = requestkh.NguoiYeuCau

            };
            return reqestKHViewModel;

        }

        public async Task<RequestKHViewModel> GetByTrangThaiAndKH(Guid MaKH)
        {
            // var requestkh = await _context.RequestKHs.FindAsync(MaKH,trangThai);
            var requestkh = await _context.RequestKHs.FirstOrDefaultAsync(q=>q.KhachHangMa==MaKH);
           // var khachhang = await _context.KhachHangs.FirstOrDefaultAsync(q => q.Ma == MaKH);
            var reqestKHViewModel = new RequestKHViewModel()
            {
                Ma = requestkh.Ma,
                Ten = requestkh.Ten,
                Stt = requestkh.Stt,
                TrangThai = requestkh.TrangThai,
                CodeMa = requestkh.CodeMa,
                KyThuatMa = requestkh.KyThuatMa,
                KhachHangMa = requestkh.KhachHangMa,
                FormThucHien = requestkh.FormThucHien,
                GhiChu = requestkh.GhiChu,
                NguoiYeuCau = requestkh.NguoiYeuCau,

            };
            return reqestKHViewModel;
        }

        public Task<List<RequestKHImageViewModel>> GetImageByMa(string MaImage)
        {
            throw new NotImplementedException();
        }

        public Task<List<RequestKHImageViewModel>> GetListImage(string MaRequetKH)
        {
            throw new NotImplementedException();
        }

        public async Task<int> RemoveImage(string MaRequestKH)
        {
            var ImageImage = await _context.RequestKHImages.FindAsync(MaRequestKH);
            if (ImageImage == null) throw new SupportShopException($"Không tìm thấy hinh can xoa:{MaRequestKH}");
            _context.RequestKHImages.Remove(ImageImage);
            return await _context.SaveChangesAsync();
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
            //Update Image in RequetsKH
            if (request.HinhNho != null)
            {
                var hinhnho = await _context.RequestKHImages.FirstOrDefaultAsync(q => q.IsDefault == true && q.RequestKHMa == request.Ma);
                if (hinhnho != null)
                {
                    hinhnho.NgayTao = DateTime.Now;
                    hinhnho.FileSize = request.HinhNho.Length;
                    hinhnho.ImagePath = await this.SaveFile(request.HinhNho);
                    _context.RequestKHImages.Update(hinhnho);
                }
              
            }
            return  await _context.SaveChangesAsync();
        }
        public Task<int> UpdateImage(string MaImage, RequestKhImageUpdateRequest request)
        {
            throw new NotImplementedException();
        }
        private async Task<string> SaveFile(IFormFile file)
        {
            var originalFileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
            var fileName = $"{Guid.NewGuid()}{Path.GetExtension(originalFileName)}";
            await _storageService.SaveFileAsync(file.OpenReadStream(), fileName);
            return fileName;
        }
    }
}
