using PhanMemThiTracNghiem.Data;
using PhanMemThiTracNghiem.DTOs;
using PhanMemThiTracNghiem.Models;
using PhanMemThiTracNghiem.Repositories;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace PhanMemThiTracNghiem.Forms.Admin.DeThi
{
    public partial class ucQuanLyDeThi : UserControl
    {
        private readonly AppDbContext AppDbContext;

        public ucQuanLyDeThi()
        {
            InitializeComponent();
            ThemeHelper.ApplyVietnameseFont(this);
            AppDbContext = new AppDbContext();
        }

        private void ucQuanLyDeThi_Load(object sender, EventArgs e)
        {
            LoadMonHoc();
            LoadNganHangDe();
        }

        #region Load Data
        private void LoadMonHoc()
        {
            var listMonHoc = AppDbContext.MonHoc.Select(m => new
            {
                m.Id,
                m.TenMon
            }).ToList();

            dgvMonThi.DataSource = listMonHoc;

            // Đặt tên cột
            if (dgvMonThi.Columns.Count > 0)
            {
                dgvMonThi.Columns["Id"].HeaderText = "Mã môn";
                dgvMonThi.Columns["TenMon"].HeaderText = "Tên môn học";
            }
        }

        private void LoadNganHangDe()
        {
            var listNganHangDe = (from nhd in AppDbContext.NganHangDe
                             join kt in AppDbContext.KyThi on nhd.Id equals kt.MaNganHangDe into ktJoin
                             from kt in ktJoin.DefaultIfEmpty()
                             join mh in AppDbContext.MonHoc on nhd.MaMon equals mh.Id into mhJoin
                             from mh in mhJoin.DefaultIfEmpty()
                             select new
                             {
                                 nhd.Id,
                                 nhd.TenDe,
                                 TenKyThi = kt != null ? kt.TenKyThi : "",
                                 TenMonHoc = mh != null ? mh.TenMon : ""
                             }).ToList();

            dgvDeThi.DataSource = listNganHangDe;

            // Đặt tên cột
            if (dgvDeThi.Columns.Count > 0)
            {
                dgvDeThi.Columns["Id"].HeaderText = "Mã ngân hàng đề";
                dgvDeThi.Columns["TenDe"].HeaderText = "Tên ngân hàng đề";
                dgvDeThi.Columns["TenKyThi"].HeaderText = "Kỳ thi";
                dgvDeThi.Columns["TenMonHoc"].HeaderText = "Môn học";
            }
        }
        #endregion

        #region Môn Học Events
        private void btnThemMonThi_Click(object sender, EventArgs e)
        {
            frmThemMonThi frm = new frmThemMonThi();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                LoadMonHoc();
            }
        }

        private void txtTimMonThi_TextChanged(object sender, EventArgs e)
        {
            string keyword = txtTimMonThi.Text.Trim().ToLower();
            if (string.IsNullOrEmpty(keyword))
            {
                LoadMonHoc();
                return;
            }

            var listMonHoc = AppDbContext.MonHoc
                .Where(m => m.Id.ToString().Contains(keyword) || m.TenMon.ToLower().Contains(keyword))
                .Select(m => new { m.Id, m.TenMon })
                .ToList();

            dgvMonThi.DataSource = listMonHoc;
        }

        private void dgvMonThi_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var maMonObj = dgvMonThi.Rows[e.RowIndex].Cells["Id"].Value;
            if (maMonObj == null) return;
            long maMon = Convert.ToInt64(maMonObj);

            if (dgvMonThi.Columns[e.ColumnIndex].Name == "colSuaMonThi")
            {
                // TODO: Mở form sửa môn học
                MessageBox.Show($"Sửa môn học: {maMon}", "Thông báo");
            }
            else if (dgvMonThi.Columns[e.ColumnIndex].Name == "colXoaMonThi")
            {
                if (MessageBox.Show($"Bạn có chắc muốn xóa môn học này?", "Xác nhận",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        var monHoc = AppDbContext.MonHoc.Find(maMon);
                        if (monHoc != null)
                        {
                            AppDbContext.MonHoc.Remove(monHoc);
                            AppDbContext.SaveChanges();
                            LoadMonHoc();
                            MessageBox.Show("Xóa thành công!", "Thông báo");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        #endregion

        #region Ngân Hàng Đề Events
        private void btnThemDeThi_Click(object sender, EventArgs e)
        {
            frmThemDeThi frm = new frmThemDeThi();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                LoadNganHangDe();

                // Mở chi tiết ngân hàng đề
                ChiTietDeThi chiTietDeThi = new ChiTietDeThi(frm.MaDeThiMoi);
                chiTietDeThi.ShowDialog();
                LoadNganHangDe();
            }
        }

        private void txtTimDeThi_TextChanged(object sender, EventArgs e)
        {
            string keyword = txtTimDeThi.Text.Trim().ToLower();
            if (string.IsNullOrEmpty(keyword))
            {
                LoadNganHangDe();
                return;
            }

            var listNganHangDe = (from nhd in AppDbContext.NganHangDe
                             join kt in AppDbContext.KyThi on nhd.Id equals kt.MaNganHangDe into ktJoin
                             from kt in ktJoin.DefaultIfEmpty()
                             join mh in AppDbContext.MonHoc on nhd.MaMon equals mh.Id into mhJoin
                             from mh in mhJoin.DefaultIfEmpty()
                             where nhd.Id.ToString().Contains(keyword) ||
                                   (nhd.TenDe != null && nhd.TenDe.ToLower().Contains(keyword)) ||
                                   (kt != null && kt.TenKyThi.ToLower().Contains(keyword)) ||
                                   (mh != null && mh.TenMon.ToLower().Contains(keyword))
                             select new
                             {
                                 nhd.Id,
                                 nhd.TenDe,
                                 TenKyThi = kt != null ? kt.TenKyThi : "",
                                 TenMonHoc = mh != null ? mh.TenMon : ""
                             }).ToList();

            dgvDeThi.DataSource = listNganHangDe;
        }

        private void dgvDeThi_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var maDeObj = dgvDeThi.Rows[e.RowIndex].Cells["Id"].Value;
            if (maDeObj == null) return;
            string maDe = maDeObj.ToString();

            if (dgvDeThi.Columns[e.ColumnIndex].Name == "colSuaDeThi")
            {
                // Mở chi tiết ngân hàng đề để sửa
                ChiTietDeThi chiTietDeThi = new ChiTietDeThi(maDe);
                chiTietDeThi.ShowDialog();
                LoadNganHangDe();
            }
            else if (dgvDeThi.Columns[e.ColumnIndex].Name == "colXoaDeThi")
            {
                if (MessageBox.Show($"Bạn có chắc muốn xóa ngân hàng đề này?", "Xác nhận",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        long maDeId = Convert.ToInt64(maDeObj);
                        var nganHangDe = AppDbContext.NganHangDe.Find(maDeId);
                        if (nganHangDe != null)
                        {
                            AppDbContext.NganHangDe.Remove(nganHangDe);
                            AppDbContext.SaveChanges();
                            LoadNganHangDe();
                            MessageBox.Show("Xóa thành công!", "Thông báo");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void dgvDeThi_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var maDeObj = dgvDeThi.Rows[e.RowIndex].Cells["Id"].Value;
            if (maDeObj == null) return;
            string maDe = maDeObj.ToString();
            
            ChiTietDeThi chiTietDeThi = new ChiTietDeThi(maDe);
            chiTietDeThi.ShowDialog();
            LoadNganHangDe();
        }
        #endregion
    }
}
