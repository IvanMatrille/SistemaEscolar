using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsForm32018.Clases
{
    public static class Extensiones
    {
        public static string MensajeCampoVacio(this Control control)
        {
            return "El campo " + control.Name.Substring(3)
                                  + " No puede estar en blanco";
        }

        public static int WordCount(this String str)
        {
            return str.Split(new char[] { ' ', '.', '?' },
                             StringSplitOptions.RemoveEmptyEntries).Length;
        }
        public static void ShowMensajeVacio(this Control control)
        {
            if (control.IsNullOrWhiteSpace())
            {
                MessageBox.Show(control.MensajeCampoVacio(),
                                "Advertencia",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                control.Focus();
            }
        }
       
        public static bool IsNullOrWhiteSpace(this Control control)
        {
            return string.IsNullOrWhiteSpace(control.Text);
        }

        public static int GetSelectedColumnIntValue(this DataGridView dgv, string nombreColumna)
        {
            int valor = 0;
            int.TryParse(dgv.CurrentRow.Cells[nombreColumna].Value.ToString(), out valor);
            return valor;
        }
    }
}
