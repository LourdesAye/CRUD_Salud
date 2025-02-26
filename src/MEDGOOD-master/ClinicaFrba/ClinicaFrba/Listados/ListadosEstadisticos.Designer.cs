namespace ClinicaFrba.Listados
{
    partial class ListadosEstadisticos
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
            this.dgvListado = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbListado = new System.Windows.Forms.ComboBox();
            this.cmbSemestre = new System.Windows.Forms.ComboBox();
            this.btnListar = new System.Windows.Forms.Button();
            this.lblAnio = new System.Windows.Forms.Label();
            this.lblListado = new System.Windows.Forms.Label();
            this.gbElegir = new System.Windows.Forms.GroupBox();
            this.cmbEspecialidades = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbPlanes = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbRol = new System.Windows.Forms.ComboBox();
            this.cbmAnio = new System.Windows.Forms.ComboBox();
            this.errorRol = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorPlan = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorEspecialidad = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListado)).BeginInit();
            this.gbElegir.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorRol)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorPlan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorEspecialidad)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Size = new System.Drawing.Size(455, 75);
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // dgvListado
            // 
            this.dgvListado.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvListado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListado.Location = new System.Drawing.Point(124, 208);
            this.dgvListado.Name = "dgvListado";
            this.dgvListado.Size = new System.Drawing.Size(719, 184);
            this.dgvListado.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(206, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Semestre:";
            // 
            // cmbListado
            // 
            this.cmbListado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbListado.FormattingEnabled = true;
            this.cmbListado.Location = new System.Drawing.Point(465, 28);
            this.cmbListado.Name = "cmbListado";
            this.cmbListado.Size = new System.Drawing.Size(281, 21);
            this.cmbListado.TabIndex = 1;
            this.cmbListado.SelectedIndexChanged += new System.EventHandler(this.cmbListado_SelectedIndexChanged);
            this.cmbListado.SelectionChangeCommitted += new System.EventHandler(this.cmbListado_SelectionChangeCommitted);
            // 
            // cmbSemestre
            // 
            this.cmbSemestre.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSemestre.FormattingEnabled = true;
            this.cmbSemestre.Location = new System.Drawing.Point(266, 28);
            this.cmbSemestre.Name = "cmbSemestre";
            this.cmbSemestre.Size = new System.Drawing.Size(105, 21);
            this.cmbSemestre.TabIndex = 3;
            // 
            // btnListar
            // 
            this.btnListar.Location = new System.Drawing.Point(765, 26);
            this.btnListar.Name = "btnListar";
            this.btnListar.Size = new System.Drawing.Size(73, 23);
            this.btnListar.TabIndex = 0;
            this.btnListar.Text = "Listar";
            this.btnListar.UseVisualStyleBackColor = true;
            this.btnListar.Click += new System.EventHandler(this.btnListar_Click);
            // 
            // lblAnio
            // 
            this.lblAnio.AutoSize = true;
            this.lblAnio.Location = new System.Drawing.Point(19, 31);
            this.lblAnio.Name = "lblAnio";
            this.lblAnio.Size = new System.Drawing.Size(29, 13);
            this.lblAnio.TabIndex = 5;
            this.lblAnio.Text = "Año:";
            // 
            // lblListado
            // 
            this.lblListado.AutoSize = true;
            this.lblListado.Location = new System.Drawing.Point(418, 36);
            this.lblListado.Name = "lblListado";
            this.lblListado.Size = new System.Drawing.Size(41, 13);
            this.lblListado.TabIndex = 4;
            this.lblListado.Text = "Listado";
            // 
            // gbElegir
            // 
            this.gbElegir.Controls.Add(this.cmbEspecialidades);
            this.gbElegir.Controls.Add(this.label4);
            this.gbElegir.Controls.Add(this.label5);
            this.gbElegir.Controls.Add(this.cmbPlanes);
            this.gbElegir.Controls.Add(this.label3);
            this.gbElegir.Controls.Add(this.cmbRol);
            this.gbElegir.Controls.Add(this.cbmAnio);
            this.gbElegir.Controls.Add(this.lblListado);
            this.gbElegir.Controls.Add(this.lblAnio);
            this.gbElegir.Controls.Add(this.btnListar);
            this.gbElegir.Controls.Add(this.cmbSemestre);
            this.gbElegir.Controls.Add(this.cmbListado);
            this.gbElegir.Controls.Add(this.label2);
            this.gbElegir.Location = new System.Drawing.Point(25, 87);
            this.gbElegir.Name = "gbElegir";
            this.gbElegir.Size = new System.Drawing.Size(866, 115);
            this.gbElegir.TabIndex = 4;
            this.gbElegir.TabStop = false;
            this.gbElegir.Text = "Filtros del listado";
            // 
            // cmbEspecialidades
            // 
            this.cmbEspecialidades.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEspecialidades.FormattingEnabled = true;
            this.cmbEspecialidades.Location = new System.Drawing.Point(599, 69);
            this.cmbEspecialidades.Name = "cmbEspecialidades";
            this.cmbEspecialidades.Size = new System.Drawing.Size(220, 21);
            this.cmbEspecialidades.TabIndex = 12;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(512, 72);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Especialidades:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(252, 72);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Planes:";
            // 
            // cmbPlanes
            // 
            this.cmbPlanes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPlanes.FormattingEnabled = true;
            this.cmbPlanes.Location = new System.Drawing.Point(300, 69);
            this.cmbPlanes.Name = "cmbPlanes";
            this.cmbPlanes.Size = new System.Drawing.Size(200, 21);
            this.cmbPlanes.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(26, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Rol:";
            // 
            // cmbRol
            // 
            this.cmbRol.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRol.FormattingEnabled = true;
            this.cmbRol.Location = new System.Drawing.Point(54, 69);
            this.cmbRol.Name = "cmbRol";
            this.cmbRol.Size = new System.Drawing.Size(192, 21);
            this.cmbRol.TabIndex = 7;
            // 
            // cbmAnio
            // 
            this.cbmAnio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbmAnio.FormattingEnabled = true;
            this.cbmAnio.Location = new System.Drawing.Point(54, 28);
            this.cbmAnio.Name = "cbmAnio";
            this.cbmAnio.Size = new System.Drawing.Size(105, 21);
            this.cbmAnio.TabIndex = 6;
            this.cbmAnio.SelectionChangeCommitted += new System.EventHandler(this.cbmAnio_SelectionChangeCommitted);
            // 
            // errorRol
            // 
            this.errorRol.ContainerControl = this;
            // 
            // errorPlan
            // 
            this.errorPlan.ContainerControl = this;
            // 
            // errorEspecialidad
            // 
            this.errorEspecialidad.ContainerControl = this;
            // 
            // ListadosEstadisticos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(903, 404);
            this.Controls.Add(this.dgvListado);
            this.Controls.Add(this.gbElegir);
            this.Name = "ListadosEstadisticos";
            this.Text = "Listado Estadístico";
            this.Load += new System.EventHandler(this.ListadosEstadisticos_Load);
            this.Controls.SetChildIndex(this.gbElegir, 0);
            this.Controls.SetChildIndex(this.dgvListado, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListado)).EndInit();
            this.gbElegir.ResumeLayout(false);
            this.gbElegir.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorRol)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorPlan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorEspecialidad)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvListado;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbListado;
        private System.Windows.Forms.ComboBox cmbSemestre;
        private System.Windows.Forms.Button btnListar;
        private System.Windows.Forms.Label lblAnio;
        private System.Windows.Forms.Label lblListado;
        private System.Windows.Forms.GroupBox gbElegir;
        private System.Windows.Forms.ComboBox cbmAnio;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbRol;
        private System.Windows.Forms.ComboBox cmbEspecialidades;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbPlanes;
        private System.Windows.Forms.ErrorProvider errorRol;
        private System.Windows.Forms.ErrorProvider errorPlan;
        private System.Windows.Forms.ErrorProvider errorEspecialidad;
    }
}