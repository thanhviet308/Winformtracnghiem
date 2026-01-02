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

        // Lấy tất cả giảng viên
        public List<NGUOIDUNG> GetGIANGVIENs()
        {
            return nguoiDungBAL.GetByRole(ROLE_GIANGVIEN);
        }

        // Lấy giảng viên theo mã
        public static NGUOIDUNG GETGiangVien(string magv)
        {
            var nguoiDungBAL = new NguoiDungBAL();
            return nguoiDungBAL.GetByMaNguoiDung(magv);
        }

        // Cập nhật giảng viên
        public void CapNhapGiangVien(string magv, string tengv, DateTime ngaysinh, string matkhau)
        {
            var gv = nguoiDungBAL.GetByMaNguoiDung(magv);
            if (gv != null)
            {
                gv.HOTEN = tengv;
                gv.NGAYSINH = ngaysinh;
                gv.MATKHAU = matkhau;
                nguoiDungBAL.Update(gv);
            }
        }

        // Đổi mật khẩu
        public void DoiMatKhau(string magv, string matkhau)
        {
            var gv = nguoiDungBAL.GetByMaNguoiDung(magv);
            if (gv != null)
            {
                gv.MATKHAU = matkhau;
                nguoiDungBAL.Update(gv);
            }
        }

        // Xóa giảng viên
        public static void Delete(string magv)
        {
            var nguoiDungBAL = new NguoiDungBAL();
            nguoiDungBAL.Delete(magv);
        }

        // Tìm theo tên
        public List<NGUOIDUNG> FindName(string tengv)
        {
            return nguoiDungBAL.GetByRole(ROLE_GIANGVIEN)
                .Where(x => x.HOTEN.Contains(tengv)).ToList();
        }
    }
}
