using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INF518Core.Clases
{
    public class Seccion
    {
        public int ID { get; set; }
        public int Asignatura { get; set; }
        public int Aula { get; set; }
        public int Profesor { get; set; }
        public int Capacidad { get; set; }
        public string Dia1 { get; set; }
        public string Dia2 { get; set; }
        public string Hora1 { get; set; }
        public string Hora2 { get; set; }
        public string Observaciones { get; set; }

        public Seccion()
        {

        }
    }
}
