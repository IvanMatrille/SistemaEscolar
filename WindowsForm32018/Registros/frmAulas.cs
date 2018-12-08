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
    public partial class frmAulas : Form
    {
        private static frmAulas instancia;
        AulasMantenimiento mant;
        CarreraMantenimiento carreraMant;
        CentrosMantenimiento centroMant;
        Aulas objeto;
        Session session;

        public frmAulas(int id, Session session)
        {
            
            InitializeComponent();
            this.session = session;
            mant = new AulasMantenimiento(session);
            centroMant = new CentrosMantenimiento(session);
            carreraMant = new CarreraMantenimiento(session);
            objeto = new Aulas();
            if (id > 0)
            {
                objeto = mant.GetInfo(id); //busca los datos del formulario
                this.lblID.Text = id.ToString();
                updateFormulario();
            }

            llenarComboTipoCentros();
        }

        void llenarComboTipoCentros()
        {
            this.cbCentro.DataSource = centroMant.GetListado(null);
            this.cbCentro.ValueMember = "ID";
            this.cbCentro.DisplayMember = "NombreCorto";
        }

        void updateFormulario()
        {
            objeto.ToString();
            this.txtDescripcion.Text = objeto.Descripcion;
            this.txtCodigo.Text = objeto.Codigo;
            this.nuCantidad.Text = objeto.Capacidad.ToString();
            this.cbCentro.Text = objeto.IDCentro.ToString();
            this.txtObservaciones.Text = objeto.Observaciones; 
        }

        private frmAulas()
        {
            InitializeComponent();
            mant = new AulasMantenimiento(null);
        }

        public static frmAulas getInstancia()
        {
            //patron de diseno singleton
            if (instancia == null || instancia.IsDisposed)
                instancia = new frmAulas();

            return instancia;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            
        }
        /// <summary>
        /// Actualiza la clase de objeto desde los controles del formulario
        /// luego se envia a guardar para grabarlos e la BD
        /// </summary>
        void updateClass()
        {
            objeto.Descripcion = this.txtDescripcion.Text;
            objeto.Codigo = this.txtCodigo.Text;
            objeto.Capacidad = Convert.ToInt32(this.nuCantidad.Value);
            objeto.IDCentro = Int32.Parse(this.cbCentro.SelectedValue.ToString());
            objeto.Observaciones = this.txtObservaciones.Text;

        }

        bool camposValidados()
        {
            errorProvider1.Clear(); //limpia los errores que existan.

            if (string.IsNullOrWhiteSpace(this.txtDescripcion.Text))
            {
                this.txtDescripcion.Focus();
                MessageBox.Show("No puede dejar el campos descripcion en blanco", "Advertencia",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(this.txtCodigo.Text))
            {
                this.txtDescripcion.Focus();
                MessageBox.Show("No puede dejar campos codigo en blanco", "Advertencia",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }


        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Size size = new Size(334, 352);
            CancellationTokenSource tokenSource = new CancellationTokenSource();
            for (int i=720; i>=334; i--)
            {
                Task.Delay(0, tokenSource.Token);
                //int milliseconds = 1;
                //Thread.Sleep(milliseconds);
                size.Width = i;
                this.Size = size;
                //this.Refresh();
            }            
        }

        private void btnAceptar_Click_1(object sender, EventArgs e)
        {

            if (camposValidados())
            {
                updateClass();
                mant.Guardar(this.objeto);
                if (mant.Error.ID == 1)
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
                    MessageBox.Show(mant.Error.Descripcion);
                }
            }

        }
    }
}
