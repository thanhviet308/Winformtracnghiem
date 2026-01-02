using PhanMemThiTracNghiem.DAL;
using PhanMemThiTracNghiem.DAL.Model;
using System.Collections.Generic;

namespace PhanMemThiTracNghiem.BAL
{
    public class RoleBAL
    {
        private readonly RoleDAL roleDAL;

        public RoleBAL()
        {
            roleDAL = new RoleDAL();
        }

        // Lấy tất cả Role
        public List<ROLE> GetAll()
        {
            return roleDAL.GetAll();
        }

        // Lấy Role theo mã
        public ROLE GetByMaRole(int maRole)
        {
            return roleDAL.GetByMaRole(maRole);
        }

        // Lấy Role theo tên
        public ROLE GetByTenRole(string tenRole)
        {
            return roleDAL.GetByTenRole(tenRole);
        }
    }
}
