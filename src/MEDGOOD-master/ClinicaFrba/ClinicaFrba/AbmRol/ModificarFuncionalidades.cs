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
    public partial class ModificarFuncionalidades : FormBase
    {
        private Rol rol;

        public ModificarFuncionalidades()
        {
            InitializeComponent();
        }

        public ModificarFuncionalidades(Rol rol)
        {
            InitializeComponent();
            this.rol = rol;
            rol.funcionalidades = new List<Funcionalidad>();
        }

        private void ModificarFuncionalidades_Load(object sender, EventArgs e)
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

        private void button1_Click(object sender, EventArgs e)
        {
            Funcionalidad f = (Funcionalidad)dataGridFuncionalidades.CurrentRow.DataBoundItem;
            Funcionalidad funcionalidad = new Funcionalidad();

            funcionalidad.nombre_Funcionalidad = f.nombre_Funcionalidad;
            funcionalidad.codigo_Funcionalidad = f.codigo_Funcionalidad;

            if (!rol.tenesFuncionalidad(funcionalidad))
            {
                rol.agregaFuncionalidad(funcionalidad);
                MessageBox.Show("la funcionalidad:" + funcionalidad.nombre_Funcionalidad + "se ha agregado con éxito al rol:" + rol.nombre_rol + "", "Información", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                this.Close();
            }
            else {
                MessageBox.Show("ya existe el rol:"+rol.nombre_rol+""+","+""+"con la funcionalidad:"+funcionalidad.nombre_Funcionalidad+"", "Error agregado de funcionalidad", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); 
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Funcionalidad f = (Funcionalidad)dataGridFuncionalidades.CurrentRow.DataBoundItem;
            Funcionalidad funcionalidad = new Funcionalidad();

            funcionalidad.nombre_Funcionalidad = f.nombre_Funcionalidad;
            funcionalidad.codigo_Funcionalidad = f.codigo_Funcionalidad;

            if (rol.tenesFuncionalidad(funcionalidad))
            {
                rol.eliminaFuncionalidad(funcionalidad);
                MessageBox.Show("la funcionalidad:" + funcionalidad.nombre_Funcionalidad + "se ha eliminado con éxito del rol:" + rol.nombre_rol + "", "Información", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                this.Close();
            }
            else
            {
                MessageBox.Show("el rol:" + rol.nombre_rol + "," + "no posee la funcionalidad:" + funcionalidad.nombre_Funcionalidad, "Error borrado funcionalidad", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
