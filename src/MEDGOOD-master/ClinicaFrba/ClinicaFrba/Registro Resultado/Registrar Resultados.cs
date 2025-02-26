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
    public partial class Registrar_Resultados : FormBase
    {
        private Modelo.Consulta consultaSelecionada;

        public Registrar_Resultados()
        {
            InitializeComponent();
        }

        public Registrar_Resultados(Modelo.Consulta consultaSelecionada):this()
        {
            this.consultaSelecionada = consultaSelecionada;
        }

        private void Registrar_Resultados_Load(object sender, EventArgs e)
        {
            //que no pueda modificar fecha y hora que sea la del sistema, la actual
            dateTimePicker_fecha.Value = obtenerFecha();
            dateTimePicker_fecha.Enabled = false;
            dateTimePicker_hora.Value = obtenerHora();
            dateTimePicker_hora.Enabled = false;
            
        }

        private void button1_Click(object sender, EventArgs e)
        { 
            //validación de campos no vacios y que no superen los 255 caracteres
            
            bool vacio = false;
            
            if (txt_enfermedad.Text.Length == 0 || txt_enfermedad.Text.Length>255)
            {
                error_enfermedad.SetError(txt_enfermedad, "Por favor ingrese enfermedad,se permiten 255 caracteres");
                vacio = true;
            }
            else { error_enfermedad.Clear(); }

            if (txt_diagnostico.Text.Length == 0 || txt_diagnostico.Text.Length > 255)
            {
                error_diagnostico.SetError(txt_diagnostico, "Por favor ingrese diagnostico,se permiten 255 caracteres");
                vacio = true;
            }
            else { error_diagnostico.Clear(); }

            if (txt_sintomas.Text.Length == 0 || txt_sintomas.Text.Length > 255)
            {
                error_sintomas.SetError(txt_sintomas, "Por favor ingrese síntomas, se permiten hasta 255 caracteres");
                vacio = true;
            }
            else { error_sintomas.Clear(); }

            if (vacio) return; 

            //armado de fecha y hora de consulta con fecha y hora actual del sistema

            DateTime fechaConsulta = obtenerFecha().AddHours(obtenerHora().Hour).AddMinutes(obtenerHora().Minute).AddSeconds(obtenerHora().Second);

            if (consultaSelecionada.cumpleFechaAtencion(fechaConsulta))
            {
                //cargo datos de la pantalla
                Consulta atencionACargar = new Consulta();
                atencionACargar.sintomas=txt_sintomas.Text;
                atencionACargar.enfermedad=txt_enfermedad.Text;
                atencionACargar.diagnostico=txt_diagnostico.Text;
                atencionACargar.comentarios=txt_comentario.Text;
                atencionACargar.fechaAtencionMedica = fechaConsulta;

                //registro de resultados en consulta
               consultaSelecionada.cargarResultadosAtencion(atencionACargar);
                //registro de atencion a consulta en turnoConsulta
               consultaSelecionada.registraAtencion();
               MessageBox.Show("El resultado de la atención se ha cargado con éxito", "Información", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
               this.Close();
            }
            else 
            {
                MessageBox.Show("fecha no válida: " + fechaConsulta, "Error Fecha", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            
        }

    
    }
}
