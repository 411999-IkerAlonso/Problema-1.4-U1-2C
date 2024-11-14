using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problema_1._4_U1_2C.Presentacion.Dominio
{
    public class Carrera
    {
        public int NroCarrera { get; set; }
        public string Nombre { get; set; }
        public List<DetalleCarrera> Detalle { get; set; }

        public Carrera()
        {
            Nombre = string.Empty;
            Detalle = new List<DetalleCarrera>();
        }

        public Carrera(int nroCarrera, string nombre,List<DetalleCarrera> detalle)
        {
            NroCarrera = nroCarrera;
            Nombre = nombre;
            Detalle = detalle;
        }

        public override string ToString()
        {
            return $"Carrera: {Nombre}";
        }
    }
}
