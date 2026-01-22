using PhanMemThiTracNghiem.Repositories;
using PhanMemThiTracNghiem.Models;
using PhanMemThiTracNghiem.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PhanMemThiTracNghiem.Services
{
    public class CauHoiService
    {
        private readonly CauHoiRepository _cauHoiRepository;

        public CauHoiService()
        {
            _cauHoiRepository = new CauHoiRepository();
        }

        // Lấy tất cả câu hỏi
        public List<CauHoiThi> GetAll()
        {
            return _cauHoiRepository.GetAll();
        }

        // Lấy câu hỏi theo ID
        public CauHoiThi GetById(long id)
        {
            return _cauHoiRepository.GetById(id);
        }

        // Lấy câu hỏi theo môn học
        public List<CauHoiThi> GetByMonHoc(long maMon)
        {
            return _cauHoiRepository.GetByMonHoc(maMon);
        }

        // Thêm câu hỏi
        public bool Add(CauHoiThi cauHoi)
        {
            return _cauHoiRepository.Add(cauHoi);
        }

        // Thêm câu hỏi với các lựa chọn
        public bool AddWithOptions(CauHoiThi cauHoi, List<LuaChonTracNghiem> luaChons)
        {
            return _cauHoiRepository.AddWithOptions(cauHoi, luaChons);
        }

        // Cập nhật câu hỏi
        public bool Update(CauHoiThi cauHoi)
        {
            return _cauHoiRepository.Update(cauHoi);
        }

        // Xóa câu hỏi
        public bool Delete(long id)
        {
            return _cauHoiRepository.Delete(id);
        }

        // ============ Legacy methods ============
        public List<CauHoiThi> GetCAUHOIs()
        {
            return _cauHoiRepository.GetCAUHOIs();
        }

        // Legacy method for backward compatibility - returns DTO
        public List<CauHoiDTO> GetThongTinCauHoi()
        {
            var cauHois = GetAll();
            var result = new List<CauHoiDTO>();
            foreach (var c in cauHois)
            {
                var dto = new CauHoiDTO
                {
                    MaCauHoi = (int)c.Id,
                    NDCAUHOI = c.NoiDung,
                    MaMT = c.MaMon?.ToString() ?? "",
                    MaGiaoVien = c.NguoiTao?.ToString() ?? ""
                };
                // Lấy các lựa chọn
                if (c.LuaChonTracNghiems != null && c.LuaChonTracNghiems.Count > 0)
                {
                    var luaChons = c.LuaChonTracNghiems.ToList().OrderBy(l => l.ThuTu).ToList();
                    if (luaChons.Count > 0) dto.DapAn1 = luaChons[0].NoiDung;
                    if (luaChons.Count > 1) dto.DapAn2 = luaChons[1].NoiDung;
                    if (luaChons.Count > 2) dto.DapAn3 = luaChons[2].NoiDung;
                    if (luaChons.Count > 3) dto.DapAn4 = luaChons[3].NoiDung;
                    foreach (var l in luaChons)
                    {
                        if (l.LaDapAnDung) { dto.DapAnDung = l.NoiDung; break; }
                    }
                }
                result.Add(dto);
            }
            return result;
        }

        public void CapNhapCauHoi(int macauh, string noidung, string dapan1, string dapan2, string dapan3, string dapan4, string dapandung, string magv)
        {
            var cauHoi = _cauHoiRepository.GetById(macauh);
            if (cauHoi != null)
            {
                cauHoi.NoiDung = noidung;
                _cauHoiRepository.Update(cauHoi);
            }
        }

        public void InsertUpdate(CauHoiDTO cauHoiDTO)
        {
            var cauHoi = new CauHoiThi
            {
                NoiDung = cauHoiDTO.NDCAUHOI,
                NguoiTao = long.TryParse(cauHoiDTO.MaGiaoVien, out long nguoiTao) ? nguoiTao : null,
                NgayTao = DateTime.Now,
                TrangThai = true
            };
            _cauHoiRepository.Add(cauHoi);
        }
    }
}
