using PhanMemThiTracNghiem.DAL;
using PhanMemThiTracNghiem.DAL.Model;
using System;
using System.Collections.Generic;

namespace PhanMemThiTracNghiem.BAL
{
    public class NguoiDungBAL
    {
        private readonly NguoiDungDAL nguoiDungDAL;

        public NguoiDungBAL()
        {
            nguoiDungDAL = new NguoiDungDAL();
        }

        // Lấy tất cả người dùng
        public List<NGUOIDUNG> GetAll()
        {
            return nguoiDungDAL.GetAll();
        }

        // Lấy người dùng theo ID
        public NGUOIDUNG GetById(int id)
        {
            return nguoiDungDAL.GetById(id);
        }

        // Lấy người dùng theo Email
        public NGUOIDUNG GetByEmail(string email)
        {
            return nguoiDungDAL.GetByEmail(email);
        }

        // Đăng nhập
        public NGUOIDUNG DangNhap(string email, string matKhau)
        {
            return nguoiDungDAL.DangNhap(email, matKhau);
        }

        // Lấy người dùng theo role
        public List<NGUOIDUNG> GetByRole(int maRole)
        {
            return nguoiDungDAL.GetByRole(maRole);
        }

        // Thêm người dùng mới
        public bool Add(NGUOIDUNG nguoiDung)
        {
            // Kiểm tra email đã tồn tại chưa
            if (nguoiDungDAL.IsEmailExist(nguoiDung.EMAIL))
            {
                return false;
            }
            return nguoiDungDAL.Add(nguoiDung);
        }

        // Cập nhật người dùng
        public bool Update(NGUOIDUNG nguoiDung)
        {
            return nguoiDungDAL.Update(nguoiDung);
        }

        // Xóa người dùng
        public bool Delete(int id)
        {
            return nguoiDungDAL.Delete(id);
        }

        // Kiểm tra email tồn tại
        public bool IsEmailExist(string email)
        {
            return nguoiDungDAL.IsEmailExist(email);
        }
    }
}
