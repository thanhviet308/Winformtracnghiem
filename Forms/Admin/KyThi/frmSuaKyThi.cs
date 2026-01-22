using System;
using System.Windows.Forms;
using PhanMemThiTracNghiem.Models;
using PhanMemThiTracNghiem.Repositories;

namespace PhanMemThiTracNghiem.Forms.Admin
{
    public partial class frmSuaKyThi : Form
    {
        private readonly KyThiRepository _kyThiRepository;
        private KITHI _kyThi;

        public frmSuaKyThi(KITHI kyThi)
        {
            InitializeComponent();
            _kyThiRepository = new KyThiRepository();
            _kyThi = kyThi;
        }

        private void frmSuaKyThi_Load(object sender, EventArgs e)
        {
            ThemeHelper.ApplyVietnameseFont(this);
            LoadKyThiInfo();
        }

        private void LoadKyThiInfo()
        {
            if (_kyThi != null)
            {
                txtMaKyThi.Text = _kyThi.MAKITHI;
                txtMaKyThi.Enabled = false; // Không cho sửa mã
                txtTenKyThi.Text = _kyThi.TENKITHI;
                
                if (_kyThi.THOIGIANBDKITHI.HasValue)
                    dtpBatDau.Value = _kyThi.THOIGIANBDKITHI.Value;
                    
                if (_kyThi.THOIGIANKTKITHI.HasValue)
                    dtpKetThuc.Value = _kyThi.THOIGIANKTKITHI.Value;
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtTenKyThi.Text))
                {
                    MessageBox.Show("Vui lòng nhập tên kỳ thi!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtTenKyThi.Focus();
                    return;
                }

                if (dtpKetThuc.Value <= dtpBatDau.Value)
                {
                    MessageBox.Show("Thời gian kết thúc phải sau thời gian bắt đầu!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    dtpKetThuc.Focus();
                    return;
                }

                _kyThi.TENKITHI = txtTenKyThi.Text.Trim();
                _kyThi.THOIGIANBDKITHI = dtpBatDau.Value;
                _kyThi.THOIGIANKTKITHI = dtpKetThuc.Value;

                _kyThiRepository.Update(_kyThi);
                MessageBox.Show("Cập nhật kỳ thi thành công!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
