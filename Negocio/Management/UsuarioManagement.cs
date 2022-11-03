using System.Collections.Generic;
using Datos.DAO;
using Datos.Infrastructure;
using Negocio.EntitiesDTO;

namespace Negocio.Management
{
    public class UsuarioManagement
    {
        public UsuarioDTO obtenerUsuario(string correo)
        {
            USUARIOS usuOld = new UsuarioDAO().buscar(correo);
            UsuarioDTO usuario = new UsuarioDTO();

            //Utils.parse(usuOld, ref usuario);
            
            parse(usuOld, usuario);

            return usuario;
        }

        public List<UsuarioDTO> obtenerUsuarios()
        {
            List<UsuarioDTO> usuarios = new List<UsuarioDTO>();
            UsuarioDTO usuario;

            foreach (USUARIOS usuOld in new UsuarioDAO().consultar())
            {
                usuario = new UsuarioDTO();
                //Utils.parse(usuOld, ref usuario);
                usuario.idUsuario = usuOld.ID_USUARIO;

                usuarios.Add(usuario);
            }

            return usuarios;
        }

        private void parse(USUARIOS usuOld, UsuarioDTO usuario)
        {
            usuario.idUsuario = usuOld.ID_USUARIO;
        }
    }
}
