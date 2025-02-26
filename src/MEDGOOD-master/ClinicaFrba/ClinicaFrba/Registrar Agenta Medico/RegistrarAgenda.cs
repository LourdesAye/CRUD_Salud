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

namespace ClinicaFrba.Registrar_Agenta_Medico
{
    public partial class RegistrarAgenda : FormBase
    {
        private Usuario user;
        DateTime ultimoHorarioFin;
        DateTime ultimoHorarioInicio;
        int minutosAñadidos = 0;
        int cantDias = 0;
        int minutosTrabajados = 0;
        int horarioMax = 20;
        int horarioMin = 10;

        public RegistrarAgenda(Usuario usuario)
        {
            InitializeComponent();
            this.user = usuario;
            List<Especialidad> especialidades = DAOEspecialidades.obtenerEspecialidadUser(usuario);
            foreach (Especialidad esp in especialidades)
            {
                comboEspec.Items.Add(esp);
            }
            comboEspec.DisplayMember = "esp_descripcion";
            comboEspec.ValueMember = "esp_codigo";
            calendario.MinDate = obtenerFecha().AddDays(1);
            calendario.SelectionStart = calendario.MinDate.AddDays(1);
            List<Agenda> agenda = DAOProfesional.obtenerAgenda(usuario,obtenerFecha());
            agendaActual.ColumnCount = 2;
            agendaActual.Columns[0].Name = "Fecha Inicio";
            agendaActual.Columns[1].Name = "Fecha Fin";
            foreach (Agenda fila in agenda){
                String primerColumna = (fila.fechaInicio.Date + fila.horaInicio.TimeOfDay).ToString();
                String segundaColumna = (fila.fechaFin.Date + fila.horaFin.TimeOfDay).ToString();
                String[] row = new String[] {primerColumna ,segundaColumna };
                agendaActual.Rows.Add(row);
            }
        }

        private void calendario_DateChanged(object sender, DateRangeEventArgs e)
        {
            if (e.Start.DayOfWeek == DayOfWeek.Sunday)
            {
                MessageBox.Show("La clínica está cerrada las domingos.");
                if (e.Start.AddDays(1) >= calendario.MaxDate)
                {
                    calendario.SelectionStart = e.Start.AddDays(-1);
                }
                else
                {
                    calendario.SelectionStart = e.Start.AddDays(1);
                }

            }
            else if (e.End.DayOfWeek == DayOfWeek.Sunday)
            {
                MessageBox.Show("La clínica está cerrada las domingos.");
                if (e.End.AddDays(-1) <= calendario.MinDate)
                {
                    calendario.SelectionEnd = e.End.AddDays(1);
                }
                else
                {
                    calendario.SelectionEnd = e.End.AddDays(1);
                }
            }
            else if (e.Start.DayOfWeek == DayOfWeek.Monday)
            {
                calendario.MaxSelectionCount = 6;
                horarioMax = 20;
                horarioMin = 7;
            }
            else if (e.Start.DayOfWeek == DayOfWeek.Tuesday)
            {
                calendario.MaxSelectionCount = 5;
                horarioMax = 20;
                horarioMin = 7;
            }
            else if (e.Start.DayOfWeek == DayOfWeek.Wednesday)
            {
                calendario.MaxSelectionCount = 4;
                horarioMax = 20;
                horarioMin = 7;
            }
            else if (e.Start.DayOfWeek == DayOfWeek.Thursday)
            {
                calendario.MaxSelectionCount = 3;
                horarioMax = 20;
                horarioMin = 7;
            }
            else if (e.Start.DayOfWeek == DayOfWeek.Friday)
            {
                calendario.MaxSelectionCount = 2;
                horarioMax = 20;
                horarioMin = 7;
            }
            else if (e.Start.DayOfWeek == DayOfWeek.Saturday)
            {
                calendario.MaxSelectionCount = 1;
                horarioMax = 15;
                horarioMin = 10;
            }
            if (e.End.DayOfWeek == DayOfWeek.Saturday)
            {
                horarioMax = 15;
                horarioMin = 10;
                horarioFin.Value = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, horarioMax, 0, 0);
                horarioInicio.Value = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, horarioMin, 0, 0);
            }
        }

        private void horarioFin_ValueChanged(object sender, EventArgs e)
        {
            if (horarioFin.Value.TimeOfDay.Hours >= horarioMax && horarioFin.Value.TimeOfDay.Minutes >= 0)
            {
                horarioFin.Value = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, horarioMax, 0, 0);
            }
            else if (horarioFin.Value.TimeOfDay.Hours < horarioMin)
            {
                horarioFin.Value = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, horarioMin, 0, 0);
            }
            DateTime dt = horarioFin.Value;
            if ((dt.Minute * 60 + dt.Second) % 300 != 0)
            {
                TimeSpan diff = dt - ultimoHorarioFin;
                if (diff.Ticks < 0) horarioFin.Value = ultimoHorarioFin.AddMinutes(-30);
                else horarioFin.Value = ultimoHorarioFin.AddMinutes(30);
            }
            ultimoHorarioFin = horarioFin.Value;
        }

        private void horarioInicio_ValueChanged(object sender, EventArgs e)
        {
            if (horarioInicio.Value.TimeOfDay.Hours >= horarioMax && horarioInicio.Value.TimeOfDay.Minutes >= 0)
            {
                horarioInicio.Value = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, horarioMax, 0, 0);
            }
            else if (horarioInicio.Value.TimeOfDay.Hours < horarioMin)
            {
                horarioInicio.Value = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, horarioMin, 0, 0);
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

        
        private void button1_Click(object sender, EventArgs e)
        {

            if (String.IsNullOrWhiteSpace(comboEspec.Text))
            {
                MessageBox.Show("Por favor seleccione una especialidad.");
            }
            else
            {
                //TODO: Validar agenda repetida
                if (DAOProfesional.verficarRepeticionAgenda(calendario.SelectionStart.Date, calendario.SelectionEnd.Date,comboEspec.Text,user,horarioInicio.Value,horarioFin.Value))
                {
                    MessageBox.Show("Ya registró una agenda para estos días.");
                }
                else
                {
                    cantDias = calendario.SelectionRange.End.Subtract(calendario.SelectionRange.Start).Days + 1;
                    minutosAñadidos = Convert.ToInt32(horarioFin.Value.TimeOfDay.Subtract(horarioInicio.Value.TimeOfDay).TotalMinutes * cantDias);
                    //Validación de menos de 48 hs laborales
                    minutosTrabajados = DAOProfesional.obtenerHoras(user, calendario.SelectionStart.Date);
                    if (horarioInicio.Value.Hour > horarioFin.Value.Hour)
                    {
                        MessageBox.Show("El horario de inicio no puede ser mayor que el de fin");
                    }
                    else if (minutosTrabajados + minutosAñadidos > 2880)
                    {
                        MessageBox.Show("No puede trabajar más de 48 horas en una semana.");
                    }
                    else
                    {
                        DAOProfesional.agregarAgenda(user, calendario.SelectionStart.Date, calendario.SelectionEnd.Date, horarioInicio.Value.TimeOfDay, horarioFin.Value.TimeOfDay, comboEspec.Text);
                        MessageBox.Show("Agenda guardada");
                        this.Close();
                    }
                }

            }

        }

    }
}
