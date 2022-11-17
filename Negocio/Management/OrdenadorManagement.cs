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
            WebResponse res = HttpConnection.Send(null, "GET", "api/Ordenadores/" + numSerie);
            string json = HttpConnection.ResponseToJson(res);
            Ordenador ordenador = JsonSerializer.Deserialize<Ordenador>(json);

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
            return false;
        }

        public bool BorrarOrdenador(string numSerie)
        {
            return false;
        }
    }
}
