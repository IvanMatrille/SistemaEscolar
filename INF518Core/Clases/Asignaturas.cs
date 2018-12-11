using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INF518Core.Clases
{
    public class Asignaturas
    {
        public int ID { get; set; }
        public string Descripcion { get; set; }
        public string Clave { get; set; }
        public int IDCarrera { get; set; }
        public int Creditos { get; set; }
        public string Observaciones { get; set; }

        public Asignaturas()
        {

        }
    }
}
