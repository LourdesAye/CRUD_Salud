namespace ClinicaFrba.AbmRol
{
    partial class NuevoRol
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
            this.txt_nombreRol = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dataGridFuncionalidades = new System.Windows.Forms.DataGridView();
            this.btn_nuevo_rol = new System.Windows.Forms.Button();
            this.error_nombreRol = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridFuncionalidades)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.error_nombreRol)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(78, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 18);
            this.label2.TabIndex = 1;
            this.label2.Text = "Nombre del Rol:";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // txt_nombreRol
            // 
            this.txt_nombreRol.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_nombreRol.Location = new System.Drawing.Point(200, 81);
            this.txt_nombreRol.Name = "txt_nombreRol";
            this.txt_nombreRol.Size = new System.Drawing.Size(176, 24);
            this.txt_nombreRol.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(197, 133);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(119, 18);
            this.label3.TabIndex = 3;
            this.label3.Text = "Funcionalidades:";
            // 
            // dataGridFuncionalidades
            // 
            this.dataGridFuncionalidades.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridFuncionalidades.Location = new System.Drawing.Point(81, 154);
            this.dataGridFuncionalidades.Name = "dataGridFuncionalidades";
            this.dataGridFuncionalidades.Size = new System.Drawing.Size(341, 150);
            this.dataGridFuncionalidades.TabIndex = 4;
            this.dataGridFuncionalidades.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // btn_nuevo_rol
            // 
            this.btn_nuevo_rol.Location = new System.Drawing.Point(241, 317);
            this.btn_nuevo_rol.Name = "btn_nuevo_rol";
            this.btn_nuevo_rol.Size = new System.Drawing.Size(75, 23);
            this.btn_nuevo_rol.TabIndex = 5;
            this.btn_nuevo_rol.Text = "Aceptar";
            this.btn_nuevo_rol.UseVisualStyleBackColor = true;
            this.btn_nuevo_rol.Click += new System.EventHandler(this.button1_Click);
            // 
            // error_nombreRol
            // 
            this.error_nombreRol.ContainerControl = this;
            // 
            // NuevoRol
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(538, 352);
            this.Controls.Add(this.btn_nuevo_rol);
            this.Controls.Add(this.dataGridFuncionalidades);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txt_nombreRol);
            this.Controls.Add(this.label2);
            this.Name = "NuevoRol";
            this.Text = "Nuevo Rol";
            this.Load += new System.EventHandler(this.NuevoOModificarRol_Load);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.txt_nombreRol, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.dataGridFuncionalidades, 0);
            this.Controls.SetChildIndex(this.btn_nuevo_rol, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridFuncionalidades)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.error_nombreRol)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_nombreRol;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dataGridFuncionalidades;
        private System.Windows.Forms.Button btn_nuevo_rol;
        private System.Windows.Forms.ErrorProvider error_nombreRol;
    }
}