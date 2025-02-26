using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClinicaFrba.Modelo;
using System.Data.SqlClient;

namespace ClinicaFrba.Datos.Dao
{
    class DAOEspecialidades
    {
        internal static List<Especialidad> getEspecialidadesMedicas()
        {
            List<Especialidad> especialidades = new List<Especialidad>();
            SqlDataReader lector = AccesoBaseDeDatos.GetDataReader("SELECT * FROM MEDGOOD.Especialidad", "T", new List<SqlParameter>());
            if (lector.HasRows)
            {
                while (lector.Read())
                {
                    Especialidad especialidad = new Especialidad();
                    especialidad.esp_codigo = (Decimal)lector["esp_codigo"];
                    especialidad.esp_descripcion = (String)lector["esp_descripcion"];
                    especialidad.esp_tipo_codigo= (Decimal)lector["esp_tipo_codigo"];

                    especialidades.Add(especialidad);
                }
                lector.Close();
            }
            return especialidades;

        }

        internal static List<Especialidad> obtenerEspecialidadUser(Usuario usuario)
        {
            List<Especialidad> especialidades = new List<Especialidad>();
            List<SqlParameter> parametros  = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@user", usuario.codigoDeUsuario));
            SqlDataReader lector = AccesoBaseDeDatos.GetDataReader("MEDGOOD.SP_ESPECIALIDADES_DE_USUARIO", "SP", parametros);
            if (lector.HasRows)
            {
                while (lector.Read())
                {
                    Especialidad especialidad = new Especialidad();
                    especialidad.esp_codigo = (Decimal)lector["esp_codigo"];
                    especialidad.esp_descripcion = (String)lector["esp_descripcion"];
                    especialidad.esp_tipo_codigo = (Decimal)lector["esp_tipo_codigo"];
                    especialidades.Add(especialidad);
                }
                lector.Close();
            }
            return especialidades;
        }

        internal static decimal obtenerEspecialidadUser(string especialidad)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@esp", especialidad));
            SqlDataReader lector = AccesoBaseDeDatos.GetDataReader("SELECT esp_codigo FROM MEDGOOD.Especialidad WHERE esp_descripcion=@esp", "T", parametros);
            lector.Read();
            decimal codigo = (decimal)lector["esp_codigo"];
            return codigo;
        }

        internal static List<Especialidad> especialidadesMedicas()
        {
            List<Especialidad> especialidades = getEspecialidadesMedicas();
            Especialidad especialidadNoElegida = new Especialidad();
            return especialidades;
        }
    }
}
