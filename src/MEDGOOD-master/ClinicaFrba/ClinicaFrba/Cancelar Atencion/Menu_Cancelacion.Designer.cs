namespace ClinicaFrba.Cancelar_Atencion
{
    partial class Menu_Cancelacion
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
            this.btn_cancelacion = new System.Windows.Forms.Button();
            this.btn_salir = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.comboTipoCan = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textMotCan = new System.Windows.Forms.TextBox();
            this.comboTurno = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // calendario
            // 
            this.calendario.Location = new System.Drawing.Point(145, 83);
            this.calendario.MaxSelectionCount = 1;
            this.calendario.Name = "calendario";
            this.calendario.ShowToday = false;
            this.calendario.TabIndex = 1;
            this.calendario.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.calendario_DateChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(142, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Seleccione una fecha:";
            // 
            // btn_cancelacion
            // 
            this.btn_cancelacion.Location = new System.Drawing.Point(44, 205);
            this.btn_cancelacion.Name = "btn_cancelacion";
            this.btn_cancelacion.Size = new System.Drawing.Size(75, 23);
            this.btn_cancelacion.TabIndex = 3;
            this.btn_cancelacion.Text = "Cancelar";
            this.btn_cancelacion.UseVisualStyleBackColor = true;
            this.btn_cancelacion.Click += new System.EventHandler(this.btn_cancelacion_Click);
            // 
            // btn_salir
            // 
            this.btn_salir.Location = new System.Drawing.Point(199, 257);
            this.btn_salir.Name = "btn_salir";
            this.btn_salir.Size = new System.Drawing.Size(75, 23);
            this.btn_salir.TabIndex = 4;
            this.btn_salir.Text = "Atrás";
            this.btn_salir.UseVisualStyleBackColor = true;
            this.btn_salir.Click += new System.EventHandler(this.btn_salir_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 123);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Tipo de cancelación:";
            // 
            // comboTipoCan
            // 
            this.comboTipoCan.FormattingEnabled = true;
            this.comboTipoCan.Location = new System.Drawing.Point(15, 139);
            this.comboTipoCan.Name = "comboTipoCan";
            this.comboTipoCan.Size = new System.Drawing.Size(118, 21);
            this.comboTipoCan.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 163);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(118, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Motivo de cancelación:";
            // 
            // textMotCan
            // 
            this.textMotCan.Location = new System.Drawing.Point(15, 179);
            this.textMotCan.Name = "textMotCan";
            this.textMotCan.Size = new System.Drawing.Size(118, 20);
            this.textMotCan.TabIndex = 8;
            // 
            // comboTurno
            // 
            this.comboTurno.FormattingEnabled = true;
            this.comboTurno.Location = new System.Drawing.Point(15, 99);
            this.comboTurno.Name = "comboTurno";
            this.comboTurno.Size = new System.Drawing.Size(118, 21);
            this.comboTurno.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 83);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Turnos del día:";
            // 
            // Menu_Cancelacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(354, 290);
            this.Controls.Add(this.comboTurno);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textMotCan);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.comboTipoCan);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btn_salir);
            this.Controls.Add(this.btn_cancelacion);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.calendario);
            this.Name = "Menu_Cancelacion";
            this.Text = "Cancelación de turnos";
            this.Load += new System.EventHandler(this.Menu_Cancelacion_Load);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.calendario, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.btn_cancelacion, 0);
            this.Controls.SetChildIndex(this.btn_salir, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.comboTipoCan, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.textMotCan, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.comboTurno, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MonthCalendar calendario;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_cancelacion;
        private System.Windows.Forms.Button btn_salir;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboTipoCan;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textMotCan;
        private System.Windows.Forms.ComboBox comboTurno;
        private System.Windows.Forms.Label label5;
    }
}