using PhanMemThiTracNghiem.DAL.DTO;
using PhanMemThiTracNghiem.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PhanMemThiTracNghiem.BAL
{
    /// <summary>
    /// SinhVienBAL - Wrapper class để tương thích ngược với code cũ
    /// Sử dụng NGUOIDUNG với MAROLE = 3 (SinhVien)
    /// </summary>
    public class SinhVienBAL
    {
        private readonly NguoiDungBAL nguoiDungBAL;
        private const int ROLE_SINHVIEN = 3;

        public SinhVienBAL()
        {
            nguoiDungBAL = new NguoiDungBAL();
        }

        // Lấy tất cả sinh viên - trả về DTO
        public List<NguoiDungDTO> GetSINHVIENs()
        {
            return nguoiDungBAL.GetByRole(ROLE_SINHVIEN)
                .Select(x => new NguoiDungDTO
                {
                    ID = x.ID,
                    Email = x.EMAIL,
                    HoTen = x.HOTEN,
                    VaiTro = x.ROLE?.TENROLE ?? "Sinh viên"
                }).ToList();
        }

        // Lấy sinh viên theo email
        public static NGUOIDUNG GETSinhVien(string email)
        {
            var nguoiDungBAL = new NguoiDungBAL();
            return nguoiDungBAL.GetByEmail(email);
        }

        // Lấy sinh viên theo ID
        public NGUOIDUNG GetById(int id)
        {
            return nguoiDungBAL.GetById(id);
        }

        // Cập nhật sinh viên
        public void CapNhapSinhVien(int id, string email, string hoten)
        {
            var sv = nguoiDungBAL.GetById(id);
            if (sv != null)
            {
                sv.EMAIL = email;
                sv.HOTEN = hoten;
                nguoiDungBAL.Update(sv);
            }
        }

        // Xóa sinh viên
        public static void Delete(int id)
        {
            var nguoiDungBAL = new NguoiDungBAL();
            nguoiDungBAL.Delete(id);
        }

        // Tìm theo tên hoặc email
        public List<NguoiDungDTO> FindName(string keyword)
        {
            var search = keyword.ToLower();
            return nguoiDungBAL.GetByRole(ROLE_SINHVIEN)
                .Where(x => x.HOTEN.ToLower().Contains(search) || x.EMAIL.ToLower().Contains(search))
                .Select(x => new NguoiDungDTO
                {
                    ID = x.ID,
                    Email = x.EMAIL,
                    HoTen = x.HOTEN,
                    VaiTro = x.ROLE?.TENROLE ?? "Sinh viên"
                }).ToList();
        }
    }
}
