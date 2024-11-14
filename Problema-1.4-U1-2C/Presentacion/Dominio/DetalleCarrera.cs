using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problema_1._4_U1_2C.Presentacion.Dominio
{
    public class DetalleCarrera
    {
        public int NroDetalle { get; set; }
        public int AnioCursado { get; set; }
        public int Cuatrimestre { get; set; }

        public List<Asignatura> Materia { get; set; }

        public DetalleCarrera()
        {
            AnioCursado = 0;
            Cuatrimestre = 0;
            Materia = new List<Asignatura>();
        }

        public DetalleCarrera(int nroDetalle, int anioCursado, int cuatrimestre, List<Asignatura> materia)
        {
            NroDetalle = nroDetalle;
            AnioCursado = anioCursado;
            Cuatrimestre = cuatrimestre;
            Materia = materia;
        }

        public override string ToString()
        {
            return $"Año Cursado: {AnioCursado} |Cuatrimestre: {Cuatrimestre} |Materia: {Materia}";
        }
    }
}
