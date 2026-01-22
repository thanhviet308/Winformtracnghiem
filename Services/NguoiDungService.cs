using PhanMemThiTracNghiem.Repositories;
using PhanMemThiTracNghiem.Models;
using System;
using System.Collections.Generic;

namespace PhanMemThiTracNghiem.Services
{
    public class NguoiDungService
    {
        private readonly NguoiDungRepository NguoiDungRepository;

        public NguoiDungService()
        {
            NguoiDungRepository = new NguoiDungRepository();
        }

        // Lấy tất cả người dùng
        public List<NguoiDung> GetAll()
        {
            return NguoiDungRepository.GetAll();
        }

        // Lấy người dùng theo ID
        public NguoiDung GetById(long id)
        {
            return NguoiDungRepository.GetById(id);
        }

        // Lấy người dùng theo Email
        public NguoiDung GetByEmail(string email)
        {
            return NguoiDungRepository.GetByEmail(email);
        }

        // Đăng nhập
        public NguoiDung DangNhap(string email, string matKhau)
        {
            return NguoiDungRepository.DangNhap(email, matKhau);
        }

        // Lấy người dùng theo vai trò
        public List<NguoiDung> GetByRole(long maVaiTro)
        {
            return NguoiDungRepository.GetByRole(maVaiTro);
        }

        // Thêm người dùng mới
        public bool Add(NguoiDung nguoiDung)
        {
            // Kiểm tra email đã tồn tại chưa
            if (NguoiDungRepository.IsEmailExist(nguoiDung.Email))
            {
                return false;
            }
            return NguoiDungRepository.Add(nguoiDung);
        }

        // Cập nhật người dùng
        public bool Update(NguoiDung nguoiDung)
        {
            // Kiểm tra email đã tồn tại (trừ user hiện tại)
            if (NguoiDungRepository.IsEmailExist(nguoiDung.Email, nguoiDung.Id))
            {
                return false;
            }
            return NguoiDungRepository.Update(nguoiDung);
        }

        // Xóa người dùng (soft delete)
        public bool Delete(long id)
        {
            return NguoiDungRepository.Delete(id);
        }

        // Xóa người dùng vĩnh viễn
        public bool HardDelete(long id)
        {
            return NguoiDungRepository.HardDelete(id);
        }

        // Kiểm tra email tồn tại
        public bool IsEmailExist(string email)
        {
            return NguoiDungRepository.IsEmailExist(email);
        }
    }
}
