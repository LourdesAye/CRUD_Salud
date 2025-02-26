namespace ClinicaFrba.Registro_Llegada
{
    partial class Pagar_Consulta
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
            this.dgv_bonos_disponibles = new System.Windows.Forms.DataGridView();
            this.btn_pagar_consulta = new System.Windows.Forms.Button();
            this.label_cant_bonos_disponibles = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_bonos_disponibles)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(1, -2);
            this.label1.Size = new System.Drawing.Size(194, 79);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(79, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(287, 18);
            this.label2.TabIndex = 1;
            this.label2.Text = "Cantidad de bonos disponibles del afiliado:";
            // 
            // dgv_bonos_disponibles
            // 
            this.dgv_bonos_disponibles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_bonos_disponibles.Location = new System.Drawing.Point(40, 112);
            this.dgv_bonos_disponibles.Name = "dgv_bonos_disponibles";
            this.dgv_bonos_disponibles.Size = new System.Drawing.Size(534, 150);
            this.dgv_bonos_disponibles.TabIndex = 2;
            // 
            // btn_pagar_consulta
            // 
            this.btn_pagar_consulta.Location = new System.Drawing.Point(252, 285);
            this.btn_pagar_consulta.Name = "btn_pagar_consulta";
            this.btn_pagar_consulta.Size = new System.Drawing.Size(104, 23);
            this.btn_pagar_consulta.TabIndex = 3;
            this.btn_pagar_consulta.Text = "Pagar Consulta";
            this.btn_pagar_consulta.UseVisualStyleBackColor = true;
            this.btn_pagar_consulta.Click += new System.EventHandler(this.button1_Click);
            // 
            // label_cant_bonos_disponibles
            // 
            this.label_cant_bonos_disponibles.AutoSize = true;
            this.label_cant_bonos_disponibles.Location = new System.Drawing.Point(372, 86);
            this.label_cant_bonos_disponibles.Name = "label_cant_bonos_disponibles";
            this.label_cant_bonos_disponibles.Size = new System.Drawing.Size(0, 13);
            this.label_cant_bonos_disponibles.TabIndex = 4;
            // 
            // Pagar_Consulta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(623, 320);
            this.Controls.Add(this.label_cant_bonos_disponibles);
            this.Controls.Add(this.btn_pagar_consulta);
            this.Controls.Add(this.dgv_bonos_disponibles);
            this.Controls.Add(this.label2);
            this.Name = "Pagar_Consulta";
            this.Text = "Pagar_Consulta";
            this.Load += new System.EventHandler(this.Pagar_Consulta_Load);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.dgv_bonos_disponibles, 0);
            this.Controls.SetChildIndex(this.btn_pagar_consulta, 0);
            this.Controls.SetChildIndex(this.label_cant_bonos_disponibles, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_bonos_disponibles)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgv_bonos_disponibles;
        private System.Windows.Forms.Button btn_pagar_consulta;
        private System.Windows.Forms.Label label_cant_bonos_disponibles;
    }
}