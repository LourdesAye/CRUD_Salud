namespace ClinicaFrba.Registrar_Agenta_Medico
{
    partial class RegistrarAgenda
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
            this.calendario = new System.Windows.Forms.MonthCalendar();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.comboEspec = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.horarioInicio = new System.Windows.Forms.DateTimePicker();
            this.horarioFin = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.agendaActual = new System.Windows.Forms.DataGridView();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.agendaActual)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Size = new System.Drawing.Size(562, 315);
            // 
            // calendario
            // 
            this.calendario.Location = new System.Drawing.Point(10, 106);
            this.calendario.Name = "calendario";
            this.calendario.ShowToday = false;
            this.calendario.TabIndex = 2;
            this.calendario.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.calendario_DateChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(152, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Seleccione los días deseados:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(215, 84);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Especialidad:";
            // 
            // comboEspec
            // 
            this.comboEspec.FormattingEnabled = true;
            this.comboEspec.Location = new System.Drawing.Point(218, 106);
            this.comboEspec.Name = "comboEspec";
            this.comboEspec.Size = new System.Drawing.Size(121, 21);
            this.comboEspec.Sorted = true;
            this.comboEspec.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.horarioInicio);
            this.groupBox1.Controls.Add(this.horarioFin);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new System.Drawing.Point(218, 133);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(121, 125);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Rango horario";
            // 
            // horarioInicio
            // 
            this.horarioInicio.CustomFormat = "HH:mm";
            this.horarioInicio.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.horarioInicio.Location = new System.Drawing.Point(9, 32);
            this.horarioInicio.Name = "horarioInicio";
            this.horarioInicio.ShowUpDown = true;
            this.horarioInicio.Size = new System.Drawing.Size(106, 20);
            this.horarioInicio.TabIndex = 2;
            this.horarioInicio.Value = new System.DateTime(2016, 10, 26, 7, 0, 0, 0);
            this.horarioInicio.ValueChanged += new System.EventHandler(this.horarioInicio_ValueChanged);
            // 
            // horarioFin
            // 
            this.horarioFin.CustomFormat = "HH:mm";
            this.horarioFin.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.horarioFin.Location = new System.Drawing.Point(9, 82);
            this.horarioFin.Name = "horarioFin";
            this.horarioFin.ShowUpDown = true;
            this.horarioFin.Size = new System.Drawing.Size(106, 20);
            this.horarioFin.TabIndex = 3;
            this.horarioFin.Value = new System.DateTime(2016, 10, 26, 20, 0, 0, 0);
            this.horarioFin.ValueChanged += new System.EventHandler(this.horarioFin_ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 66);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(24, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Fin:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Inicio:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(242, 264);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "Guardar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // agendaActual
            // 
            this.agendaActual.AllowUserToAddRows = false;
            this.agendaActual.AllowUserToDeleteRows = false;
            this.agendaActual.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.agendaActual.Location = new System.Drawing.Point(361, 106);
            this.agendaActual.Name = "agendaActual";
            this.agendaActual.ReadOnly = true;
            this.agendaActual.Size = new System.Drawing.Size(272, 152);
            this.agendaActual.TabIndex = 8;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(358, 84);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(79, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "Agenda actual:";
            // 
            // RegistrarAgenda
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(658, 314);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.agendaActual);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.comboEspec);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.calendario);
            this.Name = "RegistrarAgenda";
            this.ShowIcon = false;
            this.Text = "Registrar agenda";
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.calendario, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.comboEspec, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.button1, 0);
            this.Controls.SetChildIndex(this.agendaActual, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.agendaActual)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MonthCalendar calendario;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboEspec;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker horarioFin;
        private System.Windows.Forms.DateTimePicker horarioInicio;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView agendaActual;
        private System.Windows.Forms.Label label6;
    }
}