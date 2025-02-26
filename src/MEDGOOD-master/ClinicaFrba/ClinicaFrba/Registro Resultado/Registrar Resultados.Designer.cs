namespace ClinicaFrba.Registro_Resultado
{
    partial class Registrar_Resultados
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_enfermedad = new System.Windows.Forms.TextBox();
            this.txt_diagnostico = new System.Windows.Forms.TextBox();
            this.dateTimePicker_hora = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker_fecha = new System.Windows.Forms.DateTimePicker();
            this.button1 = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.txt_sintomas = new System.Windows.Forms.TextBox();
            this.error_sintomas = new System.Windows.Forms.ErrorProvider(this.components);
            this.error_diagnostico = new System.Windows.Forms.ErrorProvider(this.components);
            this.label7 = new System.Windows.Forms.Label();
            this.txt_comentario = new System.Windows.Forms.TextBox();
            this.error_enfermedad = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.error_sintomas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.error_diagnostico)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.error_enfermedad)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Size = new System.Drawing.Size(198, 113);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(91, 122);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Diagnótico:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(97, 89);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Síntomas:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(69, 211);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Fecha Atención:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(74, 244);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Hora Atención:";
            // 
            // txt_enfermedad
            // 
            this.txt_enfermedad.Location = new System.Drawing.Point(158, 149);
            this.txt_enfermedad.Name = "txt_enfermedad";
            this.txt_enfermedad.Size = new System.Drawing.Size(210, 20);
            this.txt_enfermedad.TabIndex = 8;
            // 
            // txt_diagnostico
            // 
            this.txt_diagnostico.Location = new System.Drawing.Point(158, 115);
            this.txt_diagnostico.Name = "txt_diagnostico";
            this.txt_diagnostico.Size = new System.Drawing.Size(210, 20);
            this.txt_diagnostico.TabIndex = 9;
            // 
            // dateTimePicker_hora
            // 
            this.dateTimePicker_hora.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dateTimePicker_hora.Location = new System.Drawing.Point(158, 238);
            this.dateTimePicker_hora.Name = "dateTimePicker_hora";
            this.dateTimePicker_hora.Size = new System.Drawing.Size(210, 20);
            this.dateTimePicker_hora.TabIndex = 10;
            // 
            // dateTimePicker_fecha
            // 
            this.dateTimePicker_fecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker_fecha.Location = new System.Drawing.Point(158, 205);
            this.dateTimePicker_fecha.Name = "dateTimePicker_fecha";
            this.dateTimePicker_fecha.Size = new System.Drawing.Size(210, 20);
            this.dateTimePicker_fecha.TabIndex = 11;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(175, 288);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 12;
            this.button1.Text = "Aceptar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(91, 180);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(68, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Comentarios:";
            // 
            // txt_sintomas
            // 
            this.txt_sintomas.Location = new System.Drawing.Point(158, 86);
            this.txt_sintomas.Name = "txt_sintomas";
            this.txt_sintomas.Size = new System.Drawing.Size(210, 20);
            this.txt_sintomas.TabIndex = 14;
            // 
            // error_sintomas
            // 
            this.error_sintomas.ContainerControl = this;
            // 
            // error_diagnostico
            // 
            this.error_diagnostico.ContainerControl = this;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(85, 152);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(67, 13);
            this.label7.TabIndex = 15;
            this.label7.Text = "Enfermedad:";
            // 
            // txt_comentario
            // 
            this.txt_comentario.Location = new System.Drawing.Point(158, 177);
            this.txt_comentario.Name = "txt_comentario";
            this.txt_comentario.Size = new System.Drawing.Size(210, 20);
            this.txt_comentario.TabIndex = 16;
            // 
            // error_enfermedad
            // 
            this.error_enfermedad.ContainerControl = this;
            // 
            // Registrar_Resultados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(428, 331);
            this.Controls.Add(this.txt_comentario);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txt_sintomas);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dateTimePicker_fecha);
            this.Controls.Add(this.dateTimePicker_hora);
            this.Controls.Add(this.txt_diagnostico);
            this.Controls.Add(this.txt_enfermedad);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Name = "Registrar_Resultados";
            this.Text = "Registrar_Resultados";
            this.Load += new System.EventHandler(this.Registrar_Resultados_Load);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.txt_enfermedad, 0);
            this.Controls.SetChildIndex(this.txt_diagnostico, 0);
            this.Controls.SetChildIndex(this.dateTimePicker_hora, 0);
            this.Controls.SetChildIndex(this.dateTimePicker_fecha, 0);
            this.Controls.SetChildIndex(this.button1, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this.txt_sintomas, 0);
            this.Controls.SetChildIndex(this.label7, 0);
            this.Controls.SetChildIndex(this.txt_comentario, 0);
            ((System.ComponentModel.ISupportInitialize)(this.error_sintomas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.error_diagnostico)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.error_enfermedad)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_enfermedad;
        private System.Windows.Forms.TextBox txt_diagnostico;
        private System.Windows.Forms.DateTimePicker dateTimePicker_hora;
        private System.Windows.Forms.DateTimePicker dateTimePicker_fecha;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txt_sintomas;
        private System.Windows.Forms.ErrorProvider error_sintomas;
        private System.Windows.Forms.TextBox txt_comentario;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ErrorProvider error_diagnostico;
        private System.Windows.Forms.ErrorProvider error_enfermedad;
    }
}