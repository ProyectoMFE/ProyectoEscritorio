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
        public Usuario ObtenerUsuario(string correo)
        {
            WebResponse res = HttpConnection.Send(null, "GET", "api/Usuarios/" + correo);
            string json = HttpConnection.ResponseToJson(res);
            Usuario lista = JsonSerializer.Deserialize<Usuario>(json);

            return lista;
        }

        public List<Usuario> ObtenerUsuarios()
        {
            return null;
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
