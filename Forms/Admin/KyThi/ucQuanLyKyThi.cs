using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using PhanMemThiTracNghiem.Models;
using PhanMemThiTracNghiem.Repositories;

namespace PhanMemThiTracNghiem.Forms.Admin
{
    public partial class ucQuanLyKyThi : UserControl
    {
        private readonly KyThiRepository _kyThiRepository;
        private List<KITHI> _allKyThi;

        public ucQuanLyKyThi()
        {
            InitializeComponent();
            _kyThiRepository = new KyThiRepository();
        }

        private void ucQuanLyKyThi_Load(object sender, EventArgs e)
        {
            ThemeHelper.ApplyVietnameseFont(this);
            SetupDataGridView();
            LoadKyThi();
        }

        private void SetupDataGridView()
        {
            dgvKyThi.AutoGenerateColumns = false;
            dgvKyThi.Columns.Clear();

            // Thêm các cột dữ liệu
            dgvKyThi.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "MAKITHI",
                HeaderText = "Mã kỳ thi",
                Name = "colMaKyThi",
                Width = 120
            });

            dgvKyThi.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "TENKITHI",
                HeaderText = "Tên kỳ thi",
                Name = "colTenKyThi",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });

            dgvKyThi.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "THOIGIANBDKITHI",
                HeaderText = "Thời gian bắt đầu",
                Name = "colThoiGianBD",
                Width = 180
            });

            dgvKyThi.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "THOIGIANKTKITHI",
                HeaderText = "Thời gian kết thúc",
                Name = "colThoiGianKT",
                Width = 180
            });

            // Thêm cột Sửa và Xóa
            var colSua = new DataGridViewLinkColumn
            {
                HeaderText = "Thao tác",
                Text = "Sửa",
                UseColumnTextForLinkValue = true,
                LinkColor = System.Drawing.Color.FromArgb(59, 130, 246),
                Name = "colSua",
                Width = 60
            };
            dgvKyThi.Columns.Add(colSua);

            var colXoa = new DataGridViewLinkColumn
            {
                HeaderText = "",
                Text = "Xóa",
                UseColumnTextForLinkValue = true,
                LinkColor = System.Drawing.Color.FromArgb(239, 68, 68),
                Name = "colXoa",
                Width = 60
            };
            dgvKyThi.Columns.Add(colXoa);
        }

        private void LoadKyThi()
        {
            try
            {
                _allKyThi = _kyThiRepository.GetKITHIs();
                dgvKyThi.DataSource = null;
                dgvKyThi.DataSource = _allKyThi;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải dữ liệu kỳ thi: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            string keyword = txtTimKiem.Text.Trim().ToLower();
            if (string.IsNullOrEmpty(keyword))
            {
                dgvKyThi.DataSource = null;
                dgvKyThi.DataSource = _allKyThi;
            }
            else
            {
                var filtered = _allKyThi.Where(k =>
                    (k.MAKITHI != null && k.MAKITHI.ToLower().Contains(keyword)) ||
                    (k.TENKITHI != null && k.TENKITHI.ToLower().Contains(keyword))
                ).ToList();
                dgvKyThi.DataSource = null;
                dgvKyThi.DataSource = filtered;
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            var frm = new frmThemKyThi();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                LoadKyThi();
            }
        }

        private void dgvKyThi_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var kyThi = dgvKyThi.Rows[e.RowIndex].DataBoundItem as KITHI;
            if (kyThi == null) return;

            if (e.ColumnIndex == dgvKyThi.Columns["colSua"].Index)
            {
                var frm = new frmSuaKyThi(kyThi);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    LoadKyThi();
                }
            }
            else if (e.ColumnIndex == dgvKyThi.Columns["colXoa"].Index)
            {
                var result = MessageBox.Show(
                    $"Bạn có chắc chắn muốn xóa kỳ thi '{kyThi.TENKITHI}'?",
                    "Xác nhận xóa",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        _kyThiRepository.Delete(kyThi.MAKITHI);
                        MessageBox.Show("Xóa kỳ thi thành công!", "Thông báo",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadKyThi();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Lỗi khi xóa: {ex.Message}", "Lỗi",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private string GenerateMaKyThi()
        {
            var allKyThi = _kyThiRepository.GetKITHIs();
            if (allKyThi == null || allKyThi.Count == 0)
            {
                return "KT001";
            }

            // Lấy số lớn nhất từ các mã hiện có
            int maxNumber = 0;
            foreach (var kt in allKyThi)
            {
                if (!string.IsNullOrEmpty(kt.MAKITHI) && kt.MAKITHI.StartsWith("KT"))
                {
                    string numberPart = kt.MAKITHI.Substring(2);
                    if (int.TryParse(numberPart, out int number))
                    {
                        if (number > maxNumber)
                            maxNumber = number;
                    }
                }
            }

            return $"KT{(maxNumber + 1).ToString("D3")}";
        }
    }
}
