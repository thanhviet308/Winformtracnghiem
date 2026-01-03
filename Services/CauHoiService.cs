using PhanMemThiTracNghiem.Repositories;
using PhanMemThiTracNghiem.DTOs;
using PhanMemThiTracNghiem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhanMemThiTracNghiem.Services
{
    internal class CauHoiService
    {
        private readonly CauHoiRepository CauHoiRepository;
        public CauHoiService()
        {
            CauHoiRepository = new CauHoiRepository();
        }
        public List<CAUHOI> GetThongTinCauHoi()
        {
            return CauHoiRepository.GetThongTinCauHoi();
        }

        public static void InsertUpdate(CauHoiDTO a)
        {
            CauHoiRepository.InsertUpdate(a);
        }


        public void CapNhapCauHoi(int macauhoi, string noidung, string dapan1, string dapan2, string dapan3, string dapan4,string dapandung,string magv)
        {
            CauHoiRepository.CapNhapCauHoi(macauhoi, noidung, dapan1, dapan2, dapan3, dapan4,dapandung,magv);
        }

        public List<CAUHOI> GetCAUHOIs()
        {
            return CauHoiRepository.GetCAUHOIs();
        }

        public static void Delete(int macauhoi)
        {
            CAUHOI.Delete(macauhoi);    
        }

        public List<CAUHOI> FindName(string mamon)
        {
            return CauHoiRepository.FindName(mamon);
        }
    }
    
}
