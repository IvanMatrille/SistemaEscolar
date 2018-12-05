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
    public class ProfesorMantenimiento : ClaseBase
    {
        public ProfesorMantenimiento(Session session) : base(session)
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
            sql.Append("SELECT ID, Cedula, Nombre, Apellido, Sexo, FechaNacimiento,"
                    + " EstadoCivil, TelefonoCasa, TelefonoMovil, Email, Observaciones "
                    + " FROM tblProfesor ");
            if (!string.IsNullOrWhiteSpace(filtro))
            {
                sql.Append(" WHERE ");
                sql.Append(filtro);
            }
            sql.Append(" ORDER BY ID, Nombre, Apellido");

            return GetDataTableFromSQL(sql.ToString());
        }

        public void Guardar(Profesor item)
        {
            StringBuilder sql = new StringBuilder();

            if (item.ID == 0)
            {
                sql.AppendFormat("INSERT INTO tblProfesor ( Cedula, Nombre, Apellido, Sexo, FechaNacimiento, "
                   + "EstadoCivil, TelefonoCasa, TelefonoMovil, Email, Observaciones) "
                   + "VALUES "
                   + "( '{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}' )",
                   item.Cedula,
                   item.Nombre,
                   item.Apellido,
                   item.Sexo,
                   item.FechaNacimiento.Date.ToString("yyyy/MM/dd"),
                   item.EstadoCivil,
                   item.TelefonoCasa,
                   item.TelefonoMovil,
                   item.Email,
                   item.Observaciones);
            }
            if (item.ID > 0)
            {
                sql.AppendFormat("UPDATE tblProfesor SET "
                    + " Cedula='{0}', Nombre='{1}', Apellido='{2}', Sexo='{3}', FechaNacimiento='{4}', "
                    + "EstadoCivil='{5}', TelefonoCasa='{6}', TelefonoMovil='{7}', Email='{8}', Observaciones='{9}', "
                    + " WHERE ID={10}",
                    item.Cedula,
                    item.Nombre,
                    item.Apellido,
                    item.Sexo,
                    item.FechaNacimiento.Date.ToString("yyyy/MM/dd"),
                    item.EstadoCivil,
                    item.TelefonoCasa,
                    item.TelefonoMovil,
                    item.Email,
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

        public Profesor GetInfo(int id)
        {
            Profesor item = new Profesor();
            StringBuilder str = new StringBuilder();
            str.AppendFormat("SELECT ID, Cedula, Nombre, Apellido, Sexo, FechaNacimiento,"
                    + " EstadoCivil, TelefonoCasa, TelefonoMovil, Email, Observaciones "
                    + " FROM tblProfesor WHERE ID={0};", id);
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
                        item.Observaciones = reader["Observaciones"].ToString();
                        item.Email = reader["Email"].ToString();
                        item.TelefonoCasa = reader["TelefonoCasa"].ToString();
                        item.TelefonoMovil = reader["TelefonoMovil"].ToString();
                        item.Cedula = reader["Cedula"].ToString();
                        item.Sexo = reader["Sexo"].ToString();
                        item.EstadoCivil = reader["EstadoCivil"].ToString();
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
