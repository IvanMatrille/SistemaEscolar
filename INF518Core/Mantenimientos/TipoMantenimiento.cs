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
    public class TipoMantenimiento : ClaseBase
    {
        public TipoMantenimiento(Session session) : base(session)
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

        public DataTable GetListado(string filtro)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("SELECT ID, Descripcion, CostoCredito, CostoInscripcion, Observaciones "
                        + " FROM tblTipoEstudiantes ");
            if (!string.IsNullOrWhiteSpace(filtro))
            {
                sql.Append(" WHERE ");
                sql.Append(filtro);
                sql.Append(" AND Inactivo=0 ");
            }
            sql.Append("ORDER BY ID, Descripcion");

            return GetDataTableFromSQL(sql.ToString());
        }

        public void Guardar(TipoEstudiante item)
        {
            StringBuilder sql = new StringBuilder();

            if (item.ID == 0)
            {
                sql.AppendFormat("INSERT INTO tblTipoEstudiantes ( Descripcion, CostoCredito, CostoInscripcion, Observaciones ) "
                   + "VALUES "
                   + "( '{0}', '{1}', '{2}', '{3}' )",
                   item.Descripcion,
                   item.CostoCredito,
                   item.CostoInscripcion,
                   item.Observaciones);
            }
            if (item.ID > 0)
            {
                sql.AppendFormat("UPDATE tblTipoEstudiantes SET "
                    + " Descripcion='{0}', CostoCredito='{1}', CostoInscripcion='{2}', Observaciones='{3}' "
                    + " WHERE ID={5}",
                    item.Descripcion,
                    item.CostoCredito,
                    item.CostoInscripcion,
                    item.Observaciones,
                    item.ID);
            }
            Command.CommandType = CommandType.Text;
            Command.Connection = Connection;
            Command.CommandText = sql.ToString();
            try
            {
                Connection.Open(); //abre la conexion
                Command.ExecuteNonQuery();
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

        public TipoEstudiante GetInfo(int id)
        {
            TipoEstudiante item = new TipoEstudiante();
            StringBuilder str = new StringBuilder();
            str.AppendFormat("SELECT ID, Descripcion, CostoCredito, CostoInscripcion, Observaciones "
                             + " FROM tblTipoEstudiantes WHERE ID={0} AND Inactivo=0;", id);
            Command.CommandText = str.ToString();
            Command.Connection = Connection;
            Command.CommandType = CommandType.Text;
            try
            {
                Connection.Open();
                SqlDataReader reader = Command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        item.ID = reader.GetInt32(0);
                        item.Descripcion = reader["Descripcion"].ToString();
                        item.CostoInscripcion = Convert.ToDouble(reader["CostoInscripcion"].ToString());
                        item.CostoCredito = Convert.ToDouble(reader["CostoCredito"].ToString());
                        item.Observaciones = reader["Observaciones"].ToString();
                    }
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                Error.ID = 0;
                Error.Descripcion = ex.Message;
            }
            finally
            {
                Connection.Close();
            }
            return item;
        }

        public void Eliminar(int id)
        {
            StringBuilder sql = new StringBuilder();

            if (id > 0)
            {
                sql.AppendFormat("UPDATE tblTipoEstudiantes SET Inactivo='True' WHERE ID={0}", id);
            }
            Command.CommandType = CommandType.Text;
            Command.Connection = Connection;
            Command.CommandText = sql.ToString();
            try
            {
                Connection.Open(); //abre la conexion
                Command.ExecuteNonQuery();
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

    }

}


