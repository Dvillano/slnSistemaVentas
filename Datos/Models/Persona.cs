using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Models
{
    public class Persona
    {
        public Persona () { }

        public Persona(int id, string nombre, string apellido, string dni)
        {
            Id = id;
            Nombre = nombre;
            Apellido = apellido;
            DNI = dni;
        }

        public Persona(string nombre, string apellido, string dni)
        {
            Nombre = nombre;
            Apellido = apellido;
            DNI = dni;
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string DNI { get; set; }
    }
}
