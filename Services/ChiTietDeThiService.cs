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
    class ChiTietDeThiService
    {
        private readonly  ChiTietDeThiRepository danhMucCauHoiRepository;
        public ChiTietDeThiService()
        {
            danhMucCauHoiRepository = new ChiTietDeThiRepository();
        }
        public List<CHITIETDETHI> GetCauHoi()
        {
            return danhMucCauHoiRepository.GetCauHoi(); 
        }


        public static void InsertUpdate(ChiTietDeThiDTO chiTietDeThiDTO)
        {
            ChiTietDeThiRepository.InsertUpdate(chiTietDeThiDTO);
        }
    }
}
