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
            LoadMonThi();
            LoadDeThi();
        }

        #region Load Data
        private void LoadMonThi()
        {
            var listMonThi = AppDbContext.MONTHI.Select(m => new
            {
                m.MAMT,
                m.TENMT
            }).ToList();

            dgvMonThi.DataSource = listMonThi;

            // Đặt tên cột
            if (dgvMonThi.Columns.Count > 0)
            {
                dgvMonThi.Columns["MAMT"].HeaderText = "Mã môn thi";
                dgvMonThi.Columns["TENMT"].HeaderText = "Tên môn thi";
            }
        }

        private void LoadDeThi()
        {
            var listDeThi = (from dt in AppDbContext.DETHI
                             join kt in AppDbContext.KITHI on dt.MAKITHI equals kt.MAKITHI into ktJoin
                             from kt in ktJoin.DefaultIfEmpty()
                             join mt in AppDbContext.MONTHI on dt.MAMT equals mt.MAMT into mtJoin
                             from mt in mtJoin.DefaultIfEmpty()
                             select new
                             {
                                 dt.MADETHI,
                                 TenKyThi = kt != null ? kt.TENKITHI : "",
                                 TenMonThi = mt != null ? mt.TENMT : ""
                             }).ToList();

            dgvDeThi.DataSource = listDeThi;

            // Đặt tên cột
            if (dgvDeThi.Columns.Count > 0)
            {
                dgvDeThi.Columns["MADETHI"].HeaderText = "Mã đề thi";
                dgvDeThi.Columns["TenKyThi"].HeaderText = "Kỳ thi";
                dgvDeThi.Columns["TenMonThi"].HeaderText = "Môn thi";
            }
        }
        #endregion

        #region Môn Thi Events
        private void btnThemMonThi_Click(object sender, EventArgs e)
        {
            frmThemMonThi frm = new frmThemMonThi();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                LoadMonThi();
            }
        }

        private void txtTimMonThi_TextChanged(object sender, EventArgs e)
        {
            string keyword = txtTimMonThi.Text.Trim().ToLower();
            if (string.IsNullOrEmpty(keyword))
            {
                LoadMonThi();
                return;
            }

            var listMonThi = AppDbContext.MONTHI
                .Where(m => m.MAMT.ToLower().Contains(keyword) || m.TENMT.ToLower().Contains(keyword))
                .Select(m => new { m.MAMT, m.TENMT })
                .ToList();

            dgvMonThi.DataSource = listMonThi;
        }

        private void dgvMonThi_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            string maMT = dgvMonThi.Rows[e.RowIndex].Cells["MAMT"].Value?.ToString();

            if (dgvMonThi.Columns[e.ColumnIndex].Name == "colSuaMonThi")
            {
                // TODO: Mở form sửa môn thi
                MessageBox.Show($"Sửa môn thi: {maMT}", "Thông báo");
            }
            else if (dgvMonThi.Columns[e.ColumnIndex].Name == "colXoaMonThi")
            {
                if (MessageBox.Show($"Bạn có chắc muốn xóa môn thi này?", "Xác nhận",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        var monThi = AppDbContext.MONTHI.Find(maMT);
                        if (monThi != null)
                        {
                            AppDbContext.MONTHI.Remove(monThi);
                            AppDbContext.SaveChanges();
                            LoadMonThi();
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

        #region Đề Thi Events
        private void btnThemDeThi_Click(object sender, EventArgs e)
        {
            frmThemDeThi frm = new frmThemDeThi();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                LoadDeThi();

                // Mở chi tiết đề thi
                ChiTietDeThi chiTietDeThi = new ChiTietDeThi(frm.MaDeThiMoi);
                chiTietDeThi.ShowDialog();
                LoadDeThi();
            }
        }

        private void txtTimDeThi_TextChanged(object sender, EventArgs e)
        {
            string keyword = txtTimDeThi.Text.Trim().ToLower();
            if (string.IsNullOrEmpty(keyword))
            {
                LoadDeThi();
                return;
            }

            var listDeThi = (from dt in AppDbContext.DETHI
                             join kt in AppDbContext.KITHI on dt.MAKITHI equals kt.MAKITHI into ktJoin
                             from kt in ktJoin.DefaultIfEmpty()
                             join mt in AppDbContext.MONTHI on dt.MAMT equals mt.MAMT into mtJoin
                             from mt in mtJoin.DefaultIfEmpty()
                             where dt.MADETHI.ToLower().Contains(keyword) ||
                                   (kt != null && kt.TENKITHI.ToLower().Contains(keyword)) ||
                                   (mt != null && mt.TENMT.ToLower().Contains(keyword))
                             select new
                             {
                                 dt.MADETHI,
                                 TenKyThi = kt != null ? kt.TENKITHI : "",
                                 TenMonThi = mt != null ? mt.TENMT : ""
                             }).ToList();

            dgvDeThi.DataSource = listDeThi;
        }

        private void dgvDeThi_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            string maDT = dgvDeThi.Rows[e.RowIndex].Cells["MADETHI"].Value?.ToString();

            if (dgvDeThi.Columns[e.ColumnIndex].Name == "colSuaDeThi")
            {
                // Mở chi tiết đề thi để sửa
                ChiTietDeThi chiTietDeThi = new ChiTietDeThi(maDT);
                chiTietDeThi.ShowDialog();
                LoadDeThi();
            }
            else if (dgvDeThi.Columns[e.ColumnIndex].Name == "colXoaDeThi")
            {
                if (MessageBox.Show($"Bạn có chắc muốn xóa đề thi này?", "Xác nhận",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        var deThi = AppDbContext.DETHI.Find(maDT);
                        if (deThi != null)
                        {
                            AppDbContext.DETHI.Remove(deThi);
                            AppDbContext.SaveChanges();
                            LoadDeThi();
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

            string maDT = dgvDeThi.Rows[e.RowIndex].Cells["MADETHI"].Value?.ToString();
            ChiTietDeThi chiTietDeThi = new ChiTietDeThi(maDT);
            chiTietDeThi.ShowDialog();
            LoadDeThi();
        }
        #endregion
    }
}
