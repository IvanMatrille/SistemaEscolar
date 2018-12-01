using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsForm32018.Registros
{
    public partial class frmProfesor : Form
    {
        public frmProfesor()
        {
            InitializeComponent();
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            //MainForm frm = (MainForm)this.MdiParent;
            //frm.profesorToolStripMenuItem.Enabled = true;
            Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        public string Nombre
        {
            get { return this.txtNombre.Text; }
        }
    }
}
