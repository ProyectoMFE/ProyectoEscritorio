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
    public class PantallaManagement
    {
        public Pantalla ObtenerPantalla(string numSerie)
        {
            Pantalla pantalla;
            try
            {
                WebResponse res = HttpConnection.Send(null, "GET", "api/Pantallas/" + numSerie);
                string json = HttpConnection.ResponseToJson(res);
                pantalla = JsonSerializer.Deserialize<Pantalla>(json);
            }
            catch (Exception)
            {
                pantalla = null;
            }
            return pantalla;
        }

        public List<Pantalla> ObtenerPantallas()
        {
            WebResponse res = HttpConnection.Send(null, "GET", "api/Pantallas/");
            string json = HttpConnection.ResponseToJson(res);
            List<Pantalla> lista = JsonSerializer.Deserialize<List<Pantalla>>(json);

            return lista;
        }

        public bool ModificarPantalla(Pantalla dispositivo)
        {
            try
            {
                string json = JsonSerializer.Serialize(dispositivo);
                WebResponse res = HttpConnection.Send(json, "PUT", "api/Pantallas/" + dispositivo.numSerie);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool InsertarPantalla(Pantalla dispositivo)
        {
            try
            {
                Pantalla aux = ObtenerPantalla(dispositivo.numSerie);

                if (aux != null)
                {
                    return false;
                }

                string json = JsonSerializer.Serialize(dispositivo);
                WebResponse res = HttpConnection.Send(json, "POST", "api/Pantallas");
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool BorrarPantalla(string numSerie)
        {
            WebResponse res = HttpConnection.Send(null, "DELETE", "api/Pantallas/" + numSerie);
            string json = HttpConnection.ResponseToJson(res);

            return true;
        }
    }
}
