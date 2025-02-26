using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClinicaFrba.Datos.Dao;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicaFrba.Modelo
{
     public class Afiliado: Usuario
    {
         // es el número de afiliado
         public decimal codigoAfiliado { get; set; }
         //es la pk de tabla Afiliado: afi_numeroafiliado
        public decimal idAfiliado { get; set; }
        public decimal estadoCivil { get; set; }
        public Int32 cantHijos { get; set; }
       // public decimal plan { get; set; }
        // necesito un objeto plan que contenga todo lo referenciado a él
        public PlanMedico planMedico { get; set; } 
        public decimal codUser { get; set; }
        public decimal afiliadoPrincial { get; set; }

       public void crearAfiliado()
        {
            DAOAfiliado.create(this);
        }

       public Afiliado() {
           planMedico = new PlanMedico();
       }

         
       /* public Afiliado(String user): base(user)
        {
            //base el el super de java
            //carga de afiliado y plan
            Afiliado afilAux= DAOAfiliado.cargarAfiliado(this,user);

        }
         */

       /* public Afiliado(decimal valorDeBusqueda):base()
        {
           Afiliado afil=  DAOAfiliado.generarAfiliadoPorNumeroAfiliado(valorDeBusqueda);
           this.idAfiliado= afil.idAfiliado;
           PlanMedico planAfil = new PlanMedico();
           planAfil.precio_bono_consulta = afil.planMedico.precio_bono_consulta;
           planAfil.codigo = afil.planMedico.codigo;
           planAfil.descripcion = afil.planMedico.descripcion;
           planMedico = planAfil;
        }
        * */


        internal bool existeAfiliado()
        {
            return DAOAfiliado.existeCodigoAfiliado(this);
        }

        internal void update()
        {
            DAOAfiliado.update(this);
        }

        internal void cargateConTuplan()
        {
            DAOAfiliado.cargarAfiliado(this);
        }

        internal Afiliado cargatePorTuCodigo()
        {
            return DAOAfiliado.cargarAfiliadoPorSuCodigo(this);
        }

    }
}
