using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClinicaFrba.Modelo;

namespace ClinicaFrba.Compra_Bono
{
    public partial class Compra_Exitosa : FormBase
    {
        private Modelo.CompraBono compra;

        public Compra_Exitosa()
        {
           
        }
        

        public Compra_Exitosa(CompraBono compraExitosa)
        {
            InitializeComponent();
            this.compra = compraExitosa;
            this.label_cod_afiliado.Text = Convert.ToString(compra.numeroAfiliadoComprador);
            this.label_cant_compra_bonos.Text = Convert.ToString(compra.cantidadBonosComprados);
            this.label_total_a_pagar.Text = Convert.ToString(compra.totalAPagar);
            
        }

        private void Compra_Exitosa_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
