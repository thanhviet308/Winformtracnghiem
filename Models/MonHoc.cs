namespace PhanMemThiTracNghiem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// Bảng môn học
    /// </summary>
    [Table("mon_hoc")]
    public class MonHoc
    {
        public MonHoc()
        {
            CauHoiThis = new HashSet<CauHoiThi>();
            NganHangDes = new HashSet<NganHangDe>();
            CauTrucDes = new HashSet<CauTrucDe>();
            PhanCongGiangDays = new HashSet<PhanCongGiangDay>();
        }

        [Key]
        [Column("id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Required]
        [Column("ten_mon")]
        [StringLength(100)]
        public string TenMon { get; set; }

        [Column("mo_ta")]
        public string MoTa { get; set; }

        [Column("ngay_tao")]
        public DateTime NgayTao { get; set; } = DateTime.Now;

        [Column("trang_thai")]
        public bool TrangThai { get; set; } = true;

        // Navigation properties
        public virtual ICollection<CauHoiThi> CauHoiThis { get; set; }
        public virtual ICollection<NganHangDe> NganHangDes { get; set; }
        public virtual ICollection<CauTrucDe> CauTrucDes { get; set; }
        public virtual ICollection<PhanCongGiangDay> PhanCongGiangDays { get; set; }
    }
}
