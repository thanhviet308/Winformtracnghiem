using PhanMemThiTracNghiem.Services;
using PhanMemThiTracNghiem.Models;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace PhanMemThiTracNghiem.Forms.Admin.MonHoc
{
    public partial class ucQuanLyMonHoc : UserControl
    {
        private readonly MonHocService MonHocService;

        public ucQuanLyMonHoc()
        {
            InitializeComponent();
            ThemeHelper.ApplyVietnameseFont(this);
            MonHocService = new MonHocService();
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                var list = MonHocService.GetThongTinMonThi();
                dgvMonHoc.Rows.Clear();

                foreach (var item in list)
                {
                    int index = dgvMonHoc.Rows.Add();
                    dgvMonHoc.Rows[index].Cells["colId"].Value = item.Id;
                    dgvMonHoc.Rows[index].Cells["colTenMon"].Value = item.TenMon;
                    dgvMonHoc.Rows[index].Cells["colSua"].Value = "Sửa";
                    dgvMonHoc.Rows[index].Cells["colXoa"].Value = "Xóa";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            string keyword = txtTimKiem.Text.Trim().ToLower();
            if (string.IsNullOrEmpty(keyword))
            {
                LoadData();
                return;
            }

            var list = MonHocService.GetThongTinMonThi();
            dgvMonHoc.Rows.Clear();

            foreach (var item in list)
            {
                if (item.TenMon.ToLower().Contains(keyword))
                {
                    int index = dgvMonHoc.Rows.Add();
                    dgvMonHoc.Rows[index].Cells["colId"].Value = item.Id;
                    dgvMonHoc.Rows[index].Cells["colTenMon"].Value = item.TenMon;
                    dgvMonHoc.Rows[index].Cells["colSua"].Value = "Sửa";
                    dgvMonHoc.Rows[index].Cells["colXoa"].Value = "Xóa";
                }
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            var frm = new frmThemMonHoc();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                LoadData();
            }
        }

        private void dgvMonHoc_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var columnName = dgvMonHoc.Columns[e.ColumnIndex].Name;
            var id = Convert.ToInt64(dgvMonHoc.Rows[e.RowIndex].Cells["colId"].Value);

            if (columnName == "colSua")
            {
                var monHoc = MonHocService.GetById(id);
                if (monHoc != null)
                {
                    var frm = new frmSuaMonHoc(monHoc);
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        LoadData();
                    }
                }
            }
            else if (columnName == "colXoa")
            {
                var result = MessageBox.Show("Bạn có chắc chắn muốn xóa môn học này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    if (MonHocService.Delete(id))
                    {
                        MessageBox.Show("Xóa môn học thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadData();
                    }
                    else
                    {
                        MessageBox.Show("Không thể xóa môn học!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
