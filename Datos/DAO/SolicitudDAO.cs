using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos.Infrastructure;

namespace Datos.DAO
{
    class SolicitudDAO : DAO<SOLICITUDES>
    {
        private ProyectoMFEEntities contexto;
        public bool borrar(object id)
        {
            throw new NotImplementedException();
        }

        public SOLICITUDES buscar(object id)
        {
            throw new NotImplementedException();
        }

        public List<SOLICITUDES> consultar()
        {
            throw new NotImplementedException();
        }

        public bool insertar(SOLICITUDES id)
        {
            throw new NotImplementedException();
        }

        public bool modificar(object id, SOLICITUDES nuevo)
        {
            throw new NotImplementedException();
        }
    }
}
