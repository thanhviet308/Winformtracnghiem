using PhanMemThiTracNghiem.Data;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhanMemThiTracNghiem.Repositories;
using PhanMemThiTracNghiem.DTOs;
using PhanMemThiTracNghiem.Models;

namespace PhanMemThiTracNghiem.Repositories
{
    class ChiTietKyThiRepository
    {
        private readonly AppDbContext chiTietKyThi;
        public ChiTietKyThiRepository()
        {
            chiTietKyThi = new AppDbContext();
        }
        public List<CHITIETKYTHI> GetThongTinChiTietKyThi()
        {
            return chiTietKyThi.CHITIETKYTHI.ToList();
        }

        public static void InsertUpdate(ChiTietKiThiDTO chiTietKiThiDTO)
        {
            CHITIETKYTHI cHITIETKYTHI = new CHITIETKYTHI();
            cHITIETKYTHI.MAKITHI = chiTietKiThiDTO.MaKiThi;
            cHITIETKYTHI.MAMT = chiTietKiThiDTO.MaMonThi;
            cHITIETKYTHI.DIEM = chiTietKiThiDTO.Diem;
            cHITIETKYTHI.THOIGIANBD = chiTietKiThiDTO.ThoiGianBD;
            cHITIETKYTHI.THOIGIANKT = chiTietKiThiDTO.ThoiGianKT;
            cHITIETKYTHI.THOIGIANTHI = chiTietKiThiDTO.ThoiGianThi;
            cHITIETKYTHI.MASV = chiTietKiThiDTO.MaSinhVien;
            cHITIETKYTHI.InsertUpdate();
        }
        public void LuuChiTietKyThi(NGUOIDUNG nd, String MAKT, MONTHI monThi, float diem, DateTime thoiGianBD, DateTime thoiGianKT, int thoiGianThi)
        {
            foreach (var item in GetThongTinChiTietKyThi())
            {
                if (item.MAKITHI == MAKT && item.MASV == nd.ID.ToString() && item.MAMT == item.MAMT)
                {
                    item.DIEM = diem;
                    item.THOIGIANBD = thoiGianBD;
                    item.THOIGIANKT = thoiGianKT;
                    item.THOIGIANTHI = thoiGianThi;
                    chiTietKyThi.SaveChanges();
                    break;
                }
            }
        }
    }
}

