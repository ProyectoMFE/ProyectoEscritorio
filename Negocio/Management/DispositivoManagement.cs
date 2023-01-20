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
        /// <summary>
        /// Funcion que devuelve un dispositivo basado en el numero de serie recibido.
        /// </summary>
        /// <param name="numSerie">Numero de serie por el que se va a buscar los dispositivos</param>
        /// <returns>Devuelve el dispositivo con ese numero de serie si existe de lo contrario devolvera null</returns>
        public Dispositivo ObtenerDispositivo(string numSerie)
        {
            Dispositivo dispositivo;
            try
            {
                WebResponse res = HttpConnection.Send(null, "GET", "api/Dispositivos/" + numSerie);
                string json = HttpConnection.ResponseToJson(res);
                dispositivo = JsonSerializer.Deserialize<Dispositivo>(json);
            }
            catch
            {
                dispositivo = null;
            }

            return dispositivo;
        }

        /// <summary>
        /// Funcion que devuelve la lista de todos los dispositvos que tenemos almacenados en la BD
        /// </summary>
        /// <returns>Lista de los dispositivos que hay en la BD</returns>
        public List<Dispositivo> ObtenerDispositivos()
        {
            WebResponse res = HttpConnection.Send(null, "GET", "api/Dispositivos");
            string json = HttpConnection.ResponseToJson(res);
            List<Dispositivo> lista = JsonSerializer.Deserialize<List<Dispositivo>>(json);

            return lista;
        }
        /// <summary>
        /// Modifica en dispositivo que hay en la BD. El dispositiv que recibimos debera tener el mismo id que el que se quiere modificar.
        /// </summary>
        /// <param name="dispositivo">Dispositivo que reemplazara al que tenemos en la BD</param>
        /// <returns>Devulve True si todo a funcionado correctamente de lo contrario devolvera false</returns>
        public bool ModificarDispositivo(Dispositivo dispositivo)
        {
            try
            {
                Dispositivo aux = ObtenerDispositivo(dispositivo.numSerie);

                if (aux == null)
                {
                    return false;
                }

                dispositivo.estado="Disponible";
                string json = JsonSerializer.Serialize(dispositivo);
                WebResponse res = HttpConnection.Send(json, "PUT", $"api/Dispositivos/{dispositivo.numSerie}");
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        /// <summary>
        /// Inserta un dispositivo en la base de datos
        /// </summary>
        /// <param name="dispositivo">Dispositivo que se insertara en la BD</param>
        /// <returns>devuelve True si todo ha funcionado correctamtente de lo contrario devolvera false</returns>
        public bool InsertarDispositivo(Dispositivo dispositivo)
        {
            try
            {
                Dispositivo aux = ObtenerDispositivo(dispositivo.numSerie);

                if (aux != null)
                {
                    return false;
                }

                string json = JsonSerializer.Serialize(dispositivo);
                WebResponse res = HttpConnection.Send(json, "POST", "api/Dispositivos");

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        /// <summary>
        /// Borra un dispositivo de BD
        /// </summary>
        /// <param name="numSerie">Numero de serie del dispositivo que va a ser eliminado de la BD</param>
        /// <returns>devuelve True si todo ha funcionado correctamtente de lo contrario devolvera false</returns>
        public bool BorrarDispositivo(string numSerie)
        {
            try
            {
                WebResponse res = HttpConnection.Send(null, "DELETE", "api/Dispositivos/" + numSerie);
                string json = HttpConnection.ResponseToJson(res);

                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
        /// <summary>
        /// Funcion que devulve una lista de dispositivos los cuales dichos dispositivos tiene que 
        /// tener la categoria igual que una de las categorias recibidas como parametro.
        /// <param name="categorias">Categoria por la que se va a filtrar las categorias.</param>
        /// <returns>Devulve una lista de dispositivos filtrados por la categoria recibida.</returns>
        public List<Dispositivo> obtenerDispositivosPorCategoria(List<string> categorias)
        {
            List<Dispositivo> listaDispositivos = new List<Dispositivo>();

            WebResponse res = HttpConnection.Send(null, "GET", "api/Dispositivos/");
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
        /// <summary>
        /// Funcion que devulve una lista de dispositivos los cuales dichos dispositivos tiene que 
        /// tener la marca igual que una de las marcas recibidos como parametro.
        /// </summary>
        /// <param name="marcas">Lista de marcas por las cuales se va a realizar el filtrado.</param>
        /// <returns>Devuevle una lista de dispositivos filtrados por marca</returns>
        public List<Dispositivo> obtenerDispositivosPorMarca(List<string> marcas)
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
        /// <summary>
        /// Funcion que devulve una lista de dispositivos los cuales dichos dispositivos tiene que 
        /// tener el modelo igual que uno de los modelos recibidos como parametro.
        /// </summary>
        /// <param name="modelos">lista de los modelos por el que se va a filtrar los dispositivos</param>
        /// <returns>Lista de los dispositivos filtrados</returns>
        public List<Dispositivo> obtenerDispositivosPorModelo(List<string> modelos)
        {
            List<Dispositivo> listaDispositivos = new List<Dispositivo>();

            WebResponse res = HttpConnection.Send(null, "GET", "api/Dispositivos/");
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
        /// <summary>
        /// Funcion que devulve una lista de dispositivos los cuales dichos dispositivos tiene que 
        /// tener la localizacion igual que una de las localizacion recibidas como parametro.
        /// </summary>
        /// <param name="localizaciones">lista de los localizaciones por el que se va a filtrar los dispositivos</param>
        /// <returns>Lista de los dispositivos filtrados</returns>
        public List<Dispositivo> obtenerDispositivosPorLocalizacion(List<string> localizaciones)
        {
            List<Dispositivo> listaDispositivos = new List<Dispositivo>();

            WebResponse res = HttpConnection.Send(null, "GET", "api/Dispositivos/");
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
        /// <summary>
        /// Función que devulve una lista de dispositivos los cuales dichos dispositivos tiene que 
        /// tener el estado igual que uno de los estados recibidas como parametro.
        /// </summary>
        /// <param name="estados">Lista de estados por el que se van a filtrar los dispositivos</param>
        /// <returns>Devulve la lista de dispositivos filtradas.¡</returns>
        public List<Dispositivo> obtenerDispositivosPorEstado(List<string> estados)
        {
            List<Dispositivo> listaDispositivos = new List<Dispositivo>();

            WebResponse res = HttpConnection.Send(null, "GET", "api/Dispositivos/");
            string json = HttpConnection.ResponseToJson(res);
            List<Dispositivo> lista = JsonSerializer.Deserialize<List<Dispositivo>>(json);

            foreach (Dispositivo dispositivo in lista)
            {
                foreach (string estado in estados)
                {
                    if (dispositivo.estado.Equals(estado))
                    {
                        listaDispositivos.Add(dispositivo);
                    }
                }
            }
            return listaDispositivos;
        }
    }
}
