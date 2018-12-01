using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using INF518Core.Clases;


namespace INF518Core
{
    public class ClaseBase
    {
        private Session session;
        private string strConn = string.Empty;
        private SqlConnection conn;
        private SqlCommand cmd;
        private SqlDataAdapter adapter;
        private ErrorResponse error;

        public ClaseBase(Session session)
        {
            this.session = session;
            strConn = ConfigurationManager.ConnectionStrings["strConn"].ToString();
   
            //instanciando los elementos del sql server
            conn = new SqlConnection(strConn);
            cmd = new SqlCommand();
            cmd.CommandTimeout = 30;
            adapter = new SqlDataAdapter(cmd);
            error = new ErrorResponse();
        }

        public Session Session {
            get
            {
                return this.session;
            }
            set
            {
                this.session = value;
            }
       }

        public ErrorResponse Error
        {
            get { return error; }
        }
        /// <summary>
        /// Retorna la cadena de conexión
        /// </summary>
        public string ConnectionString
        {
            get { return strConn; }
        }

        /// <summary>
        /// Retorna el objeto SQLCommand
        /// </summary>
        public SqlCommand Command
        {
            get
            {
                return cmd;
            }
        }

        public SqlDataAdapter Adapter
        {
            get
            {
                adapter = new SqlDataAdapter(cmd);
                return adapter;
            }
            set { adapter = value; }
        }

        /// <summary>
        /// Retorna el SqlConnection que se usará para conectarse al servidor.
        /// </summary>
        public SqlConnection Connection
        {
            get { return conn; }
        }
     }
}
