using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INF518Core.Clases
{
    public class TipoEstudiante
    {
        public int ID { get; set; }
        public string Descripcion { get; set; }
        public double CostoCredito { get; set; }
        public double CostoInscripcion { get; set; }
        public string Observaciones { get; set; }

        public TipoEstudiante()
        {

        }
    }
}