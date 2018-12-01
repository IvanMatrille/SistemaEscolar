using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INF518Core
{
    public class Session
    {
        public int UsuarioID { get; set; }
        public string Usuario { get; set; }
        public string Permisos { get; set; }
        public string Nombre { get; set; }
        public bool Autenticado { get; set; }
        public string Password { get; set; }

    }
}
