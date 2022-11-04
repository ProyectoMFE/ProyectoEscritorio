using System.Collections.Generic;
using Datos.DAO;
using Datos.Infrastructure;
using Negocio.EntitiesDTO;

namespace Negocio.Management
{
    public class UsuarioManagement
    {
        public UsuarioDTO ObtenerUsuario(string correo)
        {
            USUARIOS usuOld = new UsuarioDAO().Buscar(correo);
            UsuarioDTO usuario = new UsuarioDTO();

            // Utils.parse(usuOld, ref usuario);
            Parse(usuOld, usuario);

            return usuario;
        }

        public List<UsuarioDTO> ObtenerUsuarios()
        {
            List<UsuarioDTO> usuarios = new List<UsuarioDTO>();
            UsuarioDTO usuario;

            foreach (USUARIOS usuOld in new UsuarioDAO().Consultar())
            {
                usuario = new UsuarioDTO();

                Parse(usuOld, usuario);

                usuarios.Add(usuario);
            }

            return usuarios;
        }

        private void Parse(USUARIOS usuOld, UsuarioDTO usuario)
        {
            usuario.idUsuario = usuOld.ID_USUARIO;
        }
    }
}
