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
    public class DispositivoManagement
    {
        public Dispositivo ObtenerDispositivo(string numSerie)
        {
            WebResponse res = HttpConnection.Send(null, "GET", "api/Dispositivos/" + numSerie);
            string json = HttpConnection.ResponseToJson(res);
            Dispositivo dispositivo = JsonSerializer.Deserialize<Dispositivo>(json);

            return dispositivo;
        }

        public List<Dispositivo> ObtenerDispositivos()
        {
            WebResponse res = HttpConnection.Send(null, "GET", "api/Dispositivos");
            string json = HttpConnection.ResponseToJson(res);
            List<Dispositivo> lista = JsonSerializer.Deserialize<List<Dispositivo>>(json);

            return lista;
        }

        public bool ModificarDispositivo(Dispositivo dispositivo)
        {
            return true;
        }

        public bool InsertarDispositivo(Dispositivo dispositivo)
        {
            return true;
        }

        public bool BorrarDispositivo(string numSerie)
        {
            return new DispositivoDAO().Borrar(numSerie);
        }

        public List<Dispositivo> obtenerDispositivosPorCategoria(List<string> categorias)
        {
            List<Dispositivo> listaDispositivos = new List<Dispositivo>();

            WebResponse res = HttpConnection.Send(null, "GET", "api/Dispositivos");
            string json = HttpConnection.ResponseToJson(res);
            List<Dispositivo> lista = JsonSerializer.Deserialize<List<Dispositivo>>(json);

            Categoria categoria;
            foreach (Dispositivo dispositivo in lista)
            {
                categoria = new CategoriaManagement().ObtenerCategoria(dispositivo.idCategoria);

                foreach (string nombreCategoria in categorias)
                {
                    if (categoria.nombre.Equals(nombreCategoria))
                    {
                        listaDispositivos.Add(dispositivo);
                    }
                }
            }

            return listaDispositivos;
        }

        public List<Dispositivo> obtenerDispositivosPorMarca(List<string>marcas)
        {
            List<Dispositivo> listaDispositivos = new List<Dispositivo>();

            WebResponse res = HttpConnection.Send(null, "GET", "api/Dispositivos");
            string json = HttpConnection.ResponseToJson(res);
            List<Dispositivo> lista = JsonSerializer.Deserialize<List<Dispositivo>>(json);

            foreach (Dispositivo dispositivo in lista)
            {
                foreach (string marca in marcas)
                {
                    if (dispositivo.marca.Equals(marca))
                    {
                        listaDispositivos.Add(dispositivo);
                    }
                }
            }
            return listaDispositivos;
        }
        public List<Dispositivo> obtenerDispositivosPorModelo(List<string> modelos)
        {
            List<Dispositivo> listaDispositivos = new List<Dispositivo>();

            WebResponse res = HttpConnection.Send(null, "GET", "api/Dispositivos");
            string json = HttpConnection.ResponseToJson(res);
            List<Dispositivo> lista = JsonSerializer.Deserialize<List<Dispositivo>>(json);

            foreach (Dispositivo dispositivo in lista)
            {
                foreach (string modelo in modelos)
                {
                    if (dispositivo.modelo.Equals(modelo))
                    {
                        listaDispositivos.Add(dispositivo);
                    }
                }
            }
            return listaDispositivos;
        }
        public List<Dispositivo> obtenerDispositivosPorLocalizacion(List<string> localizaciones)
        {
            List<Dispositivo> listaDispositivos = new List<Dispositivo>();

            WebResponse res = HttpConnection.Send(null, "GET", "api/Dispositivos");
            string json = HttpConnection.ResponseToJson(res);
            List<Dispositivo> lista = JsonSerializer.Deserialize<List<Dispositivo>>(json);

            foreach (Dispositivo dispositivo in lista)
            {
                foreach (string localizacion in localizaciones)
                {
                    if (dispositivo.localizacion.Equals(localizacion))
                    {
                        listaDispositivos.Add(dispositivo);
                    }
                }
            }
            return listaDispositivos;
        }
        public List<Dispositivo> obtenerDispositivosPorEstado(List<string> estados)
        {
            List<Dispositivo> listaDispositivos = new List<Dispositivo>();
            String estadoFormateado;

            WebResponse res = HttpConnection.Send(null, "GET", "api/Dispositivos");
            string json = HttpConnection.ResponseToJson(res);
            List<Dispositivo> lista = JsonSerializer.Deserialize<List<Dispositivo>>(json);

            foreach (Dispositivo dispositivo in lista)
            {
                foreach (string estado in estados)
                {
                    estadoFormateado = formatearEstado(dispositivo.estado);
                    if (estadoFormateado.Equals(estado))
                    {
                        listaDispositivos.Add(dispositivo);
                    }
                }
            }
            return listaDispositivos;
        }

        private string formatearEstado(string estadoBD)
        {
            string estado = "";

            switch (estadoBD)
            {
                case "O":
                    estado = "Ocupado";
                    break;
                case "D":
                    estado = "Disponible";
                    break;
                case "I":
                    estado = "Instalado";
                    break;
                default:
                    break;
            }

            return estado;
        }




        /*
                private void ObtenerCaracteristicas(Dispositivo dispositivo)
                {
                    string numSerie = dispositivo.numSerie;

                    if (new HWRedDAO().Buscar(numSerie) != null)
                    {
                        dispositivo.caracteristica = new HWManagement().ObtenerHWRed(numSerie);
                    }else if (new OrdenadorDAO().Buscar(numSerie) != null)
                    {
                        dispositivo.caracteristica = new OrdenadorManagement().ObtenerOrdenador(numSerie);
                    }
                    else if (new PantallaDAO().Buscar(numSerie) != null)
                    {
                        dispositivo.caracteristica = new PantallaManagement().ObtenerPantalla(numSerie);
                    }
                }

                private void InsertarCaracteristicas(Dispositivo dispositivo)
                {
                    string numSerie = dispositivo.numSerie;

                    if (new HWRedDAO().Buscar(numSerie) != null)
                    {
                        new HWManagement().InsertarHWRed((HWRed) dispositivo.caracteristica);
                    }
                    else if (new OrdenadorDAO().Buscar(numSerie) != null)
                    {
                        new OrdenadorManagement().InsertarOrdenador((Ordenador) dispositivo.caracteristica);
                    }
                    else if (new PantallaDAO().Buscar(numSerie) != null)
                    {
                        new PantallaManagement().InsertarPantalla((Pantalla) dispositivo.caracteristica);
                    }
                }

                private void ModificarCaracteristicas(Dispositivo dispositivo)
                {
                    string numSerie = dispositivo.numSerie;

                    if (new HWRedDAO().Buscar(numSerie) != null)
                    {
                        new HWManagement().ModificarHWRed((HWRed)dispositivo.caracteristica);
                    }
                    else if (new OrdenadorDAO().Buscar(numSerie) != null)
                    {
                        new OrdenadorManagement().ModificarOrdenador((Ordenador)dispositivo.caracteristica);
                    }
                    else if (new PantallaDAO().Buscar(numSerie) != null)
                    {
                        new PantallaManagement().ModificarPantalla((Pantalla)dispositivo.caracteristica);
                    }
                }*/
    }
}
