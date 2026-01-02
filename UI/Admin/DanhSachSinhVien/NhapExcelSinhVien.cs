using ExcelDataReader;
using PhanMemThiTracNghiem.BAL;
using PhanMemThiTracNghiem.DAL.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Migrations;

using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhanMemThiTracNghiem.UI.Admin.DanhSachSinhVien
{
    public partial class NhapExcelSinhVien : Form
    {
        private readonly DuLieuDAL duLieuDAL;
        private readonly SinhVienBAL sinhVienBAL;
        private readonly NguoiDungBAL nguoiDungBAL;
        frmAdmin frmadmin = new frmAdmin();
        
        public NhapExcelSinhVien(frmAdmin frm)
        {
            InitializeComponent();
            duLieuDAL = new DuLieuDAL();
            sinhVienBAL = new SinhVienBAL();
            nguoiDungBAL = new NguoiDungBAL();
            this.frmadmin = frm;
        }

        DataTableCollection tableCollection;

        private void btnOpen_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog() { Filter = "Excel Workbook| *.xlsx|Excel 97-2003 Workbook|*.xls" })
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    txtFileName.Text = openFileDialog.FileName;
                    using (var stream = File.Open(openFileDialog.FileName, FileMode.Open, FileAccess.Read))
                    {
                        using (IExcelDataReader reader = ExcelReaderFactory.CreateReader(stream))
                        {
                            DataSet result = reader.AsDataSet(new ExcelDataSetConfiguration()
                            {
                                ConfigureDataTable = (_) => new ExcelDataTableConfiguration() { UseHeaderRow = true }
                            });
                            tableCollection = result.Tables;
                            cboSheet.Items.Clear();
                            foreach (DataTable table in tableCollection)
                                cboSheet.Items.Add(table.TableName); //add sheet to combobox
                        }
                    }
                }
            }
        }

        public void cboSheet_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = tableCollection[cboSheet.SelectedItem.ToString()];
           
            if (dt != null)
            {
                List<NGUOIDUNG> listsinhVien = new List<NGUOIDUNG>();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    NGUOIDUNG sinhVien = new NGUOIDUNG();
                    sinhVien.TENTAIKHOAN = dt.Rows[i]["MASV"].ToString();
                    sinhVien.HOTEN = dt.Rows[i]["TENSV"].ToString();
                    sinhVien.NGAYSINH = DateTime.Parse(dt.Rows[i]["NGAYSINH"].ToString());
                    sinhVien.MATKHAU = dt.Rows[i]["MATKHAU"].ToString();
                    sinhVien.MAROLE = 3; // Role SinhVien
                    listsinhVien.Add(sinhVien);  
                }
                dgvThemExcelSinhVien.DataSource = listsinhVien;
            }
           

        }

        private void btnLuuDL_Click(object sender, EventArgs e)
        {
            DataTable dt = tableCollection[cboSheet.SelectedItem.ToString()];
            List<NGUOIDUNG> list = new List<NGUOIDUNG>();

            try
            {

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    NGUOIDUNG sinhvien = new NGUOIDUNG()
                    {
                        TENTAIKHOAN = dt.Rows[i]["MASV"].ToString(),
                        HOTEN = dt.Rows[i]["TENSV"].ToString(),
                        NGAYSINH = DateTime.Parse(dt.Rows[i]["NGAYSINH"].ToString()),
                        MATKHAU = dt.Rows[i]["MATKHAU"].ToString(),
                        MAROLE = 3 // Role SinhVien
                    };
                    list.Add(sinhvien);
                }
                foreach (var sinhvien in list)
                {
                    nguoiDungBAL.Add(sinhvien);
                    frmadmin.frmAdmin_Load(sender, e);
                }
                MessageBox.Show("Lưu thành công!");
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
