using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClinicaFrba.Datos.Dao;
using ClinicaFrba.Modelo;

namespace ClinicaFrba.Abm_Afiliado
{
    public partial class Modif_Afiliado : FormBase
    {
        String user;
        public Modif_Afiliado(String username)
        {
            InitializeComponent();
            List<PlanMedico> planes = DAOPlanMedico.obtenerPlanes();
            foreach (PlanMedico plan in planes)
            {
                comboPlan.Items.Add(plan.descripcion);
            }
            user = username;
            Afiliado userAModif = DAOUsuario.obtenerDatosUsuario(user);
            textDom.Text = userAModif.direccion;
            textTel.Text = userAModif.telefono.ToString();
            textMail.Text = userAModif.mail;
            comboEstCiv.Text = DAOEstadoCivil.recuperarEstCivil(userAModif.estadoCivil).ToString();
            comboPlan.Text = userAModif.planMedico.descripcion;
            textCantFam.Value = userAModif.cantHijos;

        }

        private void btn_guardar_Click(object sender, EventArgs e)
        {
            var error = false;
            //Validaciones
            if (validar(error)) { return; }
            Afiliado afiliadoAModif = new Afiliado();
            afiliadoAModif.username = user;
            afiliadoAModif.idAfiliado = DAOAfiliado.obtenerIDAfiliado(user);
            afiliadoAModif.direccion = textDom.Text;
            afiliadoAModif.telefono = Convert.ToInt32(textTel.Text);
            afiliadoAModif.mail = textMail.Text;
            afiliadoAModif.estadoCivil = DAOEstadoCivil.obtenerEstCivil(comboEstCiv.Text);
            afiliadoAModif.cantHijos = Convert.ToInt32(textCantFam.Text);
            afiliadoAModif.planMedico.codigo = DAOPlanMedico.obtenerPlanMedico(comboPlan.Text);
            afiliadoAModif.fechaUltimaModif = obtenerFecha();
            afiliadoAModif.update();
            MessageBox.Show("Afiliado modificado correctamente", "Resultado", MessageBoxButtons.OK);
            this.Close();

        }

        private bool validar(bool error)
        {
            var textboxs = grupoDatos.Controls.OfType<TextBox>();
            var combos = grupoDatos.Controls.OfType<ComboBox>();
            foreach (var textbox in textboxs)
            {
                if (string.IsNullOrWhiteSpace(textbox.Text))
                {
                    errorProv.SetError(textbox, "Por favor complete el campo");
                    error = true;
                }
            }
            foreach (var combo in combos)
            {
                if (combo.SelectedIndex < 0)
                {
                    errorProv.SetError(combo, "Por favor seleccione una opción");
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

        private void textTel_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
