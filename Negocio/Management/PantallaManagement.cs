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
        /// <summary>
        /// Devulve una pantalla que tenga el mismo numero de serie de la bd
        /// </summary>
        /// <param name="numSerie">Numero de serie por el que se va a buscar la pantalla en la bd</param>
        /// <returns>devuelve la pantalla  que tenga el numero de serie en la bd. Si este no existe devuelve null</returns>
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
        /// <summary>
        /// Devulve una lista de todas las pantallas almacenadas en la bd
        /// </summary>
        /// <returns>Lista de pantalla que tenemos almacenados en la bd</returns>
        public List<Pantalla> ObtenerPantallas()
        {
            WebResponse res = HttpConnection.Send(null, "GET", "api/Pantallas/");
            string json = HttpConnection.ResponseToJson(res);
            List<Pantalla> lista = JsonSerializer.Deserialize<List<Pantalla>>(json);

            return lista;
        }
        /// <summary>
        ///  Reemplaza la pantalla que tenga el mismo numero de dispositivo que uno almacenado en la bd.
        /// </summary>
        /// <param name="dispositivo">Pantalla que reemplazara a la que esta almacenada en la BD</param>
        /// <returns>Devuelve true si todo a ido correctamente falso de lo contrario.</returns>
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
        /// <summary>
        /// Insterta una pantalla en la bd
        /// </summary>
        /// <param name="dispositivo">dispositivo que se va a insertar en la bd</param>
        /// <returns>Devulve true si se ha insertado correctamente, false en caso contrario.</returns>
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
        /// <summary>
        /// Elimina una pantalla de la bd que tenga el mismo numero de se serie que se recibe por paramentros.
        /// </summary>
        /// <param name="numSerie">Numero de deserie por el que se va a buscar en la base de datos.</param>
        /// <returns>Devulve true si todo a funcionado correctamente.</returns>
        public bool BorrarPantalla(string numSerie)
        {
            WebResponse res = HttpConnection.Send(null, "DELETE", "api/Pantallas/" + numSerie);
            string json = HttpConnection.ResponseToJson(res);

            return true;
        }
    }
}
