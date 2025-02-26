namespace ClinicaFrba.Abm_Afiliado
{
    partial class Modif_Afiliado
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
            this.grupoDatos = new System.Windows.Forms.GroupBox();
            this.btn_limpiar = new System.Windows.Forms.Button();
            this.btn_guardar = new System.Windows.Forms.Button();
            this.comboPlan = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.textCantFam = new System.Windows.Forms.NumericUpDown();
            this.label11 = new System.Windows.Forms.Label();
            this.comboEstCiv = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textMail = new System.Windows.Forms.TextBox();
            this.textDom = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textTel = new System.Windows.Forms.TextBox();
            this.btn_salir = new System.Windows.Forms.Button();
            this.errorProv = new System.Windows.Forms.ErrorProvider(this.components);
            this.grupoDatos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textCantFam)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProv)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Size = new System.Drawing.Size(223, 87);
            // 
            // grupoDatos
            // 
            this.grupoDatos.Controls.Add(this.btn_limpiar);
            this.grupoDatos.Controls.Add(this.btn_guardar);
            this.grupoDatos.Controls.Add(this.comboPlan);
            this.grupoDatos.Controls.Add(this.label13);
            this.grupoDatos.Controls.Add(this.textCantFam);
            this.grupoDatos.Controls.Add(this.label11);
            this.grupoDatos.Controls.Add(this.comboEstCiv);
            this.grupoDatos.Controls.Add(this.label4);
            this.grupoDatos.Controls.Add(this.textMail);
            this.grupoDatos.Controls.Add(this.textDom);
            this.grupoDatos.Controls.Add(this.label7);
            this.grupoDatos.Controls.Add(this.label6);
            this.grupoDatos.Controls.Add(this.label5);
            this.grupoDatos.Controls.Add(this.textTel);
            this.grupoDatos.Location = new System.Drawing.Point(10, 83);
            this.grupoDatos.Name = "grupoDatos";
            this.grupoDatos.Size = new System.Drawing.Size(477, 99);
            this.grupoDatos.TabIndex = 1;
            this.grupoDatos.TabStop = false;
            this.grupoDatos.Text = "Datos de Afiliado";
            // 
            // btn_limpiar
            // 
            this.btn_limpiar.Location = new System.Drawing.Point(385, 41);
            this.btn_limpiar.Name = "btn_limpiar";
            this.btn_limpiar.Size = new System.Drawing.Size(79, 23);
            this.btn_limpiar.TabIndex = 8;
            this.btn_limpiar.Text = "Limpiar";
            this.btn_limpiar.UseVisualStyleBackColor = true;
            this.btn_limpiar.Click += new System.EventHandler(this.btn_limpiar_Click);
            // 
            // btn_guardar
            // 
            this.btn_guardar.Location = new System.Drawing.Point(385, 14);
            this.btn_guardar.Name = "btn_guardar";
            this.btn_guardar.Size = new System.Drawing.Size(79, 23);
            this.btn_guardar.TabIndex = 7;
            this.btn_guardar.Text = "Guardar";
            this.btn_guardar.UseVisualStyleBackColor = true;
            this.btn_guardar.Click += new System.EventHandler(this.btn_guardar_Click);
            // 
            // comboPlan
            // 
            this.comboPlan.FormattingEnabled = true;
            this.comboPlan.Location = new System.Drawing.Point(272, 64);
            this.comboPlan.Name = "comboPlan";
            this.comboPlan.Size = new System.Drawing.Size(79, 21);
            this.comboPlan.TabIndex = 6;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(192, 68);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(68, 13);
            this.label13.TabIndex = 42;
            this.label13.Text = "Plan médico:";
            // 
            // textCantFam
            // 
            this.textCantFam.Location = new System.Drawing.Point(272, 41);
            this.textCantFam.Name = "textCantFam";
            this.textCantFam.Size = new System.Drawing.Size(79, 20);
            this.textCantFam.TabIndex = 5;
            this.textCantFam.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(192, 44);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(74, 13);
            this.label11.TabIndex = 40;
            this.label11.Text = "Cant. a cargo:";
            // 
            // comboEstCiv
            // 
            this.comboEstCiv.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboEstCiv.FormattingEnabled = true;
            this.comboEstCiv.Items.AddRange(new object[] {
            "Soltero/a",
            "Casado/a",
            "Viudo/a",
            "Concubinato",
            "Divoricado/a"});
            this.comboEstCiv.Location = new System.Drawing.Point(272, 15);
            this.comboEstCiv.Name = "comboEstCiv";
            this.comboEstCiv.Size = new System.Drawing.Size(79, 21);
            this.comboEstCiv.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(192, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 13);
            this.label4.TabIndex = 33;
            this.label4.Text = "Estado civil:";
            // 
            // textMail
            // 
            this.textMail.Location = new System.Drawing.Point(80, 16);
            this.textMail.Name = "textMail";
            this.textMail.Size = new System.Drawing.Size(74, 20);
            this.textMail.TabIndex = 1;
            // 
            // textDom
            // 
            this.textDom.Location = new System.Drawing.Point(80, 65);
            this.textDom.Name = "textDom";
            this.textDom.Size = new System.Drawing.Size(74, 20);
            this.textDom.TabIndex = 3;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(9, 68);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(52, 13);
            this.label7.TabIndex = 11;
            this.label7.Text = "Domicilio:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 44);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Teléfono:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 19);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(39, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "E-Mail:";
            // 
            // textTel
            // 
            this.textTel.Location = new System.Drawing.Point(80, 41);
            this.textTel.Name = "textTel";
            this.textTel.Size = new System.Drawing.Size(74, 20);
            this.textTel.TabIndex = 2;
            this.textTel.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textTel_KeyPress);
            // 
            // btn_salir
            // 
            this.btn_salir.Location = new System.Drawing.Point(188, 188);
            this.btn_salir.Name = "btn_salir";
            this.btn_salir.Size = new System.Drawing.Size(75, 23);
            this.btn_salir.TabIndex = 9;
            this.btn_salir.Text = "Atras";
            this.btn_salir.UseVisualStyleBackColor = true;
            this.btn_salir.Click += new System.EventHandler(this.btn_salir_Click);
            // 
            // errorProv
            // 
            this.errorProv.ContainerControl = this;
            // 
            // Modif_Afiliado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 228);
            this.Controls.Add(this.btn_salir);
            this.Controls.Add(this.grupoDatos);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "Modif_Afiliado";
            this.Text = "Modificación de Afiliado";
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.grupoDatos, 0);
            this.Controls.SetChildIndex(this.btn_salir, 0);
            this.grupoDatos.ResumeLayout(false);
            this.grupoDatos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textCantFam)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProv)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grupoDatos;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textMail;
        private System.Windows.Forms.TextBox textDom;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textTel;
        private System.Windows.Forms.Button btn_guardar;
        private System.Windows.Forms.Button btn_limpiar;
        private System.Windows.Forms.Button btn_salir;
        private System.Windows.Forms.NumericUpDown textCantFam;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox comboEstCiv;
        private System.Windows.Forms.ComboBox comboPlan;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ErrorProvider errorProv;
    }
}