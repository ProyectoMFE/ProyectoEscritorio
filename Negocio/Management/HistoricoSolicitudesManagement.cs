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
        public List<HistoricoSolicitud> listarSolicitudes()
        {
            WebResponse res = HttpConnection.Send(null, "GET", $"api/HistoricoSolicitudes");
            string json = HttpConnection.ResponseToJson(res);
            List<HistoricoSolicitud> solicitud = JsonSerializer.Deserialize<List<HistoricoSolicitud>>(json);

            return solicitud;
        }

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
        public List<HistoricoSolicitud> obtenerSolicitudesPorMarca(List<string> categorias)
        {
            List<HistoricoSolicitud> listaSolicitudes = new List<HistoricoSolicitud>();

            WebResponse res = HttpConnection.Send(null, "GET", "api/HistoricoSolicitudes/");
            string json = HttpConnection.ResponseToJson(res);
            List<HistoricoSolicitud> lista = JsonSerializer.Deserialize<List<HistoricoSolicitud>>(json);
            Dispositivo dispositivo;

            foreach (HistoricoSolicitud solicitud in lista)
            {
                dispositivo = new DispositivoManagement().ObtenerDispositivo(solicitud.numSerie);

                foreach (string nombreCategoria in categorias)
                {
                    if (dispositivo.marca.Equals(nombreCategoria))
                    {
                        listaSolicitudes.Add(solicitud);
                    }
                }
            }

            return listaSolicitudes;
        }

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
