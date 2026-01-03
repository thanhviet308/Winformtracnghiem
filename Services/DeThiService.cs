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
    class DeThiService
    {
        private readonly DeThiRepository DeThiRepository;
        public DeThiService()
        {
            DeThiRepository = new DeThiRepository();
        }
        public List<DETHI> GetThongTinDeThi()
        {
            return DeThiRepository.GetThongTinDeThi();
        }

        public static void InsertUpdate(DeThiDTO deThiDTO)
        {
            DeThiRepository.InsertUpdate(deThiDTO);
        }
    }
}

