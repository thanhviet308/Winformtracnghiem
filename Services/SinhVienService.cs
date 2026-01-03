using PhanMemThiTracNghiem.DTOs;
using PhanMemThiTracNghiem.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PhanMemThiTracNghiem.Services
{
    /// <summary>
    /// SinhVienService - Wrapper class để tương thích ngược với code cũ
    /// Sử dụng NGUOIDUNG với MAROLE = 3 (SinhVien)
    /// </summary>
    public class SinhVienService
    {
        private readonly NguoiDungService NguoiDungService;
        private const int ROLE_SINHVIEN = 3;

        public SinhVienService()
        {
            NguoiDungService = new NguoiDungService();
        }

        // Lấy tất cả sinh viên - trả về DTO
        public List<NguoiDungDTO> GetSINHVIENs()
        {
            return NguoiDungService.GetByRole(ROLE_SINHVIEN)
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
            var NguoiDungService = new NguoiDungService();
            return NguoiDungService.GetByEmail(email);
        }

        // Lấy sinh viên theo ID
        public NGUOIDUNG GetById(int id)
        {
            return NguoiDungService.GetById(id);
        }

        // Cập nhật sinh viên
        public void CapNhapSinhVien(int id, string email, string hoten)
        {
            var sv = NguoiDungService.GetById(id);
            if (sv != null)
            {
                sv.EMAIL = email;
                sv.HOTEN = hoten;
                NguoiDungService.Update(sv);
            }
        }

        // Xóa sinh viên
        public static void Delete(int id)
        {
            var NguoiDungService = new NguoiDungService();
            NguoiDungService.Delete(id);
        }

        // Tìm theo tên hoặc email
        public List<NguoiDungDTO> FindName(string keyword)
        {
            var search = keyword.ToLower();
            return NguoiDungService.GetByRole(ROLE_SINHVIEN)
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
