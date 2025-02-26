namespace ClinicaFrba.Registro_Llegada
{
    partial class RegistroLlegadaAfiliado
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_apellido_profesional = new System.Windows.Forms.TextBox();
            this.btn_buscar_turno = new System.Windows.Forms.Button();
            this.txt_nombre_profesional = new System.Windows.Forms.TextBox();
            this.cmb_especialidades_medicas = new System.Windows.Forms.ComboBox();
            this.dgv_turnos = new System.Windows.Forms.DataGridView();
            this.btn_registro_atencion = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_turnos)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Size = new System.Drawing.Size(327, 265);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(353, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Especialidad:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(81, 37);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(110, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Datos del Profesional:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txt_apellido_profesional);
            this.groupBox1.Controls.Add(this.btn_buscar_turno);
            this.groupBox1.Controls.Add(this.txt_nombre_profesional);
            this.groupBox1.Controls.Add(this.cmb_especialidades_medicas);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(19, 83);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(604, 139);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtros de Búsqueda de Turnos";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(51, 74);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Apellido:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(51, 99);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Nombre:";
            // 
            // txt_apellido_profesional
            // 
            this.txt_apellido_profesional.Location = new System.Drawing.Point(100, 67);
            this.txt_apellido_profesional.Name = "txt_apellido_profesional";
            this.txt_apellido_profesional.Size = new System.Drawing.Size(156, 20);
            this.txt_apellido_profesional.TabIndex = 6;
            // 
            // btn_buscar_turno
            // 
            this.btn_buscar_turno.Location = new System.Drawing.Point(356, 99);
            this.btn_buscar_turno.Name = "btn_buscar_turno";
            this.btn_buscar_turno.Size = new System.Drawing.Size(81, 23);
            this.btn_buscar_turno.TabIndex = 5;
            this.btn_buscar_turno.Text = "Buscar Turno";
            this.btn_buscar_turno.UseVisualStyleBackColor = true;
            this.btn_buscar_turno.Click += new System.EventHandler(this.btn_buscar_turno_Click);
            // 
            // txt_nombre_profesional
            // 
            this.txt_nombre_profesional.Location = new System.Drawing.Point(100, 96);
            this.txt_nombre_profesional.Name = "txt_nombre_profesional";
            this.txt_nombre_profesional.Size = new System.Drawing.Size(156, 20);
            this.txt_nombre_profesional.TabIndex = 4;
            // 
            // cmb_especialidades_medicas
            // 
            this.cmb_especialidades_medicas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_especialidades_medicas.FormattingEnabled = true;
            this.cmb_especialidades_medicas.Location = new System.Drawing.Point(326, 66);
            this.cmb_especialidades_medicas.Name = "cmb_especialidades_medicas";
            this.cmb_especialidades_medicas.Size = new System.Drawing.Size(156, 21);
            this.cmb_especialidades_medicas.TabIndex = 3;
            // 
            // dgv_turnos
            // 
            this.dgv_turnos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_turnos.Location = new System.Drawing.Point(19, 271);
            this.dgv_turnos.Name = "dgv_turnos";
            this.dgv_turnos.Size = new System.Drawing.Size(604, 157);
            this.dgv_turnos.TabIndex = 4;
            // 
            // btn_registro_atencion
            // 
            this.btn_registro_atencion.Location = new System.Drawing.Point(249, 434);
            this.btn_registro_atencion.Name = "btn_registro_atencion";
            this.btn_registro_atencion.Size = new System.Drawing.Size(112, 23);
            this.btn_registro_atencion.TabIndex = 5;
            this.btn_registro_atencion.Text = "Registrar atención";
            this.btn_registro_atencion.UseVisualStyleBackColor = true;
            this.btn_registro_atencion.Click += new System.EventHandler(this.btn_registro_atencion_Click);
            // 
            // RegistroLlegadaAfiliado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(639, 469);
            this.Controls.Add(this.btn_registro_atencion);
            this.Controls.Add(this.dgv_turnos);
            this.Controls.Add(this.groupBox1);
            this.Name = "RegistroLlegadaAfiliado";
            this.Text = "Registro De Llegada";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.dgv_turnos, 0);
            this.Controls.SetChildIndex(this.btn_registro_atencion, 0);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_turnos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btn_buscar_turno;
        private System.Windows.Forms.TextBox txt_nombre_profesional;
        private System.Windows.Forms.ComboBox cmb_especialidades_medicas;
        private System.Windows.Forms.DataGridView dgv_turnos;
        private System.Windows.Forms.Button btn_registro_atencion;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_apellido_profesional;
    }
}