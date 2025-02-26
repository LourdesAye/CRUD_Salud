using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace ClinicaFrba.Datos
{
    class AccesoBaseDeDatos
    {
       // para conectar base de datos con visual
        private static SqlConnection connection = new SqlConnection();

        public static SqlConnection GetConnection()
        {
            if (connection.State == ConnectionState.Closed)
            {
                connection.ConnectionString =
                   @System.Configuration.ConfigurationManager.AppSettings["ConnectionString"];
                // el string "ConnectionString" se obtiene del app.config
                connection.Open();
            }
            return connection;
        }

        private static SqlCommand BuildSQLCommand(string commandtext, List<SqlParameter> parameters)
        {
            // sqlCommand es para el manejo de instrucciones de sql desde visual
            SqlCommand sqlCommand = new SqlCommand();
            // necesita la conexion a la base de datos
            sqlCommand.Connection = GetConnection();
            //CommandText : propiedad a la que se le pasa procedimiento,tabla, instruccion (en formato string)
            sqlCommand.CommandText = commandtext;
            //la instruccion tiene parametros que se cargan desde visual
            if (parameters != null)
            {
                foreach (SqlParameter param in parameters) { sqlCommand.Parameters.Add(param); }
            }
            return sqlCommand;
        }


        public static object ExecStoredProcedure(string commandText, List<SqlParameter> parameters)
        {
          //para la ejecucion de un stored Procedure 
          //recibe nombre del stored procedure y la lista de parametros 
            try
            {
                SqlCommand sqlCommand = BuildSQLCommand(commandText, parameters);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.ExecuteNonQuery();
                return sqlCommand.Parameters["@ret"].Value;
            }
            catch { return 0; }
        }

        public static SqlDataReader GetDataReader(string commandtext, string commandtype, List<SqlParameter> parameters)
        {
            //SqlDataReader:para leer un conjunto de registros, filas de una tabla de una base de datos
            SqlCommand sqlCommand = BuildSQLCommand(commandtext, parameters);
            SetCommandType(commandtype, sqlCommand);
            //ExecuteReader:metodo de SqlCommand que crea el SqlDataReader
            return sqlCommand.ExecuteReader();
        }

        private static void SetCommandType(string commandtype, SqlCommand sqlCommand)
        {
            //para simplificar
            //CommandType:indica de que tipo es la instruccion de sql del CommandText
            //CommandType puede ser: StoredProcedure,TableDirect,Text
            switch (commandtype)
            {
                case "T":
                    sqlCommand.CommandType = CommandType.Text;
                    break;
                case "TD":
                    sqlCommand.CommandType = CommandType.TableDirect;
                    break;
                case "SP":
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    break;
            }
        }

        public static int  WriteInBase(string commandtext, string commandtype, List<SqlParameter> parameters)
        {
            //para modificar base de datos ya sea instruccion o stored procedure
            SqlCommand sqlCommand = BuildSQLCommand(commandtext, parameters);
            SetCommandType(commandtype, sqlCommand);
            return sqlCommand.ExecuteNonQuery();

        }
    }
}
