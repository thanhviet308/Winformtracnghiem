namespace PhanMemThiTracNghiem.DAL.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("NGUOIDUNG")]
    public partial class NGUOIDUNG
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NGUOIDUNG()
        {
            CAUHOI = new HashSet<CAUHOI>();
            CHITIETKYTHI = new HashSet<CHITIETKYTHI>();
            KITHI = new HashSet<KITHI>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required]
        [StringLength(100)]
        public string MATKHAU { get; set; }

        [Required]
        [StringLength(100)]
        public string EMAIL { get; set; }

        [Required]
        [StringLength(50)]
        public string HOTEN { get; set; }

        public int? MAROLE { get; set; }

        [ForeignKey("MAROLE")]
        public virtual ROLE ROLE { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CAUHOI> CAUHOI { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CHITIETKYTHI> CHITIETKYTHI { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KITHI> KITHI { get; set; }
    }
}
