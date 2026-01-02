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

        // Lấy tất cả sinh viên
        public List<NGUOIDUNG> GetSINHVIENs()
        {
            return nguoiDungBAL.GetByRole(ROLE_SINHVIEN);
        }

        // Lấy sinh viên theo mã
        public static NGUOIDUNG GETSinhVien(string masv)
        {
            var nguoiDungBAL = new NguoiDungBAL();
            return nguoiDungBAL.GetByMaNguoiDung(masv);
        }

        // Cập nhật sinh viên
        public void CapNhapSinhVien(string masv, string lop, string tensv, DateTime ngaysinh)
        {
            var sv = nguoiDungBAL.GetByMaNguoiDung(masv);
            if (sv != null)
            {
                sv.HOTEN = tensv;
                sv.NGAYSINH = ngaysinh;
                // LOP không còn trong NGUOIDUNG, bỏ qua
                nguoiDungBAL.Update(sv);
            }
        }

        // Xóa sinh viên
        public static void Delete(string masv)
        {
            var nguoiDungBAL = new NguoiDungBAL();
            nguoiDungBAL.Delete(masv);
        }

        // Tìm theo tên
        public List<NGUOIDUNG> FindName(string tensv)
        {
            return nguoiDungBAL.GetByRole(ROLE_SINHVIEN)
                .Where(x => x.HOTEN.Contains(tensv)).ToList();
        }
    }
}
