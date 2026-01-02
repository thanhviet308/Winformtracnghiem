using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace PhanMemThiTracNghiem.DAL.Model
{
    public partial class DuLieuDAL : DbContext
    {
        public DuLieuDAL()
            : base("name=DuLieu")
        {
        }

        public virtual DbSet<BANGDIEM> BANGDIEM { get; set; }
        public virtual DbSet<CAUHOI> CAUHOI { get; set; }
        public virtual DbSet<CHITIETDETHI> CHITIETDETHI { get; set; }
        public virtual DbSet<CHITIETKYTHI> CHITIETKYTHI { get; set; }
        public virtual DbSet<DETHI> DETHI { get; set; }
        public virtual DbSet<KITHI> KITHI { get; set; }
        public virtual DbSet<MONTHI> MONTHI { get; set; }
        public virtual DbSet<ROLE> ROLE { get; set; }
        public virtual DbSet<NGUOIDUNG> NGUOIDUNG { get; set; }
      

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BANGDIEM>()
                .Property(e => e.MASV)
                .IsUnicode(false);

            modelBuilder.Entity<BANGDIEM>()
                .Property(e => e.MAKITHI)
                .IsUnicode(false);

            modelBuilder.Entity<BANGDIEM>()
                .Property(e => e.MAMT)
                .IsUnicode(false);

            modelBuilder.Entity<CAUHOI>()
                .Property(e => e.MAGV)
                .IsUnicode(false);

            modelBuilder.Entity<CAUHOI>()
                .Property(e => e.MAMT)
                .IsUnicode(false);
/*
            modelBuilder.Entity<CAUHOI>()
                .HasMany(e => e.CHITIETDETHI)
                .WithRequired(e => e.CAUHOI)
                .WillCascadeOnDelete(false);*/

            modelBuilder.Entity<CHITIETDETHI>()
                .Property(e => e.MADETHI)
                .IsUnicode(false);

            modelBuilder.Entity<CHITIETKYTHI>()
                .Property(e => e.MAKITHI)
                .IsUnicode(false);

            modelBuilder.Entity<CHITIETKYTHI>()
                .Property(e => e.MAMT)
                .IsUnicode(false);

            modelBuilder.Entity<CHITIETKYTHI>()
                .Property(e => e.MASV)
                .IsUnicode(false);

/*            modelBuilder.Entity<CHITIETKYTHI>()
                .HasOptional(e => e.BANGDIEM)
                .WithRequired(e => e.CHITIETKYTHI);*/

            modelBuilder.Entity<DETHI>()
                .Property(e => e.MADETHI)
                .IsUnicode(false);

            modelBuilder.Entity<DETHI>()
                .Property(e => e.MAKITHI)
                .IsUnicode(false);

            modelBuilder.Entity<DETHI>()
                .Property(e => e.MAMT)
                .IsUnicode(false);

/*            modelBuilder.Entity<DETHI>()
                .HasMany(e => e.CHITIETDETHI)
                .WithRequired(e => e.DETHI)
                .WillCascadeOnDelete(false);*/

            modelBuilder.Entity<KITHI>()
                .Property(e => e.MAKITHI)
                .IsUnicode(false);

            modelBuilder.Entity<KITHI>()
                .Property(e => e.ADMIN)
                .IsUnicode(false);

        /*    modelBuilder.Entity<KITHI>()
                .HasMany(e => e.CHITIETKYTHI)
                .WithRequired(e => e.KITHI)
                .WillCascadeOnDelete(false);*/

            modelBuilder.Entity<MONTHI>()
                .Property(e => e.MAMT)
                .IsUnicode(false);
/*
            modelBuilder.Entity<MONTHI>()
                .HasMany(e => e.CHITIETKYTHI)
                .WithRequired(e => e.MONTHI)
                .WillCascadeOnDelete(false);*/

            // ROLE configuration
            modelBuilder.Entity<ROLE>()
                .HasMany(e => e.NGUOIDUNG)
                .WithOptional(e => e.ROLE)
                .HasForeignKey(e => e.MAROLE);

            // NGUOIDUNG configuration
            modelBuilder.Entity<NGUOIDUNG>()
                .Property(e => e.TENTAIKHOAN)
                .IsUnicode(false);

            modelBuilder.Entity<NGUOIDUNG>()
                .Property(e => e.MATKHAU)
                .IsUnicode(false);

            modelBuilder.Entity<NGUOIDUNG>()
                .Property(e => e.EMAIL)
                .IsUnicode(false);
        }
    }
}
