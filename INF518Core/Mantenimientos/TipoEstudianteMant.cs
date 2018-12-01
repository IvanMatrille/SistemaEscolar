using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using INF518Core.Clases;

namespace INF518Core.Mantenimientos
{
    public class TipoEstudianteMant : ClaseBase
    {
        public TipoEstudianteMant(Session session) : base(session)
        {
        }

        public DataTable GetDataTableFromSQL(string sql)
        {
            DataTable dt = new DataTable();
            if (!string.IsNullOrWhiteSpace(sql))
            {
                Command.CommandType = CommandType.Text;
                Command.Connection = Connection;
                Command.CommandText = sql; //el query a la db
                try
                {
                    Connection.Open(); //abre la conexion
                    Adapter.Fill(dt); //llena el datatable de datos
                    Error.ID = 1; //todo bien si es 1
                    Error.Descripcion = "OK";
                }
                catch (Exception ex)
                {
                    Error.ID = 0; //0 es error
                    Error.Descripcion = ex.Message; //mensaje de error
                }
                finally
                {
                    Connection.Close(); //cierra la conexion
                }
            }
            return dt;
        }

        public DataTable GetTiposEstudiantes()
        {
            DataTable dt = new DataTable();
            Command.CommandType = CommandType.Text;
            Command.Connection = Connection;
            Command.CommandText = "SELECT ID, Descripcion, CostoCredito, CostoInscripcion, Observaciones, Inactivo FROM tblTipoEstudiantes;"; //el query a la db
            try
            {
                Connection.Open(); //abre la conexion
                Adapter.Fill(dt); //llena el datatable de datos
                Error.ID = 1; //todo bien si es 1
                Error.Descripcion = "OK";
            }
            catch (Exception ex)
            {
                Error.ID = 0; //0 es error
                Error.Descripcion = ex.Message; //mensaje de error
            }
            finally
            {
                Connection.Close(); //cierra la conexion
            }
            return dt;
        }


    }
}
