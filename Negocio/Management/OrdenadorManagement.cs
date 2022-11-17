using Datos.DAO;
using Datos.Infrastructure;
using Negocio.EntitiesDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Negocio.Management
{
    public class OrdenadorManagement
    {
        public Ordenador ObtenerOrdenador(string numSerie)
        {
            Ordenador ordenador;
            try
            {
                WebResponse res = HttpConnection.Send(null, "GET", "api/Ordenadores/" + numSerie);
                string json = HttpConnection.ResponseToJson(res);
                ordenador = JsonSerializer.Deserialize<Ordenador>(json);
            }
            catch (Exception)
            {
                ordenador = null;
            }          
            return ordenador;
        }

        public List<Ordenador> ObtenerOrdenadores()
        {
            return null;
        }

        public bool ModificarOrdenador(Ordenador dispositivo)
        {
            return false;
        }

        public bool InsertarOrdenador(Ordenador dispositivo)
        {
            try
            {
                Ordenador aux = ObtenerOrdenador(dispositivo.numSerie);

                if (aux != null)
                {
                    return false;
                }

                string json = JsonSerializer.Serialize(dispositivo);
                WebResponse res = HttpConnection.Send(json, "POST", "api/Ordenadores/");
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool BorrarOrdenador(string numSerie)
        {
            WebResponse res = HttpConnection.Send(null, "DELETE", "api/Ordenadores/" + numSerie);
            string json = HttpConnection.ResponseToJson(res);

            return true;
        }
    }
}
