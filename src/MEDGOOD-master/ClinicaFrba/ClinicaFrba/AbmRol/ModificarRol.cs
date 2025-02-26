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

namespace ClinicaFrba.AbmRol
{
    public partial class ModificarRol : FormBase
    {
        public Rol rol;

        public ModificarRol()
        {
            InitializeComponent();
        }

        public ModificarRol(Rol rol)
        {
            InitializeComponent();
            this.rol = rol;
        }

        private void ModificarRol_Load(object sender, EventArgs e)
        {

        }

        private void btn_habilitar_Click(object sender, EventArgs e)
        {
            if (!rol.habilitado())
            {
                rol.habilitate();
                MessageBox.Show("el rol se ha habilitado con éxito", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                this.Close();
            }
            else
            {
                MessageBox.Show("el rol ya se encontraba habilitado", "Error habilitación rol", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btn_inhabilitar_Click(object sender, EventArgs e)
        {

            if (rol.habilitado())
            {
                rol.inhabilitate();
                MessageBox.Show("el rol se ha inhabilitado con éxito", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                this.Close();
            }
            else
            {
                MessageBox.Show("el rol ya se encontraba inhabilitado", "Error inhabilitación rol", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btn_cambiar_nombre_rol_Click(object sender, EventArgs e)
        {
            this.Hide();
            CambiarNombreRol modifRol = new CambiarNombreRol(rol);
            modifRol.ShowDialog();
            this.Show();
        }

        private void btn_modificar_funcionalidades_Click(object sender, EventArgs e)
        {
            this.Hide();
            ModificarFuncionalidades modifRol = new ModificarFuncionalidades(rol);
            modifRol.ShowDialog();
            this.Show();
        }
    }
}
