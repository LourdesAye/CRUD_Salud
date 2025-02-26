using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaFrba.Modelo
{
    public class Profesional : Usuario
    {
        public decimal numero { get; set; }
        public Int32 matricula { get; set; }
        public String observaciones { get; set; }
        public Int32 codUsuario { get; set; }

    }
}
