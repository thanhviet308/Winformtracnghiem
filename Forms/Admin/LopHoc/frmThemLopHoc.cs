using PhanMemThiTracNghiem.Models;
using PhanMemThiTracNghiem.Services;
using System;
using System.Windows.Forms;

namespace PhanMemThiTracNghiem.Forms.Admin.LopHoc
{
    public partial class frmThemLopHoc : Form
    {
        private readonly LopHocService LopHocService;

        public frmThemLopHoc()
        {
            InitializeComponent();
            ThemeHelper.ApplyVietnameseFont(this);
            LopHocService = new LopHocService();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtTenLop.Text))
                {
                    MessageBox.Show("Vui lòng nhập tên lớp học!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var lopHoc = new Models.LopHoc
                {
                    TenLop = txtTenLop.Text.Trim(),
                    NgayTao = DateTime.Now
                };

                if (LopHocService.Add(lopHoc))
                {
                    MessageBox.Show("Thêm lớp học thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Không thể thêm lớp học!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
