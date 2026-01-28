namespace PhanMemThiTracNghiem.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// Bảng cấu trúc đề thi (số câu cơ bản, nâng cao)
    /// </summary>
    [Table("cau_truc_de")]
    public class CauTrucDe
    {
        [Key]
        [Column("id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Column("ma_ngan_hang_de")]
        public long? MaNganHangDe { get; set; }

        [Column("ma_mon")]
        public long? MaMon { get; set; }

        [Column("so_cau")]
        public int SoCau { get; set; }

        // Navigation properties
        [ForeignKey("MaNganHangDe")]
        public virtual NganHangDe NganHangDe { get; set; }

        [ForeignKey("MaMon")]
        public virtual MonHoc MonHoc { get; set; }
    }
}
