using PhanMemThiTracNghiem.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PhanMemThiTracNghiem.BAL
{
    /// <summary>
    /// QuanTriBAL - Wrapper class để tương thích ngược với code cũ
    /// Sử dụng NGUOIDUNG với MAROLE = 1 (Admin)
    /// </summary>
    public class QuanTriBAL
    {
        private readonly NguoiDungBAL nguoiDungBAL;
        private const int ROLE_ADMIN = 1;

        public QuanTriBAL()
        {
            nguoiDungBAL = new NguoiDungBAL();
        }

        // Lấy tất cả quản trị
        public List<NGUOIDUNG> GetQUANTRIs()
        {
            return nguoiDungBAL.GetByRole(ROLE_ADMIN);
        }

        // Lấy quản trị theo mã
        public static NGUOIDUNG GETQuanTri(string admin)
        {
            var nguoiDungBAL = new NguoiDungBAL();
            return nguoiDungBAL.GetByMaNguoiDung(admin);
        }
    }
}
