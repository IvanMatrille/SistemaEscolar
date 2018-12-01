using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsForm32018.Clases;
using INF518Core;
using WindowsForm32018.Registros;
namespace WindowsForm32018
{
    public partial class frmConsultaEstudiantes : Form
    {
        Mantenimiento mant;
        DataTable dt;
        public frmConsultaEstudiantes()
        {
            mant = new Mantenimiento();
            
            InitializeComponent();
        }


        private void btBuscar_Click_1(object sender, EventArgs e)
        {
            string filtro = string.Empty;
            dt = new DataTable();
            dgvEstudiantes.DataSource = null;
            this.dgvEstudiantes.AutoGenerateColumns = false;

            if (!string.IsNullOrWhiteSpace(this.txtNombre.Text))
            {
                filtro = string.Format("AND (RTRIM(Nombre)+' '+RTRIM(Apellido)) LIKE '%{0}%'", this.txtNombre.Text);
            }


            dt = mant.GetListadoEstudiantes(buildFiltro());
            this.dgvEstudiantes.DataSource = dt;
            this.lbTotal.Text = dt.Rows.Count.ToString("#,###");
        }



        string buildFiltro()
        {

            StringBuilder filtro = new StringBuilder("ID>0");
            if (!string.IsNullOrWhiteSpace(this.txtNombre.Text))
            {
                filtro.AppendFormat("AND (Nombre+' '+Apellido) LIKE '%{0}%'", this.txtNombre.Text);
            }
            return filtro.ToString();
        }

        private void btModificar_Click(object sender, EventArgs e)
        {
            int id = 0;
            int.TryParse(dgvEstudiantes.CurrentRow.Cells["colID"].Value.ToString(), out id);

            if(id > 0)
            {
                frmEstudiantes frm = new frmEstudiantes(id);
                frm.StartPosition = FormStartPosition.CenterScreen;
                if (frm.ShowDialog()== DialogResult.OK)
                {
                    btBuscar_Click_1(sender, e);
                }
            }
        }

       

      
        private void dgvEstudiantes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btNuevo_Click(object sender, EventArgs e)
        {
            frmEstudiantes frm = new frmEstudiantes(0);
            frm.StartPosition = FormStartPosition.CenterScreen;

            if (frm.ShowDialog() == DialogResult.OK)
            {
                btBuscar_Click_1(sender, e);
            }
        }

        private void txtNombre_TextChanged(object sender , EventArgs e)
        {
            if (dt!=null && dt.Rows.Count>0)
            {
                this.dt.DefaultView.RowFilter = buildFiltro();
                this.lbTotal.Text = dt.DefaultView.Count.ToString("#,###");
            }
        }

     
    }
}
