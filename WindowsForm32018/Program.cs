using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using INF518Core.Clases;

namespace WindowsForm32018
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            frmLogin frm = new frmLogin();
            frm.StartPosition = FormStartPosition.CenterScreen;
            Application.Run(frm);
            if (frm.DialogResult == DialogResult.OK)
            {
                Session session = frm.Session;
                frm.Dispose();
                Application.Run(new MainForm(session));
            }
        }
    }
}
