using ClinicaFrba.Datos.Dao;
using ClinicaFrba.Modelo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicaFrba.Pedir_Turno
{
    public partial class Busqueda_Prof : FormBase
    {
        Usuario usuario;
        List<Especialidad> especialidades;
        Boolean agendaCargada = true;
        public Busqueda_Prof(Usuario user)
        {
            InitializeComponent();
            especialidades = DAOEspecialidades.getEspecialidadesMedicas();
            foreach (Especialidad esp in especialidades)
            {
                comboEspec.Items.Add(esp.esp_descripcion);
            }
            usuario = user;
            data_prof.ColumnCount = 8;
            data_prof.Columns[0].Name = "Número";
            data_prof.Columns[1].Name = "Nombre";
            data_prof.Columns[2].Name = "Apellido";
            data_prof.Columns[3].Name = "Matrícula";
            data_prof.Columns[4].Name = "Observaciones";
            data_prof.Columns[5].Name = "Dirección";
            data_prof.Columns[6].Name = "Teléfono";
            data_prof.Columns[7].Name = "Mail";
            DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
            data_prof.Columns.Add(btn);
            btn.HeaderText = "Pedido de turno";
            btn.Text = "Pedir turno";
            btn.Name = "btn_turno";
            btn.UseColumnTextForButtonValue = true;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (comboEspec.SelectedIndex != -1)
            {
                data_prof.Rows.Clear();
                List<Profesional> profesionales = DAOProfesional.buscarProfesionalesEspec(comboEspec.Text);
                foreach (Profesional pr in profesionales)
                {
                    String[] row = new String[] {pr.numero.ToString(), pr.nombre,pr.apellido,pr.matricula.ToString(),pr.observaciones,pr.direccion,pr.telefono.ToString(),pr.mail };
                    data_prof.Rows.Add(row);
                }
            }
            
        }

        private void data_prof_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 8)
            {
                Decimal numeroProf = Convert.ToInt32(data_prof.Rows[e.RowIndex].Cells["Número"].Value);
                String especialidad = comboEspec.Text;
                this.Hide();
                DateTime fechaMax = DAOProfesional.obtenerUltimaAgenda(numeroProf, out agendaCargada);
                if (agendaCargada == false)
                {
                    MessageBox.Show("El profesional no cargó su agenda todavía.");
                }
                else
                {
                    new Turno_Prof(usuario.username, numeroProf, especialidad, fechaMax).ShowDialog();
                    data_prof.Rows.Clear();
                    this.Show();
                }
                
            }
        }
    }
}
