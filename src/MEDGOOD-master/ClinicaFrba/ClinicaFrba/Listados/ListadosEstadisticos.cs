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
namespace ClinicaFrba.Listados
{
    public partial class ListadosEstadisticos : FormBase
    {
        public List<PlanMedico> planes;
        private List<PlanMedico> planesAux;

        public ListadosEstadisticos()
        {
            InitializeComponent();
        }



        private void ListadosEstadisticos_Load(object sender, EventArgs e)
        {
            cargarSemestres();
            cargarAnios();
            cargarTiposListados();
            cargarPlanesMedicos();
            cargarRoles();
            cargarEspecialidades();
            cmbListado.SelectedIndex = -1;
            cbmAnio.SelectedIndex = 0;
            cmbRol.SelectedIndex = 0;
                label3.Visible = false;
                cmbRol.Visible = false;
               label5.Visible = false;
                cmbPlanes.Visible = false;
                label4.Visible = false;
                cmbEspecialidades.Visible = false;
            
        }

        private void cargarEspecialidades()
        {
            cmbEspecialidades.DataSource = DAOEspecialidades.especialidadesMedicas();
            cmbEspecialidades.DisplayMember = "esp_descripcion";
        }

        private void cargarPlanesMedicos()
        {
            planes = DAOPlanMedico.getPlanes();
            cmbPlanes.DataSource = planes;
            cmbPlanes.DisplayMember = "descripcion";
        }

        private void cargarRoles()
        {
            Dictionary<int, string> roles = new Dictionary<int, string>();
            roles.Add(1, "Afiliados");
            roles.Add(2, "Profesionales");
            roles.Add(3, "Profesionales y Afiliados");
            //roles.Add(0, "Ninguno");
            cmbRol.DataSource = new BindingSource(roles, null);
            cmbRol.DisplayMember = "Value";
            cmbRol.ValueMember = "Key";
        }


        private void cargarTiposListados()
        {
            Dictionary<int, string> listados = new Dictionary<int, string>();
            listados.Add(1, "Especialidades con más cancelaciones");
            listados.Add(2, "Profesionales más consultados");
            listados.Add(3, "Profesionales con más horas trabajadas");
            listados.Add(4, "Afiliados con mayor cantidad de bonos comprados");
            listados.Add(5, "Especialidades con más bonos de consulta utilizados");
            cmbListado.DataSource = new BindingSource(listados, null);
            cmbListado.DisplayMember = "Value";
            cmbListado.ValueMember = "Key";
        }

        private void cargarAnios()
        {
            for (int i = 2000; i < 2025; i++)
                cbmAnio.Items.Add(i);
        }

        private void cargarSemestres()
        {
            Dictionary<int, string> trimestres = new Dictionary<int, string>();
            trimestres.Add(1, "1er. semestre");
            trimestres.Add(2, "2do. semestre");
            cmbSemestre.DataSource = new BindingSource(trimestres, null);
            cmbSemestre.DisplayMember = "Value";
            cmbSemestre.ValueMember = "Key";
        }

        private void gbElegir_Enter(object sender, EventArgs e)
        {

        }

        private Decimal obtenerPlan()
        {
            planesAux = new List<PlanMedico>();
            foreach (PlanMedico plan in planes)
                if (plan.descripcion == cmbPlanes.Text)
                {
                    planesAux.Add(plan);
                }
            return planesAux[0].codigo;

        }

        private void btnListar_Click(object sender, EventArgs e)
        {
            //validacion de elección de listado

            if (cmbListado.Text.Length == 0) {
                MessageBox.Show("Debe elegir un tipo de listado", "Advertencia elección tipo de listado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            DAOListadoEstadistico daoListadoEstadistico = new DAOListadoEstadistico();

            //obteniendo valores del formulario

            int semestre = Convert.ToInt32(cmbSemestre.SelectedValue);

            int listado = Convert.ToInt32(cmbListado.SelectedValue);

            int anio = Convert.ToInt32(cbmAnio.Text);

            int rol = Convert.ToInt32(cmbRol.SelectedValue);

            int plan = Convert.ToInt32(obtenerPlan());

            Especialidad especialidad = (Especialidad)cmbEspecialidades.SelectedItem;

            int especialidadElegida = Convert.ToInt32(especialidad.esp_codigo);

            //para devolver las diferentes busquedas

            dgvListado.DataSource = daoListadoEstadistico.obtenerEstadisticas(semestre, listado, anio, rol, plan, especialidadElegida);

        }

        private void cmbListado_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cbmAnio_SelectionChangeCommitted(object sender, EventArgs e)
        {
        }

        private void label1_Click(object sender, EventArgs e){
        

        }

        private void cmbListado_SelectionChangeCommitted(object sender, EventArgs e)
        {
            //ante el evento de cambiar combobox de listados se hacen visible o no ciertos campos

                int listado = Convert.ToInt32(cmbListado.SelectedValue);
                if (listado == 1)
                {
                    label3.Visible = true;
                    cmbRol.Visible = true;
                    label5.Visible = false;
                    cmbPlanes.Visible = false;
                    label4.Visible = false;
                    cmbEspecialidades.Visible = false;
                }
                if (listado == 3)
                {
                    label4.Visible = true;
                    cmbEspecialidades.Visible = true;
                    label3.Visible = false;
                    cmbRol.Visible = false;
                    label5.Visible = false;
                    cmbPlanes.Visible = false;
                }
                if (listado == 2)
                {
                    label5.Visible = true;
                    cmbPlanes.Visible = true;
                    label4.Visible = false;
                    cmbEspecialidades.Visible = false;
                    label3.Visible = false;
                    cmbRol.Visible = false;
                }
                if (listado == 4 || listado==5)
                {
                    label4.Visible = false;
                    cmbEspecialidades.Visible = false;
                    label5.Visible = false;
                    cmbPlanes.Visible = false;
                    label3.Visible = false;
                    cmbRol.Visible = false;
                }
            }


        }
    }