using PhanMemThiTracNghiem.Data;
using PhanMemThiTracNghiem.Models;
using PhanMemThiTracNghiem.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PhanMemThiTracNghiem.Repositories
{
    public class MonHocRepository
    {
        private readonly AppDbContext _context;

        public MonHocRepository()
        {
            _context = new AppDbContext();
        }

        public List<MonHoc> GetAll()
        {
            return _context.MonHoc.ToList();
        }

        // Lấy môn học theo ID
        public MonHoc GetById(long id)
        {
            return _context.MonHoc.Find(id);
        }

        // Thêm môn học mới
        public bool Add(MonHoc monHoc)
        {
            try
            {
                _context.MonHoc.Add(monHoc);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        // Cập nhật môn học
        public bool Update(MonHoc monHoc)
        {
            try
            {
                var existing = _context.MonHoc.Find(monHoc.Id);
                if (existing != null)
                {
                    existing.TenMon = monHoc.TenMon;
                    existing.MoTa = monHoc.MoTa;
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

        public bool Delete(long id)
        {
            try
            {
                var monHoc = _context.MonHoc.Find(id);
                if (monHoc != null)
                {
                    _context.MonHoc.Remove(monHoc);
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
        public List<MonHoc> GetThongTinMonThi()
        {
            return GetAll();
        }

        public static void InsertUpdate(MonThiDTO monThiDTO)
        {
            using (var context = new AppDbContext())
            {
                var monHoc = new MonHoc
                {
                    TenMon = monThiDTO.TenMT,
                    MoTa = "",
                    NgayTao = DateTime.Now
                };
                context.MonHoc.Add(monHoc);
                context.SaveChanges();
            }
        }
    }
}
