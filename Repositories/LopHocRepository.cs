using PhanMemThiTracNghiem.Data;
using PhanMemThiTracNghiem.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PhanMemThiTracNghiem.Repositories
{
    public class LopHocRepository
    {
        private readonly AppDbContext _context;

        public LopHocRepository()
        {
            _context = new AppDbContext();
        }

        // Lấy tất cả lớp học
        public List<LopHoc> GetAll()
        {
            return _context.LopHoc.ToList();
        }

        // Lấy lớp học theo ID
        public LopHoc GetById(long id)
        {
            return _context.LopHoc
                .Include(l => l.LopHocSinhViens)
                    .ThenInclude(ls => ls.SinhVien)
                .FirstOrDefault(l => l.Id == id);
        }

        // Lấy sinh viên trong lớp
        public List<NguoiDung> GetSinhVienInLop(long maLop)
        {
            return _context.LopHocSinhVien
                .Include(ls => ls.SinhVien)
                .Where(ls => ls.MaLop == maLop)
                .Select(ls => ls.SinhVien)
                .ToList();
        }

        // Thêm lớp học
        public bool Add(LopHoc lopHoc)
        {
            try
            {
                _context.LopHoc.Add(lopHoc);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        // Cập nhật lớp học
        public bool Update(LopHoc lopHoc)
        {
            try
            {
                var existing = _context.LopHoc.Find(lopHoc.Id);
                if (existing != null)
                {
                    existing.TenLop = lopHoc.TenLop;
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

        // Xóa lớp học
        public bool Delete(long id)
        {
            try
            {
                var lopHoc = _context.LopHoc.Find(id);
                if (lopHoc != null)
                {
                    _context.LopHoc.Remove(lopHoc);
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

        // Thêm sinh viên vào lớp
        public bool AddSinhVienToLop(long maLop, long maSinhVien)
        {
            try
            {
                var lopHocSinhVien = new LopHocSinhVien
                {
                    MaLop = maLop,
                    MaSinhVien = maSinhVien
                };
                _context.LopHocSinhVien.Add(lopHocSinhVien);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        // Xóa sinh viên khỏi lớp
        public bool RemoveSinhVienFromLop(long maLop, long maSinhVien)
        {
            try
            {
                var lopHocSinhVien = _context.LopHocSinhVien
                    .FirstOrDefault(ls => ls.MaLop == maLop && ls.MaSinhVien == maSinhVien);
                if (lopHocSinhVien != null)
                {
                    _context.LopHocSinhVien.Remove(lopHocSinhVien);
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
    }
}
