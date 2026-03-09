using PhanMemThiTracNghiem.Services;
using PhanMemThiTracNghiem.Models;
using PhanMemThiTracNghiem.Data;
using PhanMemThiTracNghiem.Forms;
using ExcelDataReader;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace PhanMemThiTracNghiem.Forms.GiangVien
{
    public partial class frmImportCauHoi : Form
    {
        private readonly MonHocService _monHocService;
        private readonly AppDbContext _context;
        private NguoiDung _nguoiDung;
        private string _filePath;
        private DataTableCollection _tableCollection;
        private List<CauHoiImportDTO> _previewData;

        // Constructor mới - không cần file path
        public frmImportCauHoi(NguoiDung nguoiDung)
        {
            InitializeComponent();
            ThemeHelper.ApplyVietnameseFont(this);
            _monHocService = new MonHocService();
            _context = new AppDbContext();
            _nguoiDung = nguoiDung;

            LoadMonHoc();
            UpdateUI();
        }

        // Constructor cũ - tương thích ngược
        public frmImportCauHoi(NguoiDung nguoiDung, string filePath) : this(nguoiDung)
        {
            if (!string.IsNullOrEmpty(filePath))
            {
                _filePath = filePath;
                LoadExcelFile();
                UpdateUI();
            }
        }

        private void LoadMonHoc()
        {
            cboMonHoc.Items.Clear();
            var monHocs = _monHocService.GetThongTinMonThi();
            foreach (var mh in monHocs)
            {
                cboMonHoc.Items.Add(mh);
            }
            cboMonHoc.DisplayMember = "TenMon";
            cboMonHoc.ValueMember = "Id";

            if (monHocs.Count > 0)
                cboMonHoc.SelectedIndex = 0;
        }

        private void UpdateUI()
        {
            bool hasFile = !string.IsNullOrEmpty(_filePath);
            panelGuide.Visible = !hasFile;
            panelConfig.Visible = hasFile;
            panelPreview.Visible = hasFile;
            btnImport.Enabled = hasFile && _previewData != null && _previewData.Count > 0;
        }

        private void btnChonFile_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Excel Workbook|*.xlsx|Excel 97-2003 Workbook|*.xls";
                openFileDialog.Title = "Chọn file Excel chứa câu hỏi";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    _filePath = openFileDialog.FileName;
                    LoadExcelFile();
                    UpdateUI();
                }
            }
        }

        private void btnTaiFileMau_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "Excel Workbook|*.xlsx";
                saveFileDialog.FileName = "MauImportCauHoi.xlsx";
                saveFileDialog.Title = "Lưu file mẫu import câu hỏi";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                        using (var package = new ExcelPackage())
                        {
                            var ws = package.Workbook.Worksheets.Add("CauHoi");

                            // Header row
                            ws.Cells[1, 1].Value = "NDCAUHOI";
                            ws.Cells[1, 2].Value = "DAPAN1";
                            ws.Cells[1, 3].Value = "DAPAN2";
                            ws.Cells[1, 4].Value = "DAPAN3";
                            ws.Cells[1, 5].Value = "DAPAN4";
                            ws.Cells[1, 6].Value = "DAPANDUNG";

                            // Style header
                            using (var headerRange = ws.Cells[1, 1, 1, 6])
                            {
                                headerRange.Style.Font.Bold = true;
                                headerRange.Style.Font.Size = 12;
                                headerRange.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                                headerRange.Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.FromArgb(94, 148, 255));
                                headerRange.Style.Font.Color.SetColor(System.Drawing.Color.White);
                                headerRange.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                            }

                            // Sample data
                            ws.Cells[2, 1].Value = "Thủ đô của Việt Nam là gì?";
                            ws.Cells[2, 2].Value = "Hà Nội";
                            ws.Cells[2, 3].Value = "TP. Hồ Chí Minh";
                            ws.Cells[2, 4].Value = "Đà Nẵng";
                            ws.Cells[2, 5].Value = "Huế";
                            ws.Cells[2, 6].Value = "A";

                            ws.Cells[3, 1].Value = "1 + 1 = ?";
                            ws.Cells[3, 2].Value = "1";
                            ws.Cells[3, 3].Value = "2";
                            ws.Cells[3, 4].Value = "3";
                            ws.Cells[3, 5].Value = "4";
                            ws.Cells[3, 6].Value = "B";

                            ws.Cells[4, 1].Value = "Ngôn ngữ lập trình nào được dùng cho .NET?";
                            ws.Cells[4, 2].Value = "Java";
                            ws.Cells[4, 3].Value = "Python";
                            ws.Cells[4, 4].Value = "C#";
                            ws.Cells[4, 5].Value = "JavaScript";
                            ws.Cells[4, 6].Value = "C";

                            // Instruction sheet
                            var wsGuide = package.Workbook.Worksheets.Add("HuongDan");
                            wsGuide.Cells[1, 1].Value = "HƯỚNG DẪN IMPORT CÂU HỎI";
                            wsGuide.Cells[1, 1].Style.Font.Bold = true;
                            wsGuide.Cells[1, 1].Style.Font.Size = 16;

                            wsGuide.Cells[3, 1].Value = "Cột";
                            wsGuide.Cells[3, 2].Value = "Mô tả";
                            wsGuide.Cells[3, 3].Value = "Bắt buộc";
                            using (var hr = wsGuide.Cells[3, 1, 3, 3])
                            {
                                hr.Style.Font.Bold = true;
                                hr.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                                hr.Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.FromArgb(94, 148, 255));
                                hr.Style.Font.Color.SetColor(System.Drawing.Color.White);
                            }

                            wsGuide.Cells[4, 1].Value = "NDCAUHOI";
                            wsGuide.Cells[4, 2].Value = "Nội dung câu hỏi";
                            wsGuide.Cells[4, 3].Value = "Có";
                            wsGuide.Cells[5, 1].Value = "DAPAN1";
                            wsGuide.Cells[5, 2].Value = "Đáp án A";
                            wsGuide.Cells[5, 3].Value = "Có";
                            wsGuide.Cells[6, 1].Value = "DAPAN2";
                            wsGuide.Cells[6, 2].Value = "Đáp án B";
                            wsGuide.Cells[6, 3].Value = "Có";
                            wsGuide.Cells[7, 1].Value = "DAPAN3";
                            wsGuide.Cells[7, 2].Value = "Đáp án C";
                            wsGuide.Cells[7, 3].Value = "Có";
                            wsGuide.Cells[8, 1].Value = "DAPAN4";
                            wsGuide.Cells[8, 2].Value = "Đáp án D";
                            wsGuide.Cells[8, 3].Value = "Có";
                            wsGuide.Cells[9, 1].Value = "DAPANDUNG";
                            wsGuide.Cells[9, 2].Value = "Đáp án đúng (A, B, C hoặc D)";
                            wsGuide.Cells[9, 3].Value = "Có";

                            wsGuide.Cells[11, 1].Value = "LƯU Ý:";
                            wsGuide.Cells[11, 1].Style.Font.Bold = true;
                            wsGuide.Cells[11, 1].Style.Font.Color.SetColor(System.Drawing.Color.Red);
                            wsGuide.Cells[12, 1].Value = "1. Dữ liệu bắt đầu từ dòng 2 (dòng 1 là tiêu đề).";
                            wsGuide.Cells[13, 1].Value = "2. Cột DAPANDUNG nhập A, B, C hoặc D (viết hoa).";
                            wsGuide.Cells[14, 1].Value = "3. Không được để trống nội dung câu hỏi.";
                            wsGuide.Cells[15, 1].Value = "4. Mỗi câu hỏi phải có ít nhất 2 đáp án.";
                            wsGuide.Cells[16, 1].Value = "5. Nhập dữ liệu vào sheet \"CauHoi\".";

                            ws.Cells.AutoFitColumns();
                            wsGuide.Cells.AutoFitColumns();
                            wsGuide.Column(2).Width = 35;

                            package.SaveAs(new FileInfo(saveFileDialog.FileName));
                        }

                        var result = MessageBox.Show(
                            "Đã tạo file mẫu thành công!\nBạn có muốn mở file không?",
                            "Thành công", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                        if (result == DialogResult.Yes)
                        {
                            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                            {
                                FileName = saveFileDialog.FileName,
                                UseShellExecute = true
                            });
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi tạo file mẫu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void LoadExcelFile()
        {
            try
            {
                System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
                using (var stream = File.Open(_filePath, FileMode.Open, FileAccess.Read))
                {
                    using (IExcelDataReader reader = ExcelReaderFactory.CreateReader(stream))
                    {
                        DataSet result = reader.AsDataSet(new ExcelDataSetConfiguration()
                        {
                            ConfigureDataTable = (_) => new ExcelDataTableConfiguration() { UseHeaderRow = true }
                        });
                        _tableCollection = result.Tables;

                        cboSheet.Items.Clear();
                        foreach (DataTable table in _tableCollection)
                        {
                            cboSheet.Items.Add(table.TableName);
                        }

                        if (cboSheet.Items.Count > 0)
                            cboSheet.SelectedIndex = 0;
                    }
                }

                lblFilePath.Text = "📄 " + Path.GetFileName(_filePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi đọc file Excel: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cboSheet_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadPreviewData();
        }

        private void LoadPreviewData()
        {
            if (_tableCollection == null || cboSheet.SelectedItem == null) return;

            try
            {
                DataTable dt = _tableCollection[cboSheet.SelectedItem.ToString()];
                _previewData = new List<CauHoiImportDTO>();

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    var row = dt.Rows[i];
                    var cauHoi = new CauHoiImportDTO
                    {
                        STT = i + 1,
                        NoiDung = GetValue(row, "NDCAUHOI") ?? GetValue(row, "NoiDung") ?? GetValue(row, "CauHoi") ?? "",
                        DapAn1 = GetValue(row, "DAPAN1") ?? GetValue(row, "DapAnA") ?? "",
                        DapAn2 = GetValue(row, "DAPAN2") ?? GetValue(row, "DapAnB") ?? "",
                        DapAn3 = GetValue(row, "DAPAN3") ?? GetValue(row, "DapAnC") ?? "",
                        DapAn4 = GetValue(row, "DAPAN4") ?? GetValue(row, "DapAnD") ?? "",
                        DapAnDung = GetValue(row, "DAPANDUNG") ?? GetValue(row, "DapAnDung") ?? ""
                    };

                    if (!string.IsNullOrWhiteSpace(cauHoi.NoiDung))
                    {
                        _previewData.Add(cauHoi);
                    }
                }

                dgvPreview.Rows.Clear();
                foreach (var item in _previewData)
                {
                    int index = dgvPreview.Rows.Add();
                    dgvPreview.Rows[index].Cells["colSTT"].Value = item.STT;
                    dgvPreview.Rows[index].Cells["colNoiDung"].Value = item.NoiDung.Length > 50
                        ? item.NoiDung.Substring(0, 50) + "..."
                        : item.NoiDung;
                    dgvPreview.Rows[index].Cells["colDapAn1"].Value = item.DapAn1;
                    dgvPreview.Rows[index].Cells["colDapAn2"].Value = item.DapAn2;
                    dgvPreview.Rows[index].Cells["colDapAn3"].Value = item.DapAn3;
                    dgvPreview.Rows[index].Cells["colDapAn4"].Value = item.DapAn4;
                    dgvPreview.Rows[index].Cells["colDapAnDung"].Value = item.DapAnDung;
                }

                lblTongSo.Text = $"✅ Tổng số: {_previewData.Count} câu hỏi hợp lệ";
                btnImport.Enabled = _previewData.Count > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi đọc dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string GetValue(DataRow row, string columnName)
        {
            if (row.Table.Columns.Contains(columnName))
            {
                return row[columnName]?.ToString();
            }
            return null;
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            if (cboMonHoc.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn môn học!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (_previewData == null || _previewData.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để import!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var monHoc = (MonHoc)cboMonHoc.SelectedItem;
                int successCount = 0;
                int failCount = 0;

                progressBar.Maximum = _previewData.Count;
                progressBar.Value = 0;

                foreach (var item in _previewData)
                {
                    try
                    {
                        var cauHoi = new CauHoiThi
                        {
                            NoiDung = item.NoiDung,
                            MaMon = monHoc.Id,
                            NguoiTao = _nguoiDung.Id,
                            NgayTao = DateTime.Now,
                            TrangThai = true
                        };

                        _context.CauHoiThi.Add(cauHoi);
                        _context.SaveChanges();

                        var luaChons = new List<LuaChonTracNghiem>();
                        int thuTu = 1;

                        if (!string.IsNullOrWhiteSpace(item.DapAn1))
                        {
                            luaChons.Add(new LuaChonTracNghiem
                            {
                                MaCauHoi = cauHoi.Id,
                                NoiDung = item.DapAn1,
                                ThuTu = thuTu++,
                                LaDapAnDung = item.DapAnDung.Trim().Equals(item.DapAn1.Trim(), StringComparison.OrdinalIgnoreCase)
                                    || item.DapAnDung.Trim().ToUpper() == "A"
                            });
                        }

                        if (!string.IsNullOrWhiteSpace(item.DapAn2))
                        {
                            luaChons.Add(new LuaChonTracNghiem
                            {
                                MaCauHoi = cauHoi.Id,
                                NoiDung = item.DapAn2,
                                ThuTu = thuTu++,
                                LaDapAnDung = item.DapAnDung.Trim().Equals(item.DapAn2.Trim(), StringComparison.OrdinalIgnoreCase)
                                    || item.DapAnDung.Trim().ToUpper() == "B"
                            });
                        }

                        if (!string.IsNullOrWhiteSpace(item.DapAn3))
                        {
                            luaChons.Add(new LuaChonTracNghiem
                            {
                                MaCauHoi = cauHoi.Id,
                                NoiDung = item.DapAn3,
                                ThuTu = thuTu++,
                                LaDapAnDung = item.DapAnDung.Trim().Equals(item.DapAn3.Trim(), StringComparison.OrdinalIgnoreCase)
                                    || item.DapAnDung.Trim().ToUpper() == "C"
                            });
                        }

                        if (!string.IsNullOrWhiteSpace(item.DapAn4))
                        {
                            luaChons.Add(new LuaChonTracNghiem
                            {
                                MaCauHoi = cauHoi.Id,
                                NoiDung = item.DapAn4,
                                ThuTu = thuTu++,
                                LaDapAnDung = item.DapAnDung.Trim().Equals(item.DapAn4.Trim(), StringComparison.OrdinalIgnoreCase)
                                    || item.DapAnDung.Trim().ToUpper() == "D"
                            });
                        }

                        _context.LuaChonTracNghiem.AddRange(luaChons);
                        _context.SaveChanges();

                        successCount++;
                    }
                    catch
                    {
                        failCount++;
                    }

                    progressBar.Value++;
                    Application.DoEvents();
                }

                MessageBox.Show($"Import hoàn tất!\n✅ Thành công: {successCount}\n❌ Thất bại: {failCount}",
                    "Kết quả", MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (successCount > 0)
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi import: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnChonFileLai_Click(object sender, EventArgs e)
        {
            btnChonFile_Click(sender, e);
        }
    }

    public class CauHoiImportDTO
    {
        public int STT { get; set; }
        public string NoiDung { get; set; }
        public string DapAn1 { get; set; }
        public string DapAn2 { get; set; }
        public string DapAn3 { get; set; }
        public string DapAn4 { get; set; }
        public string DapAnDung { get; set; }
    }
}
