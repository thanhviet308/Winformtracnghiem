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
        public List<NGUOIDUNG> GetAll()
        {
            return NguoiDungRepository.GetAll();
        }

        // Lấy người dùng theo ID
        public NGUOIDUNG GetById(int id)
        {
            return NguoiDungRepository.GetById(id);
        }

        // Lấy người dùng theo Email
        public NGUOIDUNG GetByEmail(string email)
        {
            return NguoiDungRepository.GetByEmail(email);
        }

        // Đăng nhập
        public NGUOIDUNG DangNhap(string email, string matKhau)
        {
            return NguoiDungRepository.DangNhap(email, matKhau);
        }

        // Lấy người dùng theo role
        public List<NGUOIDUNG> GetByRole(int maRole)
        {
            return NguoiDungRepository.GetByRole(maRole);
        }

        // Thêm người dùng mới
        public bool Add(NGUOIDUNG nguoiDung)
        {
            // Kiểm tra email đã tồn tại chưa
            if (NguoiDungRepository.IsEmailExist(nguoiDung.EMAIL))
            {
                return false;
            }
            return NguoiDungRepository.Add(nguoiDung);
        }

        // Cập nhật người dùng
        public bool Update(NGUOIDUNG nguoiDung)
        {
            return NguoiDungRepository.Update(nguoiDung);
        }

        // Xóa người dùng
        public bool Delete(int id)
        {
            return NguoiDungRepository.Delete(id);
        }

        // Kiểm tra email tồn tại
        public bool IsEmailExist(string email)
        {
            return NguoiDungRepository.IsEmailExist(email);
        }
    }
}
