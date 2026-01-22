namespace PhanMemThiTracNghiem.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// Bảng vai trò (Admin, Giảng viên, Sinh viên)
    /// </summary>
    [Table("vai_tro")]
    public class VaiTro
    {
        public VaiTro()
        {
            NguoiDungs = new HashSet<NguoiDung>();
        }

        [Key]
        [Column("id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Required]
        [Column("ten_vai_tro")]
        [StringLength(50)]
        public string TenVaiTro { get; set; }

        [Column("mo_ta")]
        public string MoTa { get; set; }

        // Navigation properties
        public virtual ICollection<NguoiDung> NguoiDungs { get; set; }
    }
}
