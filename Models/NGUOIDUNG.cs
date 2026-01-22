namespace PhanMemThiTracNghiem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// Bảng người dùng (Admin, Giảng viên, Sinh viên)
    /// </summary>
    [Table("nguoi_dung")]
    public class NguoiDung
    {
        public NguoiDung()
        {
            // Câu hỏi được tạo bởi người dùng này
            CauHoiThis = new HashSet<CauHoiThi>();
            // Ngân hàng đề được tạo bởi người dùng này
            NganHangDes = new HashSet<NganHangDe>();
            // Lớp học sinh viên tham gia
            LopHocSinhViens = new HashSet<LopHocSinhVien>();
            // Phân công giảng dạy
            PhanCongGiangDays = new HashSet<PhanCongGiangDay>();
            // Phân công giám sát
            PhanCongGiamSats = new HashSet<PhanCongGiamSat>();
            // Bài thi của sinh viên
            BaiThis = new HashSet<BaiThi>();
        }

        [Key]
        [Column("id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Required]
        [Column("ho_ten")]
        [StringLength(100)]
        public string HoTen { get; set; }

        [Required]
        [Column("email")]
        [StringLength(100)]
        public string Email { get; set; }

        [Required]
        [Column("mat_khau")]
        [StringLength(255)]
        public string MatKhau { get; set; }

        [Column("ma_vai_tro")]
        public long? MaVaiTro { get; set; }

        [Column("ngay_tao")]
        public DateTime NgayTao { get; set; } = DateTime.Now;

        [Column("trang_thai")]
        public bool TrangThai { get; set; } = true;

        // Navigation properties
        [ForeignKey("MaVaiTro")]
        public virtual VaiTro VaiTro { get; set; }

        public virtual ICollection<CauHoiThi> CauHoiThis { get; set; }
        public virtual ICollection<NganHangDe> NganHangDes { get; set; }
        public virtual ICollection<LopHocSinhVien> LopHocSinhViens { get; set; }
        public virtual ICollection<PhanCongGiangDay> PhanCongGiangDays { get; set; }
        public virtual ICollection<PhanCongGiamSat> PhanCongGiamSats { get; set; }
        public virtual ICollection<BaiThi> BaiThis { get; set; }
    }
}
