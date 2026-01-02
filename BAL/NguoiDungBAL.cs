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

        // Lấy người dùng theo mã
        public NGUOIDUNG GetByMaNguoiDung(string maNguoiDung)
        {
            return nguoiDungDAL.GetByMaNguoiDung(maNguoiDung);
        }

        // Đăng nhập
        public NGUOIDUNG DangNhap(string taiKhoan, string matKhau)
        {
            return nguoiDungDAL.DangNhap(taiKhoan, matKhau);
        }

        // Lấy người dùng theo role
        public List<NGUOIDUNG> GetByRole(int maRole)
        {
            return nguoiDungDAL.GetByRole(maRole);
        }

        // Thêm người dùng mới
        public bool Add(NGUOIDUNG nguoiDung)
        {
            // Kiểm tra tài khoản đã tồn tại chưa
            if (nguoiDungDAL.IsExist(nguoiDung.TENTAIKHOAN))
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
        public bool Delete(string maNguoiDung)
        {
            return nguoiDungDAL.Delete(maNguoiDung);
        }

        // Kiểm tra tài khoản tồn tại
        public bool IsExist(string maNguoiDung)
        {
            return nguoiDungDAL.IsExist(maNguoiDung);
        }
    }
}
