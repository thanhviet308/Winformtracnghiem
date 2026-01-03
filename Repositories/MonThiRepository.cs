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
    class MonThiRepository
    {
        private readonly AppDbContext monThi;
        public MonThiRepository()
        {
            monThi = new AppDbContext();
        }
        public List<MONTHI> GetThongTinMonThi()
        {
            return monThi.MONTHI.ToList();
        }

        public static void InsertUpdate(MonThiDTO monThiDTO)
        {

            
            MONTHI monthi = new MONTHI();
            monthi.STT = monThiDTO.STT;
            monthi.MAMT = monThiDTO.MaMT;
            monthi.TENMT = monThiDTO.TenMT;
            monthi.InsertUpdate();
        }
    }
}

