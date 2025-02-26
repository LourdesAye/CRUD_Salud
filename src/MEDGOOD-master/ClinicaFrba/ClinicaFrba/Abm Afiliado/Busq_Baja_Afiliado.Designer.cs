namespace ClinicaFrba.Abm_Afiliado
{
    partial class Busq_Baja_Afiliado
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
            this.btn_buscar = new System.Windows.Forms.Button();
            this.btn_limpiar = new System.Windows.Forms.Button();
            this.group_filtros = new System.Windows.Forms.GroupBox();
            this.btn_calendario = new System.Windows.Forms.Button();
            this.textFecha = new System.Windows.Forms.TextBox();
            this.textDNI = new System.Windows.Forms.TextBox();
            this.textApellido = new System.Windows.Forms.TextBox();
            this.textNombre = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.data_afiliados = new System.Windows.Forms.DataGridView();
            this.btn_salir = new System.Windows.Forms.Button();
            this.calendario = new System.Windows.Forms.MonthCalendar();
            this.group_filtros.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.data_afiliados)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_buscar
            // 
            this.btn_buscar.Location = new System.Drawing.Point(376, 176);
            this.btn_buscar.Name = "btn_buscar";
            this.btn_buscar.Size = new System.Drawing.Size(75, 23);
            this.btn_buscar.TabIndex = 7;
            this.btn_buscar.Text = "Buscar";
            this.btn_buscar.UseVisualStyleBackColor = true;
            this.btn_buscar.Click += new System.EventHandler(this.btn_buscar_Click);
            // 
            // btn_limpiar
            // 
            this.btn_limpiar.Location = new System.Drawing.Point(10, 176);
            this.btn_limpiar.Name = "btn_limpiar";
            this.btn_limpiar.Size = new System.Drawing.Size(75, 23);
            this.btn_limpiar.TabIndex = 6;
            this.btn_limpiar.Text = "Limpiar";
            this.btn_limpiar.UseVisualStyleBackColor = true;
            // 
            // group_filtros
            // 
            this.group_filtros.Controls.Add(this.btn_calendario);
            this.group_filtros.Controls.Add(this.textFecha);
            this.group_filtros.Controls.Add(this.textDNI);
            this.group_filtros.Controls.Add(this.textApellido);
            this.group_filtros.Controls.Add(this.textNombre);
            this.group_filtros.Controls.Add(this.label4);
            this.group_filtros.Controls.Add(this.label3);
            this.group_filtros.Controls.Add(this.label2);
            this.group_filtros.Controls.Add(this.label5);
            this.group_filtros.Location = new System.Drawing.Point(10, 74);
            this.group_filtros.Name = "group_filtros";
            this.group_filtros.Size = new System.Drawing.Size(441, 96);
            this.group_filtros.TabIndex = 5;
            this.group_filtros.TabStop = false;
            this.group_filtros.Text = "Filtros de búsqueda";
            // 
            // btn_calendario
            // 
            this.btn_calendario.Location = new System.Drawing.Point(350, 61);
            this.btn_calendario.Name = "btn_calendario";
            this.btn_calendario.Size = new System.Drawing.Size(75, 23);
            this.btn_calendario.TabIndex = 10;
            this.btn_calendario.Text = "Cambiar";
            this.btn_calendario.UseVisualStyleBackColor = true;
            this.btn_calendario.Click += new System.EventHandler(this.btn_calendario_Click);
            // 
            // textFecha
            // 
            this.textFecha.Location = new System.Drawing.Point(277, 63);
            this.textFecha.Name = "textFecha";
            this.textFecha.ReadOnly = true;
            this.textFecha.Size = new System.Drawing.Size(67, 20);
            this.textFecha.TabIndex = 9;
            // 
            // textDNI
            // 
            this.textDNI.Location = new System.Drawing.Point(277, 22);
            this.textDNI.Name = "textDNI";
            this.textDNI.Size = new System.Drawing.Size(148, 20);
            this.textDNI.TabIndex = 8;
            // 
            // textApellido
            // 
            this.textApellido.Location = new System.Drawing.Point(56, 63);
            this.textApellido.Name = "textApellido";
            this.textApellido.Size = new System.Drawing.Size(100, 20);
            this.textApellido.TabIndex = 7;
            // 
            // textNombre
            // 
            this.textNombre.Location = new System.Drawing.Point(56, 22);
            this.textNombre.Name = "textNombre";
            this.textNombre.Size = new System.Drawing.Size(100, 20);
            this.textNombre.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(162, 66);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(109, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Fecha de nacimiento:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(162, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "N° Documento:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Apellido:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 25);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Nombre:";
            // 
            // data_afiliados
            // 
            this.data_afiliados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.data_afiliados.Location = new System.Drawing.Point(10, 205);
            this.data_afiliados.Name = "data_afiliados";
            this.data_afiliados.Size = new System.Drawing.Size(441, 150);
            this.data_afiliados.TabIndex = 8;
            this.data_afiliados.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.data_afiliados_CellClick);
            // 
            // btn_salir
            // 
            this.btn_salir.Location = new System.Drawing.Point(189, 361);
            this.btn_salir.Name = "btn_salir";
            this.btn_salir.Size = new System.Drawing.Size(75, 23);
            this.btn_salir.TabIndex = 9;
            this.btn_salir.Text = "Atras";
            this.btn_salir.UseVisualStyleBackColor = true;
            this.btn_salir.Click += new System.EventHandler(this.btn_salir_Click);
            // 
            // calendario
            // 
            this.calendario.Location = new System.Drawing.Point(259, 162);
            this.calendario.MaxSelectionCount = 1;
            this.calendario.Name = "calendario";
            this.calendario.TabIndex = 11;
            this.calendario.Visible = false;
            this.calendario.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.calendario_DateSelected);
            this.calendario.Leave += new System.EventHandler(this.calendario_Leave);
            // 
            // Busq_Baja_Afiliado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(465, 399);
            this.Controls.Add(this.calendario);
            this.Controls.Add(this.btn_salir);
            this.Controls.Add(this.data_afiliados);
            this.Controls.Add(this.btn_buscar);
            this.Controls.Add(this.btn_limpiar);
            this.Controls.Add(this.group_filtros);
            this.Name = "Busq_Baja_Afiliado";
            this.Text = "Búsqueda de Afiliado";
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.group_filtros, 0);
            this.Controls.SetChildIndex(this.btn_limpiar, 0);
            this.Controls.SetChildIndex(this.btn_buscar, 0);
            this.Controls.SetChildIndex(this.data_afiliados, 0);
            this.Controls.SetChildIndex(this.btn_salir, 0);
            this.Controls.SetChildIndex(this.calendario, 0);
            this.group_filtros.ResumeLayout(false);
            this.group_filtros.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.data_afiliados)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_buscar;
        private System.Windows.Forms.Button btn_limpiar;
        private System.Windows.Forms.GroupBox group_filtros;
        private System.Windows.Forms.TextBox textDNI;
        private System.Windows.Forms.TextBox textApellido;
        private System.Windows.Forms.TextBox textNombre;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView data_afiliados;
        private System.Windows.Forms.Button btn_salir;
        private System.Windows.Forms.Button btn_calendario;
        private System.Windows.Forms.TextBox textFecha;
        private System.Windows.Forms.MonthCalendar calendario;
    }
}