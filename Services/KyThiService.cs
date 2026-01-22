using System;
using System.Collections.Generic;
using PhanMemThiTracNghiem.Repositories;
using PhanMemThiTracNghiem.DTOs;
using PhanMemThiTracNghiem.Models;

namespace PhanMemThiTracNghiem.Services
{
    public class KyThiService
    {
        private readonly KyThiRepository _kyThiRepository;

        public KyThiService()
        {
            _kyThiRepository = new KyThiRepository();
        }

        // Lấy tất cả kỳ thi
        public List<KyThi> GetAll()
        {
            return _kyThiRepository.GetAll();
        }

        // Lấy kỳ thi theo ID
        public KyThi GetById(long id)
        {
            return _kyThiRepository.GetById(id);
        }

        // Lấy kỳ thi đang diễn ra
        public List<KyThi> GetActiveExams()
        {
            return _kyThiRepository.GetActiveExams();
        }

        // Thêm kỳ thi
        public bool Add(KyThi kyThi)
        {
            return _kyThiRepository.Add(kyThi);
        }

        // Cập nhật kỳ thi
        public bool Update(KyThi kyThi)
        {
            return _kyThiRepository.Update(kyThi);
        }

        // Xóa kỳ thi
        public bool Delete(long id)
        {
            return _kyThiRepository.Delete(id);
        }

        // ============ Legacy methods for backward compatibility ============
        public List<KyThi> GetThongTinKyThi()
        {
            return _kyThiRepository.GetThongTinKyThi();
        }

        public List<KyThi> GetKITHIs()
        {
            return _kyThiRepository.GetKITHIs();
        }

        public static void InsertUpdate(KiThiDTO a)
        {
            KyThiRepository.InsertUpdate(a);
        }
    }
}
