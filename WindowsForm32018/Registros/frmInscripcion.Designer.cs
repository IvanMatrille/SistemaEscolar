namespace WindowsForm32018.Registros
{
    partial class frmInscripcion
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.lblID = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnInscribir = new System.Windows.Forms.Button();
            this.dgvEstudiantes = new System.Windows.Forms.DataGridView();
            this.colID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDescripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColClave = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDia1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColHora1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColDia2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColHora2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColAsignatura = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColObservaciones = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEstudiantes)).BeginInit();
            this.SuspendLayout();
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // lblID
            // 
            this.lblID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblID.Location = new System.Drawing.Point(112, 31);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(121, 20);
            this.lblID.TabIndex = 23;
            this.lblID.Text = "NUEVO";
            this.lblID.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 35);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(18, 13);
            this.label4.TabIndex = 22;
            this.label4.Text = "ID";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvEstudiantes);
            this.groupBox1.Controls.Add(this.btnInscribir);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.lblID);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(972, 342);
            this.groupBox1.TabIndex = 44;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Seleccion de Materias";
            // 
            // btnInscribir
            // 
            this.btnInscribir.ForeColor = System.Drawing.Color.DarkGreen;
            this.btnInscribir.Location = new System.Drawing.Point(881, 31);
            this.btnInscribir.Name = "btnInscribir";
            this.btnInscribir.Size = new System.Drawing.Size(75, 23);
            this.btnInscribir.TabIndex = 25;
            this.btnInscribir.Text = "Inscribir";
            this.btnInscribir.UseVisualStyleBackColor = true;
            this.btnInscribir.Click += new System.EventHandler(this.btnInscribir_Click);
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
            this.colDescripcion,
            this.ColClave,
            this.colDia1,
            this.ColHora1,
            this.ColDia2,
            this.ColHora2,
            this.ColAsignatura,
            this.ColObservaciones});
            this.dgvEstudiantes.Location = new System.Drawing.Point(6, 69);
            this.dgvEstudiantes.MultiSelect = false;
            this.dgvEstudiantes.Name = "dgvEstudiantes";
            this.dgvEstudiantes.RowHeadersVisible = false;
            this.dgvEstudiantes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvEstudiantes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvEstudiantes.Size = new System.Drawing.Size(950, 223);
            this.dgvEstudiantes.TabIndex = 26;
            // 
            // colID
            // 
            this.colID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.colID.DataPropertyName = "ID";
            this.colID.HeaderText = "ID";
            this.colID.Name = "colID";
            this.colID.ReadOnly = true;
            this.colID.Width = 43;
            // 
            // colDescripcion
            // 
            this.colDescripcion.DataPropertyName = "IDAula";
            this.colDescripcion.HeaderText = "Aula";
            this.colDescripcion.Name = "colDescripcion";
            this.colDescripcion.ReadOnly = true;
            // 
            // ColClave
            // 
            this.ColClave.DataPropertyName = "IDProfesor";
            this.ColClave.HeaderText = "Profesor";
            this.ColClave.Name = "ColClave";
            // 
            // colDia1
            // 
            this.colDia1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colDia1.DataPropertyName = "Dia1";
            this.colDia1.HeaderText = "Dia1";
            this.colDia1.Name = "colDia1";
            this.colDia1.ReadOnly = true;
            this.colDia1.Width = 54;
            // 
            // ColHora1
            // 
            this.ColHora1.DataPropertyName = "Hora1";
            this.ColHora1.HeaderText = "Hora 1";
            this.ColHora1.Name = "ColHora1";
            // 
            // ColDia2
            // 
            this.ColDia2.DataPropertyName = "Dia2";
            this.ColDia2.HeaderText = "Dia 2";
            this.ColDia2.Name = "ColDia2";
            // 
            // ColHora2
            // 
            this.ColHora2.DataPropertyName = "Hora2";
            this.ColHora2.HeaderText = "Hora 2";
            this.ColHora2.Name = "ColHora2";
            // 
            // ColAsignatura
            // 
            this.ColAsignatura.DataPropertyName = "IDAsignatura";
            this.ColAsignatura.HeaderText = "Asignatura";
            this.ColAsignatura.Name = "ColAsignatura";
            // 
            // ColObservaciones
            // 
            this.ColObservaciones.DataPropertyName = "Observaciones";
            this.ColObservaciones.HeaderText = "Observaciones";
            this.ColObservaciones.Name = "ColObservaciones";
            this.ColObservaciones.Width = 183;
            // 
            // frmInscripcion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(996, 366);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmInscripcion";
            this.ShowIcon = false;
            this.Text = "Registro de Estudiantes";
            this.Load += new System.EventHandler(this.frmInscripcion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEstudiantes)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.Button btnInscribir;
        private System.Windows.Forms.DataGridView dgvEstudiantes;
        private System.Windows.Forms.DataGridViewTextBoxColumn colID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDescripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColClave;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDia1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColHora1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColDia2;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColHora2;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColAsignatura;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColObservaciones;
    }
}