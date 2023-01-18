using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using Datos.DAO;
using Datos.Infrastructure;
using Negocio.EntitiesDTO;

namespace Negocio.Management
{
    public class UsuarioManagement
    {
        /// <summary>
        /// Obtiene un usuario, que tenga el mismo id que el recibido por paramentros.
        /// </summary>
        /// <param name="id">Id del usuaio que se busca en la bd</param>
        /// <returns>Devuelve el usuario que tenga el id recibido por parametros.</returns>
        public Usuario ObtenerUsuario(int id)
        {
            WebResponse res = HttpConnection.Send(null, "GET", "api/Usuarios/" + id);
            string json = HttpConnection.ResponseToJson(res);
            Usuario lista = JsonSerializer.Deserialize<Usuario>(json);

            return lista;
        }

        /// <summary>
        /// Devuelve el usuario de la bd que tenga el correo igual que el parametro recibido.
        /// </summary>
        /// <param name="correo">Correo por el que se busca el usuario</param>
        /// <returns>Usuario que se devulve de la bd</returns>
        public Usuario ObtenerUsuario(string correo)
        {
            List<Usuario> usuarios = ObtenerUsuarios();

            foreach (Usuario usuario in usuarios)
            {
                if (usuario.correo.Equals(correo))
                {
                    return usuario;
                }
            }

            return null;
        }
        /// <summary>
        /// Devuelve una lista de todos los usuarios almacenados en la bd
        /// </summary>
        /// <returns>Lista de todos los usuario de la bd</returns>
        public List<Usuario> ObtenerUsuarios()
        {
            WebResponse res = HttpConnection.Send(null, "GET", "api/Usuarios");
            string json = HttpConnection.ResponseToJson(res);
            List<Usuario> lista = JsonSerializer.Deserialize<List<Usuario>>(json);

            return lista;
        }
        /// <summary>
        /// Reemplaza en la bd el usuario que tenga el mismo correo que el correo del usuario recibido
        /// por parametros.
        /// </summary>
        /// <param name="usuario">Usuario qu reemplazara a otro en la bd</param>
        /// <returns>Devuelve true si todo a funcionado correctamente y false en caso contrario</returns>
        public bool ModificarUsuario(Usuario usuario)
        {
            try
            {
                Usuario usu = new UsuarioManagement().ObtenerUsuario(usuario.correo);

                if (usu == null)
                {
                    return false;
                }

                usuario.tipo = "P";
                string json = JsonSerializer.Serialize(usuario);
                WebResponse res = HttpConnection.Send(json, "PUT", $"api/Usuarios/{usuario.correo}");
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        /// <summary>
        /// Inserta un usuario recibido por parametros en la basde de datos.
        /// </summary>
        /// <param name="usuario">Usuario que va a ser insertado en la bd.</param>
        /// <returns>Devuelve true si todo funcionado correctamente y false en caso contrario.</returns>
        public bool InsertarUsuario(Usuario usuario)
        {
            try
            {
                Usuario usu = new UsuarioManagement().ObtenerUsuario(usuario.correo);

                if (usu != null)
                {
                    return false;
                }

                usuario.tipo = "P";
                string json = JsonSerializer.Serialize(usuario);              
                WebResponse res = HttpConnection.Send(json, "POST", "api/Usuarios");
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        /// <summary>
        /// Borra el usuario en la bd que tenga el mismo correo que el recibido por parametros.
        /// </summary>
        /// <param name="correo">Correo del usuario que se quiere eliminar.</param>
        /// <returns>Devulve true si todo a funcionado correctamente y flase en caso contrario.</returns>
        public bool BorrarUsuario(string correo)
        {
            try
            {
                Usuario usu = new UsuarioManagement().ObtenerUsuario(correo);

                if (usu == null)
                {
                    return false;
                }


                WebResponse res = HttpConnection.Send(null, "DELETE", $"api/Usuarios/{correo}");
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
