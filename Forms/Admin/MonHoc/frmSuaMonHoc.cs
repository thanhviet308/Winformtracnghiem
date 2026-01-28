using PhanMemThiTracNghiem.Services;
using System;
using System.Windows.Forms;

namespace PhanMemThiTracNghiem.Forms.Admin.MonHoc
{
    public partial class frmSuaMonHoc : Form
    {
        private readonly MonHocService MonHocService;
        private readonly Models.MonHoc _monHoc;

        public frmSuaMonHoc(Models.MonHoc monHoc)
        {
            InitializeComponent();
            ThemeHelper.ApplyVietnameseFont(this);
            MonHocService = new MonHocService();
            _monHoc = monHoc;

            // Load dữ liệu
            txtTenMon.Text = monHoc.TenMon;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtTenMon.Text))
                {
                    MessageBox.Show("Vui lòng nhập tên môn học!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                _monHoc.TenMon = txtTenMon.Text.Trim();

                if (MonHocService.Update(_monHoc))
                {
                    MessageBox.Show("Cập nhật môn học thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Không thể cập nhật môn học!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
