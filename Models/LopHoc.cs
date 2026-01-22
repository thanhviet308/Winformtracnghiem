namespace PhanMemThiTracNghiem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// Bảng lớp học
    /// </summary>
    [Table("lop_hoc")]
    public class LopHoc
    {
        public LopHoc()
        {
            LopHocSinhViens = new HashSet<LopHocSinhVien>();
            KyThis = new HashSet<KyThi>();
            PhanCongGiangDays = new HashSet<PhanCongGiangDay>();
        }

        [Key]
        [Column("id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Required]
        [Column("ten_lop")]
        [StringLength(100)]
        public string TenLop { get; set; }

        [Column("ngay_tao")]
        public DateTime NgayTao { get; set; } = DateTime.Now;

        // Navigation properties
        public virtual ICollection<LopHocSinhVien> LopHocSinhViens { get; set; }
        public virtual ICollection<KyThi> KyThis { get; set; }
        public virtual ICollection<PhanCongGiangDay> PhanCongGiangDays { get; set; }
    }
}
