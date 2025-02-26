namespace ClinicaFrba.AbmRol
{
    partial class ModificarRol
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
            this.btn_cambiar_nombre_rol = new System.Windows.Forms.Button();
            this.btn_habilitar = new System.Windows.Forms.Button();
            this.btn_inhabilitar = new System.Windows.Forms.Button();
            this.btn_modificar_funcionalidades = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_cambiar_nombre_rol
            // 
            this.btn_cambiar_nombre_rol.Location = new System.Drawing.Point(101, 162);
            this.btn_cambiar_nombre_rol.Name = "btn_cambiar_nombre_rol";
            this.btn_cambiar_nombre_rol.Size = new System.Drawing.Size(137, 23);
            this.btn_cambiar_nombre_rol.TabIndex = 1;
            this.btn_cambiar_nombre_rol.Text = "cambiar nombre";
            this.btn_cambiar_nombre_rol.UseVisualStyleBackColor = true;
            this.btn_cambiar_nombre_rol.Click += new System.EventHandler(this.btn_cambiar_nombre_rol_Click);
            // 
            // btn_habilitar
            // 
            this.btn_habilitar.Location = new System.Drawing.Point(101, 84);
            this.btn_habilitar.Name = "btn_habilitar";
            this.btn_habilitar.Size = new System.Drawing.Size(137, 23);
            this.btn_habilitar.TabIndex = 2;
            this.btn_habilitar.Text = "habilitar";
            this.btn_habilitar.UseVisualStyleBackColor = true;
            this.btn_habilitar.Click += new System.EventHandler(this.btn_habilitar_Click);
            // 
            // btn_inhabilitar
            // 
            this.btn_inhabilitar.Location = new System.Drawing.Point(101, 123);
            this.btn_inhabilitar.Name = "btn_inhabilitar";
            this.btn_inhabilitar.Size = new System.Drawing.Size(137, 23);
            this.btn_inhabilitar.TabIndex = 3;
            this.btn_inhabilitar.Text = "inhabilitar";
            this.btn_inhabilitar.UseVisualStyleBackColor = true;
            this.btn_inhabilitar.Click += new System.EventHandler(this.btn_inhabilitar_Click);
            // 
            // btn_modificar_funcionalidades
            // 
            this.btn_modificar_funcionalidades.Location = new System.Drawing.Point(101, 201);
            this.btn_modificar_funcionalidades.Name = "btn_modificar_funcionalidades";
            this.btn_modificar_funcionalidades.Size = new System.Drawing.Size(137, 23);
            this.btn_modificar_funcionalidades.TabIndex = 4;
            this.btn_modificar_funcionalidades.Text = "modificar funcionalidad";
            this.btn_modificar_funcionalidades.UseVisualStyleBackColor = true;
            this.btn_modificar_funcionalidades.Click += new System.EventHandler(this.btn_modificar_funcionalidades_Click);
            // 
            // ModificarRol
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(322, 259);
            this.Controls.Add(this.btn_modificar_funcionalidades);
            this.Controls.Add(this.btn_inhabilitar);
            this.Controls.Add(this.btn_habilitar);
            this.Controls.Add(this.btn_cambiar_nombre_rol);
            this.Name = "ModificarRol";
            this.Text = "Modificar Rol";
            this.Load += new System.EventHandler(this.ModificarRol_Load);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.btn_cambiar_nombre_rol, 0);
            this.Controls.SetChildIndex(this.btn_habilitar, 0);
            this.Controls.SetChildIndex(this.btn_inhabilitar, 0);
            this.Controls.SetChildIndex(this.btn_modificar_funcionalidades, 0);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_cambiar_nombre_rol;
        private System.Windows.Forms.Button btn_habilitar;
        private System.Windows.Forms.Button btn_inhabilitar;
        private System.Windows.Forms.Button btn_modificar_funcionalidades;
    }
}