using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClinicaFrba.Modelo;
using System.Data.SqlClient;

namespace ClinicaFrba.Datos.Dao
{
    class DAOCompraBono
    {
        internal static void registraCompra(CompraBono compraBono)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@codigo_afiliado", compraBono.codAfiliadoComprador));
            parametros.Add(new SqlParameter("@com_cantidad", compraBono.cantidadBonosComprados));
            parametros.Add(new SqlParameter("@com_monto_unidad", compraBono.precioUnitarioBonoConsulta));
            parametros.Add(new SqlParameter("@com_fecha", compraBono.fechacompra));
            parametros.Add(new SqlParameter("@com_monto_total",compraBono.totalAPagar));
            AccesoBaseDeDatos.WriteInBase("MEDGOOD.sp_registrar_compra","SP",parametros);
        }
    }
}
