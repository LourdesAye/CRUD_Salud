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
using ClinicaFrba.AbmRol;
using ClinicaFrba.Compra_Bono;
using ClinicaFrba.Abm_Afiliado;
using ClinicaFrba.Registro_Llegada;
using ClinicaFrba.Registro_Resultado;
using ClinicaFrba.Registrar_Agenta_Medico;
using ClinicaFrba.Pedir_Turno;
using ClinicaFrba.Cancelar_Atencion;
using ClinicaFrba.Listados;
using ClinicaFrba.Datos.Dao;

namespace ClinicaFrba.Login
{
    public partial class FormMenuPrincipal : FormBase
    {
        private Usuario usuario;

        public FormMenuPrincipal()
        {
            InitializeComponent();
        }

        public FormMenuPrincipal(Usuario usuario)
        {
            InitializeComponent();
            this.usuario = usuario;
            foreach (Control boton in this.Controls)
            {
                if (boton is Button)
                {
                    boton.Enabled = false;
                    if (usuario.FuncionalidadValida(boton.Text))
                    {
                        boton.Enabled = true;
                    }
                }
            }
        }

        private void FormMenuPrincipal_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            AbmAfiliado menuAfiliado = new AbmAfiliado();
            menuAfiliado.ShowDialog();
            this.Show();
        }

        private void abm_rol_Click(object sender, EventArgs e)
        {
            this.Hide();
            PrincipalRol menuRol = new PrincipalRol();
            menuRol.ShowDialog();
            this.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (usuario.afiliado())
            {
                this.Hide();
                Compra_Bono_Afiliado com_afil = new Compra_Bono_Afiliado(usuario);
                com_afil.ShowDialog();
                this.Show();
            }
            else
            {
                this.Hide();
                Busqueda_Afiliado_Comprador com_afil = new Busqueda_Afiliado_Comprador();
                com_afil.ShowDialog();
                this.Show();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            RegistroLlegadaAfiliado registroLlegada = new RegistroLlegadaAfiliado();
            registroLlegada.ShowDialog();
            this.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {

            this.Hide();
            Registro_Resultado_Consulta_Medica registroResult = new Registro_Resultado_Consulta_Medica(usuario);
            registroResult.ShowDialog();
            this.Show();
        }

        private void btn_registro_aagenda_Click(object sender, EventArgs e)
        {
            this.Hide();
            RegistrarAgenda registroAgenda = new RegistrarAgenda(usuario);
            registroAgenda.ShowDialog();
            this.Show();
        }

        private void btn_solicitar_turno_Click(object sender, EventArgs e)
        {
            this.Hide();
            Busqueda_Prof busqProf = new Busqueda_Prof(usuario);
            busqProf.ShowDialog();
            this.Show();
        }


        private void btn_cancelar_atencion_medica_Click(object sender, EventArgs e)
        {
            this.Hide();
            if (!DAOUsuario.tieneTurnosActivos(usuario,obtenerFecha()))
            {
                MessageBox.Show("No tiene turnos activos.");
            }
            else
            {
                Menu_Cancelacion menuCan = new Menu_Cancelacion(usuario);
                menuCan.ShowDialog();
            }
            this.Show();
            
        }

        private void btn_listado_estadistico_Click(object sender, EventArgs e)
        {
            this.Hide();
            ListadosEstadisticos listados = new ListadosEstadisticos();
            listados.ShowDialog();
            this.Show();
        }
    }
}
