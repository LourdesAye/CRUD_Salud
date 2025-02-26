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
    class DAORol
    {
        internal static List<Rol> getRolesDe(Usuario usuario)
        {
            List<Rol> rolesDe = new List<Rol>();
            List<SqlParameter> paramList = new List<SqlParameter>();

            paramList.Add(new SqlParameter("@userId", usuario.codigoDeUsuario));
            SqlDataReader lector = AccesoBaseDeDatos.GetDataReader("MEDGOOD.sp_rolesDe", "SP", paramList);

            if (lector.HasRows)
            {
                while (lector.Read())
                {
                    Rol unRol = new Rol();
                    unRol.nombre_rol = (string)lector["rol_descripcion"];
                    unRol.codigo_rol = (decimal)lector["rol_codigo"];
                    unRol.estado_inhabilitado = (Boolean)lector["rol_Estado"];
                    unRol.userId = (decimal)lector["rol_usu_codigo"];
                    rolesDe.Add(unRol);
                }
            }
            return rolesDe;
        }

        internal static List<Rol> buscarRoles()
        {
            List<Rol> roles = new List<Rol>();
            SqlDataReader lector = AccesoBaseDeDatos.GetDataReader("SELECT ROL_CODIGO,ROL_DESCRIPCION,ROL_ESTADO FROM MEDGOOD.ROL", "T", new List<SqlParameter>());
            if (lector.HasRows)
            {
                while (lector.Read())
                {
                    Rol unRol = new Rol();
                    unRol.nombre_rol = (string)lector["rol_descripcion"];
                    unRol.codigo_rol = (decimal)lector["rol_codigo"];
                    unRol.estado_inhabilitado = (Boolean)lector["rol_Estado"];
                    roles.Add(unRol);
                }
                lector.Close();
            }
            return roles;
        }

        internal static bool existeNombreRol(string nombreRolNuevo)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@nombre", nombreRolNuevo));
            List<Rol> roles = new List<Rol>();
            SqlDataReader lector = AccesoBaseDeDatos.GetDataReader("SELECT R.ROL_CODIGO,R.ROL_DESCRIPCION FROM MEDGOOD.ROL R WHERE R.ROL_DESCRIPCION=@nombre", "T", parametros);
            if (lector.HasRows)
            {
                while (lector.Read())
                {
                    Rol unRol = new Rol();
                    unRol.codigo_rol = (decimal)lector["rol_codigo"];
                    unRol.nombre_rol = (string)lector["rol_descripcion"];
                    roles.Add(unRol);
                }
                lector.Close();
            }
            return roles.Count >= 1;
        }

        internal static void crearRol(Rol rol)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@cod_funcionalidad",rol.funcionalidades[0].codigo_Funcionalidad));
            parametros.Add(new SqlParameter("@nombre_rol", rol.nombre_rol));
            AccesoBaseDeDatos.WriteInBase("MEDGOOD.SP_CREAR_ROL", "SP", parametros);
        }


        internal static void cambiarNombreDeRol(Rol rol, string nuevoNombre)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@cod_rol", rol.codigo_rol));
            parametros.Add(new SqlParameter("@nombre_rol", nuevoNombre));
            AccesoBaseDeDatos.WriteInBase("MEDGOOD.sp_cambiarNombre_rol", "SP", parametros);

        }

        internal static void habilitarRol(Rol rol)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@cod_rol", rol.codigo_rol));
            AccesoBaseDeDatos.WriteInBase("MEDGOOD.sp_habilitar_rol", "SP", parametros);
        }

        internal static void inhabilitar(Rol rol)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@cod_rol",rol.codigo_rol));
            AccesoBaseDeDatos.ExecStoredProcedure("MEDGOOD.sp_inhabilitar_rol", parametros);
            
        }
    }
}
