namespace PhanMemThiTracNghiem.DAL.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("CHITIETKYTHI")]
    public partial class CHITIETKYTHI
    {
        public CHITIETKYTHI()
        {

        }

        [StringLength(11)]
        public string MAKITHI { get; set; }

        [StringLength(40)]
        public string MAMT { get; set; }

        public double? DIEM { get; set; }

        public int? THOIGIANTHI { get; set; }

        public DateTime? THOIGIANBD { get; set; }

        public DateTime? THOIGIANKT { get; set; }

        [StringLength(15)]
        public string MASV { get; set; }
        
        [NotMapped]
        public object MONTHI { get; internal set; }

        //public virtual BANGDIEM BANGDIEM { get; set; }

        //public virtual KITHI KITHI { get; set; }

        //public virtual MONTHI MONTHI { get; set; }

        //public virtual SINHVIEN SINHVIEN { get; set; }


        public void InsertUpdate()
        {
            DuLieuDAL context = new DuLieuDAL();
            var existing = context.CHITIETKYTHI.Find(this.MAKITHI, this.MAMT, this.MASV);
            if (existing == null)
                context.CHITIETKYTHI.Add(this);
            else
                context.Entry(existing).CurrentValues.SetValues(this);
            context.SaveChanges();
        }
    }
}
