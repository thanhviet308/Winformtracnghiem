using PhanMemThiTracNghiem.Data;
using PhanMemThiTracNghiem.Models;
using PhanMemThiTracNghiem.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PhanMemThiTracNghiem.Services
{
    public class LopHocService
    {
        private readonly LopHocRepository _lopHocRepository;
        private readonly AppDbContext _context;

        public LopHocService()
        {
            _lopHocRepository = new LopHocRepository();
            _context = new AppDbContext();
        }

        // Lấy tất cả lớp học
        public List<LopHoc> GetAll()
        {
            return _lopHocRepository.GetAll();
        }

        // Lấy lớp học theo ID kèm sinh viên
        public LopHoc GetById(long id)
        {
            return _lopHocRepository.GetById(id);
        }

        // Thêm lớp học
        public bool Add(LopHoc lopHoc)
        {
            lopHoc.NgayTao = DateTime.Now;
            return _lopHocRepository.Add(lopHoc);
        }

        // Cập nhật lớp học
        public bool Update(LopHoc lopHoc)
        {
            return _lopHocRepository.Update(lopHoc);
        }

        // Xóa lớp học
        public bool Delete(long id)
        {
            return _lopHocRepository.Delete(id);
        }

        // Lấy sinh viên trong lớp
        public List<NguoiDung> GetSinhVienInLop(long maLop)
        {
            return _lopHocRepository.GetSinhVienInLop(maLop);
        }

        // Lấy sinh viên chưa thuộc lớp nào
        public List<NguoiDung> GetSinhVienChuaThuocLop(long maLop)
        {
            var sinhVienTrongLop = _context.LopHocSinhVien
                .Where(ls => ls.MaLop == maLop)
                .Select(ls => ls.MaSinhVien)
                .ToList();

            return _context.NguoiDung
                .Where(n => n.MaVaiTro == 3 && !sinhVienTrongLop.Contains(n.Id))
                .ToList();
        }

        // Gán sinh viên vào lớp
        public bool AddSinhVienToLop(long maLop, long maSinhVien)
        {
            return _lopHocRepository.AddSinhVienToLop(maLop, maSinhVien);
        }

        // Gán nhiều sinh viên vào lớp
        public int AddMultipleSinhVienToLop(long maLop, List<long> maSinhViens)
        {
            int count = 0;
            foreach (var maSinhVien in maSinhViens)
            {
                if (_lopHocRepository.AddSinhVienToLop(maLop, maSinhVien))
                    count++;
            }
            return count;
        }

        // Xóa sinh viên khỏi lớp
        public bool RemoveSinhVienFromLop(long maLop, long maSinhVien)
        {
            return _lopHocRepository.RemoveSinhVienFromLop(maLop, maSinhVien);
        }

        // Xóa tất cả sinh viên khỏi lớp
        public bool RemoveAllSinhVienFromLop(long maLop)
        {
            try
            {
                var sinhViens = _context.LopHocSinhVien.Where(ls => ls.MaLop == maLop);
                _context.LopHocSinhVien.RemoveRange(sinhViens);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        // Đếm số sinh viên trong lớp
        public int CountSinhVienInLop(long maLop)
        {
            return _context.LopHocSinhVien.Count(ls => ls.MaLop == maLop);
        }

        // ========== PHÂN CÔNG GIẢNG DẠY ==========

        // Lấy tất cả phân công
        public List<PhanCongGiangDay> GetAllPhanCong()
        {
            return _context.PhanCongGiangDay
                .Include(p => p.LopHoc)
                .Include(p => p.MonHoc)
                .Include(p => p.GiangVien)
                .ToList();
        }

        // Lấy phân công theo lớp
        public List<PhanCongGiangDay> GetPhanCongByLop(long maLop)
        {
            return _context.PhanCongGiangDay
                .Include(p => p.MonHoc)
                .Include(p => p.GiangVien)
                .Where(p => p.MaLop == maLop)
                .ToList();
        }

        // Thêm phân công
        public bool AddPhanCong(long maLop, long maMon, long? maGiangVien)
        {
            try
            {
                // Kiểm tra đã tồn tại chưa
                var existing = _context.PhanCongGiangDay
                    .FirstOrDefault(p => p.MaLop == maLop && p.MaMon == maMon);
                
                if (existing != null)
                {
                    // Cập nhật giảng viên
                    existing.MaGiangVien = maGiangVien;
                    existing.NgayPhanCong = DateTime.Now;
                }
                else
                {
                    // Thêm mới
                    var phanCong = new PhanCongGiangDay
                    {
                        MaLop = maLop,
                        MaMon = maMon,
                        MaGiangVien = maGiangVien,
                        NgayPhanCong = DateTime.Now
                    };
                    _context.PhanCongGiangDay.Add(phanCong);
                }
                
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        // Xóa phân công
        public bool DeletePhanCong(long maLop, long maMon)
        {
            try
            {
                var phanCong = _context.PhanCongGiangDay
                    .FirstOrDefault(p => p.MaLop == maLop && p.MaMon == maMon);
                
                if (phanCong != null)
                {
                    _context.PhanCongGiangDay.Remove(phanCong);
                    _context.SaveChanges();
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }

        // Lấy danh sách giảng viên
        public List<NguoiDung> GetAllGiangVien()
        {
            return _context.NguoiDung
                .Where(n => n.MaVaiTro == 2) // Role giảng viên = 2
                .ToList();
        }

        public List<MonHoc> GetAllMonHoc()
        {
            return _context.MonHoc.ToList();
        }
    }
}
