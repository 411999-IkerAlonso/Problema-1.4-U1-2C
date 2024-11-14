using Problema_1._4_U1_2C.Presentacion.Dominio;
using Problema_1._4_U1_2C.Servicios.Interfaces;
using Problema_1._4_U1_2C.Servicios.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problema_1._4_U1_2C.Implementaciones.Services
{
    public class CarreraRepositoryService
    {
        private ICarreraRepository _carreraRepository;

        public CarreraRepositoryService()
        {
            _carreraRepository = new CarreraRepository();
        }

        public List<Carrera> GetCarreras()
        {
            return _carreraRepository.GetAll();
        }

        public Carrera GetCarreraById(int id)
        {
            return _carreraRepository.GetById(id);
        }

        public Carrera GetCarreraByName(string name)
        {
            return _carreraRepository.GetByName(name);
        }
    }
}
