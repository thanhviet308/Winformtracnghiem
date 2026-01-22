using PhanMemThiTracNghiem.Data;
using PhanMemThiTracNghiem.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PhanMemThiTracNghiem.Repositories
{
    public class CauHoiRepository
    {
        private readonly AppDbContext _context;

        public CauHoiRepository()
        {
            _context = new AppDbContext();
        }

        // Lấy tất cả câu hỏi
        public List<CauHoiThi> GetAll()
        {
            return _context.CauHoiThi
                .Include(c => c.MonHoc)
                .Include(c => c.LuaChonTracNghiems)
                .Where(c => c.TrangThai == true)
                .ToList();
        }

        // Lấy câu hỏi theo ID
        public CauHoiThi GetById(long id)
        {
            return _context.CauHoiThi
                .Include(c => c.MonHoc)
                .Include(c => c.LuaChonTracNghiems)
                .FirstOrDefault(c => c.Id == id);
        }

        // Lấy câu hỏi theo môn học
        public List<CauHoiThi> GetByMonHoc(long maMon)
        {
            return _context.CauHoiThi
                .Include(c => c.LuaChonTracNghiems)
                .Where(c => c.MaMon == maMon && c.TrangThai == true)
                .ToList();
        }

        // Lấy câu hỏi theo người tạo
        public List<CauHoiThi> GetByNguoiTao(long nguoiTao)
        {
            return _context.CauHoiThi
                .Include(c => c.MonHoc)
                .Include(c => c.LuaChonTracNghiems)
                .Where(c => c.NguoiTao == nguoiTao && c.TrangThai == true)
                .ToList();
        }

        // Thêm câu hỏi
        public bool Add(CauHoiThi cauHoi)
        {
            try
            {
                _context.CauHoiThi.Add(cauHoi);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        // Thêm câu hỏi với các lựa chọn
        public bool AddWithOptions(CauHoiThi cauHoi, List<LuaChonTracNghiem> luaChons)
        {
            try
            {
                _context.CauHoiThi.Add(cauHoi);
                _context.SaveChanges();

                foreach (var luaChon in luaChons)
                {
                    luaChon.MaCauHoi = cauHoi.Id;
                    _context.LuaChonTracNghiem.Add(luaChon);
                }
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        // Cập nhật câu hỏi
        public bool Update(CauHoiThi cauHoi)
        {
            try
            {
                var existing = _context.CauHoiThi.Find(cauHoi.Id);
                if (existing != null)
                {
                    existing.NoiDung = cauHoi.NoiDung;
                    existing.MaMon = cauHoi.MaMon;
                    existing.TrangThai = cauHoi.TrangThai;
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

        // Xóa câu hỏi (soft delete)
        public bool Delete(long id)
        {
            try
            {
                var cauHoi = _context.CauHoiThi.Find(id);
                if (cauHoi != null)
                {
                    cauHoi.TrangThai = false;
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

        // ============ Legacy methods ============
        public List<CauHoiThi> GetCAUHOIs()
        {
            return GetAll();
        }
    }
}
