namespace WindowsForm32018.Registros
{
    partial class frmConsultaEstudiantes
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvEstudiantes = new System.Windows.Forms.DataGridView();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.btnModificar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.colID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColMatricula = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colApellido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColCedula = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFechaNacimiento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColCarrera = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColTelefono = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColEmail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColCelular = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColEstadoCivil = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColObservaciones = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColSexo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEstudiantes)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvEstudiantes
            // 
            this.dgvEstudiantes.AllowUserToAddRows = false;
            this.dgvEstudiantes.AllowUserToDeleteRows = false;
            this.dgvEstudiantes.AllowUserToOrderColumns = true;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.dgvEstudiantes.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvEstudiantes.BackgroundColor = System.Drawing.Color.White;
            this.dgvEstudiantes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEstudiantes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colID,
            this.ColMatricula,
            this.colNombre,
            this.colApellido,
            this.ColCedula,
            this.colFechaNacimiento,
            this.ColCarrera,
            this.ColTelefono,
            this.ColEmail,
            this.ColCelular,
            this.ColEstadoCivil,
            this.ColObservaciones,
            this.ColSexo});
            this.dgvEstudiantes.Location = new System.Drawing.Point(12, 66);
            this.dgvEstudiantes.MultiSelect = false;
            this.dgvEstudiantes.Name = "dgvEstudiantes";
            this.dgvEstudiantes.RowHeadersVisible = false;
            this.dgvEstudiantes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvEstudiantes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvEstudiantes.Size = new System.Drawing.Size(994, 223);
            this.dgvEstudiantes.TabIndex = 0;
            // 
            // btnBuscar
            // 
            this.btnBuscar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btnBuscar.Location = new System.Drawing.Point(802, 6);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(99, 23);
            this.btnBuscar.TabIndex = 1;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(6, 22);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(267, 20);
            this.txtNombre.TabIndex = 3;
            this.txtNombre.TextChanged += new System.EventHandler(this.txtNombre_TextChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtNombre);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(279, 48);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtrar Por";
            // 
            // btnImprimir
            // 
            this.btnImprimir.Location = new System.Drawing.Point(802, 31);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(99, 23);
            this.btnImprimir.TabIndex = 5;
            this.btnImprimir.Text = "Imprimir";
            this.btnImprimir.UseVisualStyleBackColor = true;
            // 
            // btnNuevo
            // 
            this.btnNuevo.ForeColor = System.Drawing.Color.Green;
            this.btnNuevo.Location = new System.Drawing.Point(907, 6);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(99, 23);
            this.btnNuevo.TabIndex = 6;
            this.btnNuevo.Text = "Nuevo";
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // btnModificar
            // 
            this.btnModificar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnModificar.Location = new System.Drawing.Point(907, 31);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(99, 23);
            this.btnModificar.TabIndex = 7;
            this.btnModificar.Text = "Modificar";
            this.btnModificar.UseVisualStyleBackColor = true;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(892, 296);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Total:";
            // 
            // lblTotal
            // 
            this.lblTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTotal.Location = new System.Drawing.Point(930, 292);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(76, 20);
            this.lblTotal.TabIndex = 8;
            this.lblTotal.Text = "0";
            this.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // colID
            // 
            this.colID.DataPropertyName = "ID";
            this.colID.HeaderText = "ID";
            this.colID.Name = "colID";
            this.colID.ReadOnly = true;
            this.colID.Width = 25;
            // 
            // ColMatricula
            // 
            this.ColMatricula.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.ColMatricula.DataPropertyName = "Matricula";
            this.ColMatricula.HeaderText = "Matricula";
            this.ColMatricula.Name = "ColMatricula";
            this.ColMatricula.ReadOnly = true;
            this.ColMatricula.Width = 75;
            // 
            // colNombre
            // 
            this.colNombre.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.colNombre.DataPropertyName = "Nombre";
            this.colNombre.HeaderText = "Nombre";
            this.colNombre.Name = "colNombre";
            this.colNombre.ReadOnly = true;
            this.colNombre.Width = 69;
            // 
            // colApellido
            // 
            this.colApellido.DataPropertyName = "Apellido";
            this.colApellido.HeaderText = "Apellido";
            this.colApellido.Name = "colApellido";
            this.colApellido.ReadOnly = true;
            // 
            // ColCedula
            // 
            this.ColCedula.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.ColCedula.DataPropertyName = "Cedula";
            this.ColCedula.HeaderText = "Cedula";
            this.ColCedula.Name = "ColCedula";
            this.ColCedula.Width = 65;
            // 
            // colFechaNacimiento
            // 
            this.colFechaNacimiento.DataPropertyName = "FechaNacimiento";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.colFechaNacimiento.DefaultCellStyle = dataGridViewCellStyle4;
            this.colFechaNacimiento.HeaderText = "F. Nacimiento";
            this.colFechaNacimiento.Name = "colFechaNacimiento";
            this.colFechaNacimiento.ReadOnly = true;
            // 
            // ColCarrera
            // 
            this.ColCarrera.DataPropertyName = "IDCarrera";
            this.ColCarrera.HeaderText = "Carrera";
            this.ColCarrera.Name = "ColCarrera";
            // 
            // ColTelefono
            // 
            this.ColTelefono.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader;
            this.ColTelefono.DataPropertyName = "TelefonoCasa";
            this.ColTelefono.HeaderText = "Telefono";
            this.ColTelefono.Name = "ColTelefono";
            this.ColTelefono.Width = 5;
            // 
            // ColEmail
            // 
            this.ColEmail.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader;
            this.ColEmail.DataPropertyName = "Email";
            this.ColEmail.HeaderText = "Correo";
            this.ColEmail.Name = "ColEmail";
            this.ColEmail.Width = 5;
            // 
            // ColCelular
            // 
            this.ColCelular.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader;
            this.ColCelular.DataPropertyName = "TelefonoMovil";
            this.ColCelular.HeaderText = "Celular";
            this.ColCelular.Name = "ColCelular";
            this.ColCelular.Width = 5;
            // 
            // ColEstadoCivil
            // 
            this.ColEstadoCivil.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.ColEstadoCivil.DataPropertyName = "EstadoCivil";
            this.ColEstadoCivil.HeaderText = "Estado Civil";
            this.ColEstadoCivil.Name = "ColEstadoCivil";
            this.ColEstadoCivil.Width = 87;
            // 
            // ColObservaciones
            // 
            this.ColObservaciones.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.ColObservaciones.DataPropertyName = "Observaciones";
            this.ColObservaciones.HeaderText = "Observaciones";
            this.ColObservaciones.Name = "ColObservaciones";
            this.ColObservaciones.Width = 103;
            // 
            // ColSexo
            // 
            this.ColSexo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.ColSexo.DataPropertyName = "Sexo";
            this.ColSexo.HeaderText = "Sexo";
            this.ColSexo.Name = "ColSexo";
            this.ColSexo.ReadOnly = true;
            this.ColSexo.Width = 56;
            // 
            // frmConsultaEstudiantes
            // 
            this.AcceptButton = this.btnBuscar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1018, 321);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.btnNuevo);
            this.Controls.Add(this.btnImprimir);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.dgvEstudiantes);
            this.Name = "frmConsultaEstudiantes";
            this.ShowInTaskbar = false;
            this.Text = "Consulta de Estudiantes";
            ((System.ComponentModel.ISupportInitialize)(this.dgvEstudiantes)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvEstudiantes;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnImprimir;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn colID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColMatricula;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn colApellido;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColCedula;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFechaNacimiento;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColCarrera;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColTelefono;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColEmail;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColCelular;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColEstadoCivil;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColObservaciones;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColSexo;
    }
}