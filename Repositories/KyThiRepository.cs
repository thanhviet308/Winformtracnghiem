using PhanMemThiTracNghiem.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhanMemThiTracNghiem.Repositories;
using PhanMemThiTracNghiem.DTOs;
using PhanMemThiTracNghiem.Models;

namespace PhanMemThiTracNghiem.Repositories
{
    class KyThiRepository
    {
        private readonly AppDbContext kyThi;
        public KyThiRepository()
        {
            kyThi = new AppDbContext();
        }
        public List<KITHI> GetThongTinKyThi()
        {
            return kyThi.KITHI.ToList();
        }

        public static void InsertUpdate(KiThiDTO kiThiDTO)
        {

            KITHI kithi = new KITHI();
            kithi.ID = kiThiDTO.ID;
            kithi.MAKITHI = kiThiDTO.MaKiThi;
            kithi.TENKITHI = kiThiDTO.TenKiThi;
            kithi.ADMIN = kiThiDTO.Admin;
            kithi.THOIGIANBDKITHI = kiThiDTO.ThoiGianBD;
            kithi.THOIGIANKTKITHI = kiThiDTO.ThoiGianKT;
            kithi.InsertUpdate();
        }

       

        public List<KITHI> GetKITHIs()
        {
            return kyThi.KITHI.ToList();
        }

        public List<KITHI> GetNameKITHI()
        {
            return kyThi.KITHI.ToList();
        }
    }
}

