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
    public class InscripcionMantenimiento : ClaseBase
    {
        public InscripcionMantenimiento(Session session) : base(session)
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
            sql.Append("SELECT ID, IDEstudiante, Fecha "
                        + " FROM tblInscripcion ");
            if (!string.IsNullOrWhiteSpace(filtro))
            {
                sql.Append(" WHERE ");
                sql.Append(filtro);
                sql.Append(" AND Inactivo=0 ");
            }
            sql.Append("ORDER BY ID");

            return GetDataTableFromSQL(sql.ToString());
        }

        public void Guardar(Inscripcion item)
        {
            StringBuilder sql = new StringBuilder();

            if (item.ID == 0)
            {
                sql.AppendFormat("INSERT INTO tblInscripcion ( IDEstudiante, IDSeccion, Fecha ) "
                   + "VALUES "
                   + "( '{0}', '{1}', GETDATE() )",
                   item.IDEstudiante,
                   item.IDSeccion);
            }
            if (item.ID > 0)
            {
                sql.AppendFormat("UPDATE tblInscripcion SET "
                    + " IDEstudiante='{0}', Fecha='{1}' "
                    + " WHERE ID={5}",
                    item.IDEstudiante,
                    item.IDSeccion,             
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

        //Inscripcion Detalle Inscripcion
        public void GuardarDetalle(Inscripcion item)
        {
            StringBuilder sql = new StringBuilder();

            if (item.ID == 0)
            {
                sql.AppendFormat("INSERT INTO tblInscripcion ( IDEstudiante, IDSeccion, Fecha ) "
                   + "VALUES "
                   + "( '{0}', '{1}', CURDATE() )",
                   item.IDEstudiante,
                   item.IDSeccion);
            }
            if (item.ID > 0)
            {
                sql.AppendFormat("UPDATE tblInscripcion SET "
                    + " IDEstudiante='{0}', IDSeccion='{1}', Fecha=CURDATE() "
                    + " WHERE ID={2}",
                    item.IDEstudiante,
                    item.IDSeccion,
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


        public Inscripcion GetInfo(int id)
        {
            Inscripcion item = new Inscripcion();
            StringBuilder str = new StringBuilder();
            str.AppendFormat("SELECT ID, IDEstudiante, IDSeccion, Fecha "
                             + " FROM tblInscripcion WHERE ID={0} AND Inactivo=0;", id);
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
                        item.IDEstudiante = Convert.ToInt32(reader["IDEstudiante"].ToString());
                        item.IDSeccion = Convert.ToInt32(reader["IDSeccion"].ToString());
                        item.Fecha = reader["Fecha"].ToString();                        
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
                sql.AppendFormat("UPDATE tblInscripcion SET Inactivo='True' WHERE ID={0}", id);
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