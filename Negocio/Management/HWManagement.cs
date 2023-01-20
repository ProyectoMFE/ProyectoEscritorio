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
        /// <summary>
        /// Devuelve un Hardware de Red almacenado en la BD basado en el parametro recibido.
        /// </summary>
        /// <param name="numSerie">Numero de serie por el que se buscara el Hardware de red</param>
        /// <returns>Devuelve el harware de red con el numserie recibido. Si este no existe devolvera null</returns>
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
        /// <summary>
        /// Funcion devulve todos los hardware de red de red almacenados en la BD
        /// </summary>
        /// <returns>Devulve una lista los hardware de red.</returns>
        public List<HWRed> ObtenerHWReds()
        {
            WebResponse res = HttpConnection.Send(null, "GET", "api/HwReds/");
            string json = HttpConnection.ResponseToJson(res);
            List<HWRed> lista = JsonSerializer.Deserialize<List<HWRed>>(json);

            return lista;
        }

        /// <summary>
        /// Funcion que modifica un hardware de red almacenado en la BD
        /// </summary>
        /// <param name="dispositivo">hardware de red por el que se va reemplazar el HWR almacenado en la BD</param>
        /// <returns>devulve True si todo funciona correctamente false en caso contrario.</returns>
        public bool ModificarHWRed(HWRed dispositivo)
        {
            try
            {
                string json = JsonSerializer.Serialize(dispositivo);
                WebResponse res = HttpConnection.Send(json, "PUT", "api/HwReds/" + dispositivo.numSerie);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        /// <summary>
        /// Inserta un hardware de red recibido por parametros en la BD 
        /// </summary>
        /// <param name="dispositivo">Hardware de red que se va ainsertar en la BD</param>
        /// <returns>devulve true si todo a funcionado correctamente false en caso contrario.</returns>
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
        /// <summary>
        /// Funcion que elimina un hardware de red basado en el numero de serie pasado por parametros.
        /// </summary>
        /// <param name="numSerie">numero de serie del hardware de red a borrar</param>
        /// <returns>Devuleve true si todo a funcionado correctamente.</returns>
        public bool BorrarHWRed(string numSerie)
        {
            WebResponse res = HttpConnection.Send(null, "DELETE", "api/HwReds/" + numSerie);
            string json = HttpConnection.ResponseToJson(res);

            return true;
        }
    }
}
