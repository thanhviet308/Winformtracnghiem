namespace PhanMemThiTracNghiem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// Bảng ngân hàng đề thi
    /// </summary>
    [Table("ngan_hang_de")]
    public class NganHangDe
    {
        public NganHangDe()
        {
            CauTrucDes = new HashSet<CauTrucDe>();
            KyThis = new HashSet<KyThi>();
        }

        [Key]
        [Column("id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Column("ma_mon")]
        public long? MaMon { get; set; }

        [Required]
        [Column("ten_de")]
        [StringLength(200)]
        public string TenDe { get; set; }

        [Column("tong_so_cau")]
        public int TongSoCau { get; set; }

        [Column("nguoi_tao")]
        public long? NguoiTao { get; set; }

        [Column("ngay_tao")]
        public DateTime NgayTao { get; set; } = DateTime.Now;

        // Navigation properties
        [ForeignKey("MaMon")]
        public virtual MonHoc MonHoc { get; set; }

        [ForeignKey("NguoiTao")]
        public virtual NguoiDung NguoiDung { get; set; }

        public virtual ICollection<CauTrucDe> CauTrucDes { get; set; }
        public virtual ICollection<KyThi> KyThis { get; set; }
    }
}
