namespace PhanMemThiTracNghiem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// Bảng bài thi của sinh viên
    /// </summary>
    [Table("bai_thi")]
    public class BaiThi
    {
        public BaiThi()
        {
            TraLoiBaiThis = new HashSet<TraLoiBaiThi>();
            NhatKyViPhams = new HashSet<NhatKyViPham>();
        }

        [Key]
        [Column("id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Column("ma_ky_thi")]
        public long? MaKyThi { get; set; }

        [Column("ma_sinh_vien")]
        public long? MaSinhVien { get; set; }

        [Column("thoi_gian_bat_dau")]
        public DateTime? ThoiGianBatDau { get; set; }

        [Column("thoi_gian_nop_bai")]
        public DateTime? ThoiGianNopBai { get; set; }

        [Column("diem_so")]
        public int? DiemSo { get; set; }

        [Column("trang_thai")]
        [StringLength(20)]
        public string TrangThai { get; set; } // "chua_thi", "dang_thi", "da_nop", "cham_diem"

        // Navigation properties
        [ForeignKey("MaKyThi")]
        public virtual KyThi KyThi { get; set; }

        [ForeignKey("MaSinhVien")]
        public virtual NguoiDung SinhVien { get; set; }

        public virtual ICollection<TraLoiBaiThi> TraLoiBaiThis { get; set; }
        public virtual ICollection<NhatKyViPham> NhatKyViPhams { get; set; }
    }
}
