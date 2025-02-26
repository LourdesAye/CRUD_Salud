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
    public class DAOBonos
    {

        internal static List<Bono> obtenerBonosDisponiblesDeAfiliado(Decimal codigoAfiliado)
        {
            //bonos propios y del grupo familiar
            
            List<Bono> bonosDisponibles = new List<Bono>();
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@codAfi",codigoAfiliado));

            SqlDataReader lector = AccesoBaseDeDatos.GetDataReader("MEDGOOD.sp_buscar_bonosDisponibles", "SP", parametros);

            if (lector.HasRows)
            {
                while (lector.Read())
                {   
                    Bono bono = new Bono();
                    bono.codigoBono = (Decimal)lector["bon_codigo"];
                    bono.codigoCompra = (Decimal)lector["bon_codigocompra"];
                    bono.bonoFueUsado = (Boolean)lector["bon_fue_usado"];
                    bono.bonoIdPlanDisponible = (Decimal)lector["bon_codigoplan"];
                    bonosDisponibles.Add(bono);
                }
                lector.Close();
            }
 
            return bonosDisponibles;
        }

        internal static void registraLlegada(Bono bono, Turno turnoSeleccionado)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@codBono",bono.codigoBono));
            parametros.Add(new SqlParameter("@afiUsadorBono", turnoSeleccionado.tur_codigoafiliado));
            parametros.Add(new SqlParameter("@fechaUsoBono",turnoSeleccionado.tur_fecha));
            parametros.Add(new SqlParameter("@numeroConsulta", DAOConsulta.numeroDeConsultaAfiliado(turnoSeleccionado.tur_codigoafiliado)+1));
            AccesoBaseDeDatos.WriteInBase("MEDGOOD.sp_pagar_atencion_medica", "SP", parametros);

        }
    }
}
