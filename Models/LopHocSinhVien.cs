namespace PhanMemThiTracNghiem.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// Bảng trung gian lớp học - sinh viên (quan hệ nhiều-nhiều)
    /// </summary>
    [Table("lop_hoc_sinh_vien")]
    public class LopHocSinhVien
    {
        [Key]
        [Column("ma_lop", Order = 0)]
        public long MaLop { get; set; }

        [Key]
        [Column("ma_sinh_vien", Order = 1)]
        public long MaSinhVien { get; set; }

        // Navigation properties
        [ForeignKey("MaLop")]
        public virtual LopHoc LopHoc { get; set; }

        [ForeignKey("MaSinhVien")]
        public virtual NguoiDung SinhVien { get; set; }
    }
}
