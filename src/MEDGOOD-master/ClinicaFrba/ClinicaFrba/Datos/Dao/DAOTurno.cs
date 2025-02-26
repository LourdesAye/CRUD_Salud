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
    class DAOTurno
    {
        internal static List<Turno> turnosDeEspecialista(Especialidad especialidad, String apellidoProfesional, String nombreProfesional, DateTime fechaDelDia)
        {
            //nunca pasan vacios la fecha y la especialidad
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@fechaDeHoy", fechaDelDia));
            parametros.Add(new SqlParameter("@codEspecialidad", especialidad.esp_codigo));
            //armado de query
            String query = "select T.tur_codigo,T.tur_codigoafiliado,T.tur_fecha,T.tur_profesionalcodigo,"
             + "U.Usu_nombre,U.Usu_apellido, i.Usu_apellido as afi_apellido,i.Usu_nombre  as afi_nombre from MEDGOOD.Turno T,MEDGOOD.Usuarios U,MEDGOOD.Profesionales P,"
             + " MEDGOOD.ProfporEspecialidad PF,  MEDGOOD.Usuarios I ,MEDGOOD.Afiliados a where PF.esp_codigo=@codEspecialidad"
             + " and T.tur_profesionalcodigo=PF.pro_numero and PF.pro_numero=P.pro_numero"
             +"  AND a.afi_numeroafiliado=tur_codigoafiliado and i.Usu_codigo=a.afi_codigo_username"
             + " and convert(date,T.tur_fecha)=convert(date,@fechaDeHoy)"
             + " and p.pro_codigo_usuario=U.Usu_codigo and tur_estado is null";
            //ACA AGREGO CONDICIONES
            if (!string.IsNullOrWhiteSpace(nombreProfesional))
            { query += " and U.Usu_nombre LIKE '%" + nombreProfesional + "%'"; }

            if (!string.IsNullOrWhiteSpace(apellidoProfesional))
            { query += " and U.Usu_apellido LIKE '%" + apellidoProfesional + "%'"; }

            SqlDataReader lector = AccesoBaseDeDatos.GetDataReader(query, "T", parametros);

            List<Turno> turnos = new List<Turno>();
            if (lector.HasRows)
            {
                while (lector.Read())
                {
                    Turno turno = new Turno();
                    turno.tur_codigo = (Decimal)lector["tur_codigo"];
                    turno.tur_codigoafiliado = (Decimal)lector["tur_codigoafiliado"];
                    turno.tur_fecha = (DateTime)lector["tur_fecha"];
                    turno.tur_profesionalcodigo = (Decimal)lector["tur_profesionalcodigo"];
                    turno.nombreProfesional = (String)lector["Usu_nombre"];
                    turno.apellidoProfesional = (String)lector["Usu_apellido"];
                    turno.nombreAfiliado = (String)lector["afi_nombre"];
                    turno.apellidoAfiliado = (String)lector["afi_apellido"];

                    turnos.Add(turno);
                }
                lector.Close();
            }
            return turnos;

        }

        internal static void registrarLlegadaALaAtencion(Turno turno)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@codTurno", turno.tur_codigo));
            AccesoBaseDeDatos.WriteInBase("MEDGOOD.sp_registrarLlegada_turno", "SP", parametros);
        }

        internal static void registarTurno(decimal numeroProf, string afiliado, string especialidad, DateTime fecha)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@prof", numeroProf));
            parametros.Add(new SqlParameter("@afi", afiliado));
            parametros.Add(new SqlParameter("@esp", especialidad));
            parametros.Add(new SqlParameter("@fecha", fecha));
            AccesoBaseDeDatos.WriteInBase("MEDGOOD.sp_registrar_turno", "SP", parametros);
        }

        internal static List<string> obtenerTiposCancelacion()
        {
            List<String> tipos = new List<String>();
            SqlDataReader lector = AccesoBaseDeDatos.GetDataReader("SELECT can_descripcion FROM MEDGOOD.CancelacionTipo", "T", new List<SqlParameter>());
            if (lector.HasRows)
            {
                while (lector.Read())
                {
                    tipos.Add((String)lector["can_descripcion"]);
                }
                lector.Close();
            }
            return tipos;
        }

        internal static List<Turno> obtenerTurnos(string user, Boolean esProf, DateTime fechaActual)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            List<Turno> turnos = new List<Turno>();
            parametros.Add(new SqlParameter("@user", user));
            parametros.Add(new SqlParameter("@fechaActual", fechaActual));
            SqlDataReader lector;
            if (esProf)
            {
                lector = AccesoBaseDeDatos.GetDataReader("MEDGOOD.sp_turnos_del_pro", "SP", parametros);
                if (lector.HasRows)
                {
                    while (lector.Read())
                    {
                        Turno turno = new Turno();
                        turno.tur_codigo = (Decimal)lector["Turno"];
                        if (lector["Nombre Afiliado"] == DBNull.Value)
                        {
                            turno.nombreAfiliado = "Nombre desconocido";
                        }
                        else
                        {
                            turno.nombreAfiliado = (String)lector["Nombre Afiliado"];
                        }
                        if (lector["Apellido Afiliado"] == DBNull.Value)
                        {
                            turno.apellidoAfiliado = "Apellido desconocido";
                        }
                        else
                        {
                            turno.apellidoAfiliado = (String)lector["Apellido Afiliado"];
                        }
                        turno.tur_fecha = (DateTime)lector["Fecha"];
                        turno.tur_profesionalcodigo = (Decimal)lector["Profesional"];
                        turnos.Add(turno);
                    }
                    lector.Close();
                }
            }
            else
            {
                lector = AccesoBaseDeDatos.GetDataReader("MEDGOOD.sp_turnos_del_afi", "SP", parametros);
                if (lector.HasRows)
                {
                    while (lector.Read())
                    {
                        Turno turno = new Turno();
                        turno.tur_codigo = (Decimal)lector["Codigo"];
                        turno.tur_codigoafiliado = (Decimal)lector["Afiliado"];
                        turno.tur_fecha = (DateTime)lector["Fecha"];
                        if (lector["Nombre Medico"] == DBNull.Value)
                        {
                            turno.nombreProfesional = "Nombre desconocido";
                        }
                        else
                        {
                            turno.nombreProfesional = (String)lector["Nombre Medico"];
                        }
                        if (lector["Apellido Medico"] == DBNull.Value)
                        {
                            turno.apellidoProfesional = "Apellido desconocido";
                        }
                        else
                        {
                            turno.apellidoProfesional = (String)lector["Apellido Medico"];
                        }
                        turnos.Add(turno);
                    }
                    lector.Close();
                }
            }

            return turnos;
        }

        internal static void cancelarTurno(decimal user, decimal turno, string tipoCan, string motCan)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@CodigoUser", user));
            parametros.Add(new SqlParameter("@idturno", turno));
            Decimal tipoCanCod = DAOTurno.obtenerTipoCancelacion(tipoCan);
            parametros.Add(new SqlParameter("@idMotivo", tipoCanCod));
            parametros.Add(new SqlParameter("@Comentarios", motCan));
            AccesoBaseDeDatos.WriteInBase("MEDGOOD.sp_cancelarturno", "SP", parametros);
        }

        private static decimal obtenerTipoCancelacion(string tipoCan)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@tipo", tipoCan));
            SqlDataReader lector = AccesoBaseDeDatos.GetDataReader("SELECT can_codigo FROM MEDGOOD.CancelacionTipo WHERE can_descripcion=@tipo", "T", parametros);
            lector.Read();
            Decimal cod = Convert.ToDecimal(lector["can_codigo"]);
            lector.Close();
            return cod;
        }

        internal static bool validarTurnoRepetido(string afiliado, DateTime horario)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@user", afiliado));
            parametros.Add(new SqlParameter("@horario", horario));
            SqlDataReader lector = AccesoBaseDeDatos.GetDataReader("SELECT * FROM MEDGOOD.Turno WHERE tur_codigoafiliado=(SELECT afi_numeroafiliado FROM MEDGOOD.Usuarios, MEDGOOD.Afiliados WHERE Usu_username=@user AND afi_codigo_username=Usu_codigo) AND tur_fecha=@horario AND tur_estado IS NULL ", "T", parametros);
            Boolean tieneFilas = lector.HasRows;
            lector.Close();
            return tieneFilas;
        }

        internal static string obtenerUltimoTurno(string afiliado, DateTime horario)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@user", afiliado));
            parametros.Add(new SqlParameter("@horario", horario));
            SqlDataReader lector = AccesoBaseDeDatos.GetDataReader("SELECT MAX(tur_codigo) AS turno FROM MEDGOOD.Turno WHERE tur_codigoafiliado=(SELECT afi_numeroafiliado FROM MEDGOOD.Usuarios, MEDGOOD.Afiliados WHERE Usu_username=@user AND afi_codigo_username=Usu_codigo) AND tur_fecha=@horario AND tur_estado IS NULL ", "T", parametros);
            lector.Read();
            Decimal turno = Convert.ToDecimal(lector["turno"]);
            lector.Close();
            return turno.ToString();
        }
    }
}
