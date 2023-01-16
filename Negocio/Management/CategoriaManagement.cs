using Negocio.EntitiesDTO;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text.Json;

namespace Negocio.Management
{
    public class CategoriaManagement
    {
        /// <summary>
        /// Funcion que retorna la categoria que tenga como id el parametro recibido
        /// </summary>
        /// <param name="id">campo de la categoria por el que se busca la misma</param>
        /// <returns>retorna la categoria con el id recibido por parametros</returns>
        public Categoria ObtenerCategoria(int id)
        {
            WebResponse res = HttpConnection.Send(null, "GET", "api/Categorias/" + id);
            string json = HttpConnection.ResponseToJson(res);
            Categoria categoria = JsonSerializer.Deserialize<Categoria>(json);
            return categoria;
        }
        /// <summary>
        /// Funcion que devuelve una lista de todas las categorias que tenemos en la BD
        /// </summary>
        /// <returns>Devuelve una lista con todas las categorias almacenadas</returns>
        public List<Categoria> ObtenerCategorias()
        {
            WebResponse res = HttpConnection.Send(null, "GET", "api/Categorias");
            string json = HttpConnection.ResponseToJson(res);
            List<Categoria> lista = JsonSerializer.Deserialize<List<Categoria>>(json);

            return lista;
        }
        /// <summary>
        /// Inserta la categoria recibida en la BD 
        /// </summary>
        /// <param name="categoria">Categoria que almacenaremos en la BD</param>
        /// <returns>Devolvera true si todo a funcionado correctamente de lo contrario devolvera false</returns>
        public bool InsertarCategoria(Categoria categoria)
        {
            try
            {
                string json = JsonSerializer.Serialize(categoria);
                WebResponse res = HttpConnection.Send(json, "POST", "api/Categorias");
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        /// <summary>
        /// Elimina una categoria de la BD basado en el parametro recibido
        /// </summary>
        /// <param name="idCategoria">Id de la categoria que se quiere eliminar</param>
        /// <returns>Devolvera true si todo a funcionado correctamente de lo contrario devolvera false</returns>
        public bool BorrarCategoria(int idCategoria)
        {
            try
            {
                WebResponse res = HttpConnection.Send(null, "DELETE", $"api/Categorias/{idCategoria}");
                string json = HttpConnection.ResponseToJson(res);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}
