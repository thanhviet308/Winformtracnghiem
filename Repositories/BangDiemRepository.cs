using PhanMemThiTracNghiem.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhanMemThiTracNghiem.Repositories;
using PhanMemThiTracNghiem.Models;

namespace PhanMemThiTracNghiem.Repositories
{
    class BangDiemRepository
    {
        private readonly AppDbContext diemThi;
        public BangDiemRepository()
        {
            diemThi = new AppDbContext();
        }
        public List<BANGDIEM> GetThongTinDiem()
        {
            return diemThi.BANGDIEM.ToList();
        }
        
        public bool LuuDiemThi(int ID, float DIEM, string MASV, string MAKT, string MAMT)
        {
            diemThi.BANGDIEM.Add(new BANGDIEM() { ID = ID, DIEM = DIEM, MASV = MASV, MAKITHI = MAKT, MAMT = MAMT } );
            diemThi.SaveChanges();
            return true;
        }

        public bool LuuDiemThi(BANGDIEM LuuDiemThi)
        {
            try
            {
                diemThi.BANGDIEM.Add(LuuDiemThi);
                diemThi.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

