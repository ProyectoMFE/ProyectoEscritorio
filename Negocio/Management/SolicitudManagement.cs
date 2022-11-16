using Datos.DAO;
using Negocio.EntitiesDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos.Infrastructure;

namespace Negocio.Management
{
    public class SolicitudManagement
    {
        public bool insertarSolicitud(string correo, string numSerie)
        {
            return false;
        }

        public bool finalizarSolicitud(string correo, string numSerie)
        {
            return false;
        }

        public bool aceptarSolicitud(string correo, string numSerie)
        {
            return false;
        }

        public bool rechazarSolicitud(string correo, string numSerie)
        {
            return false;
        }

        public List<Solicitud> listarSolicitudes()
        {
            return null;
        }
    }
}
