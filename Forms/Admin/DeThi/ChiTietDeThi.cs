using PhanMemThiTracNghiem.Data;
using PhanMemThiTracNghiem.Services;
using PhanMemThiTracNghiem.DTOs;
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

namespace PhanMemThiTracNghiem.Forms.Admin.DeThi
{
    public partial class ChiTietDeThi : Form
    {
        private readonly AppDbContext AppDbContext;
        private readonly CauHoiService CauHoiService;
        private string madethi;
        public ChiTietDeThi(string madethi)
        {
            this.madethi = madethi;
            InitializeComponent();
            AppDbContext = new AppDbContext();
            CauHoiService = new CauHoiService();
        }

        private void ChiTietDeThi_Load(object sender, EventArgs e)
        {
        
            List<MONTHI> listmonthi = AppDbContext.MONTHI.ToList();
            foreach (var item in listmonthi)
            {
                cbMonThi.Items.Add(item.TENMT);
                cbMonThi.SelectedIndex = 0; 
            }
            labelMaDeThi.Text = madethi;
            string tenmt = cbMonThi.Text.Trim();
            string mamt = "";
            List<MONTHI> listmonthi1 = AppDbContext.MONTHI.Where(p => p.TENMT == tenmt).ToList();
            foreach (var item in listmonthi1)
            {
                mamt = item.MAMT;
            }
            List<CAUHOI> listcauhoi = AppDbContext.CAUHOI.Where(p => p.MAMT == mamt).ToList();
          
            LoadDGVDeThi(listcauhoi);

       
            
      
        }

     

        private void cbMonThi_TextChanged(object sender, EventArgs e)
        {
           /* string tenmt = cbMonThi.Text.Trim();
            string mamt = "";
            List<MONTHI> listmonthi1 = AppDbContext.MONTHI.Where(p => p.TENMT == tenmt).ToList();
            foreach (var item in listmonthi1)
            {
                mamt = item.MAMT;
            }
            List<CAUHOI> listcauhoi = AppDbContext.CAUHOI.Where(p => p.MAMT == mamt).ToList();
            
            if (mamt == "")
            {
               ChiTietDeThi_Load(sender, e);
            }
            else
            {
                dgvCauHoiDeThi.DataSource = CauHoiService.FindName(mamt);
               
            }*/
        }

  
        private void btnThem_Click(object sender, EventArgs e)
        {
           
            List<CHITIETDETHI> list = new List<CHITIETDETHI>();

            try
            {

                for (int i = 0; i < dgvChiTDeThi.Rows.Count; i++)
                {
                    if (dgvChiTDeThi.Rows[i].Cells["colMaCauHoi"].Value != null)
                    {
                        CHITIETDETHI chiTietDeThi = new CHITIETDETHI();
                        chiTietDeThi.MADETHI = madethi;
                        chiTietDeThi.MACAUHOI = int.Parse(dgvChiTDeThi.Rows[i].Cells["colMaCauHoi"].Value.ToString());
                        chiTietDeThi.MUCDO = "1";
                        list.Add(chiTietDeThi);
                    }                       
                }
                foreach (var chitiet in list)
                {
                    AppDbContext.CHITIETDETHI.Add(chitiet);
                    AppDbContext.SaveChanges();
                 //   ChiTietDeThi_Load(sender, e);
                }
                MessageBox.Show("Luu thành công");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void LoadctDGVDeThi(List<CHITIETDETHI> listCT)
        {
            dgvChiTDeThi.Rows.Clear();
            foreach (var item in listCT)
            {
                int index = dgvChiTDeThi.Rows.Add();
                dgvChiTDeThi.Rows[index].Cells["colMaDeThi"].Value = item.MADETHI;
                dgvCauHoiDeThi.Rows[index].Cells["colMaCauHoi"].Value = item.MACAUHOI;
            }
        }

        private void LoadDGVDeThi(List<CAUHOI> listCauHOi)
        {
            dgvCauHoiDeThi.Rows.Clear();
            foreach (var item in listCauHOi)
            {
                int index = dgvCauHoiDeThi.Rows.Add();
                dgvCauHoiDeThi.Rows[index].Cells["colSTT"].Value = item.STT;
                dgvCauHoiDeThi.Rows[index].Cells["colMaCH"].Value = item.MACAUHOI;
                dgvCauHoiDeThi.Rows[index].Cells["colNoiDung"].Value = item.NDCAUHOI;
                dgvCauHoiDeThi.Rows[index].Cells["coldapan1"].Value = item.DAPAN1;
                dgvCauHoiDeThi.Rows[index].Cells["coldapan2"].Value = item.DAPAN2;
                dgvCauHoiDeThi.Rows[index].Cells["coldapan3"].Value = item.DAPAN3;
                dgvCauHoiDeThi.Rows[index].Cells["coldapan4"].Value = item.DAPAN4;
                dgvCauHoiDeThi.Rows[index].Cells["coldapandung"].Value = item.DAPANDUNG;
                dgvCauHoiDeThi.Rows[index].Cells["colMaGV"].Value = item.MAGV;
                dgvCauHoiDeThi.Rows[index].Cells["colMaMT"].Value = item.MAMT;  
                
            }
        }

        private void dgvCauHoiDeThi_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                dgvCauHoiDeThi.CurrentRow.Selected = true;
                if (dgvChiTDeThi.RowCount > 1)
                {
                    for (int i = 0; i < dgvChiTDeThi.RowCount; i++)
                    {
                        if (dgvChiTDeThi.Rows[i].Cells["colMaCauHoi"].Value != null)
                        // int mach = int.Parse(dgvChiTDeThi.Rows[i].Cells["colMaCauHoi"].ToString());
                            if (dgvChiTDeThi.Rows[i].Cells["colMaCauHoi"].Value.ToString() == dgvCauHoiDeThi.Rows[e.RowIndex].Cells["colMaCH"].Value.ToString())
                            {
                                MessageBox.Show("Mã câu h?i dã t?n t?i trong d? thi");
                                return;
                            }
                    }
                    int index = dgvChiTDeThi.Rows.Add();
                    dgvChiTDeThi.Rows[index].Cells["colMaDeThi"].Value = madethi;
                    dgvChiTDeThi.Rows[index].Cells["colMaCauHoi"].Value = dgvCauHoiDeThi.Rows[e.RowIndex].Cells["colMaCH"].FormattedValue.ToString();
                    return;
                }
                int index1 = dgvChiTDeThi.Rows.Add();
                dgvChiTDeThi.Rows[index1].Cells["colMaDeThi"].Value = madethi;
                dgvChiTDeThi.Rows[index1].Cells["colMaCauHoi"].Value = dgvCauHoiDeThi.Rows[e.RowIndex].Cells["colMaCH"].FormattedValue.ToString();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Looix",ex.Message);
            }    
        }

        private void dgvChiTDeThi_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
