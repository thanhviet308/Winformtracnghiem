using Guna.UI2.WinForms;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace PhanMemThiTracNghiem.Forms
{
    /// <summary>
    /// Theme Helper - Áp dụng style thống nhất cho phần mềm thi trắc nghiệm
    /// Phong cách: Modern, Clean, Professional - Education Theme
    /// </summary>
    public static class ThemeHelper
    {
        // ===== MAIN COLORS - Màu chủ đạo =====
        public static readonly Color PrimaryColor = Color.FromArgb(0, 122, 204);        // Xanh dương chính
        public static readonly Color PrimaryDarkColor = Color.FromArgb(0, 92, 158);     // Xanh dương đậm
        public static readonly Color SecondaryColor = Color.FromArgb(40, 167, 69);      // Xanh lá (Success)
        public static readonly Color DangerColor = Color.FromArgb(220, 53, 69);         // Đỏ (Danger)
        public static readonly Color WarningColor = Color.FromArgb(255, 193, 7);        // Vàng (Warning)
        public static readonly Color InfoColor = Color.FromArgb(23, 162, 184);          // Cyan (Info)
        
        // ===== BACKGROUND COLORS =====
        public static readonly Color BackgroundLight = Color.FromArgb(248, 249, 250);   // Nền sáng
        public static readonly Color BackgroundWhite = Color.White;                      // Trắng
        public static readonly Color BackgroundDark = Color.FromArgb(52, 58, 64);       // Nền tối
        public static readonly Color SidebarColor = Color.FromArgb(33, 37, 41);         // Sidebar đen
        
        // ===== TEXT COLORS =====
        public static readonly Color TextPrimary = Color.FromArgb(33, 37, 41);          // Text chính
        public static readonly Color TextSecondary = Color.FromArgb(108, 117, 125);     // Text phụ
        public static readonly Color TextLight = Color.White;                            // Text trắng
        
        // ===== BORDER =====
        public static readonly Color BorderColor = Color.FromArgb(206, 212, 218);
        public static readonly int BorderRadius = 8;
        public static readonly int BorderThickness = 1;

        // ===== FONT NAME - Font hỗ trợ tiếng Việt Unicode =====
        public static readonly string FontFamily = "Segoe UI";

        // ===== FONTS =====
        public static readonly Font FontTitle = new Font(FontFamily, 18F, FontStyle.Bold);
        public static readonly Font FontSubtitle = new Font(FontFamily, 14F, FontStyle.Bold);
        public static readonly Font FontNormal = new Font(FontFamily, 11F, FontStyle.Regular);
        public static readonly Font FontSmall = new Font(FontFamily, 9F, FontStyle.Regular);
        public static readonly Font FontButton = new Font(FontFamily, 10F, FontStyle.Bold);
        public static readonly Font FontLarge = new Font(FontFamily, 16F, FontStyle.Bold);

        // ===== FONTS KHÔNG HỖ TRỢ TIẾNG VIỆT TỐT =====
        private static readonly string[] UnsupportedFonts = new string[]
        {
            "Microsoft Sans Serif",
            "Sitka Subheading",
            "Sitka Text",
            "Sitka Display",
            "Sitka Heading",
            "Sitka Banner",
            "Cambria",
            "Cambria Math"
        };

        /// <summary>
        /// Kiểm tra font có hỗ trợ tiếng Việt không
        /// </summary>
        private static bool IsUnsupportedFont(string fontName)
        {
            foreach (var unsupported in UnsupportedFonts)
            {
                if (fontName.Equals(unsupported, StringComparison.OrdinalIgnoreCase))
                    return true;
            }
            return false;
        }

        /// <summary>
        /// Tạo font mới với font family hỗ trợ tiếng Việt, giữ nguyên size và style
        /// </summary>
        private static Font CreateVietnameseFont(Font originalFont)
        {
            if (originalFont == null) return FontNormal;
            return new Font(FontFamily, originalFont.Size, originalFont.Style);
        }

        /// <summary>
        /// Áp dụng theme cho toàn bộ Form
        /// </summary>
        public static void ApplyTheme(Form form)
        {
            form.BackColor = BackgroundLight;
            form.Font = FontNormal;
            
            // Áp dụng style cho tất cả controls trong form
            ApplyThemeToControls(form.Controls);
        }

        /// <summary>
        /// Chỉ sửa font tiếng Việt cho Form (không thay đổi style/theme)
        /// Sử dụng method này nếu không muốn thay đổi màu sắc
        /// </summary>
        public static void ApplyVietnameseFont(Form form)
        {
            if (form.Font != null && IsUnsupportedFont(form.Font.Name))
            {
                form.Font = CreateVietnameseFont(form.Font);
            }
            ApplyVietnameseFontToControls(form.Controls);
        }

        /// <summary>
        /// Chỉ sửa font tiếng Việt cho UserControl (không thay đổi style/theme)
        /// </summary>
        public static void ApplyVietnameseFont(UserControl userControl)
        {
            if (userControl.Font != null && IsUnsupportedFont(userControl.Font.Name))
            {
                userControl.Font = CreateVietnameseFont(userControl.Font);
            }
            ApplyVietnameseFontToControls(userControl.Controls);
        }

        /// <summary>
        /// Áp dụng font tiếng Việt đệ quy cho tất cả controls (không thay đổi style)
        /// </summary>
        private static void ApplyVietnameseFontToControls(Control.ControlCollection controls)
        {
            foreach (Control control in controls)
            {
                // Kiểm tra và thay thế font không hỗ trợ tiếng Việt
                if (control.Font != null && IsUnsupportedFont(control.Font.Name))
                {
                    control.Font = CreateVietnameseFont(control.Font);
                }

                // Xử lý đặc biệt cho Guna2DataGridView
                if (control is Guna2DataGridView dgv)
                {
                    FixDataGridViewFont(dgv);
                }

                // Đệ quy cho các controls con
                if (control.HasChildren)
                {
                    ApplyVietnameseFontToControls(control.Controls);
                }
            }
        }

        /// <summary>
        /// Sửa font cho DataGridView
        /// </summary>
        private static void FixDataGridViewFont(Guna2DataGridView dgv)
        {
            var headerFont = dgv.ThemeStyle.HeaderStyle.Font;
            if (headerFont != null && IsUnsupportedFont(headerFont.Name))
            {
                dgv.ThemeStyle.HeaderStyle.Font = CreateVietnameseFont(headerFont);
            }

            var rowFont = dgv.ThemeStyle.RowsStyle.Font;
            if (rowFont != null && IsUnsupportedFont(rowFont.Name))
            {
                dgv.ThemeStyle.RowsStyle.Font = CreateVietnameseFont(rowFont);
            }

            var altRowFont = dgv.ThemeStyle.AlternatingRowsStyle.Font;
            if (altRowFont != null && IsUnsupportedFont(altRowFont.Name))
            {
                dgv.ThemeStyle.AlternatingRowsStyle.Font = CreateVietnameseFont(altRowFont);
            }

            // Fix ColumnHeadersDefaultCellStyle
            if (dgv.ColumnHeadersDefaultCellStyle?.Font != null && 
                IsUnsupportedFont(dgv.ColumnHeadersDefaultCellStyle.Font.Name))
            {
                dgv.ColumnHeadersDefaultCellStyle.Font = CreateVietnameseFont(dgv.ColumnHeadersDefaultCellStyle.Font);
            }

            // Fix DefaultCellStyle
            if (dgv.DefaultCellStyle?.Font != null && 
                IsUnsupportedFont(dgv.DefaultCellStyle.Font.Name))
            {
                dgv.DefaultCellStyle.Font = CreateVietnameseFont(dgv.DefaultCellStyle.Font);
            }
        }

        /// <summary>
        /// Áp dụng theme đệ quy cho tất cả controls
        /// </summary>
        private static void ApplyThemeToControls(Control.ControlCollection controls)
        {
            foreach (Control control in controls)
            {
                // Kiểm tra và thay thế font không hỗ trợ tiếng Việt trước
                if (control.Font != null && IsUnsupportedFont(control.Font.Name))
                {
                    control.Font = CreateVietnameseFont(control.Font);
                }

                // Guna2Button - Primary
                if (control is Guna2Button btn)
                {
                    ApplyPrimaryButtonStyle(btn);
                }
                // Guna2TextBox
                else if (control is Guna2TextBox txt)
                {
                    ApplyTextBoxStyle(txt);
                }
                // Guna2ComboBox
                else if (control is Guna2ComboBox cmb)
                {
                    ApplyComboBoxStyle(cmb);
                }
                // Guna2DataGridView
                else if (control is Guna2DataGridView dgv)
                {
                    ApplyDataGridViewStyle(dgv);
                    FixDataGridViewFont(dgv);
                }
                // Guna2Panel
                else if (control is Guna2Panel pnl)
                {
                    ApplyPanelStyle(pnl);
                }
                // Guna2TabControl
                else if (control is Guna2TabControl tab)
                {
                    ApplyTabControlStyle(tab);
                }
                // Label
                else if (control is Label lbl)
                {
                    ApplyLabelStyle(lbl);
                }
                // Panel
                else if (control is Panel panel)
                {
                    panel.BackColor = BackgroundWhite;
                }

                // Đệ quy cho các controls con
                if (control.HasChildren)
                {
                    ApplyThemeToControls(control.Controls);
                }
            }
        }

        /// <summary>
        /// Style cho Button chính (Primary)
        /// </summary>
        public static void ApplyPrimaryButtonStyle(Guna2Button btn)
        {
            btn.FillColor = PrimaryColor;
            btn.ForeColor = TextLight;
            btn.Font = FontButton;
            btn.BorderRadius = BorderRadius;
            btn.BorderThickness = 0;
            btn.HoverState.FillColor = PrimaryDarkColor;
            btn.HoverState.ForeColor = TextLight;
            btn.Cursor = Cursors.Hand;
        }

        /// <summary>
        /// Style cho Button thành công (Success)
        /// </summary>
        public static void ApplySuccessButtonStyle(Guna2Button btn)
        {
            btn.FillColor = SecondaryColor;
            btn.ForeColor = TextLight;
            btn.Font = FontButton;
            btn.BorderRadius = BorderRadius;
            btn.BorderThickness = 0;
            btn.HoverState.FillColor = Color.FromArgb(33, 136, 56);
            btn.HoverState.ForeColor = TextLight;
            btn.Cursor = Cursors.Hand;
        }

        /// <summary>
        /// Style cho Button nguy hiểm (Danger)
        /// </summary>
        public static void ApplyDangerButtonStyle(Guna2Button btn)
        {
            btn.FillColor = DangerColor;
            btn.ForeColor = TextLight;
            btn.Font = FontButton;
            btn.BorderRadius = BorderRadius;
            btn.BorderThickness = 0;
            btn.HoverState.FillColor = Color.FromArgb(185, 43, 56);
            btn.HoverState.ForeColor = TextLight;
            btn.Cursor = Cursors.Hand;
        }

        /// <summary>
        /// Style cho Button cảnh báo (Warning)
        /// </summary>
        public static void ApplyWarningButtonStyle(Guna2Button btn)
        {
            btn.FillColor = WarningColor;
            btn.ForeColor = TextPrimary;
            btn.Font = FontButton;
            btn.BorderRadius = BorderRadius;
            btn.BorderThickness = 0;
            btn.HoverState.FillColor = Color.FromArgb(224, 168, 0);
            btn.HoverState.ForeColor = TextPrimary;
            btn.Cursor = Cursors.Hand;
        }

        /// <summary>
        /// Style cho TextBox
        /// </summary>
        public static void ApplyTextBoxStyle(Guna2TextBox txt)
        {
            txt.BorderRadius = BorderRadius;
            txt.BorderColor = BorderColor;
            txt.BorderThickness = BorderThickness;
            txt.FillColor = BackgroundWhite;
            txt.ForeColor = TextPrimary;
            txt.Font = FontNormal;
            txt.FocusedState.BorderColor = PrimaryColor;
            txt.HoverState.BorderColor = PrimaryColor;
            txt.PlaceholderForeColor = TextSecondary;
        }

        /// <summary>
        /// Style cho ComboBox
        /// </summary>
        public static void ApplyComboBoxStyle(Guna2ComboBox cmb)
        {
            cmb.BorderRadius = BorderRadius;
            cmb.BorderColor = BorderColor;
            cmb.BorderThickness = BorderThickness;
            cmb.FillColor = BackgroundWhite;
            cmb.ForeColor = TextPrimary;
            cmb.Font = FontNormal;
            cmb.FocusedState.BorderColor = PrimaryColor;
            cmb.HoverState.BorderColor = PrimaryColor;
        }

        /// <summary>
        /// Style cho DataGridView
        /// </summary>
        public static void ApplyDataGridViewStyle(Guna2DataGridView dgv)
        {
            // Theme chung
            dgv.ThemeStyle.BackColor = BackgroundWhite;
            dgv.ThemeStyle.GridColor = BorderColor;
            dgv.BorderStyle = BorderStyle.None;
            
            // Header style
            dgv.ThemeStyle.HeaderStyle.BackColor = PrimaryColor;
            dgv.ThemeStyle.HeaderStyle.ForeColor = TextLight;
            dgv.ThemeStyle.HeaderStyle.Font = FontButton;
            dgv.ColumnHeadersHeight = 40;
            dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            
            // Row style
            dgv.ThemeStyle.RowsStyle.BackColor = BackgroundWhite;
            dgv.ThemeStyle.RowsStyle.ForeColor = TextPrimary;
            dgv.ThemeStyle.RowsStyle.Font = FontNormal;
            dgv.ThemeStyle.RowsStyle.SelectionBackColor = Color.FromArgb(200, 220, 240);
            dgv.ThemeStyle.RowsStyle.SelectionForeColor = TextPrimary;
            dgv.RowTemplate.Height = 35;
            
            // Alternating row style
            dgv.ThemeStyle.AlternatingRowsStyle.BackColor = BackgroundLight;
            dgv.ThemeStyle.AlternatingRowsStyle.ForeColor = TextPrimary;
            dgv.ThemeStyle.AlternatingRowsStyle.Font = FontNormal;
            dgv.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = Color.FromArgb(200, 220, 240);
            dgv.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = TextPrimary;

            // Other settings
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToDeleteRows = false;
            dgv.ReadOnly = true;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        /// <summary>
        /// Style cho Panel
        /// </summary>
        public static void ApplyPanelStyle(Guna2Panel pnl)
        {
            pnl.BorderRadius = BorderRadius;
            pnl.FillColor = BackgroundWhite;
            pnl.BorderColor = BorderColor;
            pnl.BorderThickness = 0;
        }

        /// <summary>
        /// Style cho Panel có viền
        /// </summary>
        public static void ApplyPanelWithBorderStyle(Guna2Panel pnl)
        {
            pnl.BorderRadius = BorderRadius;
            pnl.FillColor = BackgroundWhite;
            pnl.BorderColor = BorderColor;
            pnl.BorderThickness = BorderThickness;
        }

        /// <summary>
        /// Style cho Panel Sidebar
        /// </summary>
        public static void ApplySidebarPanelStyle(Guna2Panel pnl)
        {
            pnl.BorderRadius = 0;
            pnl.FillColor = SidebarColor;
            pnl.BorderThickness = 0;
        }

        /// <summary>
        /// Style cho TabControl
        /// </summary>
        public static void ApplyTabControlStyle(Guna2TabControl tab)
        {
            tab.TabButtonHoverState.FillColor = Color.FromArgb(240, 240, 240);
            tab.TabButtonHoverState.ForeColor = PrimaryColor;
            tab.TabButtonSelectedState.FillColor = PrimaryColor;
            tab.TabButtonSelectedState.ForeColor = TextLight;
            tab.TabButtonIdleState.FillColor = BackgroundLight;
            tab.TabButtonIdleState.ForeColor = TextPrimary;
            tab.TabButtonSize = new Size(180, 45);
            tab.ItemSize = new Size(180, 45);
        }

        /// <summary>
        /// Style cho Label
        /// </summary>
        public static void ApplyLabelStyle(Label lbl)
        {
            lbl.ForeColor = TextPrimary;
            lbl.Font = FontNormal;
            lbl.BackColor = Color.Transparent;
        }

        /// <summary>
        /// Style cho Label tiêu đề
        /// </summary>
        public static void ApplyTitleLabelStyle(Label lbl)
        {
            lbl.ForeColor = PrimaryColor;
            lbl.Font = FontTitle;
            lbl.BackColor = Color.Transparent;
        }

        /// <summary>
        /// Style cho Label phụ đề
        /// </summary>
        public static void ApplySubtitleLabelStyle(Label lbl)
        {
            lbl.ForeColor = TextPrimary;
            lbl.Font = FontSubtitle;
            lbl.BackColor = Color.Transparent;
        }

        /// <summary>
        /// Style cho DateTimePicker
        /// </summary>
        public static void ApplyDateTimePickerStyle(Guna2DateTimePicker dtp)
        {
            dtp.BorderRadius = BorderRadius;
            dtp.BorderColor = BorderColor;
            dtp.BorderThickness = BorderThickness;
            dtp.FillColor = BackgroundWhite;
            dtp.ForeColor = TextPrimary;
            dtp.Font = FontNormal;
        }

        /// <summary>
        /// Tạo hiệu ứng shadow cho Panel
        /// </summary>
        public static void ApplyShadowEffect(Guna2Panel pnl)
        {
            pnl.ShadowDecoration.Enabled = true;
            pnl.ShadowDecoration.Color = Color.Black;
            pnl.ShadowDecoration.Depth = 20;
            pnl.ShadowDecoration.BorderRadius = BorderRadius;
        }
    }
}
