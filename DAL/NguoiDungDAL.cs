using PhanMemThiTracNghiem.DAL.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PhanMemThiTracNghiem.DAL
{
    public class NguoiDungDAL
    {
        private readonly DuLieuDAL duLieuDAL;

        public NguoiDungDAL()
        {
            duLieuDAL = new DuLieuDAL();
        }

        // Lấy tất cả người dùng
        public List<NGUOIDUNG> GetAll()
        {
            return duLieuDAL.NGUOIDUNG.Include(x => x.ROLE).ToList();
        }

        // Lấy người dùng theo ID
        public NGUOIDUNG GetById(int id)
        {
            return duLieuDAL.NGUOIDUNG.Include(x => x.ROLE)
                .FirstOrDefault(x => x.ID == id);
        }

        // Lấy người dùng theo Email
        public NGUOIDUNG GetByEmail(string email)
        {
            return duLieuDAL.NGUOIDUNG.Include(x => x.ROLE)
                .FirstOrDefault(x => x.EMAIL == email);
        }

        // Đăng nhập - kiểm tra email và mật khẩu
        public NGUOIDUNG DangNhap(string email, string matKhau)
        {
            string hashedPassword = PhanMemThiTracNghiem.BAL.PasswordHelper.HashPassword(matKhau);
            return duLieuDAL.NGUOIDUNG.Include(x => x.ROLE)
                .FirstOrDefault(x => x.EMAIL == email && x.MATKHAU == hashedPassword);
        }

        // Lấy người dùng theo role
        public List<NGUOIDUNG> GetByRole(int maRole)
        {
            return duLieuDAL.NGUOIDUNG.Include(x => x.ROLE)
                .Where(x => x.MAROLE == maRole).ToList();
        }

        // Thêm người dùng mới
        public bool Add(NGUOIDUNG nguoiDung)
        {
            try
            {
                duLieuDAL.NGUOIDUNG.Add(nguoiDung);
                duLieuDAL.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        // Cập nhật người dùng
        public bool Update(NGUOIDUNG nguoiDung)
        {
            try
            {
                var existing = duLieuDAL.NGUOIDUNG.Find(nguoiDung.ID);
                if (existing != null)
                {
                    existing.MATKHAU = nguoiDung.MATKHAU;
                    existing.EMAIL = nguoiDung.EMAIL;
                    existing.HOTEN = nguoiDung.HOTEN;
                    existing.MAROLE = nguoiDung.MAROLE;
                    duLieuDAL.SaveChanges();
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }

        // Xóa người dùng
        public bool Delete(int id)
        {
            try
            {
                var nguoiDung = duLieuDAL.NGUOIDUNG.Find(id);
                if (nguoiDung != null)
                {
                    duLieuDAL.NGUOIDUNG.Remove(nguoiDung);
                    duLieuDAL.SaveChanges();
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
            return duLieuDAL.NGUOIDUNG.Any(x => x.EMAIL == email);
        }
    }
}
