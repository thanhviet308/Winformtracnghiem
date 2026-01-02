using PhanMemThiTracNghiem.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PhanMemThiTracNghiem.DAL
{
    public class RoleDAL
    {
        private readonly DuLieuDAL duLieuDAL;

        public RoleDAL()
        {
            duLieuDAL = new DuLieuDAL();
        }

        // Lấy tất cả Role
        public List<ROLE> GetAll()
        {
            return duLieuDAL.ROLE.ToList();
        }

        // Lấy Role theo mã
        public ROLE GetByMaRole(int maRole)
        {
            return duLieuDAL.ROLE.Find(maRole);
        }

        // Lấy Role theo tên
        public ROLE GetByTenRole(string tenRole)
        {
            return duLieuDAL.ROLE.FirstOrDefault(x => x.TENROLE == tenRole);
        }
    }
}
