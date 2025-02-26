namespace ClinicaFrba.Pedir_Turno
{
    partial class Turno_Prof
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
            this.calendario = new System.Windows.Forms.MonthCalendar();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.horarioInicio = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Size = new System.Drawing.Size(162, 70);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(137, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Seleccione el día deseado:";
            // 
            // calendario
            // 
            this.calendario.Location = new System.Drawing.Point(10, 105);
            this.calendario.MaxSelectionCount = 1;
            this.calendario.Name = "calendario";
            this.calendario.ShowToday = false;
            this.calendario.TabIndex = 4;
            this.calendario.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.calendario_DateChanged);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(156, 279);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(75, 23);
            this.btnGuardar.TabIndex = 8;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.horarioInicio);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new System.Drawing.Point(214, 117);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(121, 61);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Horario";
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
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Llegada:";
            // 
            // Turno_Prof
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(396, 318);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.calendario);
            this.Name = "Turno_Prof";
            this.Text = "Turno_Prof";
            this.Load += new System.EventHandler(this.Turno_Prof_Load);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.calendario, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.btnGuardar, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MonthCalendar calendario;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker horarioInicio;
        private System.Windows.Forms.Label label4;
    }
}