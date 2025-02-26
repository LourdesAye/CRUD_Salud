namespace ClinicaFrba.Pedir_Turno
{
    partial class Busqueda_Prof
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
            this.data_prof = new System.Windows.Forms.DataGridView();
            this.comboEspec = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.data_prof)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Size = new System.Drawing.Size(810, 173);
            // 
            // data_prof
            // 
            this.data_prof.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.data_prof.Location = new System.Drawing.Point(10, 160);
            this.data_prof.Name = "data_prof";
            this.data_prof.Size = new System.Drawing.Size(892, 175);
            this.data_prof.TabIndex = 9;
            this.data_prof.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.data_prof_CellContentClick);
            // 
            // comboEspec
            // 
            this.comboEspec.FormattingEnabled = true;
            this.comboEspec.Location = new System.Drawing.Point(192, 27);
            this.comboEspec.Name = "comboEspec";
            this.comboEspec.Size = new System.Drawing.Size(121, 21);
            this.comboEspec.TabIndex = 10;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnBuscar);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.comboEspec);
            this.groupBox1.Location = new System.Drawing.Point(12, 85);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(890, 69);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtro";
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(348, 25);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(75, 23);
            this.btnBuscar.TabIndex = 11;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(180, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Seleccione la especialidad deseada:";
            // 
            // Busqueda_Prof
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(914, 347);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.data_prof);
            this.Name = "Busqueda_Prof";
            this.Text = "Búsqueda de profesional";
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.data_prof, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.data_prof)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView data_prof;
        private System.Windows.Forms.ComboBox comboEspec;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnBuscar;
    }
}