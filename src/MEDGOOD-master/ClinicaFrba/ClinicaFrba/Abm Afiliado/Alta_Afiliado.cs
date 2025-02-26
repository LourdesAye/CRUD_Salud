using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClinicaFrba.Modelo;
using ClinicaFrba.Datos.Dao;
using System.Windows.Forms;
using System.Configuration;

namespace ClinicaFrba.Abm_Afiliado
{
    public partial class Alta_Afiliado : FormBase
    {
        int flag = 0;
        decimal afiliadoPrinc;
        DateTime fechaHoy = DateTime.Parse(ConfigurationManager.AppSettings["fecha"]);

        public Alta_Afiliado(int flagRepeticiones, decimal idPrincipal)
        {
            InitializeComponent();
            textCantFam.Minimum = 0;
            afiliadoPrinc = idPrincipal;
            flag = flagRepeticiones;
            List<PlanMedico> planes = DAOPlanMedico.obtenerPlanes();
            foreach (PlanMedico plan in planes)
            {
                comboPlan.Items.Add(plan.descripcion);
            }
        }

        private void btn_guardar_Click(object sender, EventArgs e)
        {
            var error = false;
            //Validaciones de campos vacios
            errorProv.Clear();
            if (validarCamposVacios(error)) { return; }
            //Creación del usuario para el afiliado
            Usuario nuevoUsuario = new Usuario(txt_username.Text);
            //nuevoUsuario.username = obtenerUsername();
            //valida si existe un username igual
            if (nuevoUsuario.existeUsername())
            {
                MessageBox.Show("Ya existe un usuario con ese username", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                //valida si existe usuario, es decir, valida número de documento
                if (nuevoUsuario.existeNumeroDocumento(Convert.ToInt32(textDni.Text)))
                {
                    MessageBox.Show("Ya existe un usuario con ese número de documento", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    nuevoUsuario.username = txt_username.Text;
                    //el pass se guarda encriptado
                    nuevoUsuario.password = nuevoUsuario.encriptacionPasswordFormulario(textPass.Text);
                    nuevoUsuario.fechaCreacion = obtenerFecha();
                    nuevoUsuario.fechaUltimaModif = obtenerFecha();
                    nuevoUsuario.fechaNacimiento = Convert.ToDateTime(textFechaNac.Value);
                    nuevoUsuario.intentosFallidos = 0;
                    nuevoUsuario.inhabilitado = false;
                    nuevoUsuario.nombre = textNom.Text;
                    nuevoUsuario.apellido = textApellido.Text;
                    nuevoUsuario.nroDocumento = Convert.ToInt32(textDni.Text);
                    nuevoUsuario.tipoDocumento = (Int32)DAOTipoDocumento.obtenerTipoDoc(comboTipoDoc.Text);
                    nuevoUsuario.direccion = textDom.Text;
                    nuevoUsuario.telefono = Convert.ToInt32(textTel.Text);
                    nuevoUsuario.mail = textMail.Text;
                    if (comboSexo.SelectedIndex == 1)
                    {
                        nuevoUsuario.sexo = 1;
                    }
                    else
                    {
                        nuevoUsuario.sexo = 0;
                    }
                    nuevoUsuario.preguntaSecreta = textPregSec.Text;
                    nuevoUsuario.respuestaSecreta = textRtaSec.Text;
                    nuevoUsuario.fechaCreacion = obtenerFecha();
                    nuevoUsuario.create();
                    nuevoUsuario.codigoDeUsuario = DAOUsuario.obtenerIDNuevoUsuario();
                    //Creación del afiliado modelo
                    Afiliado nuevoAfiliado = new Afiliado();
                    if (afiliadoPrinc == 0)
                    {
                        nuevoAfiliado.idAfiliado = (DAOAfiliado.obtenerIDNuevoAfiliado() * 100) + 1;
                        nuevoAfiliado.afiliadoPrincial = 0;
                    }
                    else
                    {
                        nuevoAfiliado.afiliadoPrincial = Math.Truncate(afiliadoPrinc / 100);
                        nuevoAfiliado.idAfiliado = afiliadoPrinc++;
                    }
                    nuevoAfiliado.codUser = nuevoUsuario.codigoDeUsuario;
                    nuevoAfiliado.estadoCivil = DAOEstadoCivil.obtenerEstCivil(comboEstCiv.Text);
                    nuevoAfiliado.cantHijos = Convert.ToInt32(textCantFam.Text);
                    nuevoAfiliado.planMedico.codigo = DAOPlanMedico.obtenerPlanMedico(comboPlan.Text);
                    nuevoAfiliado.crearAfiliado();

                    //Pregunta por pareja
                    if (flag == 1)
                    {
                        nuevoAfiliado.idAfiliado = (DAOAfiliado.obtenerIDNuevoAfiliado() * 100) + 1;
                        if (comboEstCiv.Text == "Casado/a" || comboEstCiv.Text == "Concubinato")
                        {
                            DialogResult dialogResult = MessageBox.Show("¿Desea afiliar a su cónyugue?", "Datos de cónyugue", MessageBoxButtons.YesNo);
                            if (dialogResult == DialogResult.Yes)
                            {
                                var nuevaVentana = new Alta_Afiliado(0, nuevoAfiliado.idAfiliado + 1);
                                nuevaVentana.textCantFam = this.textCantFam;
                                nuevaVentana.textCantFam.Enabled = false;
                                nuevaVentana.comboEstCiv.SelectedIndex = this.comboEstCiv.SelectedIndex;
                                nuevaVentana.comboEstCiv.Enabled = false;
                                nuevaVentana.ShowDialog();
                            }
                        }
                        //Pregunta por hijos
                        if (textCantFam.Value > 0)
                        {
                            DialogResult dialogResult = MessageBox.Show("¿Desea afiliar a sus familiares a cargo?", "Datos de familiares a cargo", MessageBoxButtons.YesNo);
                            if (dialogResult == DialogResult.Yes)
                            {
                                for (int i = 0; i < textCantFam.Value; i++)
                                {
                                    (new Alta_Afiliado(0, nuevoAfiliado.idAfiliado)).ShowDialog();
                                }
                            }
                        }
                    }
                    MessageBox.Show("Usuario afiliado correctamente.", "Resultado", MessageBoxButtons.OK);
                    this.Close();
                }



            }
        }

        private bool validarCamposVacios(bool error)
        {
            var controles = grupoDatos.Controls;
            foreach (Control control in controles)
            {
                if (string.IsNullOrWhiteSpace(control.Text))
                {
                    errorProv.SetError(control, "Por favor complete el campo");
                    error = true;
                }
            }
            return error;
        }

        private void btn_limpiar_Click(object sender, EventArgs e)
        {
            limpiar(this);
        }

        private void btn_salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textDni_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textFechaNac_ValueChanged(object sender, EventArgs e)
        {

        }

        private void Alta_Afiliado_Load(object sender, EventArgs e)
        {
            textFechaNac.Value = obtenerFecha();
        }
    }
}
