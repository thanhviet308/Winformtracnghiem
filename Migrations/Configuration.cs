namespace PhanMemThiTracNghiem.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using PhanMemThiTracNghiem.DAL.Model;

    internal sealed class Configuration : DbMigrationsConfiguration<PhanMemThiTracNghiem.DAL.Model.DuLieuDAL>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(PhanMemThiTracNghiem.DAL.Model.DuLieuDAL context)
        {
            //  This method will be called after migrating to the latest version.

            // Thêm Role mặc định
            context.ROLE.AddOrUpdate(
                r => r.TENROLE,
                new ROLE { MAROLE = 1, TENROLE = "Admin" },
                new ROLE { MAROLE = 2, TENROLE = "GiangVien" },
                new ROLE { MAROLE = 3, TENROLE = "SinhVien" }
            );

            // Lưu Role trước để có thể tham chiếu
            context.SaveChanges();

            // Thêm tài khoản Admin mặc định
            context.NGUOIDUNG.AddOrUpdate(
                n => n.TENTAIKHOAN,
                new NGUOIDUNG
                {
                    TENTAIKHOAN = "admin",
                    MATKHAU = "123456",
                    EMAIL = "admin@gmail.com",
                    HOTEN = "Administrator",
                    NGAYSINH = new DateTime(2000, 1, 1),
                    MAROLE = 1
                }
            );
        }
    }
}
