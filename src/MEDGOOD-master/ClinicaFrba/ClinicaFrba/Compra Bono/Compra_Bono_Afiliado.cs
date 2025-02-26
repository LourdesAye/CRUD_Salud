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
    public partial class Compra_Bono_Afiliado : FormBase
    {
        public Afiliado afiliado;


        public Compra_Bono_Afiliado()
        {
            InitializeComponent();
        }

        public Compra_Bono_Afiliado(Usuario usuario)
            : this()
        {
            afiliado = new Afiliado();
            afiliado.codigoDeUsuario = usuario.codigoDeUsuario;
            afiliado.cargateConTuplan();
        }

        public Compra_Bono_Afiliado(Afiliado afil)
            : this()
        {
            afiliado = afil;

        }

        private void Compra_Bono_Afiliado_Load(object sender, EventArgs e)
        {

        }

        protected void btn_compra_Click(object sender, EventArgs e)
        {
            //validar afiliado activo=no baja logica,no usu_inhabilitado,que tenga un plan
            if (afiliado.fueBorrado())
            {
                MessageBox.Show("El afiliado número:" + afiliado.codigoAfiliado + " no se encuentra activo, no posee plan ", "Error compra de bonos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                CompraBono compra = new CompraBono();
                compra.numeroAfiliadoComprador = afiliado.codigoAfiliado;
                compra.codAfiliadoComprador = afiliado.idAfiliado;
                compra.cantidadBonosComprados = numericUpDown_cant_bonos.Value;
                compra.precioUnitarioBonoConsulta = afiliado.planMedico.precio_bono_consulta;
                compra.fechacompra = obtenerFecha();
                //aca modificaciones en la tabla bonos y compraBonos
                compra.registrate();
                Hide();
                //muestra el total a pagar, informa compra del bono
                Compra_Exitosa panelCompra = new Compra_Exitosa(compra);
                panelCompra.ShowDialog();
                Close();
            }

        }
    }
}
