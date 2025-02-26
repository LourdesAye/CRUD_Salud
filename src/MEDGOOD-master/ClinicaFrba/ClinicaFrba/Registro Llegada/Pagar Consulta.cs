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

namespace ClinicaFrba.Registro_Llegada
{
    public partial class Pagar_Consulta : FormBase
    {
        private Turno turnoSeleccionado;

        public Pagar_Consulta()
        {
            InitializeComponent();
        }

        public Pagar_Consulta(Turno turnoElegido)
            : this()
        {
            this.turnoSeleccionado = turnoElegido;
            this.cargarGrillaBonosDisponibles();

        }

        private void cargarGrillaBonosDisponibles()
        {
            //codigo del bono es necesario para poder pagar la cosulta
            DataGridViewTextBoxColumn colCodBono = new DataGridViewTextBoxColumn();
            colCodBono.DataPropertyName = "codigoBono";
            colCodBono.HeaderText = "Código del Bono";
            colCodBono.Width = 120;
            //de la compra sale de quien es el bono, dato importante
            DataGridViewTextBoxColumn colCodCompra = new DataGridViewTextBoxColumn();
            colCodCompra.DataPropertyName = "codigoCompra";
            colCodCompra.HeaderText = "Código de compra";
            colCodCompra.Width = 120;
            //quiero ver si fue usado el bono
            DataGridViewTextBoxColumn colBonoUsado = new DataGridViewTextBoxColumn();
            colBonoUsado.DataPropertyName = "bonoFueUsado";
            colBonoUsado.HeaderText = "Bono Usado";
            colBonoUsado.Width = 120;
            //supuestamente no esta usado
            DataGridViewTextBoxColumn colCodAfiliado = new DataGridViewTextBoxColumn();
            colCodAfiliado.DataPropertyName = "idAfiliado";
            colCodAfiliado.HeaderText = "Código del afiliado que lo utiliza";
            colCodAfiliado.Width = 120;
            //es importante para validación
            DataGridViewTextBoxColumn colPlanBono = new DataGridViewTextBoxColumn();
            colPlanBono.DataPropertyName = "bonoIdPlanDisponible";
            colPlanBono.HeaderText = "Plan del Bono";
            colPlanBono.Width = 120;
            //en null si no lo usa, es la fecha del registro que es la fecha del turnoConsulta
            DataGridViewTextBoxColumn colFechaImpresionBono = new DataGridViewTextBoxColumn();
            colFechaImpresionBono.DataPropertyName = "fechaimpresionBono";
            colFechaImpresionBono.HeaderText = "Fecha de Impresión";
            colFechaImpresionBono.Width = 120;
            //debe estar en cero si esta disponible
            DataGridViewTextBoxColumn colNroConsulta = new DataGridViewTextBoxColumn();
            colNroConsulta.DataPropertyName = "nroConsulta";
            colNroConsulta.HeaderText = "Número Consulta bono";
            colNroConsulta.Width = 120;
            DataGridViewTextBoxColumn colCantBonosDisponibles = new DataGridViewTextBoxColumn();
            colCantBonosDisponibles.DataPropertyName = "cantBonosDisponibles";
            colCantBonosDisponibles.HeaderText = "cantBonosDisponibles";
            colCantBonosDisponibles.Width = 120;
            dgv_bonos_disponibles.Columns.Add(colCodBono);
            dgv_bonos_disponibles.Columns.Add(colCodCompra);
            dgv_bonos_disponibles.Columns.Add(colBonoUsado);
            dgv_bonos_disponibles.Columns.Add(colCodAfiliado);
            dgv_bonos_disponibles.Columns.Add(colPlanBono);
            dgv_bonos_disponibles.Columns.Add(colFechaImpresionBono);
            dgv_bonos_disponibles.Columns.Add(colNroConsulta);
            dgv_bonos_disponibles.Columns.Add(colCantBonosDisponibles);
            this.dgv_bonos_disponibles.Columns[7].Visible = false;
            this.dgv_bonos_disponibles.Columns[3].Visible = false;
            this.dgv_bonos_disponibles.Columns[5].Visible = false;
            this.dgv_bonos_disponibles.Columns[6].Visible = false;

        }

        private void Pagar_Consulta_Load(object sender, EventArgs e)
        {
            //aca del turnoConsulta tomo el codigo de afiliado
            //segun codigo de afiliado busco sus bonos y los del grupo familiar que no se hayan usado
            //y que el bono plan = plan del afiliado
            List<Bono> bonosDisponibles = DAOBonos.obtenerBonosDisponiblesDeAfiliado(turnoSeleccionado.tur_codigoafiliado);
            dgv_bonos_disponibles.DataSource = bonosDisponibles;
            label_cant_bonos_disponibles.Text = Convert.ToString(bonosDisponibles.Count);
        }

        private void button1_Click(object sender, EventArgs e)
        { 
            //valida que no tiene bonos disponibles
             if (dgv_bonos_disponibles.Rows.Count==0)
             {
                 MessageBox.Show("No tiene bonos disponibles", "Pago con bono", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
             }
             else{
            //se usa bono se modifica tabla bonos
            //bon_fue_usado=1
            //bon_codigoafiliado el que lo usó que es el del turnoConsulta
            //bon fecha de impresion es fecha del turnoConsulta
            //bon_nroconsultabono se rellena con cant consultas del afiliado+1

            Bono bonoSeleccionado = (Bono)dgv_bonos_disponibles.CurrentRow.DataBoundItem;
            bonoSeleccionado.registraLlegada(turnoSeleccionado);

            //se registar llegada
            //nueva fila en tabla consultas
            //poner bono usado:con_bonocodigo
            //con_fechallegada_afiliado: fecha del turnoConsulta

            Consulta registroLlegada = new Consulta();
            registroLlegada.turno = turnoSeleccionado.tur_codigo;
            registroLlegada.bono = bonoSeleccionado.codigoBono;
            registroLlegada.fechaLlegadaAfiliado = turnoSeleccionado.tur_fecha;
            registroLlegada.registrarLlegadaConsulta();

           //el turnoConsulta pasa a registrado 

           turnoSeleccionado.registraLlegadaAfiliado();

           MessageBox.Show("Se ha registrado la llegada del afiliado con éxito", "Registro de Llegada", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

           this.Close();
            
            
        }
    }
    }
}
