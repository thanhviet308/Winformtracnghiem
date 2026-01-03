using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhanMemThiTracNghiem.Repositories;
using PhanMemThiTracNghiem.DTOs;
using PhanMemThiTracNghiem.Models;
using PhanMemThiTracNghiem.Models;

namespace PhanMemThiTracNghiem.Repositories
{
    class ChiTietKyThiService
    {
        private readonly ChiTietKyThiRepository ChiTietKyThiRepository;
        public ChiTietKyThiService()
        {
            ChiTietKyThiRepository = new ChiTietKyThiRepository();
        }
        public List<CHITIETKYTHI> GetThongTinChiTietKyThi()
        {
            return ChiTietKyThiRepository.GetThongTinChiTietKyThi();
        }

        public static void InsertUpdate(ChiTietKiThiDTO chiTietKiThiDTO)
        {
            ChiTietKyThiRepository.InsertUpdate(chiTietKiThiDTO);  
        }
        public void LuuChiTietKyThi(NGUOIDUNG nd, String MAKT, MONTHI monThi, float diem, DateTime thoiGianBD, DateTime thoiGianKT, int thoiGianThi)
        {
            ChiTietKyThiRepository.LuuChiTietKyThi(nd, MAKT, monThi, diem, thoiGianBD, thoiGianKT, thoiGianThi);
        }
    }
}

