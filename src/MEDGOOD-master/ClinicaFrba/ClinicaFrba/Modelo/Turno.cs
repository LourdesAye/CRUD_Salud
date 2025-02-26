using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClinicaFrba.Datos.Dao;

namespace ClinicaFrba.Modelo
{
    public class  Turno
    {
        public Decimal tur_codigo {get;set;}
        public Decimal tur_codigoafiliado {get;set;}
        public String nombreAfiliado { get; set; }
        public String apellidoAfiliado { get; set; }
        public DateTime tur_fecha{get;set;}
        public Decimal tur_profesionalcodigo{get;set;}
        public String nombreProfesional { get; set; }
        public String apellidoProfesional { get; set; }


        internal void registraLlegadaAfiliado()
        {
            DAOTurno.registrarLlegadaALaAtencion(this);
        }
    }
}
