using PhanMemThiTracNghiem.Data;
using ExcelDataReader;
using OfficeOpenXml;
using PhanMemThiTracNghiem.Services;
using PhanMemThiTracNghiem.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;

using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhanMemThiTracNghiem.Forms.Admin.DanhSachSinhVien
{
    public partial class NhapExcelSinhVien : Form
    {
        private readonly AppDbContext AppDbContext;
        private readonly SinhVienService SinhVienService;
        private readonly NguoiDungService NguoiDungService;
        frmAdmin frmadmin = new frmAdmin();
        
        public NhapExcelSinhVien(frmAdmin frm)
        {
            InitializeComponent();
            AppDbContext = new AppDbContext();
            SinhVienService = new SinhVienService();
            NguoiDungService = new NguoiDungService();
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
            if (tableCollection == null || cboSheet.SelectedItem == null) return;
            
            DataTable dt = tableCollection[cboSheet.SelectedItem.ToString()];
           
            if (dt != null)
            {
                List<NGUOIDUNG> listsinhVien = new List<NGUOIDUNG>();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    NGUOIDUNG sinhVien = new NGUOIDUNG();
                    sinhVien.EMAIL = dt.Rows[i]["EMAIL"]?.ToString() ?? "";
                    sinhVien.HOTEN = dt.Rows[i]["TENSV"]?.ToString() ?? "";
                    sinhVien.MATKHAU = PhanMemThiTracNghiem.Helpers.PasswordHelper.HashPassword(dt.Rows[i]["MATKHAU"]?.ToString() ?? "123456");
                    sinhVien.MAROLE = 3; // Role SinhVien
                    listsinhVien.Add(sinhVien);  
                }
                // Ch? hi?n th? các c?t c?n thi?t
                var displayList = listsinhVien.Select(x => new { Email = x.EMAIL, HoTen = x.HOTEN }).ToList();
                dgvThemExcelSinhVien.DataSource = null;
                dgvThemExcelSinhVien.DataSource = displayList;
            }
        }

        private void btnLuuDL_Click(object sender, EventArgs e)
        {
            if (tableCollection == null || cboSheet.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng ch?n file Excel và sheet tru?c!");
                return;
            }
            
            DataTable dt = tableCollection[cboSheet.SelectedItem.ToString()];
            List<NGUOIDUNG> list = new List<NGUOIDUNG>();

            try
            {

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    NGUOIDUNG sinhvien = new NGUOIDUNG()
                    {
                        EMAIL = dt.Rows[i]["EMAIL"].ToString(),
                        HOTEN = dt.Rows[i]["TENSV"].ToString(),
                        MATKHAU = PhanMemThiTracNghiem.Helpers.PasswordHelper.HashPassword(dt.Rows[i]["MATKHAU"].ToString()),
                        MAROLE = 3 // Role SinhVien
                    };
                    list.Add(sinhvien);
                }
                foreach (var sinhvien in list)
                {
                    NguoiDungService.Add(sinhvien);
                    frmadmin.frmAdmin_Load(sender, e);
                }
                MessageBox.Show("Luu thành công!");
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnTaiFileMau_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "Excel Workbook|*.xlsx";
                saveFileDialog.FileName = "MauNhapSinhVien.xlsx";
                saveFileDialog.Title = "Luu file m?u";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;
                        using (var package = new ExcelPackage())
                        {
                            var worksheet = package.Workbook.Worksheets.Add("DanhSachSinhVien");
                            
                            // Header
                            worksheet.Cells[1, 1].Value = "EMAIL";
                            worksheet.Cells[1, 2].Value = "TENSV";
                            worksheet.Cells[1, 3].Value = "MATKHAU";
                            
                            // Style header
                            using (var range = worksheet.Cells[1, 1, 1, 3])
                            {
                                range.Style.Font.Bold = true;
                                range.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                                range.Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.LightBlue);
                            }
                            
                            // D? li?u m?u
                            worksheet.Cells[2, 1].Value = "sinhvien1@gmail.com";
                            worksheet.Cells[2, 2].Value = "Nguy?n Van A";
                            worksheet.Cells[2, 3].Value = "123456";
                            
                            worksheet.Cells[3, 1].Value = "sinhvien2@gmail.com";
                            worksheet.Cells[3, 2].Value = "Tr?n Th? B";
                            worksheet.Cells[3, 3].Value = "123456";
                            
                            // Auto fit columns
                            worksheet.Cells.AutoFitColumns();
                            
                            // Save file
                            FileInfo fileInfo = new FileInfo(saveFileDialog.FileName);
                            package.SaveAs(fileInfo);
                            
                            MessageBox.Show("Ðã t?i file m?u thành công!\n\nHu?ng d?n:\n- EMAIL: Email dang nh?p\n- TENSV: H? và tên sinh viên\n- MATKHAU: M?t kh?u dang nh?p", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("L?i: " + ex.Message);
                    }
                }
            }
        }
    }
}
