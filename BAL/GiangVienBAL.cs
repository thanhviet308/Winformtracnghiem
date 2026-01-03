using PhanMemThiTracNghiem.DAL.DTO;
using PhanMemThiTracNghiem.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PhanMemThiTracNghiem.BAL
{
    /// <summary>
    /// GiangVienBAL - Wrapper class để tương thích ngược với code cũ
    /// Sử dụng NGUOIDUNG với MAROLE = 2 (GiangVien)
    /// </summary>
    public class GiangVienBAL
    {
        private readonly NguoiDungBAL nguoiDungBAL;
        private const int ROLE_GIANGVIEN = 2;

        public GiangVienBAL()
        {
            nguoiDungBAL = new NguoiDungBAL();
        }

        // Lấy tất cả giảng viên - trả về DTO để hiển thị
        public List<NguoiDungDTO> GetGIANGVIENs()
        {
            return nguoiDungBAL.GetByRole(ROLE_GIANGVIEN)
                .Select(x => new NguoiDungDTO
                {
                    ID = x.ID,
                    Email = x.EMAIL,
                    HoTen = x.HOTEN,
                    VaiTro = x.ROLE?.TENROLE ?? "Giảng viên"
                }).ToList();
        }

        // Lấy giảng viên theo email
        public static NGUOIDUNG GETGiangVien(string email)
        {
            var nguoiDungBAL = new NguoiDungBAL();
            return nguoiDungBAL.GetByEmail(email);
        }

        // Lấy giảng viên theo ID
        public NGUOIDUNG GetById(int id)
        {
            return nguoiDungBAL.GetById(id);
        }

        // Cập nhật giảng viên
        public void CapNhapGiangVien(int id, string email, string hoten, string matkhau)
        {
            var gv = nguoiDungBAL.GetById(id);
            if (gv != null)
            {
                gv.EMAIL = email;
                gv.HOTEN = hoten;
                if (!string.IsNullOrEmpty(matkhau))
                {
                    gv.MATKHAU = PasswordHelper.HashPassword(matkhau);
                }
                nguoiDungBAL.Update(gv);
            }
        }

        // Đổi mật khẩu
        public void DoiMatKhau(int id, string matkhau)
        {
            var gv = nguoiDungBAL.GetById(id);
            if (gv != null)
            {
                gv.MATKHAU = PasswordHelper.HashPassword(matkhau);
                nguoiDungBAL.Update(gv);
            }
        }

        // Xóa giảng viên
        public static void Delete(int id)
        {
            var nguoiDungBAL = new NguoiDungBAL();
            nguoiDungBAL.Delete(id);
        }

        // Tìm theo tên hoặc email
        public List<NguoiDungDTO> FindName(string keyword)
        {
            var search = keyword.ToLower();
            return nguoiDungBAL.GetByRole(ROLE_GIANGVIEN)
                .Where(x => x.HOTEN.ToLower().Contains(search) || x.EMAIL.ToLower().Contains(search))
                .Select(x => new NguoiDungDTO
                {
                    ID = x.ID,
                    Email = x.EMAIL,
                    HoTen = x.HOTEN,
                    VaiTro = x.ROLE?.TENROLE ?? "Giảng viên"
                }).ToList();
        }
    }
}
