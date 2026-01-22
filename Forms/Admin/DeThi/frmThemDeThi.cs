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
            List<KITHI> listKiThi = AppDbContext.KITHI.ToList();
            cbKyThi.DataSource = listKiThi;
            cbKyThi.DisplayMember = "TENKITHI";
            cbKyThi.ValueMember = "MAKITHI";
            cbKyThi.SelectedIndex = -1;

            // Load danh sách môn thi
            List<MONTHI> listMonThi = AppDbContext.MONTHI.ToList();
            cbMonThi.DataSource = listMonThi;
            cbMonThi.DisplayMember = "TENMT";
            cbMonThi.ValueMember = "MAMT";
            cbMonThi.SelectedIndex = -1;
        }

        private string GenerateMaDeThi()
        {
            int count = AppDbContext.DETHI.Count();
            string newCode;
            do
            {
                count++;
                newCode = "DT" + count.ToString("D3");
            } while (AppDbContext.DETHI.Any(d => d.MADETHI == newCode));
            return newCode;
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
                    MessageBox.Show("Vui lòng chọn môn thi!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                MaDeThiMoi = GenerateMaDeThi();

                DeThiDTO dethi = new DeThiDTO();
                dethi.MaDeThi = MaDeThiMoi;
                dethi.MaKiThi = cbKyThi.SelectedValue.ToString();
                dethi.MaMonThi = cbMonThi.SelectedValue.ToString();
                DeThiService.InsertUpdate(dethi);

                MessageBox.Show("Thêm đề thi thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
