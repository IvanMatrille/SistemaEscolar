namespace WindowsForm32018
{
    partial class frmEncriptar
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.txtTextoPlano = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtHash = new System.Windows.Forms.TextBox();
            this.cbAlgoritmo = new System.Windows.Forms.ComboBox();
            this.btnCalcular = new System.Windows.Forms.Button();
            this.cbAlgoritmo2 = new System.Windows.Forms.ComboBox();
            this.txtClave = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnVerificar = new System.Windows.Forms.Button();
            this.txtHashBD = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtTextPlano2 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtEncriptado = new System.Windows.Forms.TextBox();
            this.btnEncriptar = new System.Windows.Forms.Button();
            this.btnDesEncriptar = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.txtPlano3 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtEncriptado2 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Texto Plano";
            // 
            // txtTextoPlano
            // 
            this.txtTextoPlano.Location = new System.Drawing.Point(31, 44);
            this.txtTextoPlano.Name = "txtTextoPlano";
            this.txtTextoPlano.Size = new System.Drawing.Size(237, 20);
            this.txtTextoPlano.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Hash";
            // 
            // txtHash
            // 
            this.txtHash.Location = new System.Drawing.Point(31, 92);
            this.txtHash.Multiline = true;
            this.txtHash.Name = "txtHash";
            this.txtHash.ReadOnly = true;
            this.txtHash.Size = new System.Drawing.Size(365, 30);
            this.txtHash.TabIndex = 3;
            // 
            // cbAlgoritmo
            // 
            this.cbAlgoritmo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAlgoritmo.FormattingEnabled = true;
            this.cbAlgoritmo.Items.AddRange(new object[] {
            "SHA1",
            "SHA256",
            "SHA384",
            "SHA512"});
            this.cbAlgoritmo.Location = new System.Drawing.Point(275, 44);
            this.cbAlgoritmo.Name = "cbAlgoritmo";
            this.cbAlgoritmo.Size = new System.Drawing.Size(121, 21);
            this.cbAlgoritmo.TabIndex = 4;
            // 
            // btnCalcular
            // 
            this.btnCalcular.Location = new System.Drawing.Point(31, 127);
            this.btnCalcular.Name = "btnCalcular";
            this.btnCalcular.Size = new System.Drawing.Size(75, 23);
            this.btnCalcular.TabIndex = 5;
            this.btnCalcular.Text = "Calcular Hash";
            this.btnCalcular.UseVisualStyleBackColor = true;
            this.btnCalcular.Click += new System.EventHandler(this.btnCalcular_Click);
            // 
            // cbAlgoritmo2
            // 
            this.cbAlgoritmo2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAlgoritmo2.FormattingEnabled = true;
            this.cbAlgoritmo2.Items.AddRange(new object[] {
            "SHA1",
            "SHA256",
            "SHA384",
            "SHA512"});
            this.cbAlgoritmo2.Location = new System.Drawing.Point(275, 205);
            this.cbAlgoritmo2.Name = "cbAlgoritmo2";
            this.cbAlgoritmo2.Size = new System.Drawing.Size(121, 21);
            this.cbAlgoritmo2.TabIndex = 8;
            // 
            // txtClave
            // 
            this.txtClave.Location = new System.Drawing.Point(31, 205);
            this.txtClave.Name = "txtClave";
            this.txtClave.Size = new System.Drawing.Size(237, 20);
            this.txtClave.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 188);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Clave";
            // 
            // btnVerificar
            // 
            this.btnVerificar.Location = new System.Drawing.Point(31, 284);
            this.btnVerificar.Name = "btnVerificar";
            this.btnVerificar.Size = new System.Drawing.Size(75, 23);
            this.btnVerificar.TabIndex = 9;
            this.btnVerificar.Text = "Verificar";
            this.btnVerificar.UseVisualStyleBackColor = true;
            this.btnVerificar.Click += new System.EventHandler(this.btnVerificar_Click);
            // 
            // txtHashBD
            // 
            this.txtHashBD.Location = new System.Drawing.Point(31, 247);
            this.txtHashBD.Multiline = true;
            this.txtHashBD.Name = "txtHashBD";
            this.txtHashBD.Size = new System.Drawing.Size(365, 31);
            this.txtHashBD.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(30, 231);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Hash";
            // 
            // txtTextPlano2
            // 
            this.txtTextPlano2.Location = new System.Drawing.Point(474, 44);
            this.txtTextPlano2.Name = "txtTextPlano2";
            this.txtTextPlano2.Size = new System.Drawing.Size(285, 20);
            this.txtTextPlano2.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(471, 28);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Texto Plano";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(471, 111);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(88, 13);
            this.label6.TabIndex = 15;
            this.label6.Text = "Texto Encriptado";
            // 
            // txtEncriptado
            // 
            this.txtEncriptado.Location = new System.Drawing.Point(474, 127);
            this.txtEncriptado.Name = "txtEncriptado";
            this.txtEncriptado.Size = new System.Drawing.Size(285, 20);
            this.txtEncriptado.TabIndex = 14;
            // 
            // btnEncriptar
            // 
            this.btnEncriptar.Location = new System.Drawing.Point(584, 90);
            this.btnEncriptar.Name = "btnEncriptar";
            this.btnEncriptar.Size = new System.Drawing.Size(75, 23);
            this.btnEncriptar.TabIndex = 16;
            this.btnEncriptar.Text = "Encriptar";
            this.btnEncriptar.UseVisualStyleBackColor = true;
            this.btnEncriptar.Click += new System.EventHandler(this.btnEncriptar_Click);
            // 
            // btnDesEncriptar
            // 
            this.btnDesEncriptar.Location = new System.Drawing.Point(584, 234);
            this.btnDesEncriptar.Name = "btnDesEncriptar";
            this.btnDesEncriptar.Size = new System.Drawing.Size(75, 23);
            this.btnDesEncriptar.TabIndex = 21;
            this.btnDesEncriptar.Text = "Desencriptar";
            this.btnDesEncriptar.UseVisualStyleBackColor = true;
            this.btnDesEncriptar.Click += new System.EventHandler(this.button1_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(471, 255);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(64, 13);
            this.label7.TabIndex = 20;
            this.label7.Text = "Texto Plano";
            // 
            // txtPlano3
            // 
            this.txtPlano3.Location = new System.Drawing.Point(474, 271);
            this.txtPlano3.Name = "txtPlano3";
            this.txtPlano3.Size = new System.Drawing.Size(285, 20);
            this.txtPlano3.TabIndex = 19;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(471, 172);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(88, 13);
            this.label8.TabIndex = 18;
            this.label8.Text = "Texto Encriptado";
            // 
            // txtEncriptado2
            // 
            this.txtEncriptado2.Location = new System.Drawing.Point(474, 188);
            this.txtEncriptado2.Name = "txtEncriptado2";
            this.txtEncriptado2.Size = new System.Drawing.Size(285, 20);
            this.txtEncriptado2.TabIndex = 17;
            // 
            // frmEncriptar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(869, 329);
            this.Controls.Add(this.btnDesEncriptar);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtPlano3);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtEncriptado2);
            this.Controls.Add(this.btnEncriptar);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtEncriptado);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtTextPlano2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtHashBD);
            this.Controls.Add(this.btnVerificar);
            this.Controls.Add(this.cbAlgoritmo2);
            this.Controls.Add(this.txtClave);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnCalcular);
            this.Controls.Add(this.cbAlgoritmo);
            this.Controls.Add(this.txtHash);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtTextoPlano);
            this.Controls.Add(this.label1);
            this.Name = "frmEncriptar";
            this.Text = "frmEncriptar";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTextoPlano;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtHash;
        private System.Windows.Forms.ComboBox cbAlgoritmo;
        private System.Windows.Forms.Button btnCalcular;
        private System.Windows.Forms.ComboBox cbAlgoritmo2;
        private System.Windows.Forms.TextBox txtClave;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnVerificar;
        private System.Windows.Forms.TextBox txtHashBD;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtTextPlano2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtEncriptado;
        private System.Windows.Forms.Button btnEncriptar;
        private System.Windows.Forms.Button btnDesEncriptar;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtPlano3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtEncriptado2;
    }
}