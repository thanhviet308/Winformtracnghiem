using PhanMemThiTracNghiem.Forms.Admin;
using PhanMemThiTracNghiem.Forms.Admin.DeThi;
using PhanMemThiTracNghiem.Forms.Admin.KyThi;
using PhanMemThiTracNghiem.Forms.GiangVien;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhanMemThiTracNghiem
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmLogin());
        }
    }
}
