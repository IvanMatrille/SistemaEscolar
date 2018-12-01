using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using INF518Core;
using INF518Core.Clases;
using WindowsForm32018.Clases;

namespace WindowsForm32018.Registros
{
    public partial class frmConsultaEstudiantes : Form
    {
        Mantenimiento mant;
        DataTable dt;
        Session session;
        public frmConsultaEstudiantes(Session session)
        {
            InitializeComponent();
            this.session = session;
            mant = new Mantenimiento(session);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            dt = new DataTable(); //limpia el datatable
            dgvEstudiantes.DataSource = null; //limpia el datagridview
            this.dgvEstudiantes.AutoGenerateColumns = false; //las columnas no se toman del query directamente

            dt = mant.GetListadoEstudiantes(buildFiltro()); //carga los datos en el datable
            this.dgvEstudiantes.DataSource = dt; //asigna el datable al datagridview
            this.lblTotal.Text = dt.Rows.Count.ToString("#,###"); //asigna la cantidad de filas al label
            
        }
        /// <summary>
        /// Retorna el filtro para las consultas
        /// </summary>
        /// <returns></returns>
        string buildFiltro()
        {
            StringBuilder filtro = new StringBuilder("ID>0 ");
            if (!string.IsNullOrWhiteSpace(this.txtNombre.Text))
            {
                filtro.AppendFormat("AND (Nombre+' '+Apellido) LIKE '%{0}%' ",
                                this.txtNombre.Text);
            }
            return filtro.ToString();
        }
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            frmEstudiantes frm = new frmEstudiantes(0, session);
            frm.StartPosition = FormStartPosition.CenterScreen;
            if(frm.ShowDialog()==DialogResult.OK)
            {
                btnBuscar_Click(sender, e);
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            int id = 0;
            int.TryParse(dgvEstudiantes.CurrentRow.Cells["colID"].Value.ToString(), out id);
            if (id > 0)
            {
                frmEstudiantes frm = new frmEstudiantes(id, session);
                frm.StartPosition = FormStartPosition.CenterScreen;
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    btnBuscar_Click(sender, e);
                }
            }
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
            if(dt!=null && dt.Rows.Count>0)
            {
                this.dt.DefaultView.RowFilter = buildFiltro();
                this.lblTotal.Text = dt.DefaultView.Count.ToString("#,###");
            }
        }
    }
}
