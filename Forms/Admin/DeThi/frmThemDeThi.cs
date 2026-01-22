using PhanMemThiTracNghiem.Data;
using PhanMemThiTracNghiem.DTOs;
using PhanMemThiTracNghiem.Models;
using PhanMemThiTracNghiem.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace PhanMemThiTracNghiem.Forms.Admin.DeThi
{
    public partial class frmThemDeThi : Form
    {
        private readonly AppDbContext AppDbContext;
        public string MaDeThiMoi { get; private set; }

        public frmThemDeThi()
        {
            InitializeComponent();
            ThemeHelper.ApplyVietnameseFont(this);
            AppDbContext = new AppDbContext();
            LoadData();
        }

        private void LoadData()
        {
            // Load danh sách kỳ thi
            var listKyThi = AppDbContext.KyThi.ToList();
            cbKyThi.DataSource = listKyThi;
            cbKyThi.DisplayMember = "TenKyThi";
            cbKyThi.ValueMember = "Id";
            cbKyThi.SelectedIndex = -1;

            // Load danh sách môn học
            var listMonHoc = AppDbContext.MonHoc.ToList();
            cbMonThi.DataSource = listMonHoc;
            cbMonThi.DisplayMember = "TenMon";
            cbMonThi.ValueMember = "Id";
            cbMonThi.SelectedIndex = -1;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbKyThi.SelectedIndex < 0)
                {
                    MessageBox.Show("Vui lòng chọn kỳ thi!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (cbMonThi.SelectedIndex < 0)
                {
                    MessageBox.Show("Vui lòng chọn môn học!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Tạo ngân hàng đề mới
                var nganHangDe = new NganHangDe
                {
                    TenDe = $"Ngân hàng đề - {cbMonThi.Text}",
                    MaMon = Convert.ToInt64(cbMonThi.SelectedValue),
                    NgayTao = DateTime.Now
                };

                AppDbContext.NganHangDe.Add(nganHangDe);
                AppDbContext.SaveChanges();

                MaDeThiMoi = nganHangDe.Id.ToString();

                // Cập nhật kỳ thi để liên kết với ngân hàng đề
                long maKyThi = Convert.ToInt64(cbKyThi.SelectedValue);
                var kyThi = AppDbContext.KyThi.Find(maKyThi);
                if (kyThi != null)
                {
                    kyThi.MaNganHangDe = nganHangDe.Id;
                    AppDbContext.SaveChanges();
                }

                MessageBox.Show("Thêm ngân hàng đề thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
