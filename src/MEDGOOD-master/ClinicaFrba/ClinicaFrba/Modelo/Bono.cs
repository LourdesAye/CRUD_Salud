using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClinicaFrba.Datos.Dao;

namespace ClinicaFrba.Modelo
{
    public class Bono
    {
        public Decimal codigoBono{set;get;}
        public Decimal codigoCompra{set;get;}
        public Boolean bonoFueUsado{set;get;}
        public Decimal idAfiliado{set;get;}
        public Decimal bonoIdPlanDisponible{get;set;}
        public DateTime fechaimpresionBono {get;set;}
        public Decimal nroConsulta { get; set; }
        public Decimal cantBonosDisponibles { get; set; }

        internal void registraLlegada(Turno turnoSeleccionado)
        {
            DAOBonos.registraLlegada(this,turnoSeleccionado);
        }
    }
}
