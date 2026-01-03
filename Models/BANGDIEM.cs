namespace PhanMemThiTracNghiem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("BANGDIEM")]
    public partial class BANGDIEM
    {
        public int? ID { get; set; }

        public double? DIEM { get; set; }

        [StringLength(15)]
        public string MASV { get; set; }

        [StringLength(11)]
        public string MAKITHI { get; set; }

        [StringLength(40)]
        public string MAMT { get; set; }

        public virtual CHITIETKYTHI CHITIETKYTHI { get; set; }
    }
}
