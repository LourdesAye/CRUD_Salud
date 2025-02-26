using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClinicaFrba.Datos.Dao;
using System.Windows.Forms;

namespace ClinicaFrba.Modelo
{
    public class Rol
    {
        public String nombre_rol { set; get; }
        public Boolean estado_inhabilitado { set; get; }
        public Decimal codigo_rol { get; set; }
        public Decimal userId { get; set; }
        public List<Funcionalidad> funcionalidades { get; set; }

        internal static List<Rol> getRolesDe(Usuario usuario)
        {
            return DAORol.getRolesDe(usuario);

        }

        internal void cargarFuncionalidades()
        {
            this.funcionalidades = DAOFuncionalidad.getFuncionalidadesDe(this);
        }

        internal bool funcionalidadValida(string nombre_funcionalidad)
        {
            return this.funcionalidades.Any(f => f.nombre_Funcionalidad.Equals(nombre_funcionalidad));
        }

        internal void create()
        {
            DAORol.crearRol(this);
        }

        internal bool tenesFuncionalidad(Funcionalidad funcionalidad)
        {
            return DAOFuncionalidadesRol.tieneFuncionalidadElRol(this, funcionalidad);
        }

        internal void agregaFuncionalidad(Funcionalidad funcionalidad)
        {
            DAOFuncionalidadesRol.agregraFuncionalidadARol(this, funcionalidad);
        }

        internal void eliminaFuncionalidad(Funcionalidad funcionalidad)
        {
            DAOFuncionalidadesRol.eliminarFuncionalidadDeRol(this, funcionalidad);
        }


        internal void modificaNombre(string nuevoNombre)
        {
            DAORol.cambiarNombreDeRol(this, nuevoNombre);
        }

        internal void actualizate(string nuevoNombre)
        {
            this.nombre_rol = nuevoNombre;
        }

        internal void habilitate()
        {
            DAORol.habilitarRol(this);
        }

        internal bool habilitado()
        {
            return !this.estado_inhabilitado;
        }

        internal void inhabilitate()
        {
            DAORol.inhabilitar(this);
        }
    }
}
