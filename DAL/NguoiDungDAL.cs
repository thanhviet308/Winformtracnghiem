using PhanMemThiTracNghiem.DAL.Model;
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
            return duLieuDAL.NGUOIDUNG.Include("ROLE").ToList();
        }

        // Lấy người dùng theo mã
        public NGUOIDUNG GetByMaNguoiDung(string maNguoiDung)
        {
            return duLieuDAL.NGUOIDUNG.Include("ROLE")
                .FirstOrDefault(x => x.TENTAIKHOAN == maNguoiDung);
        }

        // Đăng nhập - kiểm tra tài khoản (mã hoặc email) và mật khẩu
        public NGUOIDUNG DangNhap(string taiKhoan, string matKhau)
        {
            return duLieuDAL.NGUOIDUNG.Include("ROLE")
                .FirstOrDefault(x => (x.TENTAIKHOAN == taiKhoan || x.EMAIL == taiKhoan) && x.MATKHAU == matKhau);
        }

        // Lấy người dùng theo role
        public List<NGUOIDUNG> GetByRole(int maRole)
        {
            return duLieuDAL.NGUOIDUNG.Include("ROLE")
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
                var existing = duLieuDAL.NGUOIDUNG.Find(nguoiDung.TENTAIKHOAN);
                if (existing != null)
                {
                    existing.MATKHAU = nguoiDung.MATKHAU;
                    existing.EMAIL = nguoiDung.EMAIL;
                    existing.HOTEN = nguoiDung.HOTEN;
                    existing.NGAYSINH = nguoiDung.NGAYSINH;
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
        public bool Delete(string maNguoiDung)
        {
            try
            {
                var nguoiDung = duLieuDAL.NGUOIDUNG.Find(maNguoiDung);
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

        // Kiểm tra tài khoản tồn tại
        public bool IsExist(string maNguoiDung)
        {
            return duLieuDAL.NGUOIDUNG.Any(x => x.TENTAIKHOAN == maNguoiDung);
        }
    }
}
