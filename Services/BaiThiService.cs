using PhanMemThiTracNghiem.Repositories;
using PhanMemThiTracNghiem.Models;
using System;
using System.Collections.Generic;

namespace PhanMemThiTracNghiem.Services
{
    public class BaiThiService
    {
        private readonly BaiThiRepository _baiThiRepository;

        public BaiThiService()
        {
            _baiThiRepository = new BaiThiRepository();
        }

        // Lấy tất cả bài thi
        public List<BaiThi> GetAll()
        {
            return _baiThiRepository.GetAll();
        }

        // Lấy bài thi theo ID
        public BaiThi GetById(long id)
        {
            return _baiThiRepository.GetById(id);
        }

        // Lấy bài thi theo sinh viên
        public List<BaiThi> GetBySinhVien(long maSinhVien)
        {
            return _baiThiRepository.GetBySinhVien(maSinhVien);
        }

        // Lấy bài thi theo kỳ thi
        public List<BaiThi> GetByKyThi(long maKyThi)
        {
            return _baiThiRepository.GetByKyThi(maKyThi);
        }

        // Tạo bài thi mới
        public bool BatDauThi(long maKyThi, long maSinhVien)
        {
            var baiThi = new BaiThi
            {
                MaKyThi = maKyThi,
                MaSinhVien = maSinhVien,
                ThoiGianBatDau = DateTime.Now,
                TrangThai = "dang_thi"
            };
            return _baiThiRepository.Add(baiThi);
        }

        // Nộp bài thi
        public bool NopBai(long baiThiId, int diemSo)
        {
            return _baiThiRepository.NopBai(baiThiId, diemSo);
        }

        // Cập nhật bài thi
        public bool Update(BaiThi baiThi)
        {
            return _baiThiRepository.Update(baiThi);
        }
    }
}
