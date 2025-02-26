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

namespace ClinicaFrba.Registro_Llegada
{
    public partial class RegistroLlegadaAfiliado : FormBase
    {
        private List<Especialidad> especialidades = new List<Especialidad>();
        
        public RegistroLlegadaAfiliado()
        {
            InitializeComponent();
            cargarGrillaTurnos();
        }

        private void cargarGrillaTurnos()
        {

            DataGridViewTextBoxColumn colCodTurno = new DataGridViewTextBoxColumn();
            colCodTurno.DataPropertyName = "tur_codigo";
            colCodTurno.HeaderText = "Código del turno";
            colCodTurno.Width = 120;
            DataGridViewTextBoxColumn colAfiliado = new DataGridViewTextBoxColumn();
            colAfiliado.DataPropertyName = "tur_codigoafiliado";
            colAfiliado.HeaderText = "Número de Afiliado";
            colAfiliado.Width = 120;
            DataGridViewTextBoxColumn colFechaTurno = new DataGridViewTextBoxColumn();
            colFechaTurno.DataPropertyName = "tur_fecha";
            colFechaTurno.HeaderText = "Fecha del Turno";
            colFechaTurno.Width = 120;
            DataGridViewTextBoxColumn colCodProfesional = new DataGridViewTextBoxColumn();
            colCodProfesional.DataPropertyName = "tur_profesionalcodigo";
            colCodProfesional.HeaderText = "Código del profesional";
            colCodProfesional.Width = 120;
            DataGridViewTextBoxColumn colFechaInicio = new DataGridViewTextBoxColumn();
            colFechaInicio.DataPropertyName = "nombreProfesional";
            colFechaInicio.HeaderText = "Nombre del profesional";
            colCodProfesional.Width = 120;
            DataGridViewTextBoxColumn colFechaFin = new DataGridViewTextBoxColumn();
            colFechaFin.DataPropertyName = "apellidoProfesional";
            colFechaFin.HeaderText = "Apellido del profesional";
            colFechaFin.Width = 120;

            dgv_turnos.Columns.Add(colCodTurno);
            dgv_turnos.Columns.Add(colAfiliado);
            dgv_turnos.Columns.Add(colFechaTurno);
            dgv_turnos.Columns.Add(colCodProfesional);
            dgv_turnos.Columns.Add(colFechaInicio);
            dgv_turnos.Columns.Add(colFechaFin);
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            //cargar comboBox con especialidades médicas
            especialidades = DAOEspecialidades.getEspecialidadesMedicas();
            cmb_especialidades_medicas.DataSource = especialidades;
            cmb_especialidades_medicas.DisplayMember = "esp_descripcion";

        }

        private void btn_buscar_turno_Click(object sender, EventArgs e)
        {
            //carga especialidad
            Especialidad especialidad = (Especialidad)cmb_especialidades_medicas.SelectedItem;
            //cargar turnos
            //los turnos no atendidos, no registrados, no cancelados,son los que tienen tur_estado en null
            List<Turno> turnos = DAOTurno.turnosDeEspecialista(especialidad, txt_apellido_profesional.Text, txt_nombre_profesional.Text,obtenerFecha());
            dgv_turnos.DataSource = turnos;
            if (turnos.Count() == 0) {
                MessageBox.Show("La búsqueda no tiene resultados", "Resultados de Búsqueda", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }

        }

        private void btn_registro_atencion_Click(object sender, EventArgs e)
        {
             if (dgv_turnos.Rows.Count>=1 && dgv_turnos.CurrentRow!=null)
            {
                Turno turnoElegido = (Turno)dgv_turnos.CurrentRow.DataBoundItem;
                this.Hide();
                Pagar_Consulta darBono = new Pagar_Consulta(turnoElegido);
                darBono.ShowDialog();
                this.Close();
            }
            else {
                MessageBox.Show("Debe elegir un turno", "Registro de Consulta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
            


        }
    }
}
