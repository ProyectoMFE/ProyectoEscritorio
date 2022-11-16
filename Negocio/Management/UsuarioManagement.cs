using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using Datos.DAO;
using Datos.Infrastructure;
using Negocio.EntitiesDTO;

namespace Negocio.Management
{
    public class UsuarioManagement
    {
        public Usuario ObtenerUsuario(string correo)
        {
            using (var client = new HttpClient())
            {
                string url = "https://localhost:7033/api/Usuarios/" + correo;
                client.DefaultRequestHeaders.Clear();
                var response = client.GetAsync(url).Result;
                var res = response.Content.ReadAsStringAsync().Result;
                List<Usuario> usuarios = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Usuario>>(res);

                return usuarios.First();
            }
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
