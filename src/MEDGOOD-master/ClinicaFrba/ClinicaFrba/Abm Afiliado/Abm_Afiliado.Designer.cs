namespace ClinicaFrba.Abm_Afiliado
{
    partial class AbmAfiliado
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
            this.btn_alta_afiliado = new System.Windows.Forms.Button();
            this.btn_modif_afiliado = new System.Windows.Forms.Button();
            this.btn_baja_afiliado = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_alta_afiliado
            // 
            this.btn_alta_afiliado.Location = new System.Drawing.Point(189, 73);
            this.btn_alta_afiliado.Name = "btn_alta_afiliado";
            this.btn_alta_afiliado.Size = new System.Drawing.Size(130, 23);
            this.btn_alta_afiliado.TabIndex = 1;
            this.btn_alta_afiliado.Text = "Alta de Afiliado";
            this.btn_alta_afiliado.UseVisualStyleBackColor = true;
            this.btn_alta_afiliado.Click += new System.EventHandler(this.btn_alta_afiliado_Click);
            // 
            // btn_modif_afiliado
            // 
            this.btn_modif_afiliado.Location = new System.Drawing.Point(189, 102);
            this.btn_modif_afiliado.Name = "btn_modif_afiliado";
            this.btn_modif_afiliado.Size = new System.Drawing.Size(130, 23);
            this.btn_modif_afiliado.TabIndex = 2;
            this.btn_modif_afiliado.Text = "Modificación de Afiliado";
            this.btn_modif_afiliado.UseVisualStyleBackColor = true;
            this.btn_modif_afiliado.Click += new System.EventHandler(this.btn_modif_afiliado_Click);
            // 
            // btn_baja_afiliado
            // 
            this.btn_baja_afiliado.Location = new System.Drawing.Point(189, 131);
            this.btn_baja_afiliado.Name = "btn_baja_afiliado";
            this.btn_baja_afiliado.Size = new System.Drawing.Size(130, 23);
            this.btn_baja_afiliado.TabIndex = 3;
            this.btn_baja_afiliado.Text = "Baja de Afiliado";
            this.btn_baja_afiliado.UseVisualStyleBackColor = true;
            this.btn_baja_afiliado.Click += new System.EventHandler(this.btn_baja_afiliado_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(10, 131);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(48, 23);
            this.btnSalir.TabIndex = 4;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.button1_Click);
            // 
            // AbmAfiliado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(367, 181);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btn_baja_afiliado);
            this.Controls.Add(this.btn_modif_afiliado);
            this.Controls.Add(this.btn_alta_afiliado);
            this.Name = "AbmAfiliado";
            this.Text = "ABM de Afiliados";
            this.Load += new System.EventHandler(this.AbmAfiliado_Load);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.btn_alta_afiliado, 0);
            this.Controls.SetChildIndex(this.btn_modif_afiliado, 0);
            this.Controls.SetChildIndex(this.btn_baja_afiliado, 0);
            this.Controls.SetChildIndex(this.btnSalir, 0);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_alta_afiliado;
        private System.Windows.Forms.Button btn_modif_afiliado;
        private System.Windows.Forms.Button btn_baja_afiliado;
        private System.Windows.Forms.Button btnSalir;

    }
}