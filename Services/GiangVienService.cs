using PhanMemThiTracNghiem.Repositories;
using PhanMemThiTracNghiem.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PhanMemThiTracNghiem.Services
{
    public class GiangVienService
    {
        private readonly NguoiDungRepository _nguoiDungRepository;
        private const long ROLE_GIANG_VIEN = 2;

        public GiangVienService()
        {
            _nguoiDungRepository = new NguoiDungRepository();
        }

        // Lấy tất cả giảng viên
        public List<NguoiDung> GetAll()
        {
            return _nguoiDungRepository.GetByRole(ROLE_GIANG_VIEN);
        }

        // Lấy giảng viên theo ID
        public NguoiDung GetById(long id)
        {
            var nguoiDung = _nguoiDungRepository.GetById(id);
            return nguoiDung?.MaVaiTro == ROLE_GIANG_VIEN ? nguoiDung : null;
        }

        // Thêm giảng viên
        public bool Add(NguoiDung giangVien)
        {
            giangVien.MaVaiTro = ROLE_GIANG_VIEN;
            giangVien.NgayTao = DateTime.Now;
            // Hash password
            giangVien.MatKhau = Helpers.PasswordHelper.HashPassword(giangVien.MatKhau);
            return _nguoiDungRepository.Add(giangVien);
        }

        // Cập nhật giảng viên
        public bool Update(NguoiDung giangVien)
        {
            return _nguoiDungRepository.Update(giangVien);
        }

        // Xóa giảng viên
        public bool Delete(long id)
        {
            return _nguoiDungRepository.Delete(id);
        }

        // Tìm kiếm theo tên
        public List<NguoiDung> FindName(string hoTen)
        {
            return GetAll().Where(g => g.HoTen.Contains(hoTen, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        // ============ Legacy methods ============
        public List<NguoiDung> GetGIANGVIENs()
        {
            return GetAll();
        }

        public void CapNhapGiangVien(int id, string email, string hoten, string matkhau)
        {
            var giangVien = _nguoiDungRepository.GetById(id);
            if (giangVien != null)
            {
                giangVien.Email = email;
                giangVien.HoTen = hoten;
                if (!string.IsNullOrEmpty(matkhau) && matkhau != "********")
                {
                    giangVien.MatKhau = Helpers.PasswordHelper.HashPassword(matkhau);
                }
                _nguoiDungRepository.Update(giangVien);
            }
        }
    }
}
