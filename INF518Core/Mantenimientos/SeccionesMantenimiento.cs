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
    public class SeccionesMantenimiento : ClaseBase
    {
        public SeccionesMantenimiento(Session session) : base(session)
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
            sql.Append("SELECT s.ID AS ID, a.Codigo AS IDAula, p.Nombre+' '+p.Apellido AS IDProfesor, "
                        + " s.Capacidad AS Capacidad, "
                        + " s.Dia1 AS Dia1, s.Hora1 AS Hora1, s.Dia2 AS Dia2, s.Hora2 AS Hora2, "
                        + " s.Observaciones AS Observaciones, asi.Descripcion AS IDasignatura"
                        + " FROM tblSecciones AS s "
                        + " INNER JOIN tblAulas AS a ON s.IDAula = a.ID "
                        + " INNER JOIN tblProfesor AS p ON s.IDProfesor = p.ID "
                        + " INNER JOIN tblAsignaturas AS asi ON s.IDAsignatura = asi.ID ");

            return GetDataTableFromSQL(sql.ToString());
        }


        public void Guardar(Seccion item)
        {
            StringBuilder sql = new StringBuilder();

            if (item.ID == 0)
            {
                sql.AppendFormat("INSERT INTO tblSecciones ( IDAula, IDProfesor, Capacidad, Dia1, Dia2, Hora1, Hora2, IDAsignatura, Observaciones ) "
                   + " VALUES "
                   + "( {0}, {1}, {2}, '{3}', '{4}', '{5}', '{6}', {7}, '{8}' )",
                   item.Aula,
                   item.Profesor,
                   item.Capacidad,
                   item.Dia1,
                   item.Dia2,
                   item.Hora1,
                   item.Hora2,
                   item.Asignatura,
                   item.Observaciones);
            }
            if (item.ID > 0)
            {
                sql.AppendFormat("UPDATE tblSecciones SET "
                    + " IDAula='{0}', IDProfesor='{1}', Capacidad='{2}', Dia1='{3}', Hora1='{4}' Dia2='{5}', Hora2='{6}', IDAsignatura='{7}', IDAsignatura='{8}' "
                    + " WHERE ID={9}",
                   item.Aula,
                   item.Profesor,
                   item.Capacidad,
                   item.Dia1,
                   item.Dia2,
                   item.Hora1,
                   item.Hora2,
                   item.Asignatura,
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

        public Seccion GetInfo(int id)
        {
            Seccion item = new Seccion();
            StringBuilder str = new StringBuilder();
            str.AppendFormat("SELECT ID, IDAula, IDProfesor, Capacidad, Dia1, Hora1, Dia2, Hora2, IDAsignatura, Observaciones "
                             + " FROM tblSecciones WHERE ID={0} AND Inactivo=0", id);
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
                        item.Aula = Convert.ToInt32(reader["IDAula"].ToString());
                        item.Profesor = Convert.ToInt32(reader["IDProfesor"].ToString());
                        item.Capacidad = Convert.ToInt32(reader["Capacidad"].ToString());
                        item.Dia1 = reader["Dia1"].ToString();
                        item.Dia2 = reader["Dia2"].ToString();
                        item.Hora1 = reader["Hora1"].ToString();
                        item.Hora2 = reader["Hora2"].ToString();
                        item.Asignatura = Convert.ToInt32(reader["IDAsignatura"].ToString());
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
                sql.AppendFormat("UPDATE tblSecciones SET Inactivo='True' WHERE ID={0}", id);
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

        //Verificar si aula esta disponible en horario, dia y profesor.
        public int validaSeccion1(int aula = 0, string hora = "", string dia = "")
        {
            int Existe = 0;
            StringBuilder str = new StringBuilder();
            str.AppendFormat("SELECT COUNT( ID ) AS contador"
                             + " FROM tblSecciones WHERE IDAula={0} AND Hora1='{1}' AND Dia1='{2}' AND Inactivo=0",
                             aula,
                             hora,
                             dia);
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
                        Existe = Convert.ToInt32(reader["contador"].ToString());
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
            return Existe;
        }

        public int validaSeccion2(int aula = 0, string hora = "", string dia = "")
        {
            int Existe = 0;
            StringBuilder str = new StringBuilder();
            str.AppendFormat("SELECT COUNT( ID ) AS contador"
                             + " FROM tblSecciones WHERE IDAula={0} AND Hora2='{1}' AND Dia2    ='{2}' AND Inactivo=0",
                             aula,
                             hora,
                             dia);
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
                        Existe = Convert.ToInt32(reader["contador"].ToString());
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
            return Existe;
        }

        /// <summary>
        /// Valida si el profesor esta libre ese dia y hora
        /// </summary>
        /// <param name="aula"></param>
        /// <param name="hora"></param>
        /// <param name="dia"></param>
        /// <returns></returns>
        public int validaProfesor1(int profesor = 0, string hora = "", string dia = "")
        {
            int Existe = 0;
            StringBuilder str = new StringBuilder();
            str.AppendFormat("SELECT COUNT( ID ) AS contador"
                             + " FROM tblSecciones WHERE IDProfesor={0} AND Hora1='{1}' AND Dia1='{2}' AND Inactivo=0",
                             profesor,
                             hora,
                             dia);
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
                        Existe = Convert.ToInt32(reader["contador"].ToString());
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
            return Existe;
        }



        public int validaProfesor2(int profesor = 0, string hora = "", string dia = "")
        {
            int Existe = 0;
            StringBuilder str = new StringBuilder();
            str.AppendFormat("SELECT COUNT( ID ) AS contador"
                             + " FROM tblSecciones WHERE IDProfesor={0} AND Hora2='{1}' AND Dia2='{2}' AND Inactivo=0",
                             profesor,
                             hora,
                             dia);
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
                        Existe = Convert.ToInt32(reader["contador"].ToString());
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
            return Existe;
        }
    }
}


