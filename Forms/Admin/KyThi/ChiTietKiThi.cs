using PhanMemThiTracNghiem.Data;
using PhanMemThiTracNghiem.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhanMemThiTracNghiem.Forms.Admin.KyThi
{
    public partial class frmChiTietKiThi: Form
    {
        private readonly AppDbContext AppDbContext;
        private string makithi;
        private string tenkithi;
        public frmChiTietKiThi(string makithi, string tenkithi)
        {
            InitializeComponent();
            this.makithi = makithi;
            this.tenkithi = tenkithi;  
            AppDbContext = new AppDbContext();    
        }

        private void frmChiTietKiThi_Load(object sender, EventArgs e)
        {
            cbMaKiThi.Items.Add(makithi);
            cbMaKiThi.SelectedIndex = 0;
            cbTenKiThi.Items.Add(tenkithi);
            cbTenKiThi.SelectedIndex = 0;
            List<CHITIETKYTHI> list = AppDbContext.CHITIETKYTHI.Where(p => p.MAKITHI == makithi).ToList();
            LoadDGVchitKiThi(list); 

        }


        private void LoadDGVchitKiThi(List<CHITIETKYTHI> list)
        {
             
            
            dgvChiTietKiThi.Rows.Clear();
            foreach (var item in list)
            {
                int index = dgvChiTietKiThi.Rows.Add();
                dgvChiTietKiThi.Rows[index].Cells["colMaKiThi"].Value = item.MAKITHI;
                dgvChiTietKiThi.Rows[index].Cells["colMaMonThi"].Value = item.MAMT;
                dgvChiTietKiThi.Rows[index].Cells["colMaSV"].Value = item.MASV;
                dgvChiTietKiThi.Rows[index].Cells["colDiem"].Value = item.DIEM;
                dgvChiTietKiThi.Rows[index].Cells["colThoiGianThi"].Value = (int)(item.THOIGIANTHI)/360 + " phút";
                dgvChiTietKiThi.Rows[index].Cells["colThoiGianBD"].Value = item.THOIGIANBD;
                dgvChiTietKiThi.Rows[index].Cells["colThoiGianKT"].Value = item.THOIGIANKT;
            }
        }

        private void dgvChiTietKiThi_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvChiTietKiThi.CurrentRow.Selected = true;
            /*  txtMaGiangVien.Text = dgvDanhSachGiangVien.Rows[e.RowIndex].Cells["MAGV"].FormattedValue.ToString();
              txtTenGiangVien.Text = dgvDanhSachGiangVien.Rows[e.RowIndex].Cells["TENGV"].FormattedValue.ToString();
              dtNgaySinhGiangVien.Value = DateTime.Parse(dgvDanhSachGiangVien.Rows[e.RowIndex].Cells["NGAYSINH"].FormattedValue.ToString());
              txtMatKhauGiangVien.Text = dgvDanhSachGiangVien.Rows[e.RowIndex].Cells["MATKHAU"].FormattedValue.ToString();*/
            float diem = float.Parse(dgvChiTietKiThi.Rows[e.RowIndex].Cells["colDiem"].FormattedValue.ToString());
            if (diem.ToString() != null)
            {
                MessageBox.Show("Kì thi này dã hoàn thành không th? s?a !!!");
            }
            else
            {
                    
            }
        }
    }
}
