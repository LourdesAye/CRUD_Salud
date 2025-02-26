using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClinicaFrba.Datos;
using ClinicaFrba.Datos.Dao;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Windows.Forms;
using System.Globalization;

namespace ClinicaFrba.Modelo
{
    public class Usuario
    {
        public Decimal codigoDeUsuario { get; set;} 
       public String username { get; set; }
       public String password { get; set; }
       public DateTime fechaCreacion { get; set; }
       public DateTime fechaUltimaModif { get; set; }
       public String preguntaSecreta { get; set; }
       public String respuestaSecreta { get; set; }
       public Decimal intentosFallidos { get; set; }
       public Boolean inhabilitado { get; set; }
       public String nombre { get; set; }
       public String apellido { get; set; }
       public Int32 nroDocumento { get; set; }
       public String direccion { get; set; }
       public Int32 telefono { get; set; }
       public String mail { get; set; }
       public DateTime fechaNacimiento { get; set; }
        public Int32 sexo { get; set; }
        public Int32 tipoDocumento { get; set; }
        public Rol rolElegido { get; set; }
        
        public Usuario(string user)
        {
            
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@user", user));
            SqlDataReader lector = AccesoBaseDeDatos.GetDataReader("SELECT * FROM MEDGOOD.Usuarios WHERE usu_username=@user", "T", parametros);
            if (lector.HasRows)
            {
                lector.Read();
                username = user;
                //el encriptado deja la contraseña en mayúscula
                password = ((string)lector["usu_password"]).ToUpper();
                intentosFallidos = (Decimal)lector["usu_intentos_fallidos"];
                codigoDeUsuario = (Decimal)lector["usu_codigo"];
                inhabilitado = (bool)lector["Usu_inhabilitado"];   
            }
            
        }

        public Usuario()
        {
            // TODO: Complete member initialization
        }



        internal bool estaHabilitado()
        {
            return this.intentosFallidos < 3;
        }

        internal bool contraseñaCorrecta(string posiblePass)
        {
         return this.password.Equals(this.encriptacionPasswordFormulario(posiblePass));
            
        }

        //encriptación de la contraseña que recibo del formulario
        //lo pongo separado porque puede servir para afiliado
        internal string encriptacionPasswordFormulario(string posiblePass)
        {
            UTF8Encoding encoderHash = new UTF8Encoding();
            SHA256Managed hasher = new SHA256Managed();
            byte[] bytesDeHasheo = hasher.ComputeHash(encoderHash.GetBytes(posiblePass));
            return  bytesDeHasheoToString(bytesDeHasheo);
        }

        // Transformar lo hasheado a string
        private string bytesDeHasheoToString(byte[] array)
        {
            StringBuilder salida = new StringBuilder("");
            for (int i = 0; i < array.Length; i++)
                salida.Append(array[i].ToString("X2"));
            return salida.ToString();
        }

        internal void borrarIntentosFallidos()
        {
            DAOUsuario.reiniciarFallidos(this);
        }

        internal void incrementarIntentosFallidos()
        {
            DAOUsuario.incrementarFallidos(this);
        }


        internal List<Rol> getRoles()
        {
           return  Rol.getRolesDe(this);
        }

        internal bool FuncionalidadValida(string nombre_funcionalidad)
        {
            return this.rolElegido.funcionalidadValida(nombre_funcionalidad);
        }

        internal bool existeUsername()
        {
            return (codigoDeUsuario != 0);
            //return DAOUsuario.existeUsername(this.username);
        }

        internal bool afiliado()
        {
            return (String.Compare(this.rolElegido.nombre_rol, "Afiliado", false)==0);
        }

        public void create()
        {
            DAOUsuario.create(this);
        }

        internal bool fueBorrado()
        {
            return this.inhabilitado; 
        }

        internal bool existeNumeroDocumento(int nroDoc)
        {
            return DAOUsuario.existeNumeroDocumento(nroDoc);
        }
    }

}