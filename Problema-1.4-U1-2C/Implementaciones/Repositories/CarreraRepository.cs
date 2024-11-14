using Problema_1._4_U1_2C.AccesoDatos;
using Problema_1._4_U1_2C.Presentacion.Dominio;
using Problema_1._4_U1_2C.Servicios.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problema_1._4_U1_2C.Servicios.Repositories
{
    public class CarreraRepository : ICarreraRepository
    {
        public void Create(Carrera carrera)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Carrera> GetAll()
        {
            List<Carrera> lstCarrera = new List<Carrera>();
            //CONECTAR A BD (LO hacemos con un Patron Singleton) Y TRAER REGISTROS
            var dt = DataHelper.GetInstance().ExecuteSPQuery("SP_RECUPERAR_CARRERAS", null); //Va a depositar en la dt todo lo que devuelve el metodo
            //MAPEAR (Recorrer los regstros y por cada registro hacer un objeto)
            foreach (DataRow item in dt.Rows) //Porque son las filas de la DT 
            {
                //CREO EL OBJETO, LE DOY LOS VALORES Y LO AGREGO A LA LISTA
               Carrera c = new Carrera();
                c.NroCarrera = (int)item["id"];
                c.Nombre = (string)item["Nombre"];
                c.Detalle = new List<DetalleCarrera>();
                if (!item.IsNull("detalle"))
                {
                    DetalleCarrera dc = new DetalleCarrera();
                    dc.NroDetalle = (int)item["nro"];
                    dc.AnioCursado = (int)item["anio_cursado"];
                    dc.Cuatrimestre = (int)item["cuatrimestre"];
                    dc.Materia = new List<Asignatura>();

                    if (!item.IsNull("nombre"))
                    {
                        Asignatura m = new Asignatura();
                        m.Id = (int)item["id"];
                        m.Nombre = item["nombre"].ToString();
                        dc.Materia.Add(m);
                    }
                    c.Detalle.Add(dc);
                }
                
                lstCarrera.Add(c);
            }
           //DESCONECTAR BD(SE DESCONECTA "SOLO")
           //EXECUTEREADER PARA LAS QUERY(SELECT)
           //EXECUTENONQUERY PARA LOS INSERT, UPDATE, DELETE
            return lstCarrera;
        }

        public Carrera GetById(int id)
        {
            var parameters = new List<ParameterSQL>();
            parameters.Add(new ParameterSQL("@idCarrera", id));
            DataTable dt = DataHelper.GetInstance().ExecuteSPQuery("SP_RECUPERAR_CARRERA_POR_ID", parameters);
            if(dt != null && dt.Rows.Count ==1)
            {
                DataRow row = dt.Rows[0];
                Carrera c = new Carrera();
                c.NroCarrera = (int)row["id"];
                c.Nombre = row["nombre"].ToString();
                c.Detalle = new List<DetalleCarrera>();
                if(!row.IsNull("detalle"))
                {
                    DetalleCarrera dc = new DetalleCarrera();
                    dc.NroDetalle = (int)row["nro"];
                    dc.AnioCursado = (int)row["anio_cursado"];
                    dc.Cuatrimestre = (int)row["cuatrimestre"];
                    dc.Materia = new List<Asignatura>();

                    if(!row.IsNull("materia"))
                    {
                        Asignatura a = new Asignatura();
                        a.Id = (int)row["id"];
                        a.Nombre = row["nombre"].ToString();
                        dc.Materia.Add(a);
                    }
                    c.Detalle.Add(dc);
                }
                return c;
            }
            else
            {
                return null;
            }
        }

        public Carrera GetByName(string name)
        {
            var parameters = new List<ParameterSQL>();
            parameters.Add(new ParameterSQL("@nombreCarrera", name));
            var dt = DataHelper.GetInstance().ExecuteSPQuery("SP_RECUPERAR_CARRERA_POR_NOMBRE", parameters);
            if (dt != null && dt.Rows.Count == 1)
            {
                DataRow row = dt.Rows[0];
                Carrera c = new Carrera();
                c.NroCarrera = (int)row["id"];
                c.Nombre = row["nombre"].ToString();
                c.Detalle = new List<DetalleCarrera>();
                if (!row.IsNull("detalle"))
                {
                    DetalleCarrera dc = new DetalleCarrera();
                    dc.NroDetalle = (int)row["nro"];
                    dc.AnioCursado = (int)row["anio_cursado"];
                    dc.Cuatrimestre = (int)row["cuatrimestre"];
                    dc.Materia = new List<Asignatura>();

                    if (!row.IsNull("materia"))
                    {
                        Asignatura a = new Asignatura();
                        a.Id = (int)row["id"];
                        a.Nombre = row["nombre"].ToString();
                        dc.Materia.Add(a);
                    }
                    c.Detalle.Add(dc);
                }
                return c;
            }
            else
            {
                return null;
            }
        }

        public void Update(int id)
        {
            throw new NotImplementedException();
        }
    }
}
