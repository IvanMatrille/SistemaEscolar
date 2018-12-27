using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsForm32018.Clases;
using INF518Core;
using INF518Core.Clases;
using INF518Core.Mantenimientos;

namespace WindowsForm32018.Registros
{
    public partial class frmInscripcion : Form
    {
        private static frmInscripcion instancia;
        Mantenimiento mant;
        SeccionesMantenimiento seccionMant;
        InscripcionMantenimiento inscripcionMant;
        Seccion objeto;
        Inscripcion inscripcion;
        Session session;
        Estudiante estudiante;
        DataTable dt;

        public frmInscripcion(int id, Session session)
        {
            InitializeComponent();
            this.session = session;
            mant = new Mantenimiento(session);
            inscripcionMant = new InscripcionMantenimiento(session);
            seccionMant = new SeccionesMantenimiento(session);
            objeto = new Seccion();
            inscripcion = new Inscripcion();
            estudiante = new Estudiante();
            if (id > 0)
            {
                objeto = seccionMant.GetInfo(id); //busca los datos del formulario
                this.lblID.Text = id.ToString();
            }
        }

        private void frmInscripcion_Load(object sender, EventArgs e)
        {
            dt = new DataTable(); //limpia el datatable
            dgvEstudiantes.DataSource = null; //limpia el datagridview
            this.dgvEstudiantes.AutoGenerateColumns = false; //las columnas no se toman del query directamente

            dt = seccionMant.GetListado(null); //carga los datos en el datable
            this.dgvEstudiantes.DataSource = dt; //asigna el datable al datagridview
        }

        private frmInscripcion()
        {
            InitializeComponent();
            mant = new Mantenimiento(null);
        }

        public static frmInscripcion getInstancia()
        {
            //patron de diseno singleton
            if (instancia == null || instancia.IsDisposed)
                instancia = new frmInscripcion();

            return instancia;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// Actualiza la clase de objeto desde los controles del formulario
        /// luego se envia a guardar para grabarlos e la BD
        /// </summary>


        private void button1_Click(object sender, EventArgs e)
        {
            Size size = new Size(334, 352);
            CancellationTokenSource tokenSource = new CancellationTokenSource();
            for (int i = 720; i >= 334; i--)
            {
                Task.Delay(0, tokenSource.Token);
                //int milliseconds = 1;
                //Thread.Sleep(milliseconds);
                size.Width = i;
                this.Size = size;
                //this.Refresh();
            }
        }

        private void btnInscribir_Click(object sender, EventArgs e)
        {
             
            int id = 0;
            int.TryParse(dgvEstudiantes.CurrentRow.Cells["colID"].Value.ToString(), out id);
            if (id > 0)
            {
                inscripcion.IDEstudiante = Convert.ToInt32(this.lblID.Text);
                inscripcion.IDSeccion = id;
                inscripcion.ID = 0;
                inscripcionMant.Guardar(inscripcion);

                if (inscripcionMant.Error.ID == 1)
                {
                    MessageBox.Show("Información Guardada Satisfactoriamente.",
                        "Información",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }

                else
                {
                    MessageBox.Show(inscripcionMant.Error.Descripcion);
                }
            }
        }


    }
}