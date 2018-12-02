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
using WindowsForm32018.Clases;

namespace WindowsForm32018
{
    public partial class frmDialogos : Form
    {
        Mantenimiento mant;
        public frmDialogos()
        {
            InitializeComponent();
            linkLabel1.Links.Add(11, 4, "http://UASD.EDU.DO");
            linkLabel1.Links.Add(20, 4, "http://www.amazon.com");
            //Visitar la UASD la UCNE para los diplomados.

            //linkLabel1_LinkClicked
            mant = new Mantenimiento(null);
            LLenarComboBoxOcupaciones();
            LlenarComboBoxManual();
            LlenarComboBox3Manual();
        }

        void LlenarComboBox3Manual()
        {
            Persona[] p = new Persona[3];
            p[0] = new Persona() { Nombre = "Nelson", Apellido = "Abreu" };
            p[1] = new Persona() { Nombre = "Jazmin", Apellido = "Castillo" };
            p[2] = new Persona() { Nombre = "Nelson", Apellido = "Abreu" };
            comboBox3.Items.AddRange(p);
            comboBox3.ValueMember = "Nombre";
            comboBox3.DisplayMember = "Apellido";
        }
        void LlenarComboBoxManual()
        {
            for (int i = 1; i <= 100; i++)
                comboBox2.Items.Add(DateTime.Now.Date.AddMonths(i));
        }

        void LLenarComboBoxOcupaciones()
        {
            this.comboBox1.DataSource = mant.GetListadoOcupaciones();
            this.comboBox1.ValueMember = "ID";
            this.comboBox1.DisplayMember = "Descripcion";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(colorDialog1.ShowDialog()==DialogResult.OK)
                 this.textBox1.BackColor = colorDialog1.Color;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
                this.textBox1.ForeColor = colorDialog1.Color;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (fontDialog1.ShowDialog() == DialogResult.OK)
                this.textBox1.Font = fontDialog1.Font;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = 
            "Todos los Archivos |*.*| Imágenes (.jpg, .png, .gif) |*.jpg; *.png; *.gif";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
                this.pictureBox1.ImageLocation = openFileDialog1.FileName;
        }

        private void button6_Click(object sender, EventArgs e)
        {   //lo graba
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                richTextBox1.SaveFile(saveFileDialog1.FileName);
        }

        private void button5_Click(object sender, EventArgs e)
        { //lo carga
            openFileDialog1.Filter =
             "Todos los Archivos |*.*| Documentos (.txt, .rtf) |*.txt; *.rtf";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
                this.richTextBox1.LoadFile(openFileDialog1.FileName);
        }

        private void copiarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Copy();
        }

        private void cortarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Cut();
        }

        private void pegarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Paste();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if(fontDialog1.ShowDialog()==DialogResult.OK)
            {
                richTextBox1.SelectionFont = fontDialog1.Font;
            }
        }

        private void fontDialog1_Apply(object sender, EventArgs e)
        {
            richTextBox1.Font = fontDialog1.Font;
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Font f = richTextBox1.SelectionFont;
            FontStyle style = richTextBox1.SelectionFont.Style;
            //Adjustando segun lo requerido
            if (richTextBox1.SelectionFont.Bold)
            {
                style &= ~FontStyle.Bold;
                this.toolStripButton1.BackColor = this.toolStrip1.BackColor;
            }
            else
            {
                style |= FontStyle.Bold;
                this.toolStripButton1.BackColor = Color.AliceBlue;
            }
            richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont, style);
        }

        private void toolStripButtonCursiva_Click(object sender, EventArgs e)
        {
            Font f = richTextBox1.SelectionFont;
            FontStyle style = richTextBox1.SelectionFont.Style;
            //Adjustando segun lo requerido
            if (richTextBox1.SelectionFont.Italic)
            {
                style &= ~FontStyle.Italic;
                this.toolStripButtonCursiva.BackColor = Color.FromName("Control");
            }
            else
            {
                style |= FontStyle.Italic;
                this.toolStripButtonCursiva.BackColor = Color.FromName("ActiveBorder");
            }
            richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont, style);
        }

        private void richTextBox1_SelectionChanged(object sender, EventArgs e)
        {
            if (richTextBox1.SelectionFont.Italic)
                this.toolStripButtonCursiva.BackColor = Color.FromName("ActiveBorder");
            else
                this.toolStripButtonCursiva.BackColor = Color.FromName("Control");


        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            e.Link.Visited = true;
            System.Diagnostics.Process.Start((string)e.Link.LinkData);
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.ucne.edu");
        }
    }
}
