using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaFrba.Modelo
{
    public class PlanMedico
    {
       public decimal codigo { get; set; }
       public String descripcion { get; set; }
       public decimal precio_bono_consulta { get; set; }
       public decimal bono_farmacia { get; set; }
    }
}
