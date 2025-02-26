namespace ClinicaFrba.Compra_Bono
{
    partial class Compra_Exitosa
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
            this.label3 = new System.Windows.Forms.Label();
            this.label_cod_afiliado = new System.Windows.Forms.Label();
            this.label = new System.Windows.Forms.Label();
            this.label_cant_compra_bonos = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label_total_a_pagar = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(21, 12);
            this.label1.Size = new System.Drawing.Size(188, 75);
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(147, 98);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(318, 24);
            this.label2.TabIndex = 1;
            this.label2.Text = "La compra se ha realizado con éxito:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(185, 162);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(122, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Código de Afiliado:";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label_cod_afiliado
            // 
            this.label_cod_afiliado.AutoSize = true;
            this.label_cod_afiliado.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_cod_afiliado.Location = new System.Drawing.Point(313, 162);
            this.label_cod_afiliado.Name = "label_cod_afiliado";
            this.label_cod_afiliado.Size = new System.Drawing.Size(0, 16);
            this.label_cod_afiliado.TabIndex = 3;
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label.Location = new System.Drawing.Point(109, 189);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(198, 16);
            this.label.TabIndex = 4;
            this.label.Text = "Cantidad de Bonos comprados:";
            // 
            // label_cant_compra_bonos
            // 
            this.label_cant_compra_bonos.AutoSize = true;
            this.label_cant_compra_bonos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_cant_compra_bonos.Location = new System.Drawing.Point(313, 189);
            this.label_cant_compra_bonos.Name = "label_cant_compra_bonos";
            this.label_cant_compra_bonos.Size = new System.Drawing.Size(0, 16);
            this.label_cant_compra_bonos.TabIndex = 5;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(209, 220);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(98, 16);
            this.label7.TabIndex = 6;
            this.label7.Text = "Monto a pagar:";
            // 
            // label_total_a_pagar
            // 
            this.label_total_a_pagar.AutoSize = true;
            this.label_total_a_pagar.Location = new System.Drawing.Point(313, 223);
            this.label_total_a_pagar.Name = "label_total_a_pagar";
            this.label_total_a_pagar.Size = new System.Drawing.Size(0, 13);
            this.label_total_a_pagar.TabIndex = 7;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(264, 267);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = "Aceptar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Compra_Exitosa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(620, 364);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label_total_a_pagar);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label_cant_compra_bonos);
            this.Controls.Add(this.label);
            this.Controls.Add(this.label_cod_afiliado);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Name = "Compra_Exitosa";
            this.Text = "Compra_Exitosa";
            this.Load += new System.EventHandler(this.Compra_Exitosa_Load);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.label_cod_afiliado, 0);
            this.Controls.SetChildIndex(this.label, 0);
            this.Controls.SetChildIndex(this.label_cant_compra_bonos, 0);
            this.Controls.SetChildIndex(this.label7, 0);
            this.Controls.SetChildIndex(this.label_total_a_pagar, 0);
            this.Controls.SetChildIndex(this.button1, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label_cod_afiliado;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.Label label_cant_compra_bonos;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label_total_a_pagar;
        private System.Windows.Forms.Button button1;
    }
}