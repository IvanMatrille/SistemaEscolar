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
    public class Mantenimiento : ClaseBase
    {
        public Mantenimiento(Session session) : base(session)
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

        public DataTable GetListadoEstudiantes(string filtro)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("SELECT ID, Nombre, Apellido, FechaNacimiento " +
                " FROM tblEstudiante3 ");
            if (!string.IsNullOrWhiteSpace(filtro))
            {
                sql.Append(" WHERE ");
                sql.Append(filtro);
            }
            sql.Append(" ORDER BY ID, Nombre, Apellido");

            return GetDataTableFromSQL(sql.ToString());
        }

        public DataTable GetListadoOcupaciones()
        {
            DataTable dt = new DataTable();
            Command.CommandType = CommandType.Text;
            Command.Connection = Connection;
            Command.CommandText = "SELECT ID, Descripcion FROM tblTipoEstudiantes;"; //el query a la db
            try
            {
                Connection.Open(); //abre la conexion
                Adapter.Fill(dt); //llena el datatable de datos
                Error.ID = 1; //todo bien si es 1
                Error.Descripcion = "OK";
            }
            catch(Exception ex)
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

        public void GuardarEstudiante(Estudiante item)
        {
            StringBuilder sql = new StringBuilder();
            if (item.ID == 0)
            { 
                sql.AppendFormat("INSERT INTO tblEstudiante3 VALUES ('{0}','{1}','{2}')",
                    item.Nombre,
                    item.Apellido,
                    item.FechaNacimiento.Date.ToString("yyyy/MM/dd"));
            }
            if (item.ID > 0)
            {
                sql.AppendFormat("UPDATE tblEstudiante3 SET Nombre='{0}', Apellido='{1}', FechaNacimiento='{2}' WHERE ID={3}",
                    item.Nombre,
                    item.Apellido,
                    item.FechaNacimiento.Date.ToString("yyyy/MM/dd"), 
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

        public Estudiante GetEstudianteInfo(int id)
        {
            Estudiante item = new Estudiante();
            StringBuilder str = new StringBuilder();
            str.AppendFormat("SELECT ID, Nombre, Apellido, FechaNacimiento " +
                " FROM tblEstudiante3 WHERE ID={0};", id);
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
                        item.Nombre = reader["Nombre"].ToString();
                        item.Apellido = reader["Apellido"].ToString();
                        item.FechaNacimiento = Convert.ToDateTime(reader["FechaNacimiento"]);
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

        #region Usuarios

        public Session GetSessionInfo(string usuario)
        {
            Session item = new Session();
            StringBuilder str = new StringBuilder();
            str.Append("SELECT u.ID, u.Usuario, u.Nombre, u.Password, t.Permisos ");
            str.Append("FROM tblUsuarios1 u ");
            str.Append("INNER JOIN tblTipoUsuario1 t ON t.ID = u.IDTipoUsuario ");
            str.AppendFormat("WHERE UPPER(Usuario) = UPPER('{0}') AND u.Inactivo = 0 ", usuario);
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
                        item.UsuarioID = reader.GetInt32(0);
                        item.Usuario = reader["Usuario"].ToString();
                        item.Nombre = reader["Nombre"].ToString();
                        item.Password = reader["Password"].ToString();
                        item.Permisos = reader["Permisos"].ToString();
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





        #endregion

    }
}
