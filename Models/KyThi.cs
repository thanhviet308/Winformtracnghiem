namespace PhanMemThiTracNghiem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// Bảng kỳ thi
    /// </summary>
    [Table("ky_thi")]
    public class KyThi
    {
        public KyThi()
        {
            PhanCongGiamSats = new HashSet<PhanCongGiamSat>();
            BaiThis = new HashSet<BaiThi>();
        }

        [Key]
        [Column("id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Column("ma_ngan_hang_de")]
        public long? MaNganHangDe { get; set; }

        [Required]
        [Column("ten_ky_thi")]
        [StringLength(200)]
        public string TenKyThi { get; set; }

        [Column("ma_lop")]
        public long? MaLop { get; set; }

        [Column("thoi_gian_bat_dau")]
        public DateTime ThoiGianBatDau { get; set; }

        [Column("thoi_gian_ket_thuc")]
        public DateTime ThoiGianKetThuc { get; set; }

        [Column("thoi_luong_phut")]
        public int ThoiLuongPhut { get; set; }

        [Column("tron_cau_hoi")]
        public bool TronCauHoi { get; set; } = false;

        [Column("tron_dap_an")]
        public bool TronDapAn { get; set; } = false;

        [Column("tong_diem")]
        public int? TongDiem { get; set; }

        [Column("ngay_tao")]
        public DateTime NgayTao { get; set; } = DateTime.Now;

        // Navigation properties
        [ForeignKey("MaNganHangDe")]
        public virtual NganHangDe NganHangDe { get; set; }

        [ForeignKey("MaLop")]
        public virtual LopHoc LopHoc { get; set; }

        public virtual ICollection<PhanCongGiamSat> PhanCongGiamSats { get; set; }
        public virtual ICollection<BaiThi> BaiThis { get; set; }
    }
}
