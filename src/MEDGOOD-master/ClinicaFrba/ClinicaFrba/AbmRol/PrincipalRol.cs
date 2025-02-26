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

namespace ClinicaFrba.AbmRol
{
    public partial class PrincipalRol : FormBase
    {
        public PrincipalRol()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //su codigo es importante
            DataGridViewTextBoxColumn colCodRol = new DataGridViewTextBoxColumn();
            colCodRol.DataPropertyName = "codigo_rol";
            colCodRol.HeaderText = "Código del Rol";
            colCodRol.Width = 120;
            //su nombre se puede modificar
            DataGridViewTextBoxColumn colNombreRol = new DataGridViewTextBoxColumn();
            colNombreRol.DataPropertyName = "nombre_rol";
            colNombreRol.HeaderText = "nombre del Rol";
            colNombreRol.Width = 120;
            //habilitado?
            DataGridViewTextBoxColumn colEstadoRol = new DataGridViewTextBoxColumn();
            colEstadoRol.DataPropertyName = "estado_inhabilitado";
            colEstadoRol.HeaderText = "Inhabilitado";
            colEstadoRol.Width = 120;

            dataGridRol.Columns.Add(colNombreRol);
            dataGridRol.Columns.Add(colEstadoRol);
            dataGridRol.Columns.Add(colCodRol);
            actualizarGrilla();
        }

        public void actualizarGrilla()
        {
            List<Rol> listaDeRoles = new List<Rol>();
            listaDeRoles = DAORol.buscarRoles();
            dataGridRol.DataSource = listaDeRoles;
            this.dataGridRol.Columns[3].Visible = false;

        }

        private void btn_nuevo_rol_Click(object sender, EventArgs e)
        {
            this.Hide();
            NuevoRol nuevoRol = new NuevoRol();
            nuevoRol.ShowDialog();
            this.actualizarGrilla();
            this.Show();

        }

        private void btn_modificar_rol_Click(object sender, EventArgs e)
        {
                Rol rol = (Rol)dataGridRol.CurrentRow.DataBoundItem;
                this.Hide();
                ModificarRol modifRol = new ModificarRol(rol);
                modifRol.ShowDialog();
                this.actualizarGrilla();
                this.Show();
        }
    }
}
