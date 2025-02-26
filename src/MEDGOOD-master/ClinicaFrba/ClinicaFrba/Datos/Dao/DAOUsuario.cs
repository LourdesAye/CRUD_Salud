using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using ClinicaFrba.Modelo;

namespace ClinicaFrba.Datos.Dao
{
    class DAOUsuario
    {


        internal static void reiniciarFallidos(Usuario usuario)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@codigo", usuario.codigoDeUsuario));
            parametros.Add(new SqlParameter("@username", usuario.username));
            AccesoBaseDeDatos.WriteInBase("MEDGOOD.sp_reiniciar_fallidos", "SP", parametros);
        }

        internal static void incrementarFallidos(Usuario usuario)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@us_intentos", usuario.intentosFallidos + 1));
            parametros.Add(new SqlParameter("@user", usuario.username));
            parametros.Add(new SqlParameter("@codigo", usuario.codigoDeUsuario));

            AccesoBaseDeDatos.WriteInBase("MEDGOOD.sp_incrementar_intentos_fallidos", "SP", parametros);
        }

        internal static decimal obtenerIDNuevoUsuario()
        {
            SqlDataReader lector = AccesoBaseDeDatos.GetDataReader("SELECT MAX(u.Usu_codigo) AS Usu_codigo FROM MEDGOOD.Usuarios u", "T", new List<SqlParameter>());
            lector.Read();
            decimal codUsuario = (decimal)lector["Usu_codigo"];
            lector.Close();
            return codUsuario;
        }


        internal static void create(Usuario usuario)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@user", usuario.username));
            parametros.Add(new SqlParameter("@pass", usuario.password));
            parametros.Add(new SqlParameter("@pregSecre", usuario.preguntaSecreta));
            parametros.Add(new SqlParameter("@resSecre", usuario.respuestaSecreta));
            parametros.Add(new SqlParameter("@nombre", usuario.nombre));
            parametros.Add(new SqlParameter("@apellido", usuario.apellido));
            parametros.Add(new SqlParameter("@nroDoc", usuario.nroDocumento));
            parametros.Add(new SqlParameter("@tipoDoc", usuario.tipoDocumento));
            parametros.Add(new SqlParameter("@direc", usuario.direccion));
            parametros.Add(new SqlParameter("@tel", usuario.telefono));
            parametros.Add(new SqlParameter("@mail", usuario.mail));
            parametros.Add(new SqlParameter("@fechaNac", usuario.fechaNacimiento));
            parametros.Add(new SqlParameter("@sexo", usuario.sexo));
            parametros.Add(new SqlParameter("@fechaCrea", usuario.fechaCreacion));
            AccesoBaseDeDatos.WriteInBase("MEDGOOD.sp_crear_usuario", "SP", parametros);
        }

        internal static void update(Usuario usuario)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@user", usuario.username));
            parametros.Add(new SqlParameter("@direc", usuario.direccion));
            parametros.Add(new SqlParameter("@tel", usuario.telefono));
            parametros.Add(new SqlParameter("@mail", usuario.mail));
            AccesoBaseDeDatos.WriteInBase("MEDGOOD.SP_MODIF_USUARIO", "SP", parametros);
        }


        internal static void delete(string username)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@user", username));
            AccesoBaseDeDatos.WriteInBase("UPDATE MEDGOOD.USUARIOS SET USU_INHABILITADO=1 WHERE USU_USERNAME=@USER", "T", parametros);
        }

        internal static bool existeUsername(String username)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@user", username));
            SqlDataReader lector = AccesoBaseDeDatos.GetDataReader("SELECT * FROM MEDGOOD.USUARIOS U WHERE USU_USERNAME=@user", "T", parametros);
            bool repetido = lector.HasRows;
            return repetido;
        }

        internal static bool existeNumeroDocumento(int nroDoc)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@nroDoc", nroDoc));
            SqlDataReader lector = AccesoBaseDeDatos.GetDataReader("SELECT * FROM MEDGOOD.USUARIOS U WHERE USU_NRODOCUMENTO=@nroDoc", "T", parametros);
            bool repetido = lector.HasRows;
            return repetido;
        }

        internal static Afiliado obtenerDatosUsuario(string user)
        {
            Afiliado usuario = new Afiliado();
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@user", user));
            SqlDataReader lector = AccesoBaseDeDatos.GetDataReader("SELECT * FROM MEDGOOD.USUARIOS, MEDGOOD.AFILIADOS WHERE USU_USERNAME=@user AND AFI_CODIGO_USERNAME=USU_CODIGO", "T", parametros);
            lector.Read();
            usuario.idAfiliado = Convert.ToDecimal(lector["afi_numeroafiliado"]);
            usuario.mail = (string)lector["usu_mail"];
            usuario.direccion = (string)lector["usu_direccion"];
            usuario.telefono = Convert.ToInt32(lector["usu_telefono"]);
            usuario.cantHijos = Convert.ToInt32(lector["afi_cantidadhijos"]);
            if (lector["afi_estadocivil"] == DBNull.Value)
            {
                usuario.estadoCivil = 1;
            }
            else
            {
                usuario.estadoCivil = Convert.ToDecimal(lector["afi_estadocivil"]);
            }
            DAOPlanMedico.obtenerPlanUsuario(usuario);
            lector.Close();
            return usuario;
        }

        internal static decimal obtenerIDUser(string user)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@user", user));
            SqlDataReader lector = AccesoBaseDeDatos.GetDataReader("SELECT usu_codigo FROM MEDGOOD.Usuarios u WHERE usu_username=@user", "T", parametros);
            lector.Read();
            decimal codUsuario = (decimal)lector["usu_codigo"];
            lector.Close();
            return codUsuario;
        }

        internal static bool obtenerTipo(string user)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@user", user));
            SqlDataReader lector = AccesoBaseDeDatos.GetDataReader("SELECT * FROM MEDGOOD.Usuarios, MEDGOOD.Profesionales  WHERE usu_username=@user AND pro_codigo_usuario=usu_codigo", "T", parametros);
            if (lector.HasRows)
            {
                lector.Close();
                return true;
            }
            else
            {
                lector.Close();
                return false;
            }
        }

        internal static List<Afiliado> getAfiliados()
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            SqlDataReader lector = AccesoBaseDeDatos.GetDataReader("MEDGOOD.sp_obtener_afiliados", "SP", parametros);
            List<Afiliado> afiliados = new List<Afiliado>();
            if (lector.HasRows)
            {
                while (lector.Read())
                {
                    Afiliado afiliado = new Afiliado();
                    PlanMedico planAux = new PlanMedico();
                    afiliado.codigoDeUsuario=(Decimal)lector["Usu_codigo"];
                    afiliado.idAfiliado=(Decimal)lector["afi_numeroafiliado"];
                    afiliado.codigoAfiliado= (Decimal)lector["afi_codigoafiliado"];
                    afiliado.nombre=(String)lector["Usu_nombre"];
                    afiliado.apellido=(String)lector["Usu_apellido"];
                    afiliado.nroDocumento=Convert.ToInt32(lector["Usu_nrodocumento"]);
                    planAux.codigo=(Decimal)lector["pla_codigo"];
                    planAux.descripcion=(String)lector["pla_descripcion"];
                    planAux.precio_bono_consulta = (Decimal)lector["pla_bono_consulta"];
                    afiliado.planMedico = planAux;
                    afiliados.Add(afiliado);
                }
                lector.Close();
            }
            return afiliados;
        }

        internal static bool tieneTurnosActivos(Usuario user, DateTime fecha)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@user", user.codigoDeUsuario));
            parametros.Add(new SqlParameter("@fecha", fecha));
            SqlDataReader lector = AccesoBaseDeDatos.GetDataReader("SELECT * FROM MEDGOOD.Turno WHERE (tur_codigoafiliado=(SELECT afi_numeroafiliado FROM MEDGOOD.Afiliados WHERE afi_codigo_username=@user) OR (tur_profesionalcodigo=(SELECT pro_numero FROM MEDGOOD.Profesionales WHERE pro_codigo_usuario=@user))) AND tur_estado IS NULL AND @fecha < tur_fecha", "T", parametros);
            lector.Read();
            bool tieneTurnos = lector.HasRows;
            lector.Close();
            return tieneTurnos;
        }
    }
}
