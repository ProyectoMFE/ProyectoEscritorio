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
        public List<Solicitud> obtenerSolicitudes(string correo, string numSerie)
        {

            WebResponse res = HttpConnection.Send(null, "GET", $"api/Solicitudes?numSerie={numSerie}&correo={correo}");
            string json = HttpConnection.ResponseToJson(res);
            List<Solicitud> solicitud = JsonSerializer.Deserialize<List<Solicitud>>(json);

            return solicitud;
        }
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

        public bool finalizarSolicitud(string correo, string numSerie)
        {
            return false;
        }

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

        public List<Solicitud> listarSolicitudes()
        {
            WebResponse res = HttpConnection.Send(null, "GET", "api/Solicitudes");
            string json = HttpConnection.ResponseToJson(res);
            List<Solicitud> lista = JsonSerializer.Deserialize<List<Solicitud>>(json);

            return lista;

        }
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
