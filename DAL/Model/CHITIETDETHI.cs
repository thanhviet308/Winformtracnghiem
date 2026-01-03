namespace PhanMemThiTracNghiem.DAL.Model
{
    using PhanMemThiTracNghiem.DAL.DTO;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("CHITIETDETHI")]
    public partial class CHITIETDETHI
    {
        [StringLength(10)]
        public string MADETHI { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MACAUHOI { get; set; }

        [StringLength(50)]
        public string MUCDO { get; set; }

        /*        public virtual CAUHOI CAUHOI { get; set; }

                public virtual DETHI DETHI { get; set; }*/

        public void InsertUpdate()
        {
            DuLieuDAL context = new DuLieuDAL();
            var existing = context.CHITIETDETHI.Find(this.MADETHI, this.MACAUHOI);
            if (existing == null)
                context.CHITIETDETHI.Add(this);
            else
                context.Entry(existing).CurrentValues.SetValues(this);
            context.SaveChanges();
        }
    }
}
