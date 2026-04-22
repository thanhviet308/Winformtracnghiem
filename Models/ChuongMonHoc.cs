namespace PhanMemThiTracNghiem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// Bảng chương của môn học
    /// </summary>
    [Table("chuong_mon_hoc")]
    public class ChuongMonHoc
    {
        public ChuongMonHoc()
        {
            CauHoiThis = new HashSet<CauHoiThi>();
        }

        [Key]
        [Column("id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Column("ma_mon")]
        public long? MaMon { get; set; }

        [Required]
        [Column("ten_chuong")]
        [StringLength(150)]
        public string TenChuong { get; set; }

        [Column("ngay_tao")]
        public DateTime NgayTao { get; set; } = DateTime.Now;

        [ForeignKey("MaMon")]
        public virtual MonHoc MonHoc { get; set; }

        public virtual ICollection<CauHoiThi> CauHoiThis { get; set; }
    }
}
