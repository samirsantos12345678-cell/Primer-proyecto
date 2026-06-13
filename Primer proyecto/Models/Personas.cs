using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace Primer_proyecto.Models
{
    public class Personas
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public DateTime FechaNac { get; set; }
        public string Correo { get; set; }
        public string Telefono { get; set; }

        [Ignore]  
        public string NombreCompleto => $"{Nombre} {Apellido}";
    }
}

