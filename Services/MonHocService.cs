using System;
using System.Collections.Generic;
using PhanMemThiTracNghiem.Repositories;
using PhanMemThiTracNghiem.DTOs;
using PhanMemThiTracNghiem.Models;

namespace PhanMemThiTracNghiem.Services
{
    public class MonHocService
    {
        private readonly MonHocRepository _monHocRepository;

        public MonHocService()
        {
            _monHocRepository = new MonHocRepository();
        }

        // Lấy tất cả môn học
        public List<MonHoc> GetAll()
        {
            return _monHocRepository.GetAll();
        }

        // Lấy môn học theo ID
        public MonHoc GetById(long id)
        {
            return _monHocRepository.GetById(id);
        }

        // Thêm môn học
        public bool Add(MonHoc monHoc)
        {
            return _monHocRepository.Add(monHoc);
        }

        // Cập nhật môn học
        public bool Update(MonHoc monHoc)
        {
            return _monHocRepository.Update(monHoc);
        }

        // Xóa môn học
        public bool Delete(long id)
        {
            return _monHocRepository.Delete(id);
        }

        // ============ Legacy methods for backward compatibility ============
        public List<MonHoc> GetThongTinMonThi()
        {
            return _monHocRepository.GetThongTinMonThi();
        }

        public static void InsertUpdate(MonThiDTO monThiDTO)
        {
            MonHocRepository.InsertUpdate(monThiDTO);
        }
    }
}
