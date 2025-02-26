using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClinicaFrba;
using ClinicaFrba.Modelo;
using ClinicaFrba.Datos.Dao;

namespace ClinicaFrba.Login
{
    public partial class InicioLogin : FormBase
    {
        public InicioLogin()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            //validación de campos no vacios

            bool vacio = false;

            if (txt_username.Text.Length == 0)
            {
                error_user.SetError(txt_username, "Por favor ingrese usuario");
                vacio = true;
            }
            else { error_user.Clear(); }



            if (txt_password.Text.Length == 0)
            {
                error_pass.SetError(txt_password, "Por favor ingrese contraseña");
                vacio = true;
            }
            else { error_pass.Clear(); }

            if (vacio) return; 

            /* validaciones del usuario: 
            -si existe: si existe ese username o si fue borrado:baja lógica
            -si esta habilitado: no superó los 3 intentos fallidos
            -si es correcta contraseña,para ese username
            */

            Usuario usuario = new Usuario(txt_username.Text);
                    
            if (usuario.existeUsername() && !usuario.fueBorrado()){ 

                if (usuario.estaHabilitado())
                {
                    if (usuario.contraseñaCorrecta(txt_password.Text))
                    {
                        usuario.borrarIntentosFallidos();
                        FormElegirRol elegirRol = new FormElegirRol(usuario);
                        elegirRol.ShowDialog();
                    }
                    else
                    {
                         usuario.incrementarIntentosFallidos();
                         MessageBox.Show("Contraseña invalida para el usuario " + txt_username.Text, "Error password", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }

                }
                else {
                    MessageBox.Show("El usuario se ha inhabilitado, contactese con el administrador", "Usuario Inhabilitado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); 
                }

            }
            else
            {
                MessageBox.Show("el usuario:"+txt_username.Text+""+" no existe", "Error username", MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
            }
        }

        }

    }

