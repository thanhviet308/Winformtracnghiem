using PhanMemThiTracNghiem.Data;
using PhanMemThiTracNghiem.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PhanMemThiTracNghiem.Repositories
{
    public class NguoiDungRepository
    {
        private readonly AppDbContext AppDbContext;

        public NguoiDungRepository()
        {
            AppDbContext = new AppDbContext();
        }

        // Lấy tất cả người dùng
        public List<NguoiDung> GetAll()
        {
            return AppDbContext.NguoiDung.Include(x => x.VaiTro).ToList();
        }

        // Lấy người dùng theo ID
        public NguoiDung GetById(long id)
        {
            return AppDbContext.NguoiDung.Include(x => x.VaiTro)
                .FirstOrDefault(x => x.Id == id);
        }

        // Lấy người dùng theo Email
        public NguoiDung GetByEmail(string email)
        {
            return AppDbContext.NguoiDung.Include(x => x.VaiTro)
                .FirstOrDefault(x => x.Email == email);
        }

        // Đăng nhập - kiểm tra email và mật khẩu
        public NguoiDung DangNhap(string email, string matKhau)
        {
            string hashedPassword = PhanMemThiTracNghiem.Helpers.PasswordHelper.HashPassword(matKhau);
            return AppDbContext.NguoiDung.Include(x => x.VaiTro)
                .FirstOrDefault(x => x.Email == email && x.MatKhau == hashedPassword);
        }

        // Lấy người dùng theo vai trò
        public List<NguoiDung> GetByRole(long maVaiTro)
        {
            return AppDbContext.NguoiDung.Include(x => x.VaiTro)
                .Where(x => x.MaVaiTro == maVaiTro).ToList();
        }

        // Thêm người dùng mới
        public bool Add(NguoiDung nguoiDung)
        {
            try
            {
                AppDbContext.NguoiDung.Add(nguoiDung);
                AppDbContext.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        // Cập nhật người dùng
        public bool Update(NguoiDung nguoiDung)
        {
            try
            {
                var existing = AppDbContext.NguoiDung.Find(nguoiDung.Id);
                if (existing != null)
                {
                    existing.MatKhau = nguoiDung.MatKhau;
                    existing.Email = nguoiDung.Email;
                    existing.HoTen = nguoiDung.HoTen;
                    existing.MaVaiTro = nguoiDung.MaVaiTro;
                    AppDbContext.SaveChanges();
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }

        // Xóa người dùng (hard delete)
        public bool Delete(long id)
        {
            return HardDelete(id);
        }

        // Xóa người dùng vĩnh viễn
        public bool HardDelete(long id)
        {
            try
            {
                var nguoiDung = AppDbContext.NguoiDung.Find(id);
                if (nguoiDung != null)
                {
                    AppDbContext.NguoiDung.Remove(nguoiDung);
                    AppDbContext.SaveChanges();
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }

        // Kiểm tra email tồn tại
        public bool IsEmailExist(string email)
        {
            return AppDbContext.NguoiDung.Any(x => x.Email == email);
        }

        // Kiểm tra email tồn tại (trừ user hiện tại)
        public bool IsEmailExist(string email, long excludeId)
        {
            return AppDbContext.NguoiDung.Any(x => x.Email == email && x.Id != excludeId);
        }
    }
}
