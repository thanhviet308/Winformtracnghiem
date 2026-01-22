using PhanMemThiTracNghiem.Data;
using PhanMemThiTracNghiem.Services;
using PhanMemThiTracNghiem.DTOs;
using PhanMemThiTracNghiem.Models;
using PhanMemThiTracNghiem.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhanMemThiTracNghiem.Forms.Admin.DeThi
{
    public partial class ChiTietDeThi : Form
    {
        private readonly AppDbContext AppDbContext;
        private readonly CauHoiService CauHoiService;
        private string madethi;
        
        public ChiTietDeThi(string madethi)
        {
            this.madethi = madethi;
            InitializeComponent();
            ThemeHelper.ApplyVietnameseFont(this);
            AppDbContext = new AppDbContext();
            CauHoiService = new CauHoiService();
        }

        private void ChiTietDeThi_Load(object sender, EventArgs e)
        {
            // Load danh sách môn học
            var listMonHoc = AppDbContext.MonHoc.ToList();
            foreach (var item in listMonHoc)
            {
                cbMonThi.Items.Add(item.TenMon);
            }
            if (cbMonThi.Items.Count > 0)
                cbMonThi.SelectedIndex = 0;
            
            labelMaDeThi.Text = madethi;
            
            // Load câu hỏi theo môn học đã chọn
            LoadCauHoiTheoMon();
        }

        private void LoadCauHoiTheoMon()
        {
            string tenMon = cbMonThi.Text.Trim();
            var monHoc = AppDbContext.MonHoc.FirstOrDefault(m => m.TenMon == tenMon);
            
            if (monHoc != null)
            {
                // Lấy danh sách câu hỏi theo môn - sử dụng CauHoiDTO
                var allCauHoi = CauHoiService.GetThongTinCauHoi();
                var listCauHoi = allCauHoi.Where(c => c.MaMT == monHoc.Id.ToString()).ToList();

                LoadDGVDeThi(listCauHoi);
            }
        }

        private void cbMonThi_TextChanged(object sender, EventArgs e)
        {
            LoadCauHoiTheoMon();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                // Lưu cấu trúc đề vào bảng CauTrucDe
                long nganHangDeId = long.TryParse(madethi, out long id) ? id : 0;
                
                for (int i = 0; i < dgvChiTDeThi.Rows.Count; i++)
                {
                    if (dgvChiTDeThi.Rows[i].Cells["colMaCauHoi"].Value != null)
                    {
                        var cauTrucDe = new CauTrucDe
                        {
                            MaNganHangDe = nganHangDeId,
                            SoCau = 1 // Mỗi câu hỏi được thêm 1 lần
                        };
                        
                        // Lấy mã môn từ câu hỏi
                        if (int.TryParse(dgvChiTDeThi.Rows[i].Cells["colMaCauHoi"].Value.ToString(), out int maCauHoi))
                        {
                            var cauHoi = AppDbContext.CauHoiThi.Find((long)maCauHoi);
                            if (cauHoi != null)
                            {
                                cauTrucDe.MaMon = cauHoi.MaMon;
                            }
                        }
                        
                        AppDbContext.CauTrucDe.Add(cauTrucDe);
                    }
                }
                AppDbContext.SaveChanges();
                MessageBox.Show("Lưu thành công");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void LoadDGVDeThi(List<CauHoiDTO> listCauHoi)
        {
            dgvCauHoiDeThi.Rows.Clear();
            foreach (var item in listCauHoi)
            {
                int index = dgvCauHoiDeThi.Rows.Add();
                dgvCauHoiDeThi.Rows[index].Cells["colSTT"].Value = item.STT;
                dgvCauHoiDeThi.Rows[index].Cells["colMaCH"].Value = item.MaCauHoi;
                dgvCauHoiDeThi.Rows[index].Cells["colNoiDung"].Value = item.NDCAUHOI;
                dgvCauHoiDeThi.Rows[index].Cells["coldapan1"].Value = item.DapAn1;
                dgvCauHoiDeThi.Rows[index].Cells["coldapan2"].Value = item.DapAn2;
                dgvCauHoiDeThi.Rows[index].Cells["coldapan3"].Value = item.DapAn3;
                dgvCauHoiDeThi.Rows[index].Cells["coldapan4"].Value = item.DapAn4;
                dgvCauHoiDeThi.Rows[index].Cells["coldapandung"].Value = item.DapAnDung;
                dgvCauHoiDeThi.Rows[index].Cells["colMaGV"].Value = item.MaGiaoVien;
                dgvCauHoiDeThi.Rows[index].Cells["colMaMT"].Value = item.MaMT;
            }
        }

        private void dgvCauHoiDeThi_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0) return;
                
                dgvCauHoiDeThi.CurrentRow.Selected = true;
                
                // Kiểm tra câu hỏi đã tồn tại trong danh sách chưa
                string maCauHoiMoi = dgvCauHoiDeThi.Rows[e.RowIndex].Cells["colMaCH"].Value?.ToString();
                
                for (int i = 0; i < dgvChiTDeThi.RowCount; i++)
                {
                    if (dgvChiTDeThi.Rows[i].Cells["colMaCauHoi"].Value != null)
                    {
                        if (dgvChiTDeThi.Rows[i].Cells["colMaCauHoi"].Value.ToString() == maCauHoiMoi)
                        {
                            MessageBox.Show("Mã câu hỏi đã tồn tại trong đề thi");
                            return;
                        }
                    }
                }
                
                // Thêm câu hỏi vào danh sách
                int index = dgvChiTDeThi.Rows.Add();
                dgvChiTDeThi.Rows[index].Cells["colMaDeThi"].Value = madethi;
                dgvChiTDeThi.Rows[index].Cells["colMaCauHoi"].Value = maCauHoiMoi;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void dgvChiTDeThi_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }
    }
}
