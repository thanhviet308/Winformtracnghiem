using System;
using System.Windows.Forms;
using PhanMemThiTracNghiem.Models;
using PhanMemThiTracNghiem.Repositories;

namespace PhanMemThiTracNghiem.Forms.Admin
{
    public partial class frmThemKyThi : Form
    {
        private readonly KyThiRepository _kyThiRepository;

        public frmThemKyThi()
        {
            InitializeComponent();
            _kyThiRepository = new KyThiRepository();
        }

        private void frmThemKyThi_Load(object sender, EventArgs e)
        {
            ThemeHelper.ApplyVietnameseFont(this);
            txtMaKyThi.Text = GenerateMaKyThi();
            txtMaKyThi.Enabled = false;
            
            // Set default dates
            dtpBatDau.Value = DateTime.Now;
            dtpKetThuc.Value = DateTime.Now.AddDays(7);
        }

        private string GenerateMaKyThi()
        {
            var allKyThi = _kyThiRepository.GetKITHIs();
            if (allKyThi == null || allKyThi.Count == 0)
            {
                return "KT001";
            }

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

                var kyThi = new KITHI
                {
                    MAKITHI = txtMaKyThi.Text.Trim(),
                    TENKITHI = txtTenKyThi.Text.Trim(),
                    THOIGIANBDKITHI = dtpBatDau.Value,
                    THOIGIANKTKITHI = dtpKetThuc.Value
                };

                _kyThiRepository.Add(kyThi);
                MessageBox.Show("Thêm kỳ thi thành công!", "Thông báo",
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
