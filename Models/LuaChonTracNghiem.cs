namespace PhanMemThiTracNghiem.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// Bảng lựa chọn trắc nghiệm cho mỗi câu hỏi
    /// </summary>
    [Table("lua_chon_trac_nghiem")]
    public class LuaChonTracNghiem
    {
        public LuaChonTracNghiem()
        {
            TraLoiBaiThis = new HashSet<TraLoiBaiThi>();
        }

        [Key]
        [Column("id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Column("ma_cau_hoi")]
        public long? MaCauHoi { get; set; }

        [Required]
        [Column("noi_dung")]
        public string NoiDung { get; set; }

        [Column("la_dap_an_dung")]
        public bool LaDapAnDung { get; set; } = false;

        [Column("thu_tu")]
        public int ThuTu { get; set; }

        // Navigation properties
        [ForeignKey("MaCauHoi")]
        public virtual CauHoiThi CauHoiThi { get; set; }

        public virtual ICollection<TraLoiBaiThi> TraLoiBaiThis { get; set; }
    }
}
