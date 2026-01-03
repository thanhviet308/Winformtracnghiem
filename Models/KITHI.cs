using PhanMemThiTracNghiem.Data;
namespace PhanMemThiTracNghiem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("KITHI")]
    public partial class KITHI
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public KITHI()
        {
    /*        CHITIETKYTHI = new HashSet<CHITIETKYTHI>();*/
        }

        public int? ID { get; set; }

        [Key]
        [StringLength(11)]
        public string MAKITHI { get; set; }

        [Required]
        [StringLength(50)]
        public string TENKITHI { get; set; }

        [StringLength(20)]
        public string ADMIN { get; set; }


        public DateTime? THOIGIANBDKITHI { get; set; }

        public DateTime? THOIGIANKTKITHI { get; set; }



  /*      [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CHITIETKYTHI> CHITIETKYTHI { get; set; }

        public virtual QUANTRI QUANTRI { get; set; }*/


        public void InsertUpdate()
        {
            AppDbContext context = new AppDbContext();
            var existing = context.KITHI.Find(this.MAKITHI);
            if (existing == null)
                context.KITHI.Add(this);
            else
                context.Entry(existing).CurrentValues.SetValues(this);
            context.SaveChanges();
        }
    }
}
