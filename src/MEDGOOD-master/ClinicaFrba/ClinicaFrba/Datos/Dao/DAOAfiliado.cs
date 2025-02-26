using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClinicaFrba.Modelo;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ClinicaFrba.Datos.Dao
{
    class DAOAfiliado
    {
        internal static decimal obtenerIDNuevoAfiliado()
        {
            SqlDataReader lector = AccesoBaseDeDatos.GetDataReader("SELECT MAX(a.afi_codigoafiliado) AS codigo FROM MEDGOOD.Afiliados a", "T", new List<SqlParameter>());
            lector.Read();
            decimal codAfiliado = (decimal)lector["codigo"];
            lector.Close();
            return codAfiliado++;
        }

        internal static void create(Afiliado afiliado)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@estadoCivil", afiliado.estadoCivil));
            parametros.Add(new SqlParameter("@cantHijos", afiliado.cantHijos));
            parametros.Add(new SqlParameter("@plan", afiliado.planMedico.codigo));
            parametros.Add(new SqlParameter("@codUser", afiliado.codUser));
            parametros.Add(new SqlParameter("@afiliadoPrincipal", afiliado.afiliadoPrincial));
            AccesoBaseDeDatos.WriteInBase("MEDGOOD.SP_CREAR_AFILIADO", "SP", parametros);
        }

        internal static void update(Afiliado afiliado)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@estadoCivil", afiliado.estadoCivil));
            parametros.Add(new SqlParameter("@mail", afiliado.mail));
            parametros.Add(new SqlParameter("@tel", afiliado.telefono));
            parametros.Add(new SqlParameter("@dom", afiliado.direccion));
            parametros.Add(new SqlParameter("@cantHijos", afiliado.cantHijos));
            parametros.Add(new SqlParameter("@plan", afiliado.planMedico.codigo));
            parametros.Add(new SqlParameter("@user", afiliado.username));
            parametros.Add(new SqlParameter("@fecha", afiliado.fechaUltimaModif));
            AccesoBaseDeDatos.WriteInBase("MEDGOOD.SP_MODIF_AFILIADO", "SP", parametros);
        }

        internal static List<Usuario> obtenerAfiliados(String textNombre, String textApellido, String textFecha, String textDNI)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            List<Usuario> usuarios = new List<Usuario>();
            if (string.IsNullOrWhiteSpace(textNombre))
            {
                parametros.Add(new SqlParameter("@nombre", ""));
            }
            else
            {
                parametros.Add(new SqlParameter("@nombre", textNombre));
            }
            if (string.IsNullOrWhiteSpace(textApellido))
            {
                parametros.Add(new SqlParameter("@apellido", DBNull.Value));
            }
            else
            {
                parametros.Add(new SqlParameter("@apellido", textApellido));
            }
            if (string.IsNullOrWhiteSpace(textFecha))
            {
                parametros.Add(new SqlParameter("@fechaNac", DBNull.Value));
            }
            else
            {
                parametros.Add(new SqlParameter("@fechaNac", textFecha));
            }
            if (string.IsNullOrWhiteSpace(textDNI))
            {
                parametros.Add(new SqlParameter("@dni", -1));
            }
            else
            {
                parametros.Add(new SqlParameter("@dni", Convert.ToDecimal(textDNI)));
            }

            SqlDataReader lector = AccesoBaseDeDatos.GetDataReader("MEDGOOD.SP_BUSC_USUARIO", "SP", parametros);
            if (lector.HasRows)
            {
                while (lector.Read())
                {
                    Usuario usuarioNuevo = new Usuario();
                    usuarioNuevo.username = (String)lector["usu_username"];
                    usuarioNuevo.nombre = (String)lector["usu_nombre"];
                    usuarioNuevo.apellido = (String)lector["usu_apellido"];
                    if (lector["usu_fechanacimiento"] == DBNull.Value)
                    {
                        usuarioNuevo.fechaNacimiento = DateTime.Today;
                    }
                    else
                    {
                        usuarioNuevo.fechaNacimiento = (DateTime)lector["usu_fechanacimiento"];
                    }
                    usuarioNuevo.nroDocumento = Convert.ToInt32(lector["usu_nrodocumento"]);
                    usuarios.Add(usuarioNuevo);
                }
                lector.Close();
            }
            return usuarios;
        }

        internal static Afiliado cargaAfiliado(Afiliado afiliado, PlanMedico plan,SqlDataReader lector) 
        {
            afiliado.codigoAfiliado = (Decimal)lector["afi_codigoafiliado"];
            afiliado.idAfiliado = (Decimal)lector["afi_numeroafiliado"];
            plan.codigo = (Decimal)lector["pla_codigo"];
            plan.descripcion = (string)lector["pla_descripcion"];
            plan.precio_bono_consulta = (Decimal)lector["pla_bono_consulta"];
            afiliado.planMedico = plan;
            return afiliado;

        
        }

        internal static Afiliado cargarAfiliadoPorSuCodigo(Afiliado afiliado) 
        {
            PlanMedico plan = new PlanMedico();
            List<SqlParameter> parametros = new List<SqlParameter>();
           parametros.Add(new SqlParameter("@codAfiliado", afiliado.codigoAfiliado));
           SqlDataReader lector = AccesoBaseDeDatos.GetDataReader("MEDGOOD.sp_cargarAfiliado_porCodAfiliado", "SP", parametros);
            if (lector.HasRows)
            {
                while (lector.Read())
                {
                    cargaAfiliado(afiliado, plan, lector);
                }
                lector.Close();
            }

            return afiliado;
            
        }

        internal static bool existeCodigoAfiliado(Afiliado afiliadoposible)
        {
            List<Afiliado> afiliados = new List<Afiliado>();
            PlanMedico plan = new PlanMedico();
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@codAfiliado", afiliadoposible.codigoAfiliado));
            SqlDataReader lector = AccesoBaseDeDatos.GetDataReader("select afi_codigoafiliado,afi_numeroafiliado,pla_codigo,pla_descripcion,pla_bono_consulta from MEDGOOD.Afiliados,MEDGOOD.Planes where afi_codigoafiliado=@codAfiliado and  pla_codigo=afi_planmedico", "T", parametros);
            if (lector.HasRows)
            {
                while (lector.Read())
                {
                    cargaAfiliado(afiliadoposible, plan, lector);
                    afiliados.Add(afiliadoposible);
                }
                lector.Close();
            }
            
            return afiliados.Count() >= 1;

        }


        internal static decimal obtenerIDAfiliado(string usuario)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@user", usuario));
            SqlDataReader lector = AccesoBaseDeDatos.GetDataReader("SELECT * FROM MEDGOOD.USUARIOS, MEDGOOD.AFILIADOS WHERE USU_USERNAME=@user AND AFI_CODIGO_USERNAME=USU_CODIGO", "T", parametros);
            lector.Read();
            Decimal numero = Convert.ToDecimal(lector["afi_numeroafiliado"]);
            lector.Close();
            return numero;
        }

        internal static void cargarAfiliado(Afiliado afiliado)
        {
            PlanMedico plan = new PlanMedico();
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@codUser", afiliado.codigoDeUsuario));
            SqlDataReader lector = AccesoBaseDeDatos.GetDataReader("MEDGOOD.sp_cargaAfiliado_porCodUser", "SP", parametros);
            if (lector.HasRows)
            {
                while (lector.Read())
                {
                    cargaAfiliado(afiliado, plan, lector);
                }
                lector.Close();
            }
        }

       
       
    }
}
