using PhanMemThiTracNghiem.Data;
using PhanMemThiTracNghiem.Models;
using PhanMemThiTracNghiem.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PhanMemThiTracNghiem.Repositories
{
    public class KyThiRepository
    {
        private readonly AppDbContext _context;

        public KyThiRepository()
        {
            _context = new AppDbContext();
        }

        // Lấy tất cả kỳ thi
        public List<KyThi> GetAll()
        {
            return _context.KyThi
                .Include(k => k.NganHangDe)
                .Include(k => k.LopHoc)
                .OrderByDescending(k => k.NgayTao)
                .ToList();
        }

        // Lấy kỳ thi theo ID
        public KyThi GetById(long id)
        {
            return _context.KyThi
                .Include(k => k.NganHangDe)
                .Include(k => k.LopHoc)
                .FirstOrDefault(k => k.Id == id);
        }

        // Lấy kỳ thi đang diễn ra
        public List<KyThi> GetActiveExams()
        {
            var now = DateTime.Now;
            return _context.KyThi
                .Include(k => k.NganHangDe)
                .Include(k => k.LopHoc)
                .Where(k => k.ThoiGianBatDau <= now && k.ThoiGianKetThuc >= now)
                .ToList();
        }

        // Thêm kỳ thi mới
        public bool Add(KyThi kyThi)
        {
            try
            {
                _context.KyThi.Add(kyThi);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        // Cập nhật kỳ thi
        public bool Update(KyThi kyThi)
        {
            try
            {
                var existing = _context.KyThi.Find(kyThi.Id);
                if (existing != null)
                {
                    existing.TenKyThi = kyThi.TenKyThi;
                    existing.MaNganHangDe = kyThi.MaNganHangDe;
                    existing.MaLop = kyThi.MaLop;
                    existing.ThoiGianBatDau = kyThi.ThoiGianBatDau;
                    existing.ThoiGianKetThuc = kyThi.ThoiGianKetThuc;
                    existing.ThoiLuongPhut = kyThi.ThoiLuongPhut;
                    existing.TronCauHoi = kyThi.TronCauHoi;
                    existing.TronDapAn = kyThi.TronDapAn;
                    existing.TongDiem = kyThi.TongDiem;
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

        // Xóa kỳ thi
        public bool Delete(long id)
        {
            try
            {
                var kyThi = _context.KyThi.Find(id);
                if (kyThi != null)
                {
                    _context.KyThi.Remove(kyThi);
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

        // ============ Legacy methods for backward compatibility ============
        // TODO: Các method này cần được cập nhật dần dần

        public List<KyThi> GetThongTinKyThi()
        {
            return GetAll();
        }

        public List<KyThi> GetKITHIs()
        {
            return GetAll();
        }

        public static void InsertUpdate(KiThiDTO kiThiDTO)
        {
            // TODO: Implement with new model
            using (var context = new AppDbContext())
            {
                var kyThi = new KyThi
                {
                    TenKyThi = kiThiDTO.TenKiThi,
                    ThoiGianBatDau = kiThiDTO.ThoiGianBD,
                    ThoiGianKetThuc = kiThiDTO.ThoiGianKT,
                    NgayTao = DateTime.Now
                };
                context.KyThi.Add(kyThi);
                context.SaveChanges();
            }
        }
    }
}
