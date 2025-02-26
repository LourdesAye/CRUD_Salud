using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClinicaFrba.Datos.Dao;
using ClinicaFrba.Modelo;

namespace ClinicaFrba.Compra_Bono
{
    public partial class Busqueda_Afiliado_Comprador : FormBase

    {
        public List<Afiliado> afiliados;

        public Busqueda_Afiliado_Comprador()
        {
            InitializeComponent();
            dgv_afiliados.AutoGenerateColumns = false;
            cargarGrillaTurnos();
        }

        private void cargarGrillaTurnos()
        {
            //pk de tabla usuario
            DataGridViewTextBoxColumn colIdUsuario = new DataGridViewTextBoxColumn();
            colIdUsuario.DataPropertyName = "codigoDeUsuario";
            colIdUsuario.HeaderText = "id usuario";
            colIdUsuario.Width = 120;
            //pk de tabla afiliado
            DataGridViewTextBoxColumn colIdAfiliado = new DataGridViewTextBoxColumn();
            colIdAfiliado.DataPropertyName = "idAfiliado";
            colIdAfiliado.HeaderText = "id afiliado";
            colIdAfiliado.Width = 120;
            //numero de afiliado, no pk
            DataGridViewTextBoxColumn colCodAfiliado = new DataGridViewTextBoxColumn();
            colCodAfiliado.DataPropertyName = "codigoAfiliado";
            colCodAfiliado.HeaderText = "Número de Afiliado";
            colCodAfiliado.Width = 120;
            //nombre afiliado
            DataGridViewTextBoxColumn colNombreAfiliado = new DataGridViewTextBoxColumn();
            colNombreAfiliado.DataPropertyName = "nombre";
            colNombreAfiliado.HeaderText = "Nombre";
            colNombreAfiliado.Width = 120;
            //apellido
            DataGridViewTextBoxColumn colApellido = new DataGridViewTextBoxColumn();
            colApellido.DataPropertyName = "apellido";
            colApellido.HeaderText = "Apellido";
            colApellido.Width = 120;
            //nroDocumento
            DataGridViewTextBoxColumn colNroDoc = new DataGridViewTextBoxColumn();
            colNroDoc.DataPropertyName = "nroDocumento";
            colNroDoc.HeaderText = "Número de documento";
            colNroDoc.Width = 120;

            dgv_afiliados.Columns.Add(colIdUsuario);
            dgv_afiliados.Columns.Add(colIdAfiliado);
            dgv_afiliados.Columns.Add(colCodAfiliado);
            dgv_afiliados.Columns.Add(colNroDoc);
            dgv_afiliados.Columns.Add(colNombreAfiliado);
            dgv_afiliados.Columns.Add(colApellido);
        }

        private void Busqueda_Afiliado_Comprador_Load(object sender, EventArgs e)
        {
            //List<Afiliado> afiliados = new List<Afiliado>();
               afiliados= DAOUsuario.getAfiliados();
               dgv_afiliados.DataSource = afiliados;
        }

        private void btn_buscar_afiliado_comprador_Click(object sender, EventArgs e)
        {
            if (txt_num_afiliado.Text.Length != 0)
            {
                List<Afiliado> afiliadosFiltrados = new List<Afiliado>();
                foreach (Afiliado afiliado in afiliados)
                {
                    if (afiliado.codigoAfiliado == Convert.ToDecimal(txt_num_afiliado.Text))
                    {
                        afiliadosFiltrados.Add(afiliado);
                    }
                }

                dgv_afiliados.DataSource = afiliadosFiltrados;
                if (afiliadosFiltrados.Count() == 0)
                {
                    MessageBox.Show("La búsqueda no tiene resultados, no hay coincidencias", "Resultados de Búsqueda", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }

            else { MessageBox.Show("No ha ingresado criterio de búsqueda", "Advertencia de Busqueda de Afiliado Comprador", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }
        }

        private void btn_comprar_bono_Click(object sender, EventArgs e)
        {
            if (dgv_afiliados.Rows.Count >= 1 && dgv_afiliados.CurrentRow != null)
            {
                Afiliado afiliadoElegido = (Afiliado)dgv_afiliados.CurrentRow.DataBoundItem;
                this.Hide();
                Compra_Bono_Afiliado compra = new Compra_Bono_Afiliado(afiliadoElegido);
                compra.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Debe elegir al afiliado que quiere comprar bonos", "Advertencia Compra Bonos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
        }

        private void txt_num_afiliado_KeyPress(object sender, KeyPressEventArgs e)
        {
            //valida que se ingrese un numero de afiliado, no un string
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Sólo se permite ingresar números", "Advertencia número de afiliado ingresado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }
    }
}
