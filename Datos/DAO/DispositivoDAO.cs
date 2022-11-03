using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos.Infrastructure;

namespace Datos.DAO
{
    class DispositivoDAO : DAO<DISPOSITIVOS>
    {
        private ProyectoMFEEntities contexto;

        public bool borrar(object id)
        {
            DISPOSITIVOS dispositivo;

            try
            {
                dispositivo = buscar(id);
                contexto.DISPOSITIVOS.Remove(dispositivo);

                return true;
            } catch (Exception ex)
            {
                return false;
            }
        }

        public DISPOSITIVOS buscar(object id)
        {
            throw new NotImplementedException();
        }

        public List<DISPOSITIVOS> consultar()
        {
            throw new NotImplementedException();
        }

        public bool insertar(DISPOSITIVOS id)
        {
            throw new NotImplementedException();
        }

        public bool modificar(object id, DISPOSITIVOS nuevo)
        {
            throw new NotImplementedException();
        }
    }
}
