namespace ClinicaFrba.Compra_Bono
{
    partial class Busqueda_Afiliado_Comprador
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
            this.dgv_afiliados = new System.Windows.Forms.DataGridView();
            this.btn_comprar_bono = new System.Windows.Forms.Button();
            this.txt_num_afiliado = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_buscar_afiliado_comprador = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_afiliados)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(-1, -13);
            this.label1.Size = new System.Drawing.Size(213, 77);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(329, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(164, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Búsqueda del afiliado comprador:";
            // 
            // dgv_afiliados
            // 
            this.dgv_afiliados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_afiliados.Location = new System.Drawing.Point(71, 114);
            this.dgv_afiliados.Name = "dgv_afiliados";
            this.dgv_afiliados.Size = new System.Drawing.Size(748, 150);
            this.dgv_afiliados.TabIndex = 2;
            // 
            // btn_comprar_bono
            // 
            this.btn_comprar_bono.Location = new System.Drawing.Point(377, 283);
            this.btn_comprar_bono.Name = "btn_comprar_bono";
            this.btn_comprar_bono.Size = new System.Drawing.Size(75, 23);
            this.btn_comprar_bono.TabIndex = 3;
            this.btn_comprar_bono.Text = "comprar";
            this.btn_comprar_bono.UseVisualStyleBackColor = true;
            this.btn_comprar_bono.Click += new System.EventHandler(this.btn_comprar_bono_Click);
            // 
            // txt_num_afiliado
            // 
            this.txt_num_afiliado.Location = new System.Drawing.Point(332, 74);
            this.txt_num_afiliado.Name = "txt_num_afiliado";
            this.txt_num_afiliado.Size = new System.Drawing.Size(120, 20);
            this.txt_num_afiliado.TabIndex = 8;
            this.txt_num_afiliado.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_num_afiliado_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(230, 81);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "número de afiliado:";
            // 
            // btn_buscar_afiliado_comprador
            // 
            this.btn_buscar_afiliado_comprador.Location = new System.Drawing.Point(458, 71);
            this.btn_buscar_afiliado_comprador.Name = "btn_buscar_afiliado_comprador";
            this.btn_buscar_afiliado_comprador.Size = new System.Drawing.Size(100, 23);
            this.btn_buscar_afiliado_comprador.TabIndex = 9;
            this.btn_buscar_afiliado_comprador.Text = "buscar afiliado";
            this.btn_buscar_afiliado_comprador.UseVisualStyleBackColor = true;
            this.btn_buscar_afiliado_comprador.Click += new System.EventHandler(this.btn_buscar_afiliado_comprador_Click);
            // 
            // Busqueda_Afiliado_Comprador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(866, 318);
            this.Controls.Add(this.btn_buscar_afiliado_comprador);
            this.Controls.Add(this.txt_num_afiliado);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btn_comprar_bono);
            this.Controls.Add(this.dgv_afiliados);
            this.Controls.Add(this.label2);
            this.Name = "Busqueda_Afiliado_Comprador";
            this.Text = "Busqueda_Afiliado_Comprador";
            this.Load += new System.EventHandler(this.Busqueda_Afiliado_Comprador_Load);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.dgv_afiliados, 0);
            this.Controls.SetChildIndex(this.btn_comprar_bono, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.txt_num_afiliado, 0);
            this.Controls.SetChildIndex(this.btn_buscar_afiliado_comprador, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_afiliados)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgv_afiliados;
        private System.Windows.Forms.Button btn_comprar_bono;
        private System.Windows.Forms.TextBox txt_num_afiliado;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btn_buscar_afiliado_comprador;
    }
}