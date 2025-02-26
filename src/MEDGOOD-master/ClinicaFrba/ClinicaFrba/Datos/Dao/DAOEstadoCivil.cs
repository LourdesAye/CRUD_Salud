using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClinicaFrba.Modelo;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ClinicaFrba.Datos.Dao
{
    class DAOEstadoCivil
    {
        internal static decimal obtenerEstCivil(String estado)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@descripcion", estado));
            SqlDataReader lector = AccesoBaseDeDatos.GetDataReader("SELECT e.est_civil_codigo FROM MEDGOOD.EstadoCivil e WHERE e.est_civil_descripcion=@descripcion", "T", parametros);
            lector.Read();
            decimal codEstado = (decimal)lector["est_civil_codigo"];
            lector.Close();
            return codEstado;
        }

        internal static string recuperarEstCivil(decimal cod)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@cod", cod));
            SqlDataReader lector = AccesoBaseDeDatos.GetDataReader("SELECT e.est_civil_descripcion FROM MEDGOOD.EstadoCivil e WHERE e.est_civil_codigo=@cod", "T", parametros);
            lector.Read();
            string estado = (string) lector["est_civil_descripcion"];
            lector.Close();
            return estado;
        }
    }
}
