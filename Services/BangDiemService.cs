using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PhanMemThiTracNghiem.Repositories;
using PhanMemThiTracNghiem.Models;

namespace PhanMemThiTracNghiem.Repositories
{
    class BangDiemService
    {
        private readonly BangDiemRepository BangDiemRepository;
        public BangDiemService()
        {
            BangDiemRepository = new BangDiemRepository();
        }
        public List<BANGDIEM> GetThongTinDiem()
        {
            return BangDiemRepository.GetThongTinDiem();
        }
        public bool LuuDiemThi(BANGDIEM LuuDiemThi)
        {
            try
            {               
                return BangDiemRepository.LuuDiemThi(LuuDiemThi);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //public bool LuuDiemThi(int ID, float DIEM, string MASV, string MAKT, string MAMT)
        //{
        //    try
        //    {
        //        return BangDiemRepository.LuuDiemThi(ID, DIEM,  MASV, MAKT, MAMT);
        //    }
        //    catch (Exception ex)
        //    {
                
        //        throw ex;
        //    }
            
        //}
    }
}

