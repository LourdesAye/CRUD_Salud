using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClinicaFrba.Modelo;
using System.Data.SqlClient;

namespace ClinicaFrba.Datos.Dao
{
    class DAOFuncionalidad
    {

        internal static List<Funcionalidad> getFuncionalidadesDe(Rol rol)
        {
            List<Funcionalidad> funcionalidades = new List<Funcionalidad>();
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@cod_rol", rol.codigo_rol));

            SqlDataReader lector = AccesoBaseDeDatos.GetDataReader("MEDGOOD.sp_funcionalidadesDe", "SP", parametros);
            if (lector.HasRows)
            {
                while (lector.Read())
                {
                    Funcionalidad funcionalidad = new Funcionalidad();
                    funcionalidad.nombre_Funcionalidad = (string)lector["fun_Descripcion"];
                    funcionalidad.codigo_Funcionalidad = (decimal)lector["fun_Codigo"];
                    funcionalidades.Add(funcionalidad);
                }
                lector.Close();
            }
            return funcionalidades;
        }

        internal static List<Funcionalidad> buscarFuncionalidades()
        {
            List<Funcionalidad> funcionalidades = new List<Funcionalidad>();
            SqlDataReader lector = AccesoBaseDeDatos.GetDataReader("SELECT * FROM MEDGOOD.FUNCIONALIDAD", "T", new List<SqlParameter>());
            if (lector.HasRows)
            {
                while (lector.Read())
                {
                    Funcionalidad f = new Funcionalidad();
                    f.codigo_Funcionalidad = (decimal)lector["fun_Codigo"];
                    f.nombre_Funcionalidad = (string)lector["fun_Descripcion"];
                    funcionalidades.Add(f);
                }
                lector.Close();
            }
            return funcionalidades;
        }
    }
}
