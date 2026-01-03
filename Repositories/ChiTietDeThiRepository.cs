using PhanMemThiTracNghiem.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhanMemThiTracNghiem.DTOs;
using PhanMemThiTracNghiem.Models;

namespace PhanMemThiTracNghiem.Repositories
{
    class ChiTietDeThiRepository
    {
        private readonly AppDbContext cauHoi;
        public ChiTietDeThiRepository()
        {
            cauHoi = new AppDbContext();
        }
        public List<CHITIETDETHI> GetCauHoi()
        {
            return cauHoi.CHITIETDETHI.ToList();
        }

        public static void InsertUpdate(ChiTietDeThiDTO chiTietDeThiDTO)
        {
            CHITIETDETHI cHITIETDETHI = new CHITIETDETHI();
            cHITIETDETHI.MADETHI = chiTietDeThiDTO.MaDeThi;
            cHITIETDETHI.MACAUHOI = chiTietDeThiDTO.MaCauHoi;
            cHITIETDETHI.MUCDO = chiTietDeThiDTO.CapDo;
            cHITIETDETHI.InsertUpdate();
        }
       
    }
}

