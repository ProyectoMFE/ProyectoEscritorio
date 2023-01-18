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
        /// <summary>
        /// Devuelve una lista de todas las solicitudes de un usuario en concreto. De un equipo concreto.
        /// </summary>
        /// <param name="correo">Correo identificador de un usuario de la app.</param>
        /// <param name="numSerie">Numerode de serie identificador de un equipo en concreto.</param>
        /// <returns>Lista de de las solicitudes filtrados por los dos parametros.</returns>
        public List<Solicitud> obtenerSolicitudes(string correo, string numSerie)
        {

            WebResponse res = HttpConnection.Send(null, "GET", $"api/Solicitudes?numSerie={numSerie}&correo={correo}");
            string json = HttpConnection.ResponseToJson(res);
            List<Solicitud> solicitud = JsonSerializer.Deserialize<List<Solicitud>>(json);

            return solicitud;
        }
        /// <summary>
        /// Devulve una lista de todas las solicitudes de un usuario en concreto.
        /// </summary>
        /// <param name="correo">Correo identificador de un usuario en la app.</param>
        /// <returns>Lista de todas las solicitudes de la bd filtrados por el usuario.</returns>
        public List<Solicitud> obtenerSolicitudes(string correo)
        {

            WebResponse res = HttpConnection.Send(null, "GET", $"api/Solicitudes?correo={correo}");
            string json = HttpConnection.ResponseToJson(res);
            List<Solicitud> solicitud = JsonSerializer.Deserialize<List<Solicitud>>(json);

            return solicitud;
        }

        /// <summary>
        /// Inserta una solicitud en la base de datos.
        /// </summary>
        /// <param name="correo">parametro para almacenar el correo. Del usuario que ha solicitado el equipo</param>
        /// <param name="numSerie">parametro utilzado para almacenar el numerso de serie del equipo solicitado.</param>
        /// <returns></returns>
        public bool insertarSolicitud(string correo, string numSerie)
        {
            try
            {
                WebResponse res = HttpConnection.Send(null, "POST", "api/Solicitudes?numSerie=" + numSerie + "&correo=" + correo);
                return true;

            }
            catch (Exception)
            {
                return false;
            }
        }
        /// <summary>
        /// Finaliza una solicitud. Basandose para identificarlo en el correo y el numero de serie de equipo.
        /// </summary>
        /// <param name="correo">Recibe el correo del usuario que solicito el equipo</param>
        /// <param name="numSerie">Numero de serie del equipo solicitado.</param>
        /// <returns>devulve true si todo a funcionado correctamente de lo contrario devulve false</returns>
        public bool finalizarSolicitud(string correo, string numSerie)
        {

            try
            {
                WebResponse res = HttpConnection.Send(null, "DELETE", $"api/Solicitudes?numSerie={numSerie}&correo={correo}");
                string json = HttpConnection.ResponseToJson(res);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        /// <summary>
        /// Acepta una solicitud de un equipo.
        /// </summary>
        /// <param name="correo">Correo del usuario que solicito el equipo.</param>
        /// <param name="numSerie">Numero de serie del equipo solicitado.</param>
        /// <returns>Devuelve true si todo a funcionado correctamente false en caso contrario.</returns>
        public bool aceptarSolicitud(string correo, string numSerie)
        {
            try
            {
                WebResponse res = HttpConnection.Send(null, "PUT", $"api/Solicitudes?numSerie={numSerie}&correo={correo}&action=A");
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }


        /// <summary>
        /// Rechaza una solicitud al macenada en la base de datos.
        /// </summary>
        /// <param name="correo">Correo del usuario que solicito el equipo</param>
        /// <param name="numSerie">Numero de serie del equipo solicitado.</param>
        /// <returns>Devulve true si todo a funcionado correctamente false en caso contrario</returns>
        public bool rechazarSolicitud(string correo, string numSerie)
        {
            try
            {
                WebResponse res = HttpConnection.Send(null, "PUT", $"api/Solicitudes?numSerie={numSerie}&correo={correo}&action=R");
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        /// <summary>
        /// Devuelve una lista de todas las solicitudes alamacenadas en la base de datos.
        /// </summary>
        /// <returns>Lista de las solicitudes de la bd.</returns>
        public List<Solicitud> listarSolicitudes()
        {
            WebResponse res = HttpConnection.Send(null, "GET", "api/Solicitudes");
            string json = HttpConnection.ResponseToJson(res);
            List<Solicitud> lista = JsonSerializer.Deserialize<List<Solicitud>>(json);

            return lista;

        }

        /// <summary>
        /// Devulve una lista de las solicitudes pendientes alamcenadas en la BD.
        /// </summary>
        /// <returns>Lista de las solicitudes pendientes</returns>
        public List<Solicitud> listarSolicitudesPendientes()
        {
            WebResponse res = HttpConnection.Send(null, "GET", "api/Solicitudes");
            string json = HttpConnection.ResponseToJson(res);
            List<Solicitud> lista = JsonSerializer.Deserialize<List<Solicitud>>(json);

            List<Solicitud> listaSolicitudesPendientes = new List<Solicitud>();
            foreach (Solicitud solicitud in lista)
            {
                if (solicitud.estado.Equals("Pendiente"))
                {
                    listaSolicitudesPendientes.Add(solicitud);
                }
            }

            return listaSolicitudesPendientes;
        }
        
        public List<Solicitud> obtenerSolicitudesPorCategoria(List<string> categorias)
        {
            List<Solicitud> listaSolicitudes = new List<Solicitud>();

            WebResponse res = HttpConnection.Send(null, "GET", "api/Solicitudes/");
            string json = HttpConnection.ResponseToJson(res);
            List<Solicitud> lista = JsonSerializer.Deserialize<List<Solicitud>>(json);
            Dispositivo dispositivo;
            Categoria categoria;
            foreach (Solicitud solicitud in lista)
            {
                dispositivo = new DispositivoManagement().ObtenerDispositivo(solicitud.numSerie);
                categoria = new CategoriaManagement().ObtenerCategoria(dispositivo.idCategoria);

                foreach (string nombreCategoria in categorias)
                {
                    if (categoria.nombre.Equals(nombreCategoria))
                    {
                        listaSolicitudes.Add(solicitud);
                    }
                }
            }

            return listaSolicitudes;
        }
        public List<Solicitud> obtenerSolicitudesPorMarca(List<string> marcas)
        {
            List<Solicitud> listaSolicitudes = new List<Solicitud>();
            WebResponse res = HttpConnection.Send(null, "GET", "api/Solicitudes/");
            string json = HttpConnection.ResponseToJson(res);
            List<Solicitud> lista = JsonSerializer.Deserialize<List<Solicitud>>(json);
            Dispositivo dispositivo;

            foreach (Solicitud solicitud in lista)
            {
                dispositivo = new DispositivoManagement().ObtenerDispositivo(solicitud.numSerie);

                foreach (string marca in marcas)
                {
                    if (dispositivo.marca.Equals(marca))
                    {
                        listaSolicitudes.Add(solicitud);
                    }
                }
            }

            return listaSolicitudes;
        }

        public List<Solicitud> obtenerSolicitudesPorModelo(List<string> modelos)
        {
            List<Solicitud> listaSolicitudes = new List<Solicitud>();
            WebResponse res = HttpConnection.Send(null, "GET", "api/Solicitudes/");
            string json = HttpConnection.ResponseToJson(res);
            List<Solicitud> lista = JsonSerializer.Deserialize<List<Solicitud>>(json);
            Dispositivo dispositivo;

            foreach (Solicitud solicitud in lista)
            {
                dispositivo = new DispositivoManagement().ObtenerDispositivo(solicitud.numSerie);

                foreach (string modelo in modelos)
                {
                    if (dispositivo.modelo.Equals(modelo))
                    {
                        listaSolicitudes.Add(solicitud);
                    }
                }
            }

            return listaSolicitudes;
        }

        public List<Solicitud> obtenerSolicitudesPorLocalizacion(List<string> localizaciones)
        {
            List<Solicitud> listaSolicitudes = new List<Solicitud>();
            WebResponse res = HttpConnection.Send(null, "GET", "api/Solicitudes/");
            string json = HttpConnection.ResponseToJson(res);
            List<Solicitud> lista = JsonSerializer.Deserialize<List<Solicitud>>(json);
            Dispositivo dispositivo;

            foreach (Solicitud solicitud in lista)
            {
                dispositivo = new DispositivoManagement().ObtenerDispositivo(solicitud.numSerie);

                foreach (string localizacion in localizaciones)
                {
                    if (dispositivo.localizacion.Equals(localizacion))
                    {
                        listaSolicitudes.Add(solicitud);
                    }
                }
            }

            return listaSolicitudes;
        }
    }
}
