using Problema_1._4_U1_2C.Presentacion.Dominio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problema_1._4_U1_2C.AccesoDatos
{
    public class DataHelper
    {
        private static DataHelper _instance;
        private SqlConnection _connection;

        private DataHelper()
        {
            _connection = new SqlConnection(Properties.Resources.StrConnection);
        }

        public static DataHelper GetInstance()
        {
            if (_instance == null)
            {
                _instance = new DataHelper();
            }
            return _instance;
        }

        public DataTable ExecuteSPQuery(string sp, List<ParameterSQL>? parameters) //Esto n o sirve si se usa TRANSACTION
        {
            DataTable dt = new DataTable();
            try
            {
                _connection.Open();
                var cmd = new SqlCommand(sp, _connection);//Que ejecute el sp que le mande por parametro y lo haga a traves de esta conexion
                cmd.CommandType = CommandType.StoredProcedure;//Hay que configurarlo, Por defecto es Text(El select), no es eso lo que mando sino el Sp por eso hay que "decirselo"
                if (parameters != null)
                {
                    foreach (var param in parameters)
                    {
                        cmd.Parameters.AddWithValue(param.Name, param.Value);
                    }
                }
                dt.Load(cmd.ExecuteReader());//Hay que cargar el Datatable
                _connection.Close();
            }
            catch (SqlException)
            {
                dt = null;
            }
            return dt;
        }


        public int ExecuteSpDML(string sp, List<ParameterSQL>? parameters) //DML: Sentencias de Insercion, Edicion y Eliminacion
        {
            int rows;
            try
            {
                _connection.Open();
                var cmd = new SqlCommand(sp, _connection);
                cmd.CommandType = CommandType.StoredProcedure;
                if (parameters != null)
                {
                    foreach(var param in parameters)
                    {
                        cmd.Parameters.AddWithValue(param.Name, param.Value);
                    }
                }
                rows = cmd.ExecuteNonQuery();
                _connection.Close();
            }
            catch (SqlException)
            {
                rows = 0;
            }
            return rows;    
        }

        public SqlConnection GetConnection() //Lo hago asi porque sino rompe el singleton
        {
            return _connection;
        }

    }
}
