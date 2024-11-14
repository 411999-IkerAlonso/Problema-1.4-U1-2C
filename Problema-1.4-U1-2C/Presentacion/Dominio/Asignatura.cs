using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problema_1._4_U1_2C.Presentacion.Dominio
{
    public class Asignatura
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        public Asignatura()
        {
            Nombre = string.Empty;
        }

        public Asignatura(int id, string nombre)
        {
            Id = id;
            Nombre = nombre;
        }

        public override string ToString()
        {
            return $"ASIGNATURA: {Nombre}";
        }
    }
}
