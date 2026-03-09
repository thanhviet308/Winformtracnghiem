using PhanMemThiTracNghiem.Repositories;
using PhanMemThiTracNghiem.Models;
using PhanMemThiTracNghiem.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PhanMemThiTracNghiem.Services
{
    public class NganHangDeService
    {
        private readonly NganHangDeRepository _nganHangDeRepository;
        private readonly AppDbContext _context;

        public NganHangDeService()
        {
            _nganHangDeRepository = new NganHangDeRepository();
            _context = new AppDbContext();
        }

        // Lấy tất cả ngân hàng đề
        public List<NganHangDe> GetAll()
        {
            return _nganHangDeRepository.GetAll();
        }

        // Lấy ngân hàng đề theo ID
        public NganHangDe GetById(long id)
        {
            return _nganHangDeRepository.GetById(id);
        }

        // Lấy ngân hàng đề theo môn học
        public List<NganHangDe> GetByMonHoc(long maMon)
        {
            return _nganHangDeRepository.GetByMonHoc(maMon);
        }

        // Lấy ngân hàng đề theo người tạo (giáo viên)
        public List<NganHangDe> GetByNguoiTao(long nguoiTaoId)
        {
            return _context.NganHangDe
                .Where(n => n.NguoiTao == nguoiTaoId)
                .ToList();
        }

        // Thêm ngân hàng đề
        public bool Add(NganHangDe nganHangDe)
        {
            return _nganHangDeRepository.Add(nganHangDe);
        }

        // Thêm ngân hàng đề với cấu trúc đề
        public bool AddWithCauTruc(NganHangDe nganHangDe, List<CauTrucDe> cauTrucs)
        {
            try
            {
                _context.NganHangDe.Add(nganHangDe);
                _context.SaveChanges();

                foreach (var ct in cauTrucs)
                {
                    ct.MaNganHangDe = nganHangDe.Id;
                    _context.CauTrucDe.Add(ct);
                }
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        // Cập nhật ngân hàng đề
        public bool Update(NganHangDe nganHangDe)
        {
            return _nganHangDeRepository.Update(nganHangDe);
        }

        // Cập nhật ngân hàng đề với cấu trúc đề
        public bool UpdateWithCauTruc(NganHangDe nganHangDe, List<CauTrucDe> cauTrucs)
        {
            try
            {
                var existing = _context.NganHangDe.Find(nganHangDe.Id);
                if (existing != null)
                {
                    existing.TenDe = nganHangDe.TenDe;
                    existing.MaMon = nganHangDe.MaMon;
                    existing.TongSoCau = nganHangDe.TongSoCau;

                    // Xóa cấu trúc cũ
                    var oldCauTrucs = _context.CauTrucDe.Where(c => c.MaNganHangDe == nganHangDe.Id).ToList();
                    _context.CauTrucDe.RemoveRange(oldCauTrucs);

                    // Thêm cấu trúc mới
                    foreach (var ct in cauTrucs)
                    {
                        ct.MaNganHangDe = nganHangDe.Id;
                        _context.CauTrucDe.Add(ct);
                    }

                    _context.SaveChanges();
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }

        // Xóa ngân hàng đề
        public bool Delete(long id)
        {
            // Kiểm tra xem có kỳ thi nào đang sử dụng không
            var hasKyThi = _context.KyThi.Any(k => k.MaNganHangDe == id);
            if (hasKyThi)
            {
                return false;
            }
            return _nganHangDeRepository.Delete(id);
        }

        // Lấy cấu trúc đề
        public List<CauTrucDe> GetCauTrucDe(long nganHangDeId)
        {
            return _context.CauTrucDe
                .Where(c => c.MaNganHangDe == nganHangDeId)
                .ToList();
        }

        // Kiểm tra số câu hỏi có đủ theo cấu trúc không
        public bool ValidateCauTrucDe(long nganHangDeId)
        {
            var nganHangDe = GetById(nganHangDeId);
            if (nganHangDe == null) return false;

            var cauTrucs = GetCauTrucDe(nganHangDeId);
            int tongSoCauTrucDe = cauTrucs.Sum(c => c.SoCau);

            return tongSoCauTrucDe == nganHangDe.TongSoCau;
        }

        // Đếm số câu hỏi theo môn học
        public int CountCauHoiByMonHoc(long maMon)
        {
            return _context.CauHoiThi.Count(c => c.MaMon == maMon && c.TrangThai);
        }
    }
}
