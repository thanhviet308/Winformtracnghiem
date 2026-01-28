using PhanMemThiTracNghiem.Models;
using PhanMemThiTracNghiem.Services;
using System;
using System.Windows.Forms;

namespace PhanMemThiTracNghiem.Forms.Admin.LopHoc
{
    public partial class frmSuaLopHoc : Form
    {
        private readonly LopHocService LopHocService;
        private readonly Models.LopHoc _lopHoc;

        public frmSuaLopHoc(Models.LopHoc lopHoc)
        {
            InitializeComponent();
            ThemeHelper.ApplyVietnameseFont(this);
            LopHocService = new LopHocService();
            _lopHoc = lopHoc;

            // Load dữ liệu
            txtTenLop.Text = lopHoc.TenLop;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtTenLop.Text))
                {
                    MessageBox.Show("Vui lòng nhập tên lớp học!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                _lopHoc.TenLop = txtTenLop.Text.Trim();

                if (LopHocService.Update(_lopHoc))
                {
                    MessageBox.Show("Cập nhật lớp học thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Không thể cập nhật lớp học!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
