using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using INF518Core.Clases;
using INF518Core;

namespace WindowsForm32018
{
    public partial class frmLogin : Form
    {
        Mantenimiento mant;
        public frmLogin()
        {
            InitializeComponent();
            Session = new Session();
            mant = new Mantenimiento(Session);
        }

        public Session Session { get; set; }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            Application.Exit();
        }

        private void chkVerContrasena_CheckedChanged(object sender, EventArgs e)
        {
            this.txtPassword.UseSystemPasswordChar =
                    !this.chkVerContrasena.Checked;
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            if (camposValidados())
            {
                this.Session = mant.GetSessionInfo(this.txtUsuario.Text.TrimEnd());
                string msg = "La combinación Usuario/Contraseña es incorrecta";
                if (Session.UsuarioID == 0)
                {
                    MessageBox.Show(msg, "Información", 
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if(!CryptorEngine.VerifyHash(this.txtPassword.Text, "SHA256", Session.Password))
                {
                    MessageBox.Show(msg, "Información", 
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            
        }

        bool camposValidados()
        {
            if(string.IsNullOrWhiteSpace(txtUsuario.Text))
            {
                MessageBox.Show("El usuario no puede estar en blanco.",
                                "Advertencia",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning
                    );
                this.txtUsuario.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("La contraseña no puede estar en blanco.",
                                "Advertencia",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning
                    );
                this.txtPassword.Focus();
                return false;
            }
            return true;
        }
    }
}
