using PhanMemThiTracNghiem.Data;
using PhanMemThiTracNghiem.DTOs;
using PhanMemThiTracNghiem.Repositories;
using System;
using System.Linq;
using System.Windows.Forms;

namespace PhanMemThiTracNghiem.Forms.Admin.DeThi
{
    public partial class frmThemMonThi : Form
    {
        private readonly AppDbContext AppDbContext;
        private readonly MonThiService MonThiService;

        public frmThemMonThi()
        {
            InitializeComponent();
            ThemeHelper.ApplyVietnameseFont(this);
            AppDbContext = new AppDbContext();
            MonThiService = new MonThiService();
        }

        private string GenerateMaMonThi()
        {
            int count = AppDbContext.MONTHI.Count();
            string newCode;
            do
            {
                count++;
                newCode = "MT" + count.ToString("D3");
            } while (AppDbContext.MONTHI.Any(m => m.MAMT == newCode));
            return newCode;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtTenMonThi.Text))
                {
                    MessageBox.Show("Vui lòng nhập tên môn thi!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                MonThiDTO monthi = new MonThiDTO();
                monthi.MaMT = GenerateMaMonThi();
                monthi.TenMT = txtTenMonThi.Text.Trim();
                MonThiService.InsertUpdate(monthi);

                MessageBox.Show("Thêm môn thi thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
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
