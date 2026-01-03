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
    class MonThiService
    {
        private readonly MonThiRepository MonThiRepository;
        public MonThiService()
        {
            MonThiRepository = new MonThiRepository();
        }
        public List<MONTHI> GetThongTinMonThi()
        {
            return MonThiRepository.GetThongTinMonThi();
        }

        public static void InsertUpdate(MonThiDTO monThiDTO)
        {
            MonThiRepository.InsertUpdate(monThiDTO);  
        }
    }
}

