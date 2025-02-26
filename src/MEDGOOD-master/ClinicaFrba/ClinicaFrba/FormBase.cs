using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Globalization;
using ClinicaFrba.Modelo;
using ClinicaFrba.Compra_Bono;

namespace ClinicaFrba
{
    public partial class FormBase : Form
    {
        public FormBase()
        {
            InitializeComponent();
        }

        private void FormBase_Load(object sender, EventArgs e)
        {

        }

        public static void limpiar(Control control)
        {
            if (control is TextBox)
            {
                if (((TextBox)control).ReadOnly == false)
                {
                    ((TextBox)control).Clear();
                }
            }
            else if (control is DateTimePicker)
            {
                ((DateTimePicker)control).Value = DateTime.Now;
            }
            else if (control is ComboBox)
            {
                ((ComboBox)control).SelectedIndex = -1;
            }
            if (control.HasChildren)
            {
                foreach (Control child in control.Controls)
                {
                    limpiar(child);
                }
            }


        }

        //hora del sistema

        public DateTime obtenerHora()
        {
            return DateTime.ParseExact(ConfigurationManager.AppSettings["hora"], "HH:mm:ss", CultureInfo.InvariantCulture);
        }

        //fecha del sistema

        public DateTime obtenerFecha()
        {
            return Convert.ToDateTime(ConfigurationManager.AppSettings["fecha"]);
        }

    }
}
