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
    public class HistoricoSolicitudesManagement
    {
        /// <summary>
        /// Funcion que devulve una lista de todas las solicitudes que tenemos almacenadas en la BD
        /// </summary>
        /// <returns>Lista de las solicitudes que tenemos en la BD</returns>
        public List<HistoricoSolicitud> listarSolicitudes()
        {
            WebResponse res = HttpConnection.Send(null, "GET", $"api/HistoricoSolicitudes");
            string json = HttpConnection.ResponseToJson(res);
            List<HistoricoSolicitud> solicitud = JsonSerializer.Deserialize<List<HistoricoSolicitud>>(json);

            return solicitud;
        }
        /// <summary>
        /// Funcion que devulve una lista de solicitudes las cuales dichas solicitudes tiene que 
        /// tener la categoria igual que uno de las categorias recibidas como parametro.
        /// </summary>
        /// <param name="categorias">Lista de categorias por las que se va a realizar el filtrado.</param>
        /// <returns>Lista de solicitudes despues de realizar el filtrado.</returns>
        public List<HistoricoSolicitud> obtenerSolicitudesPorCategoria(List<string> categorias)
        {
            List<HistoricoSolicitud> listaSolicitudes = new List<HistoricoSolicitud>();

            WebResponse res = HttpConnection.Send(null, "GET", "api/HistoricoSolicitudes/");
            string json = HttpConnection.ResponseToJson(res);
            List<HistoricoSolicitud> lista = JsonSerializer.Deserialize<List<HistoricoSolicitud>>(json);
            Dispositivo dispositivo;
            Categoria categoria;
            foreach (HistoricoSolicitud solicitud in lista)
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
        /// <summary>
        /// Funcion que devulve una lista de solicitudes las cuales dichas solicitudes tiene que 
        /// tener la marca igual que una de las marcas recibidas como parametro.
        /// </summary>
        /// <param name="marca">Lista de marcas por las cuales se va a realizar el filtrado</param>
        /// <returns>Devulve una lista de solicitudes que han pasado el filtrado</returns>
        public List<HistoricoSolicitud> obtenerSolicitudesPorMarca(List<string> marca)
        {
            List<HistoricoSolicitud> listaSolicitudes = new List<HistoricoSolicitud>();

            WebResponse res = HttpConnection.Send(null, "GET", "api/HistoricoSolicitudes/");
            string json = HttpConnection.ResponseToJson(res);
            List<HistoricoSolicitud> lista = JsonSerializer.Deserialize<List<HistoricoSolicitud>>(json);
            Dispositivo dispositivo;

            foreach (HistoricoSolicitud solicitud in lista)
            {
                dispositivo = new DispositivoManagement().ObtenerDispositivo(solicitud.numSerie);

                foreach (string nombreCategoria in marca)
                {
                    if (dispositivo.marca.Equals(nombreCategoria))
                    {
                        listaSolicitudes.Add(solicitud);
                    }
                }
            }

            return listaSolicitudes;
        }
        /// <summary>
        /// Funcion que devulve una lista de solicitudes las cuales dichas solicitudes tiene que 
        /// tener el modelo igual que una de los modelos recibidos como parametro.
        /// </summary>
        /// <param name="modelos">Lista de modelos por las cuales se va a realizar el filtrado</param>
        /// <returns>Devulve una lista de solicitudes que han pasado el filtrado</returns>
        public List<HistoricoSolicitud> obtenerSolicitudesPorModelo(List<string> modelos)
        {
            List<HistoricoSolicitud> listaSolicitudes = new List<HistoricoSolicitud>();

            WebResponse res = HttpConnection.Send(null, "GET", "api/HistoricoSolicitudes/");
            string json = HttpConnection.ResponseToJson(res);
            List<HistoricoSolicitud> lista = JsonSerializer.Deserialize<List<HistoricoSolicitud>>(json);
            Dispositivo dispositivo;

            foreach (HistoricoSolicitud solicitud in lista)
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
        /// <summary>
        /// Funcion que devulve una lista de solicitudes las cuales dichas solicitudes tiene que 
        /// tener la localizacion igual que una de las localizaciones recibidos como parametro.
        /// </summary>
        /// <param name="localizaciones">Lista de localizaciones por las cuales se va a realizar el filtrado</param>
        /// <returns>Devulve una lista de solicitudes que han pasado el filtrado</</returns>
        public List<HistoricoSolicitud> obtenerSolicitudesPorLocalizacion(List<string> localizaciones)
        {
            List<HistoricoSolicitud> listaSolicitudes = new List<HistoricoSolicitud>();

            WebResponse res = HttpConnection.Send(null, "GET", "api/HistoricoSolicitudes/");
            string json = HttpConnection.ResponseToJson(res);
            List<HistoricoSolicitud> lista = JsonSerializer.Deserialize<List<HistoricoSolicitud>>(json);
            Dispositivo dispositivo;

            foreach (HistoricoSolicitud solicitud in lista)
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
        /// <summary>
        /// Funcion que devuelve todas los solicitudes aprovadas que tenemos almacenadas en la BD
        /// </summary>
        /// <returns>Devuelve una lista de solicitudes que estan aprobadas</returns>
        public List<HistoricoSolicitud> listarSolicitudesAprobadas()
        {
            List<HistoricoSolicitud> solicitudesAprobadas = new List<HistoricoSolicitud>();
            WebResponse res = HttpConnection.Send(null, "GET", $"api/HistoricoSolicitudes");
            string json = HttpConnection.ResponseToJson(res);
            List<HistoricoSolicitud> solicitudes = JsonSerializer.Deserialize<List<HistoricoSolicitud>>(json);

            foreach (HistoricoSolicitud solicitud in solicitudes)
            {
                if (solicitud.ultimatum.Equals("Aceptado"))
                {
                    solicitudesAprobadas.Add(solicitud);
                }
            }

            return solicitudesAprobadas;
        }
        /// <summary>
        /// Funcion que devuelve todas las solicitudes rechazadas que tenemos almacenadas en la BD
        /// </summary>
        /// <returns>Devulve una lista de las solicitudes que estan rechazadas</returns>
        public List<HistoricoSolicitud> listarSolicitudesRechazadas()
        {
            List<HistoricoSolicitud> solicitudesAprobadas = new List<HistoricoSolicitud>();
            WebResponse res = HttpConnection.Send(null, "GET", $"api/HistoricoSolicitudes");
            string json = HttpConnection.ResponseToJson(res);
            List<HistoricoSolicitud> solicitudes = JsonSerializer.Deserialize<List<HistoricoSolicitud>>(json);

            foreach (HistoricoSolicitud solicitud in solicitudes)
            {
                if (solicitud.ultimatum.Equals("Rechazado"))
                {
                    solicitudesAprobadas.Add(solicitud);
                }
            }

            return solicitudesAprobadas;
        }
    }
}
