using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClinicaFrba.Modelo;
using System.Data.SqlClient;


namespace ClinicaFrba.Datos.Dao
{
    class DAOConsulta
    {
        internal static void registrarLlegadaParaConsulta(Consulta consulta)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@turno", consulta.turno));
            parametros.Add(new SqlParameter("@bono", consulta.bono));
            parametros.Add(new SqlParameter("@fechaLlegadaAfiliado", consulta.fechaLlegadaAfiliado));
            AccesoBaseDeDatos.WriteInBase("MEDGOOD.sp_registroLlegada_Afiliado", "SP", parametros);
        }

        internal static List<Consulta> consultasPendientesDe(Especialista especialista,DateTime fechaDeHoy)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@codUser", especialista.codigoDeUsuario));
            parametros.Add(new SqlParameter("@fechaDeHoy", fechaDeHoy));
            SqlDataReader lector= AccesoBaseDeDatos.GetDataReader("MEDGOOD.sp_buscar_consultas_pendientes_profesional", "SP", parametros);
            List<Consulta> consultasPendientes = new List<Consulta>();
            if (lector.HasRows)
           {
               while (lector.Read())
               {
                   Consulta consultaPendiente= new Consulta();
                   consultaPendiente.codigoConsulta = (Decimal)lector["con_codigo"];
                   consultaPendiente.turno = (Decimal)lector["con_tur_numero"];
                   consultaPendiente.bono = (Decimal)lector["con_bonocodigo"];
                   consultaPendiente.fechaLlegadaAfiliado = (DateTime)lector["con_fechallegada_afiliado"];
                   consultasPendientes.Add(consultaPendiente);
               }
               lector.Close();
           }

            return consultasPendientes;
        }

        internal static void cargarResultadosDeAtencion(Consulta consulta, Consulta atencionACargar)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@codConsulta", consulta.codigoConsulta));
            parametros.Add(new SqlParameter("@diagnostico", atencionACargar.diagnostico));
            parametros.Add(new SqlParameter("@enfermedad", atencionACargar.enfermedad));
            parametros.Add(new SqlParameter("@sintomas", atencionACargar.sintomas));
            parametros.Add(new SqlParameter("@fechaAtencion", atencionACargar.fechaAtencionMedica));
            if (!String.IsNullOrEmpty(atencionACargar.comentarios))
            {
                parametros.Add(new SqlParameter("@comentarios", atencionACargar.comentarios));
            }
            else { //pone un vacio
                parametros.Add(new SqlParameter("@comentarios",""));
            }

            AccesoBaseDeDatos.WriteInBase("MEDGOOD.sp_registroResultados_consulta", "SP", parametros);
        }

        internal static void registroDeAtencion(Consulta consulta)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@codTurno", consulta.turno));
            AccesoBaseDeDatos.WriteInBase("MEDGOOD.sp_registro_atencionMedica", "SP", parametros);
        }

        internal static bool consultaEsDeAfiliado(Consulta consulta, Afiliado posibleAfiliado)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@codTurno", consulta.turno));
            parametros.Add(new SqlParameter("@codAfiliado", posibleAfiliado.codigoAfiliado));
            SqlDataReader lector = AccesoBaseDeDatos.GetDataReader("MEDGOOD.sp_validarUsuario_Turno", "SP", parametros);
            List<Turno> consultasDelTurno = new List<Turno>();

            if (lector.HasRows)
            {
                while (lector.Read())
                {
                    Turno turnoConsulta = new Turno();
                    turnoConsulta.tur_codigo = (Decimal)lector["tur_codigo"];
                    turnoConsulta.tur_codigoafiliado = (Decimal)lector["tur_codigoafiliado"];
                    consultasDelTurno.Add(turnoConsulta);
                }
                lector.Close();
            }

            return consultasDelTurno.Count>=1;
               
        }


        internal static Decimal numeroDeConsultaAfiliado(decimal codAfi)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@codAfiliado",codAfi));
            SqlDataReader lector = AccesoBaseDeDatos.GetDataReader("MEDGOOD.sp_cantidadConsultasBono_Afiliado", "SP", parametros);
            List<Consulta> consultasAfiliado = new List<Consulta>();
            if (lector.HasRows)
            {
                while (lector.Read())
                {
                    Consulta consultaAfi = new Consulta();
                    consultaAfi.codigoConsulta = (Decimal)lector["con_codigo"];
                    consultasAfiliado.Add(consultaAfi);
                }
                lector.Close();
            }

            return consultasAfiliado.Count;
        }
    }
}
