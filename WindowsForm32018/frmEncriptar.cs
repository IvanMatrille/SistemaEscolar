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

namespace WindowsForm32018
{
    public partial class frmEncriptar : Form
    {
        public frmEncriptar()
        {
            InitializeComponent();
            this.cbAlgoritmo.SelectedIndex = 0;
            this.cbAlgoritmo2.SelectedIndex = 0; 
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            
            this.txtHash.Text = CryptorEngine.ComputeHash(this.txtTextoPlano.Text, 
                this.cbAlgoritmo.Text, null);
        }

        private void btnVerificar_Click(object sender, EventArgs e)
        {
            if(CryptorEngine.VerifyHash(this.txtClave.Text, 
                this.cbAlgoritmo2.Text, 
                this.txtHashBD.Text))
            {
                MessageBox.Show("OK");
            }
        }

        private void btnEncriptar_Click(object sender, EventArgs e)
        {
            this.txtEncriptado.Text = CryptorEngine.Encrypt(this.txtTextPlano2.Text, true);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.txtPlano3.Text = CryptorEngine.Decrypt(this.txtEncriptado2.Text, true);
        }
    }
}
