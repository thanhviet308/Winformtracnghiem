using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PhanMemThiTracNghiem.Models;

namespace PhanMemThiTracNghiem.Data
{
    public partial class AppDbContext : DbContext
    {
        private static string _connectionString;

        static AppDbContext()
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public AppDbContext()
        {
        }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        // DbSets theo thiết kế mới
        public virtual DbSet<VaiTro> VaiTro { get; set; }
        public virtual DbSet<NguoiDung> NguoiDung { get; set; }
        public virtual DbSet<MonHoc> MonHoc { get; set; }
        public virtual DbSet<LopHoc> LopHoc { get; set; }
        public virtual DbSet<LopHocSinhVien> LopHocSinhVien { get; set; }
        public virtual DbSet<CauHoiThi> CauHoiThi { get; set; }
        public virtual DbSet<LuaChonTracNghiem> LuaChonTracNghiem { get; set; }
        public virtual DbSet<NganHangDe> NganHangDe { get; set; }
        public virtual DbSet<CauTrucDe> CauTrucDe { get; set; }
        public virtual DbSet<KyThi> KyThi { get; set; }
        public virtual DbSet<PhanCongGiangDay> PhanCongGiangDay { get; set; }
        public virtual DbSet<PhanCongGiamSat> PhanCongGiamSat { get; set; }
        public virtual DbSet<BaiThi> BaiThi { get; set; }
        public virtual DbSet<TraLoiBaiThi> TraLoiBaiThi { get; set; }
        public virtual DbSet<NhatKyViPham> NhatKyViPham { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // ===== Composite Keys =====

            // lop_hoc_sinh_vien: ma_lop + ma_sinh_vien
            modelBuilder.Entity<LopHocSinhVien>(entity =>
            {
                entity.HasKey(e => new { e.MaLop, e.MaSinhVien });

                entity.HasOne(e => e.LopHoc)
                    .WithMany(l => l.LopHocSinhViens)
                    .HasForeignKey(e => e.MaLop)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(e => e.SinhVien)
                    .WithMany(n => n.LopHocSinhViens)
                    .HasForeignKey(e => e.MaSinhVien)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            // phan_cong_giang_day: ma_lop + ma_mon
            modelBuilder.Entity<PhanCongGiangDay>(entity =>
            {
                entity.HasKey(e => new { e.MaLop, e.MaMon });

                entity.HasOne(e => e.LopHoc)
                    .WithMany(l => l.PhanCongGiangDays)
                    .HasForeignKey(e => e.MaLop)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(e => e.MonHoc)
                    .WithMany(m => m.PhanCongGiangDays)
                    .HasForeignKey(e => e.MaMon)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(e => e.GiangVien)
                    .WithMany(n => n.PhanCongGiangDays)
                    .HasForeignKey(e => e.MaGiangVien)
                    .OnDelete(DeleteBehavior.SetNull);
            });

            // ===== VaiTro =====
            modelBuilder.Entity<VaiTro>(entity =>
            {
                entity.HasMany(e => e.NguoiDungs)
                    .WithOne(e => e.VaiTro)
                    .HasForeignKey(e => e.MaVaiTro)
                    .OnDelete(DeleteBehavior.SetNull);
            });

            // ===== NguoiDung =====
            modelBuilder.Entity<NguoiDung>(entity =>
            {
                entity.HasIndex(e => e.Email).IsUnique();
            });

            // ===== MonHoc =====
            modelBuilder.Entity<MonHoc>(entity =>
            {
                entity.HasMany(e => e.CauHoiThis)
                    .WithOne(e => e.MonHoc)
                    .HasForeignKey(e => e.MaMon)
                    .OnDelete(DeleteBehavior.SetNull);

                entity.HasMany(e => e.NganHangDes)
                    .WithOne(e => e.MonHoc)
                    .HasForeignKey(e => e.MaMon)
                    .OnDelete(DeleteBehavior.SetNull);
            });

            // ===== CauHoiThi =====
            modelBuilder.Entity<CauHoiThi>(entity =>
            {
                entity.HasMany(e => e.LuaChonTracNghiems)
                    .WithOne(e => e.CauHoiThi)
                    .HasForeignKey(e => e.MaCauHoi)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(e => e.NguoiDung)
                    .WithMany(n => n.CauHoiThis)
                    .HasForeignKey(e => e.NguoiTao)
                    .OnDelete(DeleteBehavior.SetNull);
            });

            // ===== NganHangDe =====
            modelBuilder.Entity<NganHangDe>(entity =>
            {
                entity.HasMany(e => e.CauTrucDes)
                    .WithOne(e => e.NganHangDe)
                    .HasForeignKey(e => e.MaNganHangDe)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasMany(e => e.KyThis)
                    .WithOne(e => e.NganHangDe)
                    .HasForeignKey(e => e.MaNganHangDe)
                    .OnDelete(DeleteBehavior.SetNull);

                entity.HasOne(e => e.NguoiDung)
                    .WithMany(n => n.NganHangDes)
                    .HasForeignKey(e => e.NguoiTao)
                    .OnDelete(DeleteBehavior.SetNull);
            });

            // ===== KyThi =====
            modelBuilder.Entity<KyThi>(entity =>
            {
                entity.HasOne(e => e.LopHoc)
                    .WithMany(l => l.KyThis)
                    .HasForeignKey(e => e.MaLop)
                    .OnDelete(DeleteBehavior.SetNull);

                entity.HasMany(e => e.PhanCongGiamSats)
                    .WithOne(e => e.KyThi)
                    .HasForeignKey(e => e.MaKyThi)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasMany(e => e.BaiThis)
                    .WithOne(e => e.KyThi)
                    .HasForeignKey(e => e.MaKyThi)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            // ===== PhanCongGiamSat =====
            modelBuilder.Entity<PhanCongGiamSat>(entity =>
            {
                entity.HasOne(e => e.GiamThi)
                    .WithMany(n => n.PhanCongGiamSats)
                    .HasForeignKey(e => e.MaGiamThi)
                    .OnDelete(DeleteBehavior.SetNull);
            });

            // ===== BaiThi =====
            modelBuilder.Entity<BaiThi>(entity =>
            {
                entity.HasOne(e => e.SinhVien)
                    .WithMany(n => n.BaiThis)
                    .HasForeignKey(e => e.MaSinhVien)
                    .OnDelete(DeleteBehavior.SetNull);

                entity.HasMany(e => e.TraLoiBaiThis)
                    .WithOne(e => e.BaiThi)
                    .HasForeignKey(e => e.MaBaiThi)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasMany(e => e.NhatKyViPhams)
                    .WithOne(e => e.BaiThi)
                    .HasForeignKey(e => e.MaBaiThi)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            // ===== TraLoiBaiThi =====
            modelBuilder.Entity<TraLoiBaiThi>(entity =>
            {
                entity.HasOne(e => e.CauHoiThi)
                    .WithMany(c => c.TraLoiBaiThis)
                    .HasForeignKey(e => e.MaCauHoi)
                    .OnDelete(DeleteBehavior.NoAction);

                entity.HasOne(e => e.LuaChonTracNghiem)
                    .WithMany(l => l.TraLoiBaiThis)
                    .HasForeignKey(e => e.MaLuaChon)
                    .OnDelete(DeleteBehavior.NoAction);
            });

            // ===== Seed Data =====

            // Seed vai trò mặc định
            modelBuilder.Entity<VaiTro>().HasData(
                new VaiTro { Id = 1, TenVaiTro = "Admin", MoTa = "Quản trị viên hệ thống" },
                new VaiTro { Id = 2, TenVaiTro = "Giảng viên", MoTa = "Giảng viên quản lý câu hỏi và đề thi" },
                new VaiTro { Id = 3, TenVaiTro = "Sinh viên", MoTa = "Sinh viên tham gia thi" }
            );

            // Seed tài khoản admin mặc định
            // Mật khẩu: 123456 (đã được hash bằng SHA256)
            modelBuilder.Entity<NguoiDung>().HasData(
                new NguoiDung
                {
                    Id = 1,
                    HoTen = "Quản trị viên",
                    Email = "admin@gmail.com",
                    MatKhau = "8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92", // SHA256 của "123456"
                    MaVaiTro = 1,
                    NgayTao = new DateTime(2026, 1, 1),
                    TrangThai = true
                }
            );
        }
    }
}
