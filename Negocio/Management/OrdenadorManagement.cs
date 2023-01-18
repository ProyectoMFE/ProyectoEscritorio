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
        /// <summary>
        /// Devulve el ordenador que tenga el mismo numerodeserie que el parametro recibido.
        /// </summary>
        /// <param name="numSerie">Parametro que se utilizara para buscar el ordenador.</param>
        /// <returns>Ordenador que tenga el numero de serie igual que el parametro recibido. Si este no existe develve null</returns>
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


        /// <summary>
        /// Reemplaza el ordenador de la base de datos que tenga el mismo numero de serie que el ordenador
        /// recibido por parametros.
        /// </summary>
        /// <param name="dispositivo">Ordenador que reemplazara al que hay en la bd</param>
        /// <returns>Devuelve true si todo va correctamente false en caso contrario</returns>
        public bool ModificarOrdenador(Ordenador dispositivo)
        {
            try
            {
                string json = JsonSerializer.Serialize(dispositivo);
                WebResponse res = HttpConnection.Send(json, "PUT", "api/Ordenadores/" + dispositivo.numSerie);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
          
            
        }
        /// <summary>
        /// Introduce un ordenador en la base de datos.
        /// </summary>
        /// <param name="dispositivo">Ordenador que se devuelve en la base de datos.</param>
        /// <returns>Devulve true si todo va correctamente y false en caso contrario.</returns>
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
        /// <summary>
        /// Elimina un ordenador en la base de datos basado en el parametro recibido.
        /// </summary>
        /// <param name="numSerie">Numerorio de serie del ordenador a eliminar.</param>
        /// <returns>Devuvelve true si todo funciona correctamente.</returns>
        public bool BorrarOrdenador(string numSerie)
        {
            WebResponse res = HttpConnection.Send(null, "DELETE", "api/Ordenadores/" + numSerie);
            string json = HttpConnection.ResponseToJson(res);

            return true;
        }
    }
}
