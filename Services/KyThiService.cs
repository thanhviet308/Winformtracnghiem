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
    class KyThiService
    {
        private readonly KyThiRepository KyThiRepository;
        public KyThiService()
        {
            KyThiRepository = new KyThiRepository();
        }
        public List<KITHI> GetThongTinKyThi()
        {
            return KyThiRepository.GetThongTinKyThi();
        }

        public static void InsertUpdate(KiThiDTO a)
        {

            KyThiRepository.InsertUpdate(a);
        }

        public List<KITHI> GetKITHIs()
        {
            return KyThiRepository.GetKITHIs();
        }
    }
}

