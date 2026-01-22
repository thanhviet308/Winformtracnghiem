namespace PhanMemThiTracNghiem.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// Bảng phân công giám sát kỳ thi
    /// </summary>
    [Table("phan_cong_giam_sat")]
    public class PhanCongGiamSat
    {
        [Key]
        [Column("id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Column("ma_ky_thi")]
        public long? MaKyThi { get; set; }

        [Column("ma_giam_thi")]
        public long? MaGiamThi { get; set; }

        [Column("ngay_phan_cong")]
        public DateTime NgayPhanCong { get; set; } = DateTime.Now;

        // Navigation properties
        [ForeignKey("MaKyThi")]
        public virtual KyThi KyThi { get; set; }

        [ForeignKey("MaGiamThi")]
        public virtual NguoiDung GiamThi { get; set; }
    }
}
