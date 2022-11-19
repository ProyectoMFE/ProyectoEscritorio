using Datos.DAO;
using Negocio.EntitiesDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos.Infrastructure;
using System.Net;
using System.Text.Json;

namespace Negocio.Management
{
    public class SolicitudManagement
    {
        public bool insertarSolicitud(string correo, string numSerie)
        {
            try
            {            
                WebResponse res = HttpConnection.Send(null, "POST", "api/Solicitudes?numSerie="+numSerie+"&correo="+correo);
                return true;

            }
            catch (Exception)
            {
                return false;
            }
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
            WebResponse res = HttpConnection.Send(null, "GET", "api/Solicitudes");
            string json = HttpConnection.ResponseToJson(res);
            List<Solicitud> lista = JsonSerializer.Deserialize<List<Solicitud>>(json);

            return lista;

        }
    }
}
