using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INF518Core.Clases
{
    public class Estudiante
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public int IdTipoEstudiante { get; set; }
        public string Cedula { get; set; }
        public string Matrícula { get; set; }
        public string Sexo { get; set; }
        public string EstadoCivil { get; set; }
        public string TelefonoCasa { get; set; }
        public string TelefonoMovil { get; set; }
        public string Email { get; set; }
        public string Observaciones { get; set; }
        public int IDCarrera { get; set; }
        public Double balance { get; set; }
        
        public Estudiante()
        {
            FechaNacimiento = DateTime.Now;
        }
    }
}
