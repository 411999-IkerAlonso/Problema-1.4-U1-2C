using Problema_1._4_U1_2C.Presentacion.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problema_1._4_U1_2C.Servicios.Interfaces
{
    public interface ICarreraRepository
    {
        //Recuperar todas las entidades
        List<Carrera> GetAll();
        //Filtrar y recuperar entidades según criterios de búsqueda
        //ID
        Carrera GetById(int id);
        //Name
        Carrera GetByName(string name);
        //Crear, modificar y registrar baja lógica de las entidades
        //CREAR
        void Create(Carrera carrera);
        //MODIFICAR
        void Update(int id);
        //BAJA LOGICA
        void Delete(int id);
    }
}
