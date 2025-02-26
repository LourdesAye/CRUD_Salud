namespace ClinicaFrba.Login
{
    partial class FormMenuPrincipal
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
            this.btn_abm_roles = new System.Windows.Forms.Button();
            this.btn_abm_afiliados = new System.Windows.Forms.Button();
            this.btn_registro_aagenda = new System.Windows.Forms.Button();
            this.btn_compra_bonos = new System.Windows.Forms.Button();
            this.btn_solicitar_turno = new System.Windows.Forms.Button();
            this.btn_registro_llegada = new System.Windows.Forms.Button();
            this.btn_registro_atencion = new System.Windows.Forms.Button();
            this.btn_cancelar_atencion_medica = new System.Windows.Forms.Button();
            this.btn_listado_estadistico = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_abm_roles
            // 
            this.btn_abm_roles.Location = new System.Drawing.Point(136, 95);
            this.btn_abm_roles.Name = "btn_abm_roles";
            this.btn_abm_roles.Size = new System.Drawing.Size(170, 23);
            this.btn_abm_roles.TabIndex = 1;
            this.btn_abm_roles.Text = "ABM de Roles";
            this.btn_abm_roles.UseVisualStyleBackColor = true;
            this.btn_abm_roles.Click += new System.EventHandler(this.abm_rol_Click);
            // 
            // btn_abm_afiliados
            // 
            this.btn_abm_afiliados.Location = new System.Drawing.Point(136, 124);
            this.btn_abm_afiliados.Name = "btn_abm_afiliados";
            this.btn_abm_afiliados.Size = new System.Drawing.Size(170, 23);
            this.btn_abm_afiliados.TabIndex = 2;
            this.btn_abm_afiliados.Text = "ABM de Afiliados";
            this.btn_abm_afiliados.UseVisualStyleBackColor = true;
            this.btn_abm_afiliados.Click += new System.EventHandler(this.button2_Click);
            // 
            // btn_registro_aagenda
            // 
            this.btn_registro_aagenda.Location = new System.Drawing.Point(136, 153);
            this.btn_registro_aagenda.Name = "btn_registro_aagenda";
            this.btn_registro_aagenda.Size = new System.Drawing.Size(170, 23);
            this.btn_registro_aagenda.TabIndex = 3;
            this.btn_registro_aagenda.Text = "Registrar Agenda";
            this.btn_registro_aagenda.UseVisualStyleBackColor = true;
            this.btn_registro_aagenda.Click += new System.EventHandler(this.btn_registro_aagenda_Click);
            // 
            // btn_compra_bonos
            // 
            this.btn_compra_bonos.Location = new System.Drawing.Point(136, 182);
            this.btn_compra_bonos.Name = "btn_compra_bonos";
            this.btn_compra_bonos.Size = new System.Drawing.Size(170, 23);
            this.btn_compra_bonos.TabIndex = 4;
            this.btn_compra_bonos.Text = "Comprar Bonos";
            this.btn_compra_bonos.UseVisualStyleBackColor = true;
            this.btn_compra_bonos.Click += new System.EventHandler(this.button4_Click);
            // 
            // btn_solicitar_turno
            // 
            this.btn_solicitar_turno.Location = new System.Drawing.Point(136, 211);
            this.btn_solicitar_turno.Name = "btn_solicitar_turno";
            this.btn_solicitar_turno.Size = new System.Drawing.Size(170, 23);
            this.btn_solicitar_turno.TabIndex = 5;
            this.btn_solicitar_turno.Text = "Pedir Turno";
            this.btn_solicitar_turno.UseVisualStyleBackColor = true;
            this.btn_solicitar_turno.Click += new System.EventHandler(this.btn_solicitar_turno_Click);
            // 
            // btn_registro_llegada
            // 
            this.btn_registro_llegada.Location = new System.Drawing.Point(136, 240);
            this.btn_registro_llegada.Name = "btn_registro_llegada";
            this.btn_registro_llegada.Size = new System.Drawing.Size(170, 23);
            this.btn_registro_llegada.TabIndex = 6;
            this.btn_registro_llegada.Text = "Registro de llegada atencion medica";
            this.btn_registro_llegada.UseVisualStyleBackColor = true;
            this.btn_registro_llegada.Click += new System.EventHandler(this.button6_Click);
            // 
            // btn_registro_atencion
            // 
            this.btn_registro_atencion.Location = new System.Drawing.Point(136, 269);
            this.btn_registro_atencion.Name = "btn_registro_atencion";
            this.btn_registro_atencion.Size = new System.Drawing.Size(170, 23);
            this.btn_registro_atencion.TabIndex = 8;
            this.btn_registro_atencion.Text = "Registro Resultado atencion medica";
            this.btn_registro_atencion.UseVisualStyleBackColor = true;
            this.btn_registro_atencion.Click += new System.EventHandler(this.button8_Click);
            // 
            // btn_cancelar_atencion_medica
            // 
            this.btn_cancelar_atencion_medica.Location = new System.Drawing.Point(136, 298);
            this.btn_cancelar_atencion_medica.Name = "btn_cancelar_atencion_medica";
            this.btn_cancelar_atencion_medica.Size = new System.Drawing.Size(170, 23);
            this.btn_cancelar_atencion_medica.TabIndex = 9;
            this.btn_cancelar_atencion_medica.Text = "Cancelar atencion medica";
            this.btn_cancelar_atencion_medica.UseVisualStyleBackColor = true;
            this.btn_cancelar_atencion_medica.Click += new System.EventHandler(this.btn_cancelar_atencion_medica_Click);
            // 
            // btn_listado_estadistico
            // 
            this.btn_listado_estadistico.Location = new System.Drawing.Point(136, 327);
            this.btn_listado_estadistico.Name = "btn_listado_estadistico";
            this.btn_listado_estadistico.Size = new System.Drawing.Size(170, 23);
            this.btn_listado_estadistico.TabIndex = 10;
            this.btn_listado_estadistico.Text = "Listado Estadistico";
            this.btn_listado_estadistico.UseVisualStyleBackColor = true;
            this.btn_listado_estadistico.Click += new System.EventHandler(this.btn_listado_estadistico_Click);
            // 
            // FormMenuPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(454, 378);
            this.Controls.Add(this.btn_listado_estadistico);
            this.Controls.Add(this.btn_cancelar_atencion_medica);
            this.Controls.Add(this.btn_registro_atencion);
            this.Controls.Add(this.btn_registro_llegada);
            this.Controls.Add(this.btn_solicitar_turno);
            this.Controls.Add(this.btn_compra_bonos);
            this.Controls.Add(this.btn_registro_aagenda);
            this.Controls.Add(this.btn_abm_afiliados);
            this.Controls.Add(this.btn_abm_roles);
            this.Name = "FormMenuPrincipal";
            this.Text = "Menú";
            this.Load += new System.EventHandler(this.FormMenuPrincipal_Load);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.btn_abm_roles, 0);
            this.Controls.SetChildIndex(this.btn_abm_afiliados, 0);
            this.Controls.SetChildIndex(this.btn_registro_aagenda, 0);
            this.Controls.SetChildIndex(this.btn_compra_bonos, 0);
            this.Controls.SetChildIndex(this.btn_solicitar_turno, 0);
            this.Controls.SetChildIndex(this.btn_registro_llegada, 0);
            this.Controls.SetChildIndex(this.btn_registro_atencion, 0);
            this.Controls.SetChildIndex(this.btn_cancelar_atencion_medica, 0);
            this.Controls.SetChildIndex(this.btn_listado_estadistico, 0);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_abm_roles;
        private System.Windows.Forms.Button btn_abm_afiliados;
        private System.Windows.Forms.Button btn_registro_aagenda;
        private System.Windows.Forms.Button btn_compra_bonos;
        private System.Windows.Forms.Button btn_solicitar_turno;
        private System.Windows.Forms.Button btn_registro_llegada;
        private System.Windows.Forms.Button btn_registro_atencion;
        private System.Windows.Forms.Button btn_cancelar_atencion_medica;
        private System.Windows.Forms.Button btn_listado_estadistico;
    }
}