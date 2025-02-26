namespace ClinicaFrba.AbmRol
{
    partial class CambiarNombreRol
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
            this.txt_nombreRol = new System.Windows.Forms.TextBox();
            this.btn_modficarNombre_rol = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(40, 111);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 18);
            this.label2.TabIndex = 2;
            this.label2.Text = "Nombre del Rol:";
            // 
            // txt_nombreRol
            // 
            this.txt_nombreRol.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_nombreRol.Location = new System.Drawing.Point(162, 105);
            this.txt_nombreRol.Name = "txt_nombreRol";
            this.txt_nombreRol.Size = new System.Drawing.Size(176, 24);
            this.txt_nombreRol.TabIndex = 3;
            // 
            // btn_modficarNombre_rol
            // 
            this.btn_modficarNombre_rol.Location = new System.Drawing.Point(149, 161);
            this.btn_modficarNombre_rol.Name = "btn_modficarNombre_rol";
            this.btn_modficarNombre_rol.Size = new System.Drawing.Size(75, 23);
            this.btn_modficarNombre_rol.TabIndex = 6;
            this.btn_modficarNombre_rol.Text = "Aceptar";
            this.btn_modficarNombre_rol.UseVisualStyleBackColor = true;
            this.btn_modficarNombre_rol.Click += new System.EventHandler(this.button1_Click);
            // 
            // CambiarNombreRol
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 236);
            this.Controls.Add(this.btn_modficarNombre_rol);
            this.Controls.Add(this.txt_nombreRol);
            this.Controls.Add(this.label2);
            this.Name = "CambiarNombreRol";
            this.Text = "Cambiar Nombre Rol";
            this.Load += new System.EventHandler(this.CambiarNombreRol_Load);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.txt_nombreRol, 0);
            this.Controls.SetChildIndex(this.btn_modficarNombre_rol, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_nombreRol;
        private System.Windows.Forms.Button btn_modficarNombre_rol;
    }
}