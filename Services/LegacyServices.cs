using PhanMemThiTracNghiem.Models;
using PhanMemThiTracNghiem.DTOs;
using PhanMemThiTracNghiem.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PhanMemThiTracNghiem.Services
{
    /// <summary>
    /// DTO for ChiTietDeThi - thay thế class cũ
    /// </summary>
    public class ChiTietDeThiDTO
    {
        public string MaDeThi { get; set; }
        public int MaCauHoi { get; set; }
    }

    /// <summary>
    /// Service tạm thời cho ChiTietDeThi - cần refactor
    /// </summary>
    public class ChiTietDeThiService
    {
        public ChiTietDeThiService()
        {
        }

        public List<ChiTietDeThiDTO> GetCauHoi()
        {
            // Trả về list rỗng - service này không còn sử dụng
            return new List<ChiTietDeThiDTO>();
        }
    }

    /// <summary>
    /// Service tạm thời cho ChiTietKyThi - cần refactor
    /// </summary>
    public class ChiTietKyThiService
    {
        private readonly AppDbContext _context;

        public ChiTietKyThiService()
        {
            _context = new AppDbContext();
        }

        public List<BaiThi> GetThongTinChiTietKyThi()
        {
            return _context.BaiThi.ToList();
        }

        public void LuuChiTietKyThi(NguoiDung nguoiDung, string maKyThi, MonHoc monHoc, float diem, DateTime thoiGianBD, DateTime thoiGianKT, int thoiGianThi)
        {
            // Tạo bài thi mới
            var baiThi = new BaiThi
            {
                MaKyThi = long.TryParse(maKyThi, out long id) ? id : (long?)null,
                MaSinhVien = nguoiDung.Id,
                ThoiGianBatDau = thoiGianBD,
                ThoiGianNopBai = thoiGianKT,
                DiemSo = (int)diem,
                TrangThai = "da_nop"
            };
            _context.BaiThi.Add(baiThi);
            _context.SaveChanges();
        }

        public Tuple<NguoiDung, MonHoc> GetThongTinSinhVienMonThi(string maSV, string maMT)
        {
            var nguoiDung = _context.NguoiDung.FirstOrDefault(n => n.Id.ToString() == maSV);
            var monHoc = _context.MonHoc.FirstOrDefault(m => m.Id.ToString() == maMT);
            return new Tuple<NguoiDung, MonHoc>(nguoiDung, monHoc);
        }
    }

    /// <summary>
    /// Service tạm thời cho BangDiem - cần refactor
    /// </summary>
    public class BangDiemService
    {
        private readonly AppDbContext _context;

        public BangDiemService()
        {
            _context = new AppDbContext();
        }

        public List<BaiThi> GetBangDiem()
        {
            return _context.BaiThi.ToList();
        }

        public void LuuDiemThi(int id, float diem, string maSV, string maKyThi, string maMT)
        {
            // Tìm bài thi và cập nhật điểm
            var baiThi = _context.BaiThi.FirstOrDefault(b => 
                b.MaSinhVien.ToString() == maSV && 
                b.MaKyThi.ToString() == maKyThi);
            
            if (baiThi != null)
            {
                baiThi.DiemSo = (int)diem;
                _context.SaveChanges();
            }
        }
    }

    /// <summary>
    /// Alias cho MonThiService để giữ tương thích
    /// </summary>
    public class MonThiService : MonHocService
    {
        public MonThiService() : base()
        {
        }
    }
}
