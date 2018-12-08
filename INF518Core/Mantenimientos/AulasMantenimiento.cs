using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using INF518Core.Clases;


namespace INF518Core
{
    public class AulasMantenimiento : ClaseBase
    {
        public AulasMantenimiento(Session session) : base(session)
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
            sql.Append("SELECT ID, Descripcion, Codigo, Capacidad, IDCentro, Observaciones "
                        + " FROM tblAulas ");
            if (!string.IsNullOrWhiteSpace(filtro))
            {
                sql.Append(" WHERE ");
                sql.Append(filtro);
                sql.Append(" AND Inactivo=0 ");
            }
            sql.Append("ORDER BY ID, Descripcion, Codigo");

            return GetDataTableFromSQL(sql.ToString());
        }

        public void Guardar(Aulas item)
        {
            StringBuilder sql = new StringBuilder();

            if (item.ID == 0)
            {
                sql.AppendFormat("INSERT INTO tblAulas ( Descripcion, Codigo, Capacidad, IDCentro, Observaciones ) "
                   + "VALUES "
                   + "( '{0}', '{1}', '{2}', '{3}', '{4}' )",
                   item.Descripcion,
                   item.Codigo,
                   item.Capacidad,
                   item.IDCentro,
                   item.Observaciones);
            }
            if (item.ID > 0)
            {
                sql.AppendFormat("UPDATE tblAulas SET "
                    + " Descripcion='{0}', Codigo='{1}', Capacidad='{2}', IDCentro='{3}', Observaciones='{4}' "
                    + " WHERE ID={5}",
                    item.Descripcion,
                    item.Codigo,
                    item.Capacidad,
                    item.IDCentro,
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

        public Aulas GetInfo(int id)
        {
            Aulas item = new Aulas();
            StringBuilder str = new StringBuilder();
            str.AppendFormat("SELECT ID, Descripcion, Codigo, Capacidad, IDCentro, Observaciones "
                             + " FROM tblAulas WHERE ID={0} AND Inactivo=0;", id);
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
                        item.Codigo = reader["Codigo"].ToString();
                        item.Capacidad = Convert.ToInt32(reader["Capacidad"].ToString());
                        item.ID = Convert.ToInt32(reader["IDCentro"].ToString());
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
                sql.AppendFormat("UPDATE tblAulas SET Inactivo='True' WHERE ID={0}", id);
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

        public DataTable GetTiposCentros()
        {
            DataTable dt = new DataTable();
            Command.CommandType = CommandType.Text;
            Command.Connection = Connection;
            Command.CommandText = "SELECT ID, Descripcion, NombreCorto, WebSite, Telefono, Observaciones FROM tblCentro"; //el query a la db
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