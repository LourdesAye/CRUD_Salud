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

namespace ClinicaFrba.Pedir_Turno
{
    public partial class Turno_Prof : FormBase
    {
        private String afiliado;
        private decimal numeroProf;
        DateTime ultimoHorarioInicio;
        DateTime horarioMax;
        DateTime horarioMin;
        DateTime fechaMaxima;
        String especialidad;

        public Turno_Prof(String usuario, decimal numero, String esp, DateTime fechaMax)
        {
            InitializeComponent();
            this.afiliado = usuario;
            this.numeroProf = numero;
            this.especialidad = esp;
            calendario.MaxSelectionCount = 1;
            calendario.MinDate = obtenerFecha().AddDays(1);
            fechaMaxima = fechaMax;
            
        }

        private void calendario_DateChanged(object sender, DateRangeEventArgs e)
        {
            Horario horarioDelDia = DAOProfesional.obtenerHorarioParaFecha(numeroProf, calendario.SelectionStart);
            if (horarioDelDia.horarioInicio == DateTime.MinValue || horarioDelDia.horarioFin == DateTime.MinValue)
            {
                MessageBox.Show("El profesional no está disponible este día.");
                btnGuardar.Enabled = false;
            }
            else
            {
                horarioMax = horarioDelDia.horarioFin;
                horarioMin = horarioDelDia.horarioInicio;
                horarioInicio.Value = horarioMin;
                btnGuardar.Enabled = true;
            }
        }

        private void horarioInicio_ValueChanged(object sender, EventArgs e)
        {
            if (horarioInicio.Value.TimeOfDay.Hours >= horarioMax.Hour && horarioInicio.Value.TimeOfDay.Minutes >= horarioMax.Minute)
            {
                horarioInicio.Value = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, horarioMax.Hour, horarioMax.Minute, 0);
            }
            else if (horarioInicio.Value.TimeOfDay.Hours < horarioMin.Hour)
            {
                horarioInicio.Value = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, horarioMin.Hour, horarioMin.Minute, 0);
            }
            DateTime dt = horarioInicio.Value;
            if ((dt.Minute * 60 + dt.Second) % 300 != 0)
            {
                TimeSpan diff = dt - ultimoHorarioInicio;
                if (diff.Ticks < 0) horarioInicio.Value = ultimoHorarioInicio.AddMinutes(-30);
                else horarioInicio.Value = ultimoHorarioInicio.AddMinutes(30);
            }
            ultimoHorarioInicio = horarioInicio.Value;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            DateTime horario = calendario.SelectionStart.AddHours(horarioInicio.Value.Hour).AddMinutes(horarioInicio.Value.Minute);
            if (DAOTurno.validarTurnoRepetido(afiliado, horario))
            {
                MessageBox.Show("Ya tiene un turno agendado en ese horario");
            }
            else
            {
                DAOTurno.registarTurno(numeroProf, afiliado, especialidad, horario);
                MessageBox.Show("Turno agendado para el día: " + horario +". Su número de turno es: "+DAOTurno.obtenerUltimoTurno(afiliado,horario));
                this.Close();
            }
        }

        private void Turno_Prof_Load(object sender, EventArgs e)
        {
            if (fechaMaxima < calendario.MinDate)
            {
                MessageBox.Show("El profesional no cargó su agenda.");
                this.Close();
            }
            else
            {
                calendario.MaxDate = fechaMaxima;
                calendario.SelectionStart = obtenerFecha().AddDays(1);
            }
        }
    }
}
