using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClinicaFrba.Datos.Dao;

namespace ClinicaFrba.Modelo
{
    public class CompraBono
    {
        //es el número de afiliado, no la pk
        public Decimal numeroAfiliadoComprador { set; get; }
        //es la pk de afiliado
      public  Decimal codAfiliadoComprador{get;set;}
      public Decimal  cantidadBonosComprados{get;set;}
      public DateTime fechacompra{get;set;}
      public Decimal precioUnitarioBonoConsulta { get; set; }
      public Decimal totalAPagar{get;set;}


      internal void registrate()
      {
          this.totalAPagar = cantidadBonosComprados * precioUnitarioBonoConsulta;
          DAOCompraBono.registraCompra(this);
      }
    }
}
