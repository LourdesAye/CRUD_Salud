namespace ClinicaFrba.Compra_Bono
{
    partial class Compra_Bono_Afiliado
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
            this.btn_compra = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.numericUpDown_cant_bonos = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_cant_bonos)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Size = new System.Drawing.Size(224, 61);
            // 
            // btn_compra
            // 
            this.btn_compra.Location = new System.Drawing.Point(109, 176);
            this.btn_compra.Name = "btn_compra";
            this.btn_compra.Size = new System.Drawing.Size(75, 23);
            this.btn_compra.TabIndex = 2;
            this.btn_compra.Text = "Aceptar";
            this.btn_compra.UseVisualStyleBackColor = true;
            this.btn_compra.Click += new System.EventHandler(this.btn_compra_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(33, 117);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "cantidad de bonos:";
            // 
            // numericUpDown_cant_bonos
            // 
            this.numericUpDown_cant_bonos.Location = new System.Drawing.Point(150, 117);
            this.numericUpDown_cant_bonos.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown_cant_bonos.Name = "numericUpDown_cant_bonos";
            this.numericUpDown_cant_bonos.Size = new System.Drawing.Size(120, 20);
            this.numericUpDown_cant_bonos.TabIndex = 4;
            this.numericUpDown_cant_bonos.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // Compra_Bono_Afiliado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(328, 235);
            this.Controls.Add(this.numericUpDown_cant_bonos);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btn_compra);
            this.Name = "Compra_Bono_Afiliado";
            this.Text = "Compra_Bono_Afiliado";
            this.Load += new System.EventHandler(this.Compra_Bono_Afiliado_Load);
            this.Click += new System.EventHandler(this.btn_compra_Click);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.btn_compra, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.numericUpDown_cant_bonos, 0);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_cant_bonos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected System.Windows.Forms.Button btn_compra;
        protected System.Windows.Forms.Label label2;
        protected System.Windows.Forms.NumericUpDown numericUpDown_cant_bonos;

    }
}