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
        public Usuario ObtenerUsuario(int id)
        {
            WebResponse res = HttpConnection.Send(null, "GET", "api/Usuarios/" + id);
            string json = HttpConnection.ResponseToJson(res);
            Usuario lista = JsonSerializer.Deserialize<Usuario>(json);

            return lista;
        }
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

        public List<Usuario> ObtenerUsuarios()
        {
            WebResponse res = HttpConnection.Send(null, "GET", "api/Usuarios");
            string json = HttpConnection.ResponseToJson(res);
            List<Usuario> lista = JsonSerializer.Deserialize<List<Usuario>>(json);

            return lista;
        }

        public bool ModificarUsuario(Usuario usuario)
        {
            return false;
        }

        public bool InsertarUsuario(Usuario usuario)
        {
            return false;
        }

        public bool BorrarUsuario(Usuario usuario)
        {
            return false;
        }
    }
}
