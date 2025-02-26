using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClinicaFrba.Datos.Dao;

namespace ClinicaFrba.Modelo
{
    public class Consulta
    {
        public decimal codigoConsulta { get; set; }
        public decimal turno { get; set; }
        public decimal bono { get; set; }
        public DateTime fechaLlegadaAfiliado { get; set; }
        public DateTime fechaAtencionMedica {get;set;}
        public String sintomas {get;set;}
        public String diagnostico {get;set;}
        public String enfermedad {get;set;}
        public String comentarios { get; set; }

        internal void registrarLlegadaConsulta()
        {
            DAOConsulta.registrarLlegadaParaConsulta(this);
        }



        internal bool cumpleFechaAtencion(DateTime fechaConsulta)
        {
            return this.fechaLlegadaAfiliado <= fechaConsulta;
        }

        internal void cargarResultadosAtencion(Consulta atencionACargar)
        {
            DAOConsulta.cargarResultadosDeAtencion(this, atencionACargar);
        }

        internal void registraAtencion()
        {
            DAOConsulta.registroDeAtencion(this);
        }

        internal bool sosDeAfiliado(Afiliado posibleAfiliado)
        {
            return DAOConsulta.consultaEsDeAfiliado(this, posibleAfiliado);
        }
    }
}
