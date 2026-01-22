namespace PhanMemThiTracNghiem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// Bảng câu hỏi thi
    /// </summary>
    [Table("cau_hoi_thi")]
    public class CauHoiThi
    {
        public CauHoiThi()
        {
            LuaChonTracNghiems = new HashSet<LuaChonTracNghiem>();
            TraLoiBaiThis = new HashSet<TraLoiBaiThi>();
        }

        [Key]
        [Column("id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Column("ma_mon")]
        public long? MaMon { get; set; }

        [Required]
        [Column("noi_dung")]
        public string NoiDung { get; set; }

        [Column("nguoi_tao")]
        public long? NguoiTao { get; set; }

        [Column("ngay_tao")]
        public DateTime NgayTao { get; set; } = DateTime.Now;

        [Column("trang_thai")]
        public bool TrangThai { get; set; } = true;

        // Navigation properties
        [ForeignKey("MaMon")]
        public virtual MonHoc MonHoc { get; set; }

        [ForeignKey("NguoiTao")]
        public virtual NguoiDung NguoiDung { get; set; }

        public virtual ICollection<LuaChonTracNghiem> LuaChonTracNghiems { get; set; }
        public virtual ICollection<TraLoiBaiThi> TraLoiBaiThis { get; set; }
    }
}
