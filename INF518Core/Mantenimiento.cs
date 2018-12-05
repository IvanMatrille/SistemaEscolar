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
            sql.Append("SELECT ID, IdTipoEstudiante, Matricula, Cedula, Nombre, Apellido, Sexo, FechaNacimiento,"
                    + " EstadoCivil, TelefonoCasa, TelefonoMovil, Email, Observaciones, IDCarrera "
                    + " FROM tblEstudiante ");
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
                 sql.AppendFormat("INSERT INTO tblEstudiante ( IdTipoEstudiante, Cedula, Nombre, Apellido, Sexo, FechaNacimiento,"
                    + " EstadoCivil, TelefonoCasa, TelefonoMovil, Email, Observaciones, IDCarrera)"
                    + " VALUES " 
                    + "( {0}, '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}', {11} )",
                    item.IdTipoEstudiante,
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
                    item.IDCarrera);
            }
            if (item.ID > 0)
            {
                sql.AppendFormat("UPDATE tblEstudiante SET "
                    + " IdTipoEstudiante={0}, Cedula='{1}', Nombre='{2}', Apellido='{3}', Sexo='{4}', FechaNacimiento='{5}', "
                    + "EstadoCivil='{6}', TelefonoCasa='{7}', TelefonoMovil='{8}', Email='{9}', Observaciones='{10}', "
                    + "IDCarrera={11}  WHERE ID={12}",
                    item.IdTipoEstudiante,
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
                    item.IDCarrera,
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
            str.AppendFormat("SELECT ID, IdTipoEstudiante, Matricula, Cedula, Nombre, Apellido, Sexo, FechaNacimiento,"
                    + " EstadoCivil, TelefonoCasa, TelefonoMovil, Email, Observaciones, IDCarrera "
                    + " FROM tblEstudiante WHERE ID={0};", id);
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
                        item.Matrícula = reader["Matricula"].ToString();
                        item.Sexo = reader["Sexo"].ToString();
                        item.EstadoCivil = reader["EstadoCivil"].ToString();
                        item.IDCarrera = Convert.ToInt32(reader[""].ToString());
                        item.balance = Convert.ToDouble(reader["Balance"].ToString());
                        item.FechaNacimiento = Convert.ToDateTime(reader["FechaNacimiento"]);
                        item.IdTipoEstudiante = Convert.ToInt32(reader["idTipoEstudiante"].ToString());
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
