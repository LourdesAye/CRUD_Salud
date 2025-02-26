using System;
using System.Windows.Forms;
using ClinicaFrba.Modelo;
using ClinicaFrba.Datos.Dao;
using System.Collections.Generic;

namespace ClinicaFrba.Cancelar_Atencion
{
    public partial class Menu_Cancelacion : FormBase
    {
        Usuario user;
        Boolean esProf;
        List<Turno> turnos;
        public Menu_Cancelacion(Usuario usuario)
        {
            InitializeComponent();
            user = usuario;
            List<String> tiposCancelacion = DAOTurno.obtenerTiposCancelacion();
            foreach (String tipo in tiposCancelacion)
            {
                comboTipoCan.Items.Add(tipo);
            }
            comboTipoCan.SelectedIndex = 1;
            esProf = DAOUsuario.obtenerTipo(usuario.username);
            turnos = DAOTurno.obtenerTurnos(user.username, esProf,obtenerFecha());
            foreach (Turno turno in turnos)
            {
                calendario.AddBoldedDate(turno.tur_fecha.Date);
            }
            calendario.MinDate = obtenerFecha().AddDays(1);
            calendario.SelectionStart = calendario.MinDate;

        }

        private void btn_salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_cancelacion_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(comboTurno.Text))
            {
                MessageBox.Show("Por favor seleccione un turno a cancelar.", "Advertencia!", MessageBoxButtons.OK);
            }
            else if (comboTipoCan.Text == "" || String.IsNullOrWhiteSpace(textMotCan.Text))
            {
                MessageBox.Show("Por favor complete todos los datos.", "Advertencia!", MessageBoxButtons.OK);
            }
            else
            {
                Decimal cod;
                DateTime fecha;
                if (esProf)
                {
                    cod = turnos.Find(turno => String.Concat(turno.nombreAfiliado, " ", turno.apellidoAfiliado) == comboTurno.Text).tur_codigo;
                    fecha = turnos.Find(turno => String.Concat(turno.nombreAfiliado, " ", turno.apellidoAfiliado) == comboTurno.Text).tur_fecha;
                }
                else
                {
                    cod = turnos.Find(turno => String.Concat(turno.nombreProfesional, " ", turno.apellidoProfesional) == comboTurno.Text).tur_codigo;
                    fecha = turnos.Find(turno => String.Concat(turno.nombreProfesional, " ", turno.apellidoProfesional) == comboTurno.Text).tur_fecha;
                }
                DAOTurno.cancelarTurno(user.codigoDeUsuario, cod, comboTipoCan.Text, textMotCan.Text);
                MessageBox.Show("El Turno del " + fecha + " ha sido cancelado.");
                this.Close();
            }
        }

        private void calendario_DateChanged(object sender, DateRangeEventArgs e)
        {
            comboTurno.Items.Clear();
            if (Array.Exists(calendario.BoldedDates, date => date == e.Start))
            {
                foreach (Turno turno in turnos)
                {
                    if (turno.tur_fecha.Date == e.Start.Date)
                    {
                        if (esProf)
                        {
                            comboTurno.Items.Add(String.Concat(turno.nombreAfiliado, " ", turno.apellidoAfiliado));
                        }
                        else
                        {
                            comboTurno.Items.Add(String.Concat(turno.nombreProfesional, " ", turno.apellidoProfesional));
                        }
                    }
                }
            }
            else
            {
                comboTurno.Items.Clear();
                if (calendario.BoldedDates.Length == 0)
                {
                    calendario.SelectionStart = obtenerFecha().AddDays(1);
                }
                else
                {
                    calendario.SelectionStart = calendario.BoldedDates[0];
                }
                comboTurno.SelectedIndex = -1;
            }
        }

        private void Menu_Cancelacion_Load(object sender, EventArgs e)
        {

        }

    }
}
