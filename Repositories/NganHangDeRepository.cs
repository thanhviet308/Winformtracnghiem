using PhanMemThiTracNghiem.Data;
using PhanMemThiTracNghiem.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PhanMemThiTracNghiem.Repositories
{
    public class NganHangDeRepository
    {
        private readonly AppDbContext _context;

        public NganHangDeRepository()
        {
            _context = new AppDbContext();
        }

        // Lấy tất cả ngân hàng đề
        public List<NganHangDe> GetAll()
        {
            return _context.NganHangDe
                .Include(n => n.MonHoc)
                .Include(n => n.NguoiDung)
                .ToList();
        }

        // Lấy ngân hàng đề theo ID
        public NganHangDe GetById(long id)
        {
            return _context.NganHangDe
                .Include(n => n.MonHoc)
                .Include(n => n.NguoiDung)
                .Include(n => n.CauTrucDes)
                .FirstOrDefault(n => n.Id == id);
        }

        // Lấy ngân hàng đề theo môn học
        public List<NganHangDe> GetByMonHoc(long maMon)
        {
            return _context.NganHangDe
                .Include(n => n.NguoiDung)
                .Where(n => n.MaMon == maMon)
                .ToList();
        }

        // Thêm ngân hàng đề
        public bool Add(NganHangDe nganHangDe)
        {
            try
            {
                _context.NganHangDe.Add(nganHangDe);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        // Cập nhật ngân hàng đề
        public bool Update(NganHangDe nganHangDe)
        {
            try
            {
                var existing = _context.NganHangDe.Find(nganHangDe.Id);
                if (existing != null)
                {
                    existing.TenDe = nganHangDe.TenDe;
                    existing.MaMon = nganHangDe.MaMon;
                    existing.TongSoCau = nganHangDe.TongSoCau;
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

        // Xóa ngân hàng đề
        public bool Delete(long id)
        {
            try
            {
                var nganHangDe = _context.NganHangDe.Find(id);
                if (nganHangDe != null)
                {
                    _context.NganHangDe.Remove(nganHangDe);
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
