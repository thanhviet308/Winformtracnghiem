using System;

namespace PhanMemThiTracNghiem.DTOs
{
    public class LopHocDTO
    {
        public long Id { get; set; }
        public string TenLop { get; set; }
        public DateTime NgayTao { get; set; }
        public int SoSinhVien { get; set; }
    }

    public class PhanCongGiangDayDTO
    {
        public long MaLop { get; set; }
        public string TenLop { get; set; }
        public long MaMon { get; set; }
        public string TenMon { get; set; }
        public long? MaGiangVien { get; set; }
        public string TenGiangVien { get; set; }
        public DateTime NgayPhanCong { get; set; }
    }
}
