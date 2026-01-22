namespace PhanMemThiTracNghiem.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// Bảng nhật ký vi phạm khi thi (chuyển tab, copy, ...)
    /// </summary>
    [Table("nhat_ky_vi_pham")]
    public class NhatKyViPham
    {
        [Key]
        [Column("id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Column("ma_bai_thi")]
        public long? MaBaiThi { get; set; }

        [Required]
        [Column("loai_vi_pham")]
        [StringLength(50)]
        public string LoaiViPham { get; set; } // "chuyen_tab", "copy", "paste", ...

        [Column("so_lan_vi_pham")]
        public int SoLanViPham { get; set; } = 0;

        [Column("lan_cuoi_xay_ra")]
        public DateTime? LanCuoiXayRa { get; set; }

        [Column("ngay_tao")]
        public DateTime NgayTao { get; set; } = DateTime.Now;

        // Navigation properties
        [ForeignKey("MaBaiThi")]
        public virtual BaiThi BaiThi { get; set; }
    }
}
