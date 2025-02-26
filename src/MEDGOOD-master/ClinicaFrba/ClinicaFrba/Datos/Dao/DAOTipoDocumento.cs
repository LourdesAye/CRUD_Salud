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
    class DAOTipoDocumento
    {
        internal static decimal obtenerTipoDoc(String desc)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@descripcion", desc));
            SqlDataReader lector = AccesoBaseDeDatos.GetDataReader("SELECT t.tip_codigo FROM MEDGOOD.TipoDocumento t WHERE t.tip_descripcion=@descripcion", "T", parametros);
            lector.Read();
            decimal codEstado = (decimal)lector["tip_codigo"];
            lector.Close();
            return codEstado;
        }
    }
}
