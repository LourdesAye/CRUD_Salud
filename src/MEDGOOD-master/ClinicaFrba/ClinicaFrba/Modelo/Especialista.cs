using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClinicaFrba.Datos.Dao;

namespace ClinicaFrba.Modelo
{
    public class Especialista: Usuario
    {
      public Decimal pro_numero{set;get;}
      public Decimal pro_matricula{set;get;}
      public String pro_observaciones{set;get;}
      public Decimal pro_codigo_usuario { set; get; }

      internal List<Consulta> consultasPendientesDelDia(DateTime fechaDeHoy)
      {
          return DAOConsulta.consultasPendientesDe(this,fechaDeHoy);
      }
    }
}
