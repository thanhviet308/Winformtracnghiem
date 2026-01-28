using PhanMemThiTracNghiem.Services;
using System;
using System.Windows.Forms;

namespace PhanMemThiTracNghiem.Forms.Admin.MonHoc
{
    public partial class frmThemMonHoc : Form
    {
        private readonly MonHocService MonHocService;

        public frmThemMonHoc()
        {
            InitializeComponent();
            ThemeHelper.ApplyVietnameseFont(this);
            MonHocService = new MonHocService();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtTenMon.Text))
                {
                    MessageBox.Show("Vui lòng nhập tên môn học!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var monHoc = new Models.MonHoc
                {
                    TenMon = txtTenMon.Text.Trim()
                };

                if (MonHocService.Add(monHoc))
                {
                    MessageBox.Show("Thêm môn học thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Không thể thêm môn học!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
