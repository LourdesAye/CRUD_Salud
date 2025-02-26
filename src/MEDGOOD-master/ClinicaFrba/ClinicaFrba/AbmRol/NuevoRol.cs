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
    public partial class NuevoRol : FormBase
    {


        public NuevoRol()
        {
            InitializeComponent();
        }

        private void NuevoOModificarRol_Load(object sender, EventArgs e)
        {
            DataGridViewTextBoxColumn colCodFuncionalidad = new DataGridViewTextBoxColumn();
            colCodFuncionalidad.DataPropertyName = "codigo_Funcionalidad";
            colCodFuncionalidad.HeaderText = "Código de la Funcionalidad";
            colCodFuncionalidad.Width = 120;

            DataGridViewTextBoxColumn colNombreFuncionalidad = new DataGridViewTextBoxColumn();
            colNombreFuncionalidad.DataPropertyName = "nombre_Funcionalidad";
            colNombreFuncionalidad.HeaderText = "nombre de la Funcionalidad";
            colNombreFuncionalidad.Width = 180;

            dataGridFuncionalidades.Columns.Add(colNombreFuncionalidad);
            dataGridFuncionalidades.Columns.Add(colCodFuncionalidad);
            actualizarGrilla();
        }

        private void actualizarGrilla()
        {
            List<Funcionalidad> listaDeRoles = new List<Funcionalidad>();
            listaDeRoles = DAOFuncionalidad.buscarFuncionalidades();
            dataGridFuncionalidades.DataSource = listaDeRoles;
        }



        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //para crear un rol se valida que no se repita nombre
            //se crea simepre con al menos una funcionalidad, la selccionada
            if (txt_nombreRol.Text != "")
            {
                if (!DAORol.existeNombreRol(txt_nombreRol.Text))
                {
                    Rol unNuevoRol = new Rol();
                    unNuevoRol.funcionalidades = new List<Funcionalidad>();
                    unNuevoRol.nombre_rol = txt_nombreRol.Text;

                    Funcionalidad f = (Funcionalidad)dataGridFuncionalidades.CurrentRow.DataBoundItem;
                    Funcionalidad funcionalidad = new Funcionalidad();

                    funcionalidad.nombre_Funcionalidad = f.nombre_Funcionalidad;
                    funcionalidad.codigo_Funcionalidad = f.codigo_Funcionalidad;

                    unNuevoRol.funcionalidades.Add(funcionalidad);

                    unNuevoRol.create();
                    MessageBox.Show("El rol fue creado con éxito", "Rol", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    this.Close();
                }

                else
                {
                    MessageBox.Show("ya existe ese nombre de rol, por favor elija otro", "Rol", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }

            else
            {
                MessageBox.Show("debe ingresar un nombre para el nuevo rol", "Rol", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
