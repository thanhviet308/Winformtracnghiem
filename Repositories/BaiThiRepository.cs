using PhanMemThiTracNghiem.Data;
using PhanMemThiTracNghiem.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PhanMemThiTracNghiem.Repositories
{
    public class BaiThiRepository
    {
        private readonly AppDbContext _context;

        public BaiThiRepository()
        {
            _context = new AppDbContext();
        }

        // Lấy tất cả bài thi
        public List<BaiThi> GetAll()
        {
            return _context.BaiThi
                .Include(b => b.KyThi)
                .Include(b => b.SinhVien)
                .ToList();
        }

        // Lấy bài thi theo ID
        public BaiThi GetById(long id)
        {
            return _context.BaiThi
                .Include(b => b.KyThi)
                .Include(b => b.SinhVien)
                .Include(b => b.TraLoiBaiThis)
                .FirstOrDefault(b => b.Id == id);
        }

        // Lấy bài thi theo sinh viên
        public List<BaiThi> GetBySinhVien(long maSinhVien)
        {
            return _context.BaiThi
                .Include(b => b.KyThi)
                .Where(b => b.MaSinhVien == maSinhVien)
                .OrderByDescending(b => b.ThoiGianBatDau)
                .ToList();
        }

        // Lấy bài thi theo kỳ thi
        public List<BaiThi> GetByKyThi(long maKyThi)
        {
            return _context.BaiThi
                .Include(b => b.SinhVien)
                .Where(b => b.MaKyThi == maKyThi)
                .ToList();
        }

        // Tạo bài thi mới
        public bool Add(BaiThi baiThi)
        {
            try
            {
                _context.BaiThi.Add(baiThi);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        // Cập nhật bài thi
        public bool Update(BaiThi baiThi)
        {
            try
            {
                var existing = _context.BaiThi.Find(baiThi.Id);
                if (existing != null)
                {
                    existing.ThoiGianNopBai = baiThi.ThoiGianNopBai;
                    existing.DiemSo = baiThi.DiemSo;
                    existing.TrangThai = baiThi.TrangThai;
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

        // Nộp bài thi
        public bool NopBai(long baiThiId, int diemSo)
        {
            try
            {
                var baiThi = _context.BaiThi.Find(baiThiId);
                if (baiThi != null)
                {
                    baiThi.ThoiGianNopBai = DateTime.Now;
                    baiThi.DiemSo = diemSo;
                    baiThi.TrangThai = "da_nop";
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
