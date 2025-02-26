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
using ClinicaFrba.Datos.Dao;

namespace ClinicaFrba.Abm_Afiliado
{

    public partial class Busq_Modif_Afiliado : FormBase
    {
        public Busq_Modif_Afiliado()
        {
            InitializeComponent();
            data_afiliados.ColumnCount = 5;
            data_afiliados.Columns[0].Name = "Username";
            data_afiliados.Columns[1].Name = "Nombre";
            data_afiliados.Columns[2].Name = "Apellido";
            data_afiliados.Columns[3].Name = "Fecha Nac";
            data_afiliados.Columns[4].Name = "Documento";
            DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
            data_afiliados.Columns.Add(btn);
            btn.HeaderText = "Botón";
            btn.Text = "Modificar";
            btn.Name = "btn_modificacion";
            btn.UseColumnTextForButtonValue = true;
        }

        private void btn_calendario_Click(object sender, EventArgs e)
        {
            calendario.Show();
        }

        private void calendario_DateSelected(object sender, DateRangeEventArgs e)
        {
            var monthCalendar = sender as MonthCalendar;
            textFecha.Text = monthCalendar.SelectionStart.ToShortDateString();
            monthCalendar.Visible = false;
        }

        private void calendario_Leave(object sender, EventArgs e)
        {
            var monthCalendar = sender as MonthCalendar;
            monthCalendar.Visible = false;
        }

        private void btn_salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_buscar_Click(object sender, EventArgs e)
        {
            data_afiliados.Rows.Clear();
            List<Usuario> afiliados = DAOAfiliado.obtenerAfiliados(textNombre.Text, textApellido.Text, textFecha.Text, textDNI.Text);
            foreach (Usuario usuario in afiliados)
            {
                String[] row = new String[] { usuario.username, usuario.nombre, usuario.apellido, usuario.fechaNacimiento.ToString(), usuario.nroDocumento.ToString() };
                data_afiliados.Rows.Add(row);
            }
        }

        private void data_afiliados_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 5)
            {
                String username = data_afiliados.Rows[e.RowIndex].Cells["Username"].Value.ToString();
                this.Hide();
                new Modif_Afiliado(username).ShowDialog();
                data_afiliados.Rows.Clear();
                this.Show();
            }
        }

        private void Busq_Modif_Afiliado_Load(object sender, EventArgs e)
        {

        }

        private void textDNI_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
