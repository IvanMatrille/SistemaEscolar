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
    public partial class frmEstudiantes : Form
    {
        private static frmEstudiantes instancia;
        Mantenimiento mant;
        TipoEstudianteMant tipoEst;
        CarreraMantenimiento carreraMant;
        Estudiante estudiante;
        Session session;

        public frmEstudiantes(int id, Session session)
        {
            
            InitializeComponent();
            this.session = session;
            mant = new Mantenimiento(session);
            tipoEst = new TipoEstudianteMant(session);
            carreraMant = new CarreraMantenimiento(session);
            estudiante = new Estudiante();
            if (id > 0)
            {
                estudiante = mant.GetEstudianteInfo(id); //busca los datos del formulario
                this.lblID.Text = id.ToString();
                updateFormulario();
            }

            llenarComboTipoEstudiante();
            llenarComboSexo();
            llenarComboCarreras();
        }

        void llenarComboTipoEstudiante()
        {
            this.cbTipoEstudiante.DataSource = tipoEst.GetTiposEstudiantes();
            this.cbTipoEstudiante.ValueMember = "ID";
            this.cbTipoEstudiante.DisplayMember = "Descripcion";            
        }

        void llenarComboCarreras()
        {
            this.cbCarrera.DataSource = carreraMant.GetListadoCarreras();
            this.cbCarrera.ValueMember = "ID";
            this.cbCarrera.DisplayMember = "Descripcion"; 
        }
        void llenarComboSexo()
        {
            cbSexo.Items.Add("M");
            cbSexo.Items.Add("F");
        }

        void updateFormulario()
        {
            this.txtNombre.Text = estudiante.Nombre;
            this.txtApellido.Text = estudiante.Apellido;
            this.dtpFechaNacimiento.Value = estudiante.FechaNacimiento;
            
        }
        private frmEstudiantes()
        {
            InitializeComponent();
            mant = new Mantenimiento(null);
        }
        public static frmEstudiantes getInstancia()
        {
            //patron de diseno singleton
            if (instancia == null || instancia.IsDisposed)
                instancia = new frmEstudiantes();

            return instancia;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            
        }
        /// <summary>
        /// Actualiza la clase de estudiante desde los controles del formulario
        /// luego se envia a guardar para grabarlos e la BD
        /// </summary>
        void updateEstudianteClass()
        {
            estudiante.Nombre = this.txtNombre.Text;
            estudiante.Apellido = this.txtApellido.Text;
            estudiante.FechaNacimiento = this.dtpFechaNacimiento.Value;
            estudiante.Cedula = this.txtCedula.Text;
            estudiante.Email = this.txtEmail.Text;
            estudiante.EstadoCivil = this.cbEstadoCivil.Text;
            estudiante.IdTipoEstudiante = Int32.Parse(this.cbTipoEstudiante.SelectedValue.ToString());
            estudiante.Sexo = this.cbSexo.Text;
            estudiante.Observaciones = this.txtObservaciones.Text;
            estudiante.TelefonoCasa = this.txtTelefono.Text;
            estudiante.TelefonoMovil = this.txtCelular.Text;
            estudiante.IDCarrera = Int32.Parse(this.cbCarrera.SelectedValue.ToString());

        }
        bool camposValidados()
        {
            errorProvider1.Clear(); //limpia los errores que existan.
            
            if (string.IsNullOrWhiteSpace(this.txtNombre.Text) && string.IsNullOrWhiteSpace(this.txtApellido.Text)
                && string.IsNullOrWhiteSpace(this.txtCedula.Text))
            {
                this.txtApellido.Focus();
                MessageBox.Show("No puede dejar campos en blanco", "Advertencia",
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
                updateEstudianteClass();
                mant.GuardarEstudiante(this.estudiante);
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
