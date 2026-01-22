namespace PhanMemThiTracNghiem.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// Bảng trả lời bài thi (câu trả lời của sinh viên)
    /// </summary>
    [Table("tra_loi_bai_thi")]
    public class TraLoiBaiThi
    {
        [Key]
        [Column("id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Column("ma_bai_thi")]
        public long? MaBaiThi { get; set; }

        [Column("ma_cau_hoi")]
        public long? MaCauHoi { get; set; }

        [Column("ma_lua_chon")]
        public long? MaLuaChon { get; set; }

        [Column("dung_hay_sai")]
        public bool? DungHaySai { get; set; }

        [Column("thoi_gian_tra_loi")]
        public DateTime? ThoiGianTraLoi { get; set; }

        // Navigation properties
        [ForeignKey("MaBaiThi")]
        public virtual BaiThi BaiThi { get; set; }

        [ForeignKey("MaCauHoi")]
        public virtual CauHoiThi CauHoiThi { get; set; }

        [ForeignKey("MaLuaChon")]
        public virtual LuaChonTracNghiem LuaChonTracNghiem { get; set; }
    }
}
