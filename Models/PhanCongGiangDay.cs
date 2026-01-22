namespace PhanMemThiTracNghiem.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// Bảng phân công giảng dạy (giảng viên - lớp - môn)
    /// </summary>
    [Table("phan_cong_giang_day")]
    public class PhanCongGiangDay
    {
        [Key]
        [Column("ma_lop", Order = 0)]
        public long MaLop { get; set; }

        [Key]
        [Column("ma_mon", Order = 1)]
        public long MaMon { get; set; }

        [Column("ma_giang_vien")]
        public long? MaGiangVien { get; set; }

        [Column("ngay_phan_cong")]
        public DateTime NgayPhanCong { get; set; } = DateTime.Now;

        // Navigation properties
        [ForeignKey("MaLop")]
        public virtual LopHoc LopHoc { get; set; }

        [ForeignKey("MaMon")]
        public virtual MonHoc MonHoc { get; set; }

        [ForeignKey("MaGiangVien")]
        public virtual NguoiDung GiangVien { get; set; }
    }
}
