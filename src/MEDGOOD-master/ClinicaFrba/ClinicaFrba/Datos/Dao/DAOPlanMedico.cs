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
    class DAOPlanMedico
    {
        
          internal static decimal obtenerPlanMedico(String descripcion)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@descripcion", descripcion));
            SqlDataReader lector = AccesoBaseDeDatos.GetDataReader("SELECT p.pla_codigo FROM MEDGOOD.Planes p WHERE p.pla_descripcion=@descripcion", "T", parametros);
            lector.Read();
            decimal codPlan = (decimal)lector["pla_codigo"];
            lector.Close();
            return codPlan;
        }
        
        internal static List<PlanMedico> obtenerPlanes()
        {
            List<PlanMedico> planes = new List<PlanMedico>();
            SqlDataReader lector = AccesoBaseDeDatos.GetDataReader("SELECT p.pla_descripcion FROM MEDGOOD.Planes p", "T", new List<SqlParameter>());
            while (lector.Read())
            {
                PlanMedico unPlan = new PlanMedico();
                unPlan.descripcion = (String)lector["pla_descripcion"];
                planes.Add(unPlan);
            }
            lector.Close();
            return planes;
        }

        internal static void obtenerPlanUsuario(Afiliado usuario)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@nroAfil", usuario.idAfiliado));
            SqlDataReader lector = AccesoBaseDeDatos.GetDataReader("SELECT * FROM MEDGOOD.Planes, MEDGOOD.Afiliados  WHERE pla_codigo=afi_planmedico AND afi_numeroafiliado=@nroAfil", "T", parametros);
            lector.Read();
            usuario.planMedico.codigo = Convert.ToDecimal(lector["pla_codigo"]);
            usuario.planMedico.descripcion = (string) lector["pla_descripcion"];
            usuario.planMedico.precio_bono_consulta = Convert.ToDecimal(lector["pla_bono_consulta"]);
            usuario.planMedico.bono_farmacia = Convert.ToDecimal(lector["pla_bono_farmacia"]);
            lector.Close();
        }

        internal static List<PlanMedico> getPlanes()
        {
            List<PlanMedico> planes = new List<PlanMedico>();
            SqlDataReader lector = AccesoBaseDeDatos.GetDataReader("SELECT p.pla_codigo,p.pla_descripcion FROM MEDGOOD.Planes p", "T", new List<SqlParameter>());
            while (lector.Read())
            {
                PlanMedico unPlan = new PlanMedico();
                unPlan.codigo = (Decimal)lector["pla_codigo"];
                unPlan.descripcion = (String)lector["pla_descripcion"];
                planes.Add(unPlan);
            }

            lector.Close();
            return planes;
        }

    }
}
