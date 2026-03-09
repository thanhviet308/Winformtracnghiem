using PhanMemThiTracNghiem.Data;
using PhanMemThiTracNghiem.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PhanMemThiTracNghiem.Services
{
    public class ThongKeService
    {
        private readonly AppDbContext _context;

        public ThongKeService()
        {
            _context = new AppDbContext();
        }

        // Thống kê kỳ thi theo ID - Mở rộng cho form frmThongKeKyThi
        public ThongKeKyThiDTO GetThongKeKyThi(long kyThiId)
        {
            var kyThi = _context.KyThi
                .Include(k => k.BaiThis)
                .ThenInclude(b => b.SinhVien)
                .FirstOrDefault(k => k.Id == kyThiId);

            if (kyThi == null) return null;

            var baiThis = kyThi.BaiThis.ToList();
            var daNopBai = baiThis.Where(b => b.TrangThai == "da_nop" || b.TrangThai == "cham_diem").ToList();

            return new ThongKeKyThiDTO
            {
                KyThiId = kyThi.Id,
                TenKyThi = kyThi.TenKyThi,
                ThoiGianBatDau = kyThi.ThoiGianBatDau,
                ThoiGianKetThuc = kyThi.ThoiGianKetThuc,
                TongSoSinhVien = baiThis.Count,
                SoDaThi = daNopBai.Count,
                SoChuaThi = baiThis.Count - daNopBai.Count,
                // Legacy properties for backward compatibility
                SoSinhVienDaThi = daNopBai.Count,
                SoSinhVienChuaThi = baiThis.Count - daNopBai.Count,
                DiemTrungBinh = daNopBai.Any() ? Math.Round(daNopBai.Average(b => b.DiemSo ?? 0), 2) : 0,
                DiemCaoNhat = daNopBai.Any() ? daNopBai.Max(b => b.DiemSo ?? 0) : 0,
                DiemThapNhat = daNopBai.Any() ? daNopBai.Min(b => b.DiemSo ?? 0) : 0,
                TyLeDau = daNopBai.Any() ? Math.Round((double)daNopBai.Count(b => (b.DiemSo ?? 0) >= (kyThi.TongDiem ?? 10) * 0.5) / daNopBai.Count * 100, 2) : 0,
                // Chi tiết bài thi với thông tin đầy đủ cho DataGridView
                ChiTietBaiThis = baiThis.Select(b => new ChiTietBaiThiDTO
                {
                    BaiThiId = b.Id,
                    MaSV = b.SinhVien?.Email ?? "N/A",
                    TenSV = b.SinhVien?.HoTen ?? "N/A",
                    TenSinhVien = b.SinhVien?.HoTen ?? "N/A",
                    DiemSo = b.DiemSo.HasValue ? (int?)b.DiemSo.Value : null,
                    ThoiGianBatDau = b.ThoiGianBatDau,
                    ThoiGianNopBai = b.ThoiGianNopBai,
                    TrangThai = b.TrangThai
                }).OrderByDescending(b => b.DiemSo ?? -1).ToList(),
                // Legacy property
                ChiTietBaiThi = baiThis.Select(b => new ChiTietBaiThiDTO
                {
                    BaiThiId = b.Id,
                    TenSinhVien = b.SinhVien?.HoTen ?? "N/A",
                    DiemSo = b.DiemSo.HasValue ? (int?)b.DiemSo.Value : null,
                    ThoiGianNopBai = b.ThoiGianNopBai,
                    TrangThai = b.TrangThai
                }).OrderByDescending(b => b.DiemSo ?? -1).ToList()
            };
        }

        // Thống kê tổng quan cho giáo viên
        public ThongKeTongQuanDTO GetThongKeTongQuan(long giaoVienId)
        {
            var tongSoCauHoi = _context.CauHoiThi.Count(c => c.NguoiTao == giaoVienId && c.TrangThai);
            var tongSoNganHangDe = _context.NganHangDe.Count(n => n.NguoiTao == giaoVienId);
            
            // Lấy các kỳ thi từ ngân hàng đề của giáo viên
            var nganHangDeIds = _context.NganHangDe.Where(n => n.NguoiTao == giaoVienId).Select(n => n.Id).ToList();
            var kyThis = _context.KyThi.Where(k => nganHangDeIds.Contains(k.MaNganHangDe ?? 0)).ToList();
            
            var tongSoKyThi = kyThis.Count;
            var kyThiDangDienRa = kyThis.Count(k => k.ThoiGianBatDau <= DateTime.Now && k.ThoiGianKetThuc >= DateTime.Now);
            var kyThiSapToi = kyThis.Count(k => k.ThoiGianBatDau > DateTime.Now);
            var kyThiDaKetThuc = kyThis.Count(k => k.ThoiGianKetThuc < DateTime.Now);

            // Đếm số bài thi đã nộp
            var kyThiIds = kyThis.Select(k => k.Id).ToList();
            var tongSoBaiThi = _context.BaiThi.Count(b => kyThiIds.Contains(b.MaKyThi ?? 0) && 
                (b.TrangThai == "da_nop" || b.TrangThai == "cham_diem"));

            return new ThongKeTongQuanDTO
            {
                TongSoCauHoi = tongSoCauHoi,
                TongSoKhungDe = tongSoNganHangDe,
                TongSoNganHangDe = tongSoNganHangDe, // Legacy
                TongSoKyThi = tongSoKyThi,
                TongSoBaiThi = tongSoBaiThi,
                KyThiDangDienRa = kyThiDangDienRa,
                KyThiSapToi = kyThiSapToi,
                KyThiDaKetThuc = kyThiDaKetThuc
            };
        }

        // Thống kê câu hỏi theo môn học
        public List<ThongKeCauHoiDTO> GetThongKeCauHoiTheoMon(long giaoVienId)
        {
            var result = _context.CauHoiThi
                .Where(c => c.NguoiTao == giaoVienId && c.TrangThai)
                .GroupBy(c => c.MonHoc)
                .Select(g => new ThongKeCauHoiDTO
                {
                    TenMon = g.Key != null ? g.Key.TenMon : "Không xác định",
                    TenMonHoc = g.Key != null ? g.Key.TenMon : "Không xác định",
                    SoCauHoi = g.Count()
                })
                .OrderByDescending(x => x.SoCauHoi)
                .ToList();

            return result;
        }

        // Thống kê kết quả thi theo thời gian
        public List<ThongKeKetQuaDTO> GetThongKeKetQuaTheoThoiGian(long giaoVienId, DateTime tuNgay, DateTime denNgay)
        {
            var nganHangDeIds = _context.NganHangDe.Where(n => n.NguoiTao == giaoVienId).Select(n => n.Id).ToList();
            
            var result = _context.BaiThi
                .Include(b => b.KyThi)
                .Where(b => nganHangDeIds.Contains(b.KyThi.MaNganHangDe ?? 0) 
                    && b.ThoiGianNopBai >= tuNgay 
                    && b.ThoiGianNopBai <= denNgay
                    && (b.TrangThai == "da_nop" || b.TrangThai == "cham_diem"))
                .GroupBy(b => b.ThoiGianNopBai.Value.Date)
                .Select(g => new ThongKeKetQuaDTO
                {
                    Ngay = g.Key,
                    SoBaiThi = g.Count(),
                    DiemTrungBinh = Math.Round(g.Average(b => b.DiemSo ?? 0), 2)
                })
                .OrderBy(x => x.Ngay)
                .ToList();

            return result;
        }

        // Thống kê vi phạm trong kỳ thi
        public List<ThongKeViPhamDTO> GetThongKeViPham(long kyThiId)
        {
            var result = _context.NhatKyViPham
                .Include(v => v.BaiThi)
                .ThenInclude(b => b.SinhVien)
                .Where(v => v.BaiThi.MaKyThi == kyThiId)
                .Select(v => new ThongKeViPhamDTO
                {
                    TenSinhVien = v.BaiThi.SinhVien.HoTen,
                    LoaiViPham = v.LoaiViPham,
                    SoLanViPham = v.SoLanViPham,
                    ThoiGian = v.LanCuoiXayRa ?? v.NgayTao
                })
                .OrderByDescending(v => v.ThoiGian)
                .ToList();

            return result;
        }
    }

    // DTOs cho thống kê
    public class ThongKeKyThiDTO
    {
        public long KyThiId { get; set; }
        public string TenKyThi { get; set; }
        public DateTime ThoiGianBatDau { get; set; }
        public DateTime ThoiGianKetThuc { get; set; }
        public int TongSoSinhVien { get; set; }
        public int SoDaThi { get; set; }
        public int SoChuaThi { get; set; }
        // Legacy names for backward compatibility
        public int SoSinhVienDaThi { get; set; }
        public int SoSinhVienChuaThi { get; set; }
        public double DiemTrungBinh { get; set; }
        public int DiemCaoNhat { get; set; }
        public int DiemThapNhat { get; set; }
        public double TyLeDau { get; set; }
        // Chi tiết bài thi với thông tin đầy đủ cho DataGridView
        public List<ChiTietBaiThiDTO> ChiTietBaiThis { get; set; }
        // Legacy property for backward compatibility
        public List<ChiTietBaiThiDTO> ChiTietBaiThi { get; set; }
    }

    public class ChiTietBaiThiDTO
    {
        public long BaiThiId { get; set; }
        public string MaSV { get; set; }
        public string TenSV { get; set; }
        public string TenSinhVien { get; set; }
        public int? DiemSo { get; set; }
        public DateTime? ThoiGianBatDau { get; set; }
        public DateTime? ThoiGianNopBai { get; set; }
        public string TrangThai { get; set; }
    }

    public class ThongKeTongQuanDTO
    {
        public int TongSoCauHoi { get; set; }
        public int TongSoKhungDe { get; set; }
        public int TongSoKyThi { get; set; }
        public int TongSoBaiThi { get; set; }
        // Legacy names for backward compatibility  
        public int TongSoNganHangDe { get; set; }
        public int KyThiDangDienRa { get; set; }
        public int KyThiSapToi { get; set; }
        public int KyThiDaKetThuc { get; set; }
    }

    public class ThongKeCauHoiDTO
    {
        public string TenMon { get; set; }
        public string TenMonHoc { get; set; }
        public int SoCauHoi { get; set; }
    }

    public class ThongKeKetQuaDTO
    {
        public DateTime Ngay { get; set; }
        public int SoBaiThi { get; set; }
        public double DiemTrungBinh { get; set; }
    }

    public class ThongKeViPhamDTO
    {
        public string TenSinhVien { get; set; }
        public string LoaiViPham { get; set; }
        public int SoLanViPham { get; set; }
        public DateTime ThoiGian { get; set; }
    }
}
