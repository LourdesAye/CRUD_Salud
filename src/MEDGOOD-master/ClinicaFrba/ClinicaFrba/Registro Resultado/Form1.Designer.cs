namespace ClinicaFrba.Registro_Resultado
{
    partial class Registro_Resultado_Consulta_Medica
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
            this.button2 = new System.Windows.Forms.Button();
            this.dgv_consultas_pendientes = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_consultas_pendientes)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(1, -3);
            this.label1.Size = new System.Drawing.Size(188, 63);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(203, 289);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(145, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "Registrar Resultados";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // dgv_consultas_pendientes
            // 
            this.dgv_consultas_pendientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_consultas_pendientes.Location = new System.Drawing.Point(27, 114);
            this.dgv_consultas_pendientes.Name = "dgv_consultas_pendientes";
            this.dgv_consultas_pendientes.Size = new System.Drawing.Size(523, 150);
            this.dgv_consultas_pendientes.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(36, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(284, 18);
            this.label2.TabIndex = 5;
            this.label2.Text = "Registrar resultado de la consulta médica:";
            // 
            // Registro_Resultado_Consulta_Medica
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(574, 335);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgv_consultas_pendientes);
            this.Controls.Add(this.button2);
            this.Name = "Registro_Resultado_Consulta_Medica";
            this.Text = "Registrar Resultados Consulta";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.button2, 0);
            this.Controls.SetChildIndex(this.dgv_consultas_pendientes, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_consultas_pendientes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataGridView dgv_consultas_pendientes;
        private System.Windows.Forms.Label label2;
    }
}