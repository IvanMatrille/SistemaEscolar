using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsForm32018.Registros;
using INF518Core.Clases;

namespace WindowsForm32018
{
    public partial class MainForm : Form
    {
        
        Session session;
        MenuPrincipal menu;
        int tiempoSegundo = DateTime.Now.Second;
        int seg = 0;
        int min = 0;
        int hora = 0;
        public MainForm(Session session)
        {
            InitializeComponent();
            this.session = session; //la session enviada desde login
            if (!session.Permisos.Equals("*"))
            {
                menu = new MenuPrincipal(this.menuStrip1); //para manejar los permisos del menu
                menu.UpdateMenuItems(session.Permisos); //los permisos enviados desde login
            }
            this.tslUsuario.Text = session.Nombre; //el usuario asignado al label del status strip

            timer1.Start();
        }
       
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("¿Está seguro que desea salir del sistema?", "Advertencia",
                   MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
            {
                e.Cancel = true;
                return;
            }

        }

        private void salirToolStripMenuItem2_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void estudianteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            frmConsultaEstudiantes frm = new frmConsultaEstudiantes(session);
            frm.MdiParent = this;
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.Show();
            //this.estudianteToolStripMenuItem.Enabled = false;
        }

        private void profesorToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
            frmConsultaProfesores frm = new frmConsultaProfesores(session);
            frm.MdiParent = this;
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.Show();
            //this.estudianteToolStripMenuItem.Enabled = false;
        }

        private void dialogosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDialogos frm = new frmDialogos();
            frm.MdiParent = this;
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.Show();
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            if(this.WindowState == FormWindowState.Minimized)
            {
                this.notifyIcon1.Visible = true;
                notifyIcon1.ShowBalloonTip(3000);
                this.Hide(); //oculta el formulari principal
            }
            if(this.WindowState == FormWindowState.Normal 
                || this.WindowState == FormWindowState.Maximized)
            {
                this.notifyIcon1.Visible = false;
                this.Show(); //presenta el formulario principal
            }
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Show();
            this.notifyIcon1.Visible = false;
            this.WindowState = FormWindowState.Normal;
        }

        private void encriptarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEncriptar frm = new frmEncriptar();
            frm.MdiParent = this;
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.Show();
        }
       
        private void timer1_Tick(object sender, EventArgs e)
        {
            seg++;
           
            if(seg == 60)
            {
                seg = 0;
                min++;
            };

            if(min == 60)
            {
                min = 0;
                hora++;
            } 
            StringBuilder stb = new StringBuilder();                   
            this.tsRejoj.Text = stb.AppendFormat("{0:d2}:{1:d2}:{2:d2}", hora, min, seg).ToString();
        }

        private void centrosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmConsultaCentros frm = new frmConsultaCentros(session);
            frm.MdiParent = this;
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.Show();
        }

        private void aulasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmConsultaAulas frm = new frmConsultaAulas(session);
            frm.MdiParent = this;
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.Show();
        }

        private void carrerasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmConsultaCarreras frm = new frmConsultaCarreras(session);
            frm.MdiParent = this;
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.Show();

        }

        private void asignaturasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmConsultaAsignatura frm = new frmConsultaAsignatura(session);
            frm.MdiParent = this;
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.Show();
        }
    }
}
