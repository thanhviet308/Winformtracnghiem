using System;

namespace PhanMemThiTracNghiem.DTOs
{
    public class MonThiDTO
    {
        public MonThiDTO()
        {
           
        }
        public MonThiDTO(int sTT, string maMT, string tenMT)
        {
            STT = sTT;
            MaMT = maMT;
            TenMT = tenMT;
        }

        public int STT { get; set; }
        public string MaMT { get; set; }
        public string TenMT { get; set; }
    }
}
