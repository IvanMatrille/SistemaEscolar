using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INF518Core.Clases
{
    public class Inscripcion
    {
        public int ID { get; set; }
        public int IDEstudiante { get; set; }
        public int IDSeccion { get; set; }
        public string Fecha { get; set; }
        
        public Inscripcion() { }
    }
}
