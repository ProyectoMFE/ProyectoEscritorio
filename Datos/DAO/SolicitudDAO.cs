using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos.Infrastructure;

namespace Datos.DAO
{
    public class SolicitudDAO : DAO<SOLICITUDES>
    {
        private ProyectoMFEEntities contexto;

        public SolicitudDAO()
        {
            this.contexto = new ProyectoMFEEntities();
        }

        public bool Borrar(object id)
        {
            SOLICITUDES solicitud;

            try
            {
                solicitud = Buscar(id);
                contexto.SOLICITUDES.Remove(solicitud);
                contexto.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public SOLICITUDES Buscar(object id)
        {
            return contexto.SOLICITUDES.Where(p => p.ID_USUARIO.Equals(id)).First();
        }

        public List<SOLICITUDES> Consultar()
        {
            return contexto.SOLICITUDES.ToList();
        }

        public bool Insertar(SOLICITUDES objeto)
        {
            try
            {
                contexto.SOLICITUDES.Add(objeto);
                contexto.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Modificar(object id, SOLICITUDES nuevo)
        {
            SOLICITUDES solicitud;

            try
            {
                solicitud = Buscar(id);

                solicitud.NUM_SERIE = nuevo.NUM_SERIE;
                solicitud.ID_USUARIO = nuevo.ID_USUARIO;
                solicitud.ESTADO = nuevo.ESTADO;

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
