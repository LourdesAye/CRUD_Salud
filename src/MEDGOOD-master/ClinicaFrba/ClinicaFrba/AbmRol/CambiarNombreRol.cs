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
    public partial class CambiarNombreRol : FormBase
    {
        private Rol rol;

        public CambiarNombreRol()
        {
            InitializeComponent();
        }

        public CambiarNombreRol(Rol rol)
        {
            InitializeComponent();
            this.rol = rol;
            this.txt_nombreRol.Text = rol.nombre_rol;
        }

        private void CambiarNombreRol_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txt_nombreRol.Text != "")
            {

                if (txt_nombreRol.Text != rol.nombre_rol)
                {
                    if (!DAORol.existeNombreRol(txt_nombreRol.Text))
                    {
                        rol.modificaNombre(txt_nombreRol.Text);
                        rol.actualizate(txt_nombreRol.Text);
                        MessageBox.Show("Se ha modificado el nombre del rol ", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        this.Close();
                        
                    }
                    else
                    {
                        MessageBox.Show("Ya existe el nombre: " + txt_nombreRol.Text + " para algún rol ", "Error nombre rol", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else
                {
                    MessageBox.Show("no ha cambiado el nombre del rol", "Error nombre Rol", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                MessageBox.Show("debe ingresar un nombre para el rol", "Error nombre Rol", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
        }
    }
}
