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

namespace ClinicaFrba.Login
{
    public partial class FormElegirRol : FormBase
    {
      public Usuario user;

        public FormElegirRol()
        {
            InitializeComponent();
        }

        public FormElegirRol( Usuario usuario)
        {
            //se obtienen los roles que posee ese usuario
            InitializeComponent();
            this.user = usuario;
            List<Rol> roles = user.getRoles();
            comboBox_roles.DataSource = roles;
            comboBox_roles.ValueMember = "codigo_rol";
            comboBox_roles.DisplayMember = "nombre_rol";

        }

        private void FormElegirRol_Load(object sender, EventArgs e)
        {

        }

        private void btn_rolAceptado_Click(object sender, EventArgs e)
        {
            //se carga menú
            //de acuerdo a los botones habilitados por rol elegido
            user.rolElegido = (Rol)comboBox_roles.SelectedItem;
            user.rolElegido.cargarFuncionalidades();
            FormMenuPrincipal menu = new FormMenuPrincipal(this.user);
            menu.ShowDialog();
            
        }

        private void comboBox_roles_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
