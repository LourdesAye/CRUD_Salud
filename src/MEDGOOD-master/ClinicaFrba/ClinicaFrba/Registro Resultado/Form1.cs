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

namespace ClinicaFrba.Registro_Resultado
{
    public partial class Registro_Resultado_Consulta_Medica : FormBase
    {
        private Especialista doctor;

        private List<Consulta> consultas = new List<Consulta>();

        public Registro_Resultado_Consulta_Medica()
        {
            InitializeComponent();
            //diagrama de la tabla

        }

        public Registro_Resultado_Consulta_Medica(Usuario usuario)
            : this()
        {
            //le llega el usuario que es un medico
            doctor = new Especialista();
            this.doctor.codigoDeUsuario = usuario.codigoDeUsuario;
            cargarGrillaConsultasPendientes();

        }

        private void cargarGrillaConsultasPendientes()
        {
            //armado de grilla

            DataGridViewTextBoxColumn ColCodConsulta = new DataGridViewTextBoxColumn();
            ColCodConsulta.DataPropertyName = "codigoConsulta";
            ColCodConsulta.HeaderText = "Código de la consulta";
            ColCodConsulta.Width = 120;

            DataGridViewTextBoxColumn colCodTurno = new DataGridViewTextBoxColumn();
            colCodTurno.DataPropertyName = "turno";
            colCodTurno.HeaderText = "Código del turno";
            colCodTurno.Width = 120;

            DataGridViewTextBoxColumn colBonoConsulta = new DataGridViewTextBoxColumn();
            colBonoConsulta.DataPropertyName = "bono";
            colBonoConsulta.HeaderText = "Código del Bono";
            colBonoConsulta.Width = 120;

            DataGridViewTextBoxColumn colFechaLlegadaAfiliado = new DataGridViewTextBoxColumn();
            colFechaLlegadaAfiliado.DataPropertyName = "fechaLlegadaAfiliado";
            colFechaLlegadaAfiliado.HeaderText = " Fecha de llegada del Paciente";
            colFechaLlegadaAfiliado.Width = 120;

            dgv_consultas_pendientes.Columns.Add(ColCodConsulta);
            dgv_consultas_pendientes.Columns.Add(colCodTurno);
            dgv_consultas_pendientes.Columns.Add(colBonoConsulta);
            dgv_consultas_pendientes.Columns.Add(colFechaLlegadaAfiliado);

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            //registro de llegadas de afiliados de ese día y de ese médico
            consultas = doctor.consultasPendientesDelDia(obtenerFecha());
            dgv_consultas_pendientes.DataSource = consultas;

            dgv_consultas_pendientes.Columns[4].Visible = false;
            dgv_consultas_pendientes.Columns[5].Visible = false;
            dgv_consultas_pendientes.Columns[6].Visible = false;
            dgv_consultas_pendientes.Columns[7].Visible = false;
            dgv_consultas_pendientes.Columns[8].Visible = false;

            
            

        }

        private void btn_buscar_consulta_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (dgv_consultas_pendientes.Rows.Count >= 1 && dgv_consultas_pendientes.CurrentRow != null)
            {
                this.Hide();
                //pasarle a la pantalla la consulta
                Consulta consultaSelecionada = (Consulta)dgv_consultas_pendientes.CurrentRow.DataBoundItem;
                Registrar_Resultados regResult = new Registrar_Resultados(consultaSelecionada);
                regResult.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Debe elegir una consulta", "Registro de Atenión", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }


        }

            }
        }
