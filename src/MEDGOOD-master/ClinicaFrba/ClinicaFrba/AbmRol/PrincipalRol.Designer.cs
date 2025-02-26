namespace ClinicaFrba.AbmRol
{
    partial class PrincipalRol
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
            this.dataGridRol = new System.Windows.Forms.DataGridView();
            this.btn_nuevo_rol = new System.Windows.Forms.Button();
            this.btn_modificar_rol = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridRol)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Size = new System.Drawing.Size(243, 87);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(134, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(123, 18);
            this.label2.TabIndex = 1;
            this.label2.Text = "Listado de Roles:";
            // 
            // dataGridRol
            // 
            this.dataGridRol.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridRol.Location = new System.Drawing.Point(32, 120);
            this.dataGridRol.Name = "dataGridRol";
            this.dataGridRol.Size = new System.Drawing.Size(405, 150);
            this.dataGridRol.TabIndex = 2;
            // 
            // btn_nuevo_rol
            // 
            this.btn_nuevo_rol.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_nuevo_rol.Location = new System.Drawing.Point(105, 291);
            this.btn_nuevo_rol.Name = "btn_nuevo_rol";
            this.btn_nuevo_rol.Size = new System.Drawing.Size(98, 29);
            this.btn_nuevo_rol.TabIndex = 3;
            this.btn_nuevo_rol.Text = "Nuevo Rol";
            this.btn_nuevo_rol.UseVisualStyleBackColor = true;
            this.btn_nuevo_rol.Click += new System.EventHandler(this.btn_nuevo_rol_Click);
            // 
            // btn_modificar_rol
            // 
            this.btn_modificar_rol.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_modificar_rol.Location = new System.Drawing.Point(230, 291);
            this.btn_modificar_rol.Name = "btn_modificar_rol";
            this.btn_modificar_rol.Size = new System.Drawing.Size(98, 29);
            this.btn_modificar_rol.TabIndex = 4;
            this.btn_modificar_rol.Text = "Modificar Rol";
            this.btn_modificar_rol.UseVisualStyleBackColor = true;
            this.btn_modificar_rol.Click += new System.EventHandler(this.btn_modificar_rol_Click);
            // 
            // PrincipalRol
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(478, 344);
            this.Controls.Add(this.btn_modificar_rol);
            this.Controls.Add(this.btn_nuevo_rol);
            this.Controls.Add(this.dataGridRol);
            this.Controls.Add(this.label2);
            this.Name = "PrincipalRol";
            this.Text = "Roles";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.dataGridRol, 0);
            this.Controls.SetChildIndex(this.btn_nuevo_rol, 0);
            this.Controls.SetChildIndex(this.btn_modificar_rol, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridRol)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dataGridRol;
        private System.Windows.Forms.Button btn_nuevo_rol;
        private System.Windows.Forms.Button btn_modificar_rol;
    }
}