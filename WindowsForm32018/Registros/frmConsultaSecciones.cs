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
using WindowsForm32018.Registros;
using INF518Core.Mantenimientos;

namespace WindowsForm32018.Registros
{
    public partial class frmConsultaSecciones : Form
    {
        SeccionesMantenimiento mant;
        DataTable dt;
        Session session;
        public frmConsultaSecciones(Session session)
        {
            InitializeComponent();
            this.session = session;
            mant = new SeccionesMantenimiento(session);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            dt = new DataTable(); //limpia el datatable
            dgvEstudiantes.DataSource = null; //limpia el datagridview
            this.dgvEstudiantes.AutoGenerateColumns = false; //las columnas no se toman del query directamente

            dt = mant.GetListado(buildFiltro()); //carga los datos en el datable
            this.dgvEstudiantes.DataSource = dt; //asigna el datable al datagridview
            this.lblTotal.Text = dt.Rows.Count.ToString("#,###"); //asigna la cantidad de filas al label
            
        }
        /// <summary>
        /// Retorna el filtro para las consultas
        /// </summary>
        /// <returns></returns>
        string buildFiltro()
        {
            StringBuilder filtro = new StringBuilder("s.ID>0 ");
            if (!string.IsNullOrWhiteSpace(this.txtNombre.Text))
            {
                filtro.AppendFormat("AND (s.IDProfesor+' '+a.Descripcion+' '+s.Dia1+' '+s.Dia2+' '+s.Hora1+' '+s.Hora2) LIKE '%{0}%' ",
                                this.txtNombre.Text);
            }
            return filtro.ToString();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            frmSecciones frm = new frmSecciones(0, session);
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
                frmSecciones frm = new frmSecciones(id, session);
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

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int id = 0;
            int.TryParse(dgvEstudiantes.CurrentRow.Cells["colID"].Value.ToString(), out id);
            if (id > 0 )
            {
                DialogResult dr = MessageBox.Show("Esta seguro que desea eliminar esta Seccion?",
                      "Advertencia", MessageBoxButtons.YesNo);
                switch (dr)
                {
                    case DialogResult.Yes:
                        mant.Eliminar(id);
                        break;
                    case DialogResult.No:
                        break;
                }
                               
            }
        }
    }
}
