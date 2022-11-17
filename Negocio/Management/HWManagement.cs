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
    public class HWManagement
    {
        public HWRed ObtenerHWRed(string numSerie)
        {
            HWRed ordenador;
            try
            {
                WebResponse res = HttpConnection.Send(null, "GET", "api/HwReds/" + numSerie);
                string json = HttpConnection.ResponseToJson(res);
                ordenador = JsonSerializer.Deserialize<HWRed>(json);
            }
            catch (Exception)
            {
                ordenador = null;
            }
            return ordenador;
        }

        public List<HWRed> ObtenerHWReds()
        {
            WebResponse res = HttpConnection.Send(null, "GET", "api/HwReds/");
            string json = HttpConnection.ResponseToJson(res);
            List<HWRed> lista = JsonSerializer.Deserialize<List<HWRed>>(json);

            return lista;
        }

        public bool ModificarHWRed(HWRed dispositivo)
        {
            return false;
        }

        public bool InsertarHWRed(HWRed dispositivo)
        {
            try
            {
                HWRed aux = ObtenerHWRed(dispositivo.numSerie);

                if (aux != null)
                {
                    return false;
                }

                string json = JsonSerializer.Serialize(dispositivo);
                WebResponse res = HttpConnection.Send(json, "POST", "api/HwReds");
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool BorrarHWRed(string numSerie)
        {
            WebResponse res = HttpConnection.Send(null, "DELETE", "api/HwReds/" + numSerie);
            string json = HttpConnection.ResponseToJson(res);

            return true;
        }
    }
}
