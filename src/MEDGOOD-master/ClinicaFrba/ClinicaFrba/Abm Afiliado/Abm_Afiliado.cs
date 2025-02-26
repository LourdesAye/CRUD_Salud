using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicaFrba.Abm_Afiliado
{
    public partial class AbmAfiliado : FormBase
    {
        public AbmAfiliado()
        {
            InitializeComponent();
        }

        private void btn_alta_afiliado_Click(object sender, EventArgs e)
        {
            //Pantalla de alta de Afiliado
            (new Alta_Afiliado(1,0)).Show();
        }

        private void btn_modif_afiliado_Click(object sender, EventArgs e)
        {
            (new Busq_Modif_Afiliado()).Show();
            //Pantalla de modificación de afiliado
        }

        private void btn_baja_afiliado_Click(object sender, EventArgs e)
        {
            (new Busq_Baja_Afiliado()).Show();
            //Pantalla de baja de afiliado
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AbmAfiliado_Load(object sender, EventArgs e)
        {

        }
    }
}
