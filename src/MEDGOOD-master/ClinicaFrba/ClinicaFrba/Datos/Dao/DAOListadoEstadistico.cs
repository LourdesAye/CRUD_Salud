using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data;

namespace ClinicaFrba.Datos.Dao
{
    class DAOListadoEstadistico
    {

        internal DataTable obtenerEstadisticas(int semestre, int listado, int anio,int rol,int plan,int especialidadElegida)
        {

            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@Anio", anio));
            parametros.Add(new SqlParameter("@Semestre", semestre));
            parametros.Add(new SqlParameter("@TipoListado", listado));
            parametros.Add(new SqlParameter("@TipoUsuario",rol));
            parametros.Add(new SqlParameter("@TipoPlan",plan));
            parametros.Add(new SqlParameter("@Especialidad",especialidadElegida));

            SqlDataReader lector = AccesoBaseDeDatos.GetDataReader("MEDGOOD.Sp_ObtenerEstadisticas", "SP", parametros);

            DataTable dt = new DataTable();
            dt.Load(lector);
            return dt;

            
            }
        }
    }

