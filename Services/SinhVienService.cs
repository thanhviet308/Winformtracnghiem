using PhanMemThiTracNghiem.Repositories;
using PhanMemThiTracNghiem.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PhanMemThiTracNghiem.Services
{
    public class SinhVienService
    {
        private readonly NguoiDungRepository _nguoiDungRepository;
        private const long ROLE_SINH_VIEN = 3;

        public SinhVienService()
        {
            _nguoiDungRepository = new NguoiDungRepository();
        }

        // Lấy tất cả sinh viên
        public List<NguoiDung> GetAll()
        {
            return _nguoiDungRepository.GetByRole(ROLE_SINH_VIEN);
        }

        // Lấy sinh viên theo ID
        public NguoiDung GetById(long id)
        {
            var nguoiDung = _nguoiDungRepository.GetById(id);
            return nguoiDung?.MaVaiTro == ROLE_SINH_VIEN ? nguoiDung : null;
        }

        // Thêm sinh viên
        public bool Add(NguoiDung sinhVien)
        {
            sinhVien.MaVaiTro = ROLE_SINH_VIEN;
            sinhVien.TrangThai = true;
            sinhVien.NgayTao = DateTime.Now;
            // Hash password - mặc định là 123456
            if (string.IsNullOrEmpty(sinhVien.MatKhau))
            {
                sinhVien.MatKhau = Helpers.PasswordHelper.HashPassword("123456");
            }
            else
            {
                sinhVien.MatKhau = Helpers.PasswordHelper.HashPassword(sinhVien.MatKhau);
            }
            return _nguoiDungRepository.Add(sinhVien);
        }

        // Cập nhật sinh viên
        public bool Update(NguoiDung sinhVien)
        {
            return _nguoiDungRepository.Update(sinhVien);
        }

        // Xóa sinh viên
        public bool Delete(long id)
        {
            return _nguoiDungRepository.Delete(id);
        }

        // Tìm kiếm theo tên
        public List<NguoiDung> FindName(string hoTen)
        {
            return GetAll().Where(s => s.HoTen.Contains(hoTen, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        // ============ Legacy methods ============
        public List<NguoiDung> GetSINHVIENs()
        {
            return GetAll();
        }

        public void CapNhapSinhVien(int id, string email, string hoten)
        {
            var sinhVien = _nguoiDungRepository.GetById(id);
            if (sinhVien != null)
            {
                sinhVien.Email = email;
                sinhVien.HoTen = hoten;
                _nguoiDungRepository.Update(sinhVien);
            }
        }
    }
}
