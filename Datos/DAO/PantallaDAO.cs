using Datos.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.DAO
{
    public class PantallaDAO : DAO<PANTALLAS>
    {
        private ProyectoMFEEntities contexto;

        public PantallaDAO()
        {
            this.contexto = new ProyectoMFEEntities();
        }

        public bool Borrar(object id)
        {
            PANTALLAS dispositivo;

            try
            {
                dispositivo = Buscar(id);
                contexto.PANTALLAS.Remove(dispositivo);
                contexto.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public PANTALLAS Buscar(object id)
        {
            try
            {
                return contexto.PANTALLAS.Where(p => p.NUM_SERIE == id).First();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<PANTALLAS> Consultar()
        {
            return contexto.PANTALLAS.ToList();
        }

        public bool Insertar(PANTALLAS objeto)
        {
            try
            {
                contexto.PANTALLAS.Add(objeto);
                contexto.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Modificar(object id, PANTALLAS nuevo)
        {
            PANTALLAS dispositivo;

            try
            {
                dispositivo = Buscar(id);

                dispositivo.NUM_SERIE = nuevo.NUM_SERIE;
                dispositivo.PULGADAS = nuevo.PULGADAS;

                contexto.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
