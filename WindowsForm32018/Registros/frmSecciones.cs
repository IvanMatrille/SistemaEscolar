﻿using System;
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
        AsignaturasMantenimiento mant;
        CarreraMantenimiento mantCarrera;
        AulasMantenimiento aulaMant;
        ProfesorMantenimiento mantProfe;
        Asignaturas objeto;
        Session session;

        public frmSecciones(int id, Session session)
        {           
            InitializeComponent();
            this.session = session;
            mant = new AsignaturasMantenimiento(session);
            mantCarrera = new CarreraMantenimiento(session);
            aulaMant = new AulasMantenimiento(session);
            mantProfe = new ProfesorMantenimiento(session);

            objeto = new Asignaturas();
            if (id > 0)
            {
                objeto = mant.GetInfo(id); //busca los datos del formulario
                this.lblID.Text = id.ToString();
                updateFormulario();
            }

            llenarComboAula();
            llenarComboProfesor();
        }

        void llenarComboProfesor()
        {
            this.cbProfesor.DataSource = mantProfe.GetListadoCombo(null);
            this.cbProfesor.ValueMember = "ID";
            this.cbProfesor.DisplayMember = "nombreCompleto ";
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

            this.cbAula.SelectedValue = objeto.IDCarrera.ToString();
            this.nuCapacidad.Value = Convert.ToInt32(objeto.Creditos.ToString());
            this.txtObservaciones.Text = objeto.Observaciones; 
        }

        private frmSecciones()
        {
            InitializeComponent();
            mant = new AsignaturasMantenimiento(null);
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
 
            objeto.Creditos = Convert.ToInt32(this.nuCapacidad.Value);
            objeto.IDCarrera = Int32.Parse(this.cbAula.SelectedValue.ToString());
            objeto.Observaciones = this.txtObservaciones.Text;
        }

        bool camposValidados()
        {
            errorProvider1.Clear(); //limpia los errores que existan.
            /*
            if (string.IsNullOrWhiteSpace(this.txtDescripcion.Text))
            {
                this.txtDescripcion.Focus();
                MessageBox.Show("No puede dejar el campos descripcion en blanco", "Advertencia",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return false;
            }

            */

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
