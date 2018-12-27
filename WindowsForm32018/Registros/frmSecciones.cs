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
    public partial class frmSecciones : Form
    {
        private static frmSecciones instancia;
        SeccionesMantenimiento mant;
        CarreraMantenimiento mantCarrera;
        AulasMantenimiento aulaMant;
        ProfesorMantenimiento mantProfe;
        AsignaturasMantenimiento mantAsignatura;
        Seccion objeto;
        Session session;

        public frmSecciones(int id, Session session)
        {           
            InitializeComponent();
            this.session = session;
            mant = new SeccionesMantenimiento(session);
            mantAsignatura = new AsignaturasMantenimiento(session);
            mantCarrera = new CarreraMantenimiento(session);
            aulaMant = new AulasMantenimiento(session);
            mantProfe = new ProfesorMantenimiento(session);

            objeto = new Seccion();
            if (id > 0)
            {
                objeto = mant.GetInfo(id); //busca los datos del formulario
                this.lblID.Text = id.ToString();
                updateFormulario();
            }

            llenarComboAula();
            llenarComboProfesor();
            llenarComboAsignatura();
        }

        void llenarComboAsignatura()
        {
            this.cbAsignatura.DataSource = mantAsignatura.GetListado(null);
            this.cbAsignatura.ValueMember = "ID";
            this.cbAsignatura.DisplayMember = "Descripcion";
        }

        void llenarComboProfesor()
        {
            this.cbProfesor.DataSource = mantProfe.GetListadoCombo(null);
            this.cbProfesor.ValueMember = "ID";
            this.cbProfesor.DisplayMember = "nombreCompleto";
        }

        void llenarComboAula()
        {
            this.cbAula.DataSource = aulaMant.GetListado(null);
            this.cbAula.ValueMember = "ID";
            this.cbAula.DisplayMember = "Codigo";
        }

        void updateFormulario()
        {
            objeto.ToString();
            this.cbAsignatura.SelectedValue = objeto.Asignatura.ToString();
            this.cbAula.SelectedValue = objeto.Aula.ToString();
            this.cbProfesor.SelectedValue = objeto.Profesor.ToString();
            this.nuCapacidad.Value = Convert.ToInt32(objeto.Capacidad.ToString());
            this.cbDia1.Text = objeto.Dia1.ToString();
            this.cbDia2.Text = objeto.Dia2.ToString();
            this.cbHora1.Text = objeto.Hora1.ToString();
            this.cbHora2.Text = objeto.Hora2.ToString();
            this.txtObservaciones.Text = objeto.Observaciones; 
        }

        private frmSecciones()
        {
            InitializeComponent();
            mant = new SeccionesMantenimiento(null);
        }

        public static frmSecciones getInstancia()
        {
            //patron de diseno singleton
            if (instancia == null || instancia.IsDisposed)
                instancia = new frmSecciones();

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
            objeto.Asignatura = Convert.ToInt32(this.cbAsignatura.SelectedValue);
            objeto.Aula = Convert.ToInt32(this.cbAula.SelectedValue);
            objeto.Profesor = Convert.ToInt32(this.cbProfesor.SelectedValue);
            objeto.Capacidad = Convert.ToInt32(this.nuCapacidad.Value);
            objeto.Dia1 = this.cbDia1.Text;
            objeto.Dia2 = this.cbDia2.Text;
            objeto.Hora1 = this.cbHora1.Text;
            objeto.Hora2 = this.cbHora2.Text;
            objeto.Observaciones = this.txtObservaciones.Text;
        }

        bool camposValidados()
        {
            errorProvider1.Clear(); //limpia los errores que existan.
            
            if (this.cbDia1.Text == "Seleccione")
            {
                this.cbDia1.Focus();
                MessageBox.Show("Seleccione un dia de la semana", "Advertencia",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return false;
            }

            if (this.cbHora1.Text == "Seleccione")
            {
                this.cbDia1.Focus();
                MessageBox.Show("Seleccione una hora del dia", "Advertencia",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return false;
            }

            if (this.nuCapacidad.Text == "0")
            {
                this.cbDia1.Focus();
                MessageBox.Show("Seleccione una capacidad para el aula", "Advertencia",
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

                int validaAulaDiaHora1 = mant.validaSeccion1(objeto.Aula, objeto.Hora1, objeto.Dia1);
                int validaAulaDiaHora2 = mant.validaSeccion2(objeto.Aula, objeto.Hora2, objeto.Dia2);
                int validaProfesor1 = mant.validaProfesor1(objeto.Profesor, objeto.Hora1, objeto.Dia1);
                int validaProfesor2 = mant.validaProfesor1(objeto.Profesor, objeto.Hora2, objeto.Dia2);

                if (validaAulaDiaHora1 == 0 && validaAulaDiaHora2 == 0)
                {

                    //VALIDA SI EL PROFESOR ESTA DISPONIBLE
                    if (validaProfesor1 == 0 && validaProfesor2 == 0)
                    {
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
                    else
                    {
                        MessageBox.Show("El profesor está ocupado en el horario que intento seleccionar ",
                                "Informacion",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.OK;
                    }



                }
                else {
                    MessageBox.Show("El aula seleccionada está ocupada en el horario que intento seleccionar ",
                                "Informacion",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                }                
            }

        }
    }
}
