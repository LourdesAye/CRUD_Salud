namespace ClinicaFrba.Login
{
    partial class FormElegirRol
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
            this.comboBox_roles = new System.Windows.Forms.ComboBox();
            this.btn_rolAceptado = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(72, 123);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(327, 18);
            this.label2.TabIndex = 1;
            this.label2.Text = "Seleccione el rol con el que desea iniciar sesión:";
            // 
            // comboBox_roles
            // 
            this.comboBox_roles.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_roles.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox_roles.FormattingEnabled = true;
            this.comboBox_roles.Location = new System.Drawing.Point(116, 166);
            this.comboBox_roles.Margin = new System.Windows.Forms.Padding(4);
            this.comboBox_roles.Name = "comboBox_roles";
            this.comboBox_roles.Size = new System.Drawing.Size(250, 26);
            this.comboBox_roles.TabIndex = 2;
            this.comboBox_roles.SelectedIndexChanged += new System.EventHandler(this.comboBox_roles_SelectedIndexChanged);
            // 
            // btn_rolAceptado
            // 
            this.btn_rolAceptado.Location = new System.Drawing.Point(196, 222);
            this.btn_rolAceptado.Margin = new System.Windows.Forms.Padding(4);
            this.btn_rolAceptado.Name = "btn_rolAceptado";
            this.btn_rolAceptado.Size = new System.Drawing.Size(112, 32);
            this.btn_rolAceptado.TabIndex = 3;
            this.btn_rolAceptado.Text = "Aceptar";
            this.btn_rolAceptado.UseVisualStyleBackColor = true;
            this.btn_rolAceptado.Click += new System.EventHandler(this.btn_rolAceptado_Click);
            // 
            // FormElegirRol
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(487, 305);
            this.Controls.Add(this.btn_rolAceptado);
            this.Controls.Add(this.comboBox_roles);
            this.Controls.Add(this.label2);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormElegirRol";
            this.Text = "Elegir Rol";
            this.Load += new System.EventHandler(this.FormElegirRol_Load);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.comboBox_roles, 0);
            this.Controls.SetChildIndex(this.btn_rolAceptado, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox_roles;
        private System.Windows.Forms.Button btn_rolAceptado;
    }
}