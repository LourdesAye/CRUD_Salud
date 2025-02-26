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
    class DAOProfesional
    {
        internal static int obtenerHoras(Usuario user, DateTime diaActual)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@user", user.codigoDeUsuario));
            parametros.Add(new SqlParameter("@dia", diaActual));
            SqlDataReader lector = AccesoBaseDeDatos.GetDataReader("MEDGOOD.SP_horas_prof", "SP", parametros);
            lector.Read();
            Int32 numero = Convert.ToInt32(lector["minutos"]);
            lector.Close();
            return numero;
        }

        internal static void agregarAgenda(Usuario user, DateTime fechaInicio, DateTime fechaFin, TimeSpan horarioInicio, TimeSpan horarioFin, string especialidad)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@user", user.codigoDeUsuario));
            parametros.Add(new SqlParameter("@fechaInic", fechaInicio));
            parametros.Add(new SqlParameter("@fechaFin", fechaFin));
            parametros.Add(new SqlParameter("@horInic", horarioInicio));
            parametros.Add(new SqlParameter("@horFin", horarioFin));
            decimal codigoEsp = DAOEspecialidades.obtenerEspecialidadUser(especialidad);
            parametros.Add(new SqlParameter("@esp", codigoEsp));
            AccesoBaseDeDatos.WriteInBase("MEDGOOD.sp_registrar_agenda", "SP", parametros);
        }

        internal static List<Profesional> buscarProfesionalesEspec(string esp)
        {
            List<Profesional> profesionales = new List<Profesional>();
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@esp", esp));
            SqlDataReader lector = AccesoBaseDeDatos.GetDataReader("MEDGOOD.SP_buscar_prof_con_esp", "SP", parametros);
            while (lector.Read())
            {
                Profesional unProf = new Profesional();
                unProf.matricula = Convert.ToInt32(lector["pro_matricula"]);
                if (lector["pro_observaciones"] == DBNull.Value)
                {
                    unProf.observaciones = "";
                }
                else
                {
                    unProf.observaciones = (String)lector["pro_observaciones"];
                }
                unProf.numero = Convert.ToDecimal(lector["pro_numero"]);
                unProf.nombre = (String)lector["usu_nombre"];
                unProf.apellido = (String)lector["usu_apellido"];
                if (lector["usu_direccion"] == DBNull.Value)
                {
                    unProf.direccion = String.Empty;
                }
                else
                {
                    unProf.direccion = (String)lector["usu_direccion"];
                }
                if (lector["usu_mail"] == DBNull.Value)
                {
                    unProf.mail = String.Empty;
                }
                else
                {
                    unProf.mail = (String)lector["usu_mail"];
                }
                if (lector["usu_telefono"] == DBNull.Value)
                {
                    unProf.telefono = 0;
                }
                else
                {
                    unProf.telefono = Convert.ToInt32(lector["usu_telefono"]);
                }
                profesionales.Add(unProf);
            }
            lector.Close();
            return profesionales;
        }

        internal static DateTime obtenerUltimaAgenda(decimal numero, out Boolean agendaCargada)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@pro", numero));
            SqlDataReader lector = AccesoBaseDeDatos.GetDataReader("SELECT MAX(age_fechafin) as MaxFecha FROM MEDGOOD.Agenda WHERE age_profesional=@pro", "T", parametros);
            lector.Read();
            DateTime data = new DateTime();
            if (lector["MaxFecha"] == DBNull.Value)
            {
                agendaCargada = false;
                data = DateTime.Parse("31/12/2199");
            }
            else
            {
                agendaCargada = true;
                data = (DateTime)lector["MaxFecha"];
            }
            lector.Close();
            return data;
        }

        internal static Horario obtenerHorarioParaFecha(decimal numeroProf, DateTime fecha)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@pro", numeroProf));
            parametros.Add(new SqlParameter("@fecha", fecha));
            SqlDataReader lector = AccesoBaseDeDatos.GetDataReader("MEDGOOD.sp_obtener_Horario", "SP", parametros);
            Horario horario = new Horario();
            if (lector.HasRows)
            {
                lector.Read();
                DateTime date = new DateTime();
                if (lector["age_horainicio"] == DBNull.Value)
                {
                    horario.horarioInicio = DateTime.MinValue;
                }
                else
                {
                    DateTime.TryParse(lector["age_horainicio"].ToString(), out date);
                    horario.horarioInicio = date;
                }
                if (lector["age_horafin"] == DBNull.Value)
                {
                    horario.horarioFin = DateTime.MinValue;
                }
                else
                {
                    DateTime.TryParse(lector["age_horafin"].ToString(), out date);
                    horario.horarioFin = date;
                }
            }
            else
            {
                horario.horarioInicio = DateTime.MinValue;
                horario.horarioFin = DateTime.MinValue;
            }


            lector.Close();
            return horario;
        }

        internal static Boolean verficarRepeticionAgenda(DateTime fechaComienzo, DateTime fechaFin,String especialidad, Usuario user, DateTime horaInicio, DateTime horaFin)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@fechaComienzo", fechaComienzo));
            parametros.Add(new SqlParameter("@fechaFin", fechaFin));
            parametros.Add(new SqlParameter("@prof", user.codigoDeUsuario));
            parametros.Add(new SqlParameter("@horaInicio", horaInicio.TimeOfDay));
            parametros.Add(new SqlParameter("@horaFin", horaFin.TimeOfDay));
            SqlDataReader lector = AccesoBaseDeDatos.GetDataReader("SELECT * FROM MEDGOOD.Agenda WHERE ((@horaInicio BETWEEN age_horainicio AND age_horafin) OR (@horaFin BETWEEN age_horainicio AND age_horafin)) AND ((@fechaComienzo BETWEEN age_fechainicio AND age_fechafin) OR (@fechaFin BETWEEN age_fechainicio AND age_fechafin)) AND age_profesional=(SELECT pro_numero FROM MEDGOOD.Profesionales WHERE pro_codigo_usuario=@prof)", "T", parametros);
            lector.Read();
            return (lector.HasRows);
        }

        internal static List<Agenda> obtenerAgenda(Usuario user, DateTime fechaActual)
        {
            List<Agenda> dias = new List<Agenda>();
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@prof", user.codigoDeUsuario));
            parametros.Add(new SqlParameter("@fecha", fechaActual));
            SqlDataReader lector = AccesoBaseDeDatos.GetDataReader("SELECT * FROM MEDGOOD.Agenda WHERE age_profesional=(SELECT pro_numero FROM MEDGOOD.Profesionales WHERE pro_codigo_usuario=@prof) AND @fecha < age_fechainicio", "T", parametros);
            while (lector.Read())
            {
                Agenda agenda = new Agenda();
                DateTime fechaInicio = new DateTime();
                DateTime fechaFin = new DateTime();
                DateTime horaInicio = new DateTime();
                DateTime horaFin = new DateTime();
                DateTime.TryParse(lector["age_fechainicio"].ToString(), out fechaInicio);
                DateTime.TryParse(lector["age_fechafin"].ToString(), out fechaFin);
                DateTime.TryParse(lector["age_horainicio"].ToString(), out horaInicio);
                DateTime.TryParse(lector["age_horafin"].ToString(), out horaFin);
                agenda.fechaInicio = fechaInicio;
                agenda.fechaFin = fechaFin;
                agenda.horaInicio = horaInicio;
                agenda.horaFin = horaFin;
                dias.Add(agenda);
            }
            lector.Close();
            return dias;
        }
    }
}