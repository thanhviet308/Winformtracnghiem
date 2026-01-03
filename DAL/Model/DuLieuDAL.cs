using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace PhanMemThiTracNghiem.DAL.Model
{
    public partial class DuLieuDAL : DbContext
    {
        private static string _connectionString;
        
        static DuLieuDAL()
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();
            
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }
        
        public DuLieuDAL()
        {
        }

        public DuLieuDAL(DbContextOptions<DuLieuDAL> options)
            : base(options)
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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Composite keys
            modelBuilder.Entity<BANGDIEM>(entity =>
            {
                entity.HasKey(e => new { e.MASV, e.MAKITHI, e.MAMT });
                entity.Property(e => e.MASV).IsUnicode(false);
                entity.Property(e => e.MAKITHI).IsUnicode(false);
                entity.Property(e => e.MAMT).IsUnicode(false);
            });

            modelBuilder.Entity<CHITIETDETHI>(entity =>
            {
                entity.HasKey(e => new { e.MADETHI, e.MACAUHOI });
                entity.Property(e => e.MADETHI).IsUnicode(false);
            });

            modelBuilder.Entity<CHITIETKYTHI>(entity =>
            {
                entity.HasKey(e => new { e.MAKITHI, e.MAMT, e.MASV });
                entity.Property(e => e.MAKITHI).IsUnicode(false);
                entity.Property(e => e.MAMT).IsUnicode(false);
                entity.Property(e => e.MASV).IsUnicode(false);
            });

            modelBuilder.Entity<CAUHOI>(entity =>
            {
                entity.Property(e => e.MAGV).IsUnicode(false);
                entity.Property(e => e.MAMT).IsUnicode(false);
            });

            modelBuilder.Entity<DETHI>(entity =>
            {
                entity.Property(e => e.MADETHI).IsUnicode(false);
                entity.Property(e => e.MAKITHI).IsUnicode(false);
                entity.Property(e => e.MAMT).IsUnicode(false);
            });

            modelBuilder.Entity<KITHI>(entity =>
            {
                entity.Property(e => e.MAKITHI).IsUnicode(false);
                entity.Property(e => e.ADMIN).IsUnicode(false);
            });

            modelBuilder.Entity<MONTHI>(entity =>
            {
                entity.Property(e => e.MAMT).IsUnicode(false);
            });

            // ROLE configuration
            modelBuilder.Entity<ROLE>(entity =>
            {
                entity.HasMany(e => e.NGUOIDUNG)
                    .WithOne(e => e.ROLE)
                    .HasForeignKey(e => e.MAROLE);
            });

            // NGUOIDUNG configuration
            modelBuilder.Entity<NGUOIDUNG>(entity =>
            {
                entity.Property(e => e.MATKHAU).IsUnicode(false);
                entity.Property(e => e.EMAIL).IsUnicode(false);
                entity.HasIndex(e => e.EMAIL).IsUnique(); // Email là duy nhất
            });

            // Seed data - tạo các role mặc định
            modelBuilder.Entity<ROLE>().HasData(
                new ROLE { MAROLE = 1, TENROLE = "Admin" },
                new ROLE { MAROLE = 2, TENROLE = "Giảng viên" },
                new ROLE { MAROLE = 3, TENROLE = "Sinh viên" }
            );

            // Seed data - tạo tài khoản admin mặc định
            // Mật khẩu: 123456 (đã được hash bằng SHA256)
            modelBuilder.Entity<NGUOIDUNG>().HasData(
                new NGUOIDUNG
                {
                    ID = 1,
                    MATKHAU = "8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92", // SHA256 của "123456"
                    HOTEN = "Quản trị viên",
                    EMAIL = "admin@gmail.com",
                    MAROLE = 1
                }
            );
        }
    }
}
