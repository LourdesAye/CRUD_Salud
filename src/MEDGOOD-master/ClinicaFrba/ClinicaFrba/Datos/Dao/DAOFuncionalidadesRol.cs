using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClinicaFrba.Modelo;
using System.Data.SqlClient;

namespace ClinicaFrba.Datos.Dao
{
    class DAOFuncionalidadesRol
    {

        internal static bool tieneFuncionalidadElRol(Rol rol, Funcionalidad funcionalidad)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@codigoRol", rol.codigo_rol));
            parametros.Add(new SqlParameter("@codigoFuncionalidad", funcionalidad.codigo_Funcionalidad));
            SqlDataReader lector = AccesoBaseDeDatos.GetDataReader("MEDGOOD.sp_tieneFuncionalidadElRol", "SP", parametros);

            if (lector.HasRows)
            {
                while (lector.Read())
                {
                    rol.codigo_rol = (Decimal)lector["fun_rol_codigo"];
                    funcionalidad.codigo_Funcionalidad = (Decimal)lector["fun_fun_codigo"];
                    rol.funcionalidades.Add(funcionalidad);
                }

            }

            return rol.funcionalidades.Count >= 1;
        }

        internal static void agregraFuncionalidadARol(Rol rol, Funcionalidad funcionalidad)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@cod_funcionalidad", funcionalidad.codigo_Funcionalidad));
            parametros.Add(new SqlParameter("@cod_rol", rol.codigo_rol));
            AccesoBaseDeDatos.WriteInBase("MEDGOOD.agregarFuncionalidad_ARol", "SP", parametros);
        }

        internal static void eliminarFuncionalidadDeRol(Rol rol, Funcionalidad funcionalidad)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@cod_rol", rol.codigo_rol));
            parametros.Add(new SqlParameter("@cod_funcionalidad", funcionalidad.codigo_Funcionalidad));
            AccesoBaseDeDatos.WriteInBase("MEDGOOD.eliminar_funcionalidadDelRol", "SP", parametros);  
        }
    }
}